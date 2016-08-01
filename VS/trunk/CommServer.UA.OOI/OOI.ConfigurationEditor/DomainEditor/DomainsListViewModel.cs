//_______________________________________________________________
//  Title   : DomainsListViewModel
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
using CAS.CommServer.UA.OOI.ConfigurationEditor.Services;
using CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel;
using CAS.Windows.Controls;
using Microsoft.Win32;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Logging;
using System;
using System.ComponentModel.Composition;
using System.Windows;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainEditor
{

  /// <summary>
  /// Class DomainsListViewModel - ViewModel of the <see cref="DomainsListView"/> to display 
  /// </summary>
  /// <seealso cref="MainRegionViewModel" />
  [Export(typeof(DomainsListViewModel))]
  [PartCreationPolicy(CreationPolicy.NonShared)]
  public class DomainsListViewModel : MainRegionViewModel
  {

    #region ImportingConstructor
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainsListViewModel"/> class.
    /// </summary>
    [ImportingConstructor()]
    public DomainsListViewModel(IDomainsManagementServices domainsServices, IEventAggregator eventAggregator, ILoggerFacade logger) : base("Data Domains")
    {
      m_EventAggregator = eventAggregator;
      m_Logger = logger;
      m_domainsServices = domainsServices;
      Action[] m_ButtonsActions = new Action[] {NewCommandHandler, AddCommandHandler, EditCommandHandler, RemoveSelectedCommandHandler};
      ButtonsPanelViewModel = new ButtonsViewModel("Create", "Add", "Edit", "Delete", m_ButtonsActions);
      SetCanExecuteButtonState();
      this.DomainsObservableCollection = m_domainsServices.GetAvailableDomains();
      logger.Log($"Created {nameof(DomainsListViewModel)}", Category.Debug, Priority.None);
    }
    #endregion

    #region Datacontext
    /// <summary>
    /// Gets the domains observable collection.
    /// </summary>
    /// <value>The domains observable collection.</value>
    public IDomainsObservableCollection DomainsObservableCollection { get; private set; }
    /// <summary>
    /// Gets or sets the current domain.
    /// </summary>
    /// <value>The current domain.</value>
    public DomainModelWrapper CurrentDomain
    {
      get
      {
        return b_CurrentDomain;
      }
      set
      {
        if (!SetProperty<DomainModelWrapper>(ref b_CurrentDomain, value))
          return;
        string _symbolicName = value != null ? value.AliasName : String.Empty;
        this.m_EventAggregator.GetEvent<Infrastructure.DomainSetEvent>().Publish(_symbolicName);
        SetCanExecuteButtonState();
      }
    }
    /// <summary>
    /// Gets or sets the buttons panel view model.
    /// </summary>
    /// <value>The buttons panel view model <see cref="ButtonsViewModel" />.</value>
    public override ButtonsViewModel ButtonsPanelViewModel
    {
      get; protected set;
    }
    /// <summary>
    /// Gets the edit popup request.
    /// </summary>
    /// <value>The edit popup request.</value>
    public IInteractionRequest EditPopupRequest { get { return b_EditPopupRequest; } }
    /// <summary>
    /// Used to popup user interface <see cref="DomainModelResolveView"/>.
    /// </summary>
    /// <value>The <see cref="IInteractionRequest"/> instance capturing interaction request to resole URI to domain model.</value>
    public IInteractionRequest ResoleUriToDomainModelPopupRequest { get { return b_ResoleUriToDomainModelPopupRequest; } }
    #endregion

    #region private
    private readonly IEventAggregator m_EventAggregator;
    private DomainModelWrapper b_CurrentDomain;
    private ILoggerFacade m_Logger;
    private InteractionRequest<IConfirmation> b_EditPopupRequest = new InteractionRequest<IConfirmation>();
    private InteractionRequest<DomainModelResolveViewModel> b_ResoleUriToDomainModelPopupRequest = new InteractionRequest<DomainModelResolveViewModel>();
    private IDomainsManagementServices m_domainsServices;

    //methods
    private void RemoveSelectedCommandHandler()
    {
      if (CurrentDomain == null) //double check
        return;
      this.m_domainsServices.Remove(CurrentDomain);
    }
    private void EditCommandHandler()
    {
      if (CurrentDomain == null) //double check
        return;
      DomainConfirmation _confirmation = new DomainConfirmation(CurrentDomain, true, m_Logger.Log) { Title = "Edit Data Domain Model" };
      bool _confirmed = false;
      b_EditPopupRequest.Raise(_confirmation, x => { _confirmed = x.Confirmed; });
      if (_confirmed)
        _confirmation.ApplyChanges();
    }
    private void AddCommandHandler()
    {
      DomainModelWrapper _dsc = null;
      DomainModelResolveViewModel _modeResolveConfirmation = new DomainModelResolveViewModel(m_Logger.Log) { Title = "Resolve Uri of Information Model to Data Domain Model Description" };
      bool _exitLoop = false;
      do
      {
        b_ResoleUriToDomainModelPopupRequest.Raise(_modeResolveConfirmation, x => { _exitLoop = x.Confirmed; });
        if (_exitLoop & _modeResolveConfirmation.ResolvedDomainModel != null)
          _dsc = _modeResolveConfirmation.ResolvedDomainModel;
        else
          _exitLoop = true;
      } while (!_exitLoop);
      if (_dsc == null)
        return;
      DomainConfirmation _confirmation = new DomainConfirmation(_dsc, false, m_Logger.Log) { Title = "Import Data Domain Model" };
      do
      {
        b_EditPopupRequest.Raise(_confirmation, x => { _exitLoop = x.Confirmed; });
        if (_exitLoop)
        {
          _exitLoop = m_domainsServices.AddDomain(_confirmation.DomainConfigurationWrapper);
          if (!_exitLoop)
            MessageBox.Show("The data domain exist", "Add data domain failed", MessageBoxButton.OK, MessageBoxImage.Error);
        }
        else
          _exitLoop = true;
      } while (!_exitLoop);
    }
    private void NewCommandHandler()
    {
      OpenFileDialog _of = new OpenFileDialog()
      {
        CheckFileExists = true,
         DefaultExt = "UANodeSet (.xml)|*.xml",
         Title = "Open OPC UA Address Space Model"
      };
      if (!_of.ShowDialog().GetValueOrDefault(false))
        return;
      DomainModelWrapper _dsc = m_domainsServices.CreateDefault();
      _dsc.UniversalAddressSpaceLocator = _of.FileName;
      DomainConfirmation _confirmation = new DomainConfirmation(_dsc, true, m_Logger.Log) { Title = "Create Data Domain Model" };
      bool _exitLoop = false;
      do
      {
        b_EditPopupRequest.Raise(_confirmation, x => { _exitLoop = x.Confirmed; });
        if (_exitLoop)
          _exitLoop = m_domainsServices.AddDomain(_confirmation.DomainConfigurationWrapper);
        else
          _exitLoop = true;
      } while (!_exitLoop);
    }
    private void SetCanExecuteButtonState()
    {
      bool _selectedOne = CurrentDomain != null;
      this.ButtonsPanelViewModel.SetCanExecuteState(true, true, _selectedOne, _selectedOne);
    }
    #endregion

  }
}
