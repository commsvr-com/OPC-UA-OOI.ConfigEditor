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

using CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel;
using CAS.Windows.ViewModel;
using Prism.Logging;
using System;
using System.Windows.Input;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainEditor
{
  internal class DomainConfirmation : ConfirmationBindable
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainConfirmation" /> class.
    /// </summary>
    /// <param name="domain">The domain.</param>
    /// <param name="log">A delegate capturing logging functionality.</param>
    internal DomainConfirmation(DomainModelWrapper domain, Action<string, Category, Prism.Logging.Priority> log)
    {
      b_DomainConfigurationWrapper = domain;
      Go2DiscoveryServiceURL = new CAS.Windows.Commands.WebDocumentationCommand(() => DomainConfigurationWrapper.UniversalDiscoveryServiceLocator);
      Go2AddressSpaceURL = new CAS.Windows.Commands.WebDocumentationCommand(() => DomainConfigurationWrapper.UniversalAddressSpaceLocator);
      m_LoggerAction = log;
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
        SetProperty<SemanticsDataIndexWrapper>(ref b_CurrentSemanticsDataIndex, value);
      }
    }
    public ICommand LookupDNSCommand { get; }
    public ICommand Go2DiscoveryServiceURL { get; }
    public ICommand Go2AddressSpaceURL { get; }
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
    public string IdToolTip { get { return Properties.Resources.IdToolTip; } }
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
    private Action<string, Category, Prism.Logging.Priority> m_LoggerAction;

  }
}
