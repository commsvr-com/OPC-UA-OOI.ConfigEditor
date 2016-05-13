
using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure;
using CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel;
using Prism.Commands;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Regions;
using System;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DataSetEditor.DataSetList
{
  [Export(typeof(DataSetListViewModel))]
  [PartCreationPolicy(CreationPolicy.NonShared)]
  internal class DataSetListViewModel : BindableBase
  {

    [ImportingConstructor]
    internal DataSetListViewModel(IAssociationServices associationServices, IDataSetModelServices dataSetModelServices, IRegionManager regionManager, IEventAggregator eventAggregator, ILoggerFacade logger)
    {
      this.HeaderInfo = Properties.Resources.DataSetsListPanelHeader;
      this.m_AssociationServices = associationServices;
      this.m_DataSetModelServices = dataSetModelServices;
      this.m_RegionManager = regionManager;
      this.m_EventAggregator = eventAggregator;
      this.m_Logger = logger;
      this.DataSetListItems = m_DataSetModelServices.GetDataSets();
      this.RemoveDataSetCommand = new DelegateCommand<string>(this.RemoveDataSetCommandHandler);
      this.b_RemoveSelectedDataSetCommand = new DelegateCommand(this.RemoveSelectedDataSetCommandHandler, () => CurrentDataSetItem != null);
      this.b_EditDataSetCommand = new DelegateCommand(this.EditDataSetCommandHandler, () => CurrentDataSetItem != null);
      this.AddDataSetCommand = new DelegateCommand(AddDataSetCommandHandler);
      this.b_DataSetListItems.CollectionChanged += this.WatchListItems_CollectionChanged;
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
        b_RemoveSelectedDataSetCommand.RaiseCanExecuteChanged();
        b_EditDataSetCommand.RaiseCanExecuteChanged();
      }
    }
    public string HeaderInfo { get; private set; }
    public ICommand RemoveDataSetCommand { get; private set; }
    public ICommand RemoveSelectedDataSetCommand { get { return b_RemoveSelectedDataSetCommand; } }
    public ICommand EditSelectedDataSetCommand { get { return b_EditDataSetCommand; } }
    public ICommand AddDataSetCommand { get; private set; }
    public String AddDataSetCommandTitle { get { return "Add DataSet"; } }
    public IInteractionRequest AddDataSetRequest { get { return b_AddRequest; } }
    public IInteractionRequest EditDataSetRequest { get { return b_EditRequest; } }
    #endregion

    #region private
    private readonly IDataSetModelServices m_DataSetModelServices;
    private readonly IEventAggregator m_EventAggregator;
    private readonly IRegionManager m_RegionManager;
    private readonly ILoggerFacade m_Logger;
    private readonly IAssociationServices m_AssociationServices;
    //
    private IDataSetConfigurationCollection b_DataSetListItems;
    private DataSetConfigurationWrapper b_CurrentDataSetItem;
    private readonly InteractionRequest<IConfirmation> b_AddRequest = new InteractionRequest<IConfirmation>();
    private readonly InteractionRequest<IConfirmation> b_EditRequest = new InteractionRequest<IConfirmation>();
    private readonly DelegateCommand b_RemoveSelectedDataSetCommand;
    private readonly DelegateCommand b_EditDataSetCommand;

    private void AddDataSetCommandHandler()
    {
      DataSetConfigurationWrapper _dsc = DataSetConfigurationWrapper.CreateDefault();
      DataSetItemConfirmation _confirmation = new DataSetItemConfirmation(_dsc, m_AssociationServices.GetAssociationCouplerViewModelEnumerator, true) { Title = "New DataSet" };
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
      DataSetItemConfirmation _confirmation = new DataSetItemConfirmation(CurrentDataSetItem, x => m_AssociationServices.GetAssociationCouplerViewModelEnumerator(x), false) { Title = "Edit DataSet" };
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
