//_______________________________________________________________
//  Title   : DataSetListViewModel
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate: 2016-06-11 21:25:44 +0200 (So, 11 cze 2016) $
//  $Rev: 12228 $
//  $LastChangedBy: mpostol $
//  $URL: svn://svnserver.hq.cas.com.pl/VS/trunk/CommServer.UA.OOI/OOI.ConfigurationEditor/DataSetEditor/DataSetList/DataSetListViewModel.cs $
//  $Id: DataSetListViewModel.cs 12228 2016-06-11 19:25:44Z mpostol $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure;
using CAS.CommServer.UA.OOI.ConfigurationEditor.Services;
using CAS.Windows.Controls;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Logging;
using Prism.Regions;
using System;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DataSetEditor
{
  [Export(typeof(DataSetListViewModel))]
  [PartCreationPolicy(CreationPolicy.NonShared)]
  internal class DataSetListViewModel : ViewModel.MainRegionViewModel
  {

    [ImportingConstructor]
    internal DataSetListViewModel
      (IDomainsManagementServices domainsService, IAssociationServices associationServices, IDataSetModelServices dataSetModelServices, IRegionManager regionManager, IEventAggregator eventAggregator, ILoggerFacade logger) :
        base(Properties.Resources.DataSetsListPanelHeader)
    {
      this.m_DomainsService = domainsService;
      this.m_AssociationServices = associationServices;
      this.m_DataSetModelServices = dataSetModelServices;
      this.m_RegionManager = regionManager;
      this.m_EventAggregator = eventAggregator;
      this.m_Logger = logger;
      this.DataSetListItems = m_DataSetModelServices.GetDataSets();
      this.RemoveDataSetCommand = new DelegateCommand<string>(this.RemoveDataSetCommandHandler);
      this.b_DataSetListItems.CollectionChanged += this.WatchListItems_CollectionChanged;
      Action[] m_ButtonsActions = new Action[] { AddDataSetCommandHandler, EditDataSetCommandHandler, RemoveSelectedDataSetCommandHandler, () => { } };
      ButtonsPanelViewModel = new ButtonsViewModel("Add", "Edit", "Delete", "", m_ButtonsActions);
      SetCanExecuteButtonState();
      logger.Log($"Created {nameof(DataSetListViewModel)}", Category.Debug, Priority.None);
    }

    #region Datacontext
    public IDataSetConfigurationCollection DataSetListItems
    {
      get { return this.b_DataSetListItems; }
      private set { SetProperty<IDataSetConfigurationCollection>(ref this.b_DataSetListItems, value); }
    }
    public DataSetConfigurationWrapper CurrentDataSetItem
    {
      get
      {
        return this.b_CurrentDataSetItem;
      }
      set
      {
        if (!SetProperty(ref this.b_CurrentDataSetItem, value))
          return;
        string _symbolicName = value != null ? this.b_CurrentDataSetItem.SymbolicName : String.Empty;
        this.m_EventAggregator.GetEvent<DataSetSelectedEvent>().Publish(_symbolicName);
        SetCanExecuteButtonState();
      }
    }
    public override ButtonsViewModel ButtonsPanelViewModel { get; protected set; }
    public ICommand RemoveDataSetCommand { get; private set; }
    public IInteractionRequest DataSetEditPopupRequest { get { return b_AddRequest; } }
    #endregion

    #region private
    private readonly IDataSetModelServices m_DataSetModelServices;
    private readonly IEventAggregator m_EventAggregator;
    private readonly IRegionManager m_RegionManager;
    private readonly ILoggerFacade m_Logger;
    private readonly IAssociationServices m_AssociationServices;
    private readonly IDomainsManagementServices m_DomainsService;
    //
    private IDataSetConfigurationCollection b_DataSetListItems;
    private DataSetConfigurationWrapper b_CurrentDataSetItem;
    private readonly InteractionRequest<IConfirmation> b_AddRequest = new InteractionRequest<IConfirmation>();

    //methods
    private void SetCanExecuteButtonState()
    {
      bool _selectedOne = CurrentDataSetItem != null;
      this.ButtonsPanelViewModel.SetCanExecuteState(true, _selectedOne, _selectedOne, false);
    }
    private void AddDataSetCommandHandler()
    {
      DataSetConfigurationWrapper _dsc = DataSetConfigurationWrapper.CreateDefault();
      DataSetItemConfirmation _confirmation = new DataSetItemConfirmation(_dsc, m_AssociationServices.GetAssociationCouplerViewModelEnumerator, true, m_DomainsService.GetAvailableDomains()) { Title = "New DataSet" };
      bool _confirmed = false;
      b_AddRequest.Raise(_confirmation, x => { _confirmed = x.Confirmed; });
      if (_confirmed)
        m_DataSetModelServices.AddDataSet(_confirmation.DataSetConfigurationWrapper);
      else
        _confirmation.Revert();
    }
    private void EditDataSetCommandHandler()
    {
      if (CurrentDataSetItem == null) //double check
        return;
      DataSetItemConfirmation _confirmation = new DataSetItemConfirmation(CurrentDataSetItem, x => m_AssociationServices.GetAssociationCouplerViewModelEnumerator(x), false, m_DomainsService.GetAvailableDomains()) { Title = "Edit DataSet" };
      bool _confirmed = false;
      b_AddRequest.Raise(_confirmation, x => { _confirmed = x.Confirmed; });
      if (!_confirmed)
        _confirmation.Revert();
    }
    private void RemoveDataSetCommandHandler(string symbolicName)
    {
      if (!m_DataSetModelServices.DataSetExists(symbolicName))
        return;
      this.m_DataSetModelServices.Remove(symbolicName);
    }
    private void RemoveSelectedDataSetCommandHandler()
    {
      if (CurrentDataSetItem == null) //double check
        return;
      this.m_DataSetModelServices.Remove(CurrentDataSetItem);
    }
    private void WatchListItems_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      if (e.Action == NotifyCollectionChangedAction.Add)
      {
        m_RegionManager.Regions[RegionNames.MainRegion].RequestNavigate("/WatchListView", nr => { });
      }
    }
    #endregion

  }
}
