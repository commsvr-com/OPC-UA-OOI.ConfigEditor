//_______________________________________________________________
//  Title   : DomainConfirmation
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel;
using CAS.CommServer.UA.OOI.ConfigurationEditor.Services;
using CAS.Windows.ViewModel;
using Prism.Commands;
using System;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainEditor
{
  internal class DomainConfirmation : ConfirmationBindable
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainConfirmation"/> class.
    /// </summary>
    /// <param name="domain">The domain.</param>
    internal DomainConfirmation(DomainModelWrapper domain)
    {
      b_DomainConfigurationWrapper = domain;
      LookupDNSCommand = DelegateCommand.FromAsyncHandler(DomainDiscoveryAsync);
    }

    #region DataContext
    /// <summary>
    /// Gets the domain configuration wrapper <see cref="DomainModelWrapper"/>.
    /// </summary>
    /// <remarks>
    /// It is to be used by the GUI.
    /// </remarks>
    /// <value>The domain configuration wrapper <see cref="DomainModelWrapper"/>.</value>
    public DomainModelWrapper DomainConfigurationWrapper
    {
      get
      {
        return b_DomainConfigurationWrapper;
      }
      set
      {
        SetProperty<DomainModelWrapper>(ref b_DomainConfigurationWrapper, value);
      }
    }

    public SemanticsDataIndexWrapper CurrentSemanticsDataIndex
    {
      get
      {
        return b_CurrentSemanticsDataIndex;
      }
      set
      {
        if (SetProperty<SemanticsDataIndexWrapper>(ref b_CurrentSemanticsDataIndex, value))
          CurrentDataSet = value?.DataSet;
      }
    }

    private FieldMetaDataCollection b_CurrentDataSet;

    public FieldMetaDataCollection CurrentDataSet
    {
      get
      {
        return b_CurrentDataSet;
      }
      set
      {
        SetProperty<FieldMetaDataCollection>(ref b_CurrentDataSet, value);
      }
    }

    public ICommand LookupDNSCommand { get; }
    public bool? CurrentIsEnabled
    {
      get
      {
        return b_CurrentIsEnabled;
      }
      set
      {
        SetProperty<bool?>(ref b_CurrentIsEnabled, value);
      }
    }
    public Cursor CurrentCursor
    {
      get
      {
        return b_CurrentCursor;
      }
      set
      {
        SetProperty<Cursor>(ref b_CurrentCursor, value);
      }
    }
    #endregion

    internal void ApplyChanges()
    {
      DomainConfigurationWrapper.ApplyChanges();
    }

    //private
    private bool? b_CurrentIsEnabled;
    private Cursor b_CurrentCursor;
    private SemanticsDataIndexWrapper b_CurrentSemanticsDataIndex;
    private DomainModelWrapper b_DomainConfigurationWrapper;
    private async Task DomainDiscoveryAsync()
    {
      Cursor _currentCursor = CurrentCursor;
      bool? _currentIsEnabled = CurrentIsEnabled;
      try
      {
        CurrentCursor = Cursors.Wait;
        CurrentIsEnabled = false;
        DomainDescriptor _newDomain = await DataDiscoveryServices.ResolveDomainDescriptionAsync<DomainDescriptor>(DomainConfigurationWrapper.URI);
        string[] _segments = DomainConfigurationWrapper.URI.Segments;
        string _aliasName = String.Empty;
        if (_segments.Length >= 1)
        {
          _segments[0] = DomainConfigurationWrapper.URI.Host;
          _aliasName = String.Join(".", _segments).Replace("/", "");
        }
        else
          _aliasName = "Enter alias for this domain";
        DomainModel _newDomainModel = new DomainModel()
        {
          AliasName = _aliasName,
          Description = _newDomain.Description,
          UniqueName = new Guid(_newDomain.UniversalDomainName),
          UniversalAddressSpaceLocator = _newDomain.UniversalAddressSpaceLocator,
          UniversalAuthorizationServerLocator = _newDomain.UniversalAuthorizationServerLocator,
          UniversalDiscoveryServiceLocator = _newDomain.UniversalDiscoveryServiceLocator,
          SemanticsDataCollection = new SemanticsDataIndex[] { },
          URI = DomainConfigurationWrapper.URI
        };
        DomainConfigurationWrapper = new DomainModelWrapper(_newDomainModel);
      }
      catch (System.Exception _e)
      {
        MessageBox.Show($"Error while resolving the domain description {_e}", "Resolving of Semantics Data", MessageBoxButton.OK, MessageBoxImage.Warning);
      }
      finally
      {
        CurrentCursor = _currentCursor;
        CurrentIsEnabled = _currentIsEnabled;
      }
    }


  }

}
