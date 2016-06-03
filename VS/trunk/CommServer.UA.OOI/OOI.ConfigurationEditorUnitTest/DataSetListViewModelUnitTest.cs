
using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using CAS.CommServer.UA.OOI.ConfigurationEditor.DataSetEditor.DataSetList;
using CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism.Events;
using Prism.Interactivity.InteractionRequest;
using Prism.Logging;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.IO;
using System.Linq;
using System.Reflection;
using UAOOI.Configuration.Networking.Serialization;
using Networking = global::UAOOI.Configuration.Networking;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class DataSetListViewModelUnitTest
  {
    [TestMethod]
    public void DataSetEditorCreatorsChainTest()
    {
      ConfigurationDataRepository _repository = new ConfigurationDataRepository();
      DataSetModelServices _dataSetModelServices = new DataSetModelServices(new DataSetConfigurationCollection(_repository, new TestLoggerFacade()));
      DataSetEditor.Services.DataSetEditorServices _service = new DataSetEditor.Services.DataSetEditorServices(_dataSetModelServices);
      TestLoggerFacade _LoggerFacade = new TestLoggerFacade();
      DataSetListViewModel _viewModel = new DataSetListViewModel(new TestAssociationServices(), _dataSetModelServices, new TestRegionManager(), new TestEventAggregator(), _LoggerFacade);
      Assert.IsNull(_viewModel.CurrentDataSetItem);
      Assert.IsFalse(String.IsNullOrEmpty(_viewModel.HeaderInfo));
      Assert.IsNotNull(_viewModel.AddDataSetCommand);
      Assert.IsTrue(_viewModel.AddDataSetCommand.CanExecute(null));
      Assert.IsNotNull(_viewModel.AddDataSetRequest);
      Assert.IsNotNull(_viewModel.RemoveDataSetCommand);
      Assert.IsTrue(_viewModel.RemoveDataSetCommand.CanExecute(null));
      Assert.IsNotNull(_viewModel.RemoveSelectedDataSetCommand);
      Assert.IsFalse(_viewModel.RemoveSelectedDataSetCommand.CanExecute(null));
      DataSetListView _view = new DataSetListView() { ViewModel = _viewModel };
      Assert.AreEqual(1, _LoggerFacade.count);
    }
    [TestMethod]
    [DeploymentItem(@"TestData\", @"TestData\")]
    public void CompositionTest()
    {
      FileInfo _configFile = new FileInfo(@"TestData\ConfigurationDataConsumer.xml");
      Assert.IsTrue(_configFile.Exists);
      Networking.UANetworkingConfiguration<Networking.Serialization.ConfigurationData> _newConfiguration = new Networking.UANetworkingConfiguration<Networking.Serialization.ConfigurationData>();
      _newConfiguration.ReadConfiguration(_configFile);
      ConfigurationDataRepository.SetConfigurationData = _newConfiguration.CurrentConfiguration;
      AggregateCatalog _catalog = new AggregateCatalog();
      _catalog.Catalogs.Add(new AssemblyCatalog(Assembly.GetAssembly(typeof(DataSetListViewModel))));
      _catalog.Catalogs.Add(new TypeCatalog(typeof(TestRegionManager), typeof(TestLoggerFacade), typeof(TestEventAggregator)));
      using (CompositionContainer _testContainer = new CompositionContainer(_catalog))
      {
        _testContainer.ComposeParts(this);
        Assert.IsNotNull(View);
        Assert.IsNotNull(View.DataSetListItems);
        CollectionAssert.AreEqual(new ObservableCollection<string>(new string[] { "DataSymbolicName" }), View.DataSetListItems.Select<DataSetConfigurationWrapper, string>(x => x.SymbolicName).ToList<string>());
      }

    }
    [TestMethod]
    public void AddDataSetCommandTest()
    {
      ConfigurationDataRepository _repository = new ConfigurationDataRepository();
      DataSetModelServices _dataSetModelServices = new DataSetModelServices(new DataSetConfigurationCollection(_repository, new TestLoggerFacade()));
      TestLoggerFacade _LoggerFacade = new TestLoggerFacade();
      DataSetListViewModel _viewModel = new DataSetListViewModel(new TestAssociationServices(), _dataSetModelServices, new TestRegionManager(), new TestEventAggregator(), _LoggerFacade);
      bool _raised = false;
      _viewModel.AddDataSetRequest.Raised += (x, y) => { _raised = true; Assert.IsInstanceOfType(y.Context, typeof(IConfirmation)); };
      Assert.IsTrue(_viewModel.AddDataSetCommand.CanExecute(null));
      _viewModel.AddDataSetCommand.Execute(null);
      Assert.IsTrue(_raised);
    }
    [TestMethod]
    public void AddDataSetRequestTest()
    {
      ConfigurationDataRepository _repository = new ConfigurationDataRepository();
      DataSetModelServices _dataSetModelServices = new DataSetModelServices(new DataSetConfigurationCollection(_repository, new TestLoggerFacade()));
      TestLoggerFacade _LoggerFacade = new TestLoggerFacade();
      DataSetListViewModel _viewModel = new DataSetListViewModel(new TestAssociationServices(), _dataSetModelServices, new TestRegionManager(), new TestEventAggregator(), _LoggerFacade);
      TestView _view = new TestView() { DataContext = _viewModel };
      Assert.IsTrue(_viewModel.AddDataSetCommand.CanExecute(null));
      _viewModel.AddDataSetCommand.Execute(null);
      Assert.IsTrue(_view.RaisedWasCalled);
      Assert.IsTrue(_view.CallbackIsNotNull);
      Assert.IsTrue(_view.ContextIsNotNull);
      Assert.IsTrue(_view.ContextType);
      Assert.IsTrue(_view.senderType);
      Assert.IsTrue(_view.DataSetConfigurationWrapperNotNull);
      Assert.IsTrue(_view.MessageHandlersNotNull);
      Assert.IsTrue(_view.MessageHandlersCount);
      Assert.IsTrue(_view.senderType);
    }

    #region Instrumentation
    [Import]
    private DataSetListViewModel View { get; set; }
    [Export(typeof(IRegionManager))]
    private class TestRegionManager : IRegionManager
    {
      public IRegionCollection Regions
      {
        get
        {
          throw new NotImplementedException();
        }
      }
      public IRegionManager AddToRegion(string regionName, object view)
      {
        throw new NotImplementedException();
      }
      public IRegionManager CreateRegionManager()
      {
        throw new NotImplementedException();
      }
      public IRegionManager RegisterViewWithRegion(string regionName, Func<object> getContentDelegate)
      {
        throw new NotImplementedException();
      }
      public IRegionManager RegisterViewWithRegion(string regionName, Type viewType)
      {
        throw new NotImplementedException();
      }
      public void RequestNavigate(string regionName, string source)
      {
        throw new NotImplementedException();
      }
      public void RequestNavigate(string regionName, Uri source)
      {
        throw new NotImplementedException();
      }
      public void RequestNavigate(string regionName, string source, Action<NavigationResult> navigationCallback)
      {
        throw new NotImplementedException();
      }
      public void RequestNavigate(string regionName, Uri target, NavigationParameters navigationParameters)
      {
        throw new NotImplementedException();
      }
      public void RequestNavigate(string regionName, string target, NavigationParameters navigationParameters)
      {
        throw new NotImplementedException();
      }
      public void RequestNavigate(string regionName, Uri source, Action<NavigationResult> navigationCallback)
      {
        throw new NotImplementedException();
      }
      public void RequestNavigate(string regionName, string target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters)
      {
        throw new NotImplementedException();
      }
      public void RequestNavigate(string regionName, Uri target, Action<NavigationResult> navigationCallback, NavigationParameters navigationParameters)
      {
        throw new NotImplementedException();
      }
    }
    [Export(typeof(IEventAggregator))]
    private class TestEventAggregator : IEventAggregator
    {
      public TEventType GetEvent<TEventType>()
        where TEventType : EventBase, new()
      {
        return new TEventType();
      }
    }
    [Export(typeof(ILoggerFacade))]
    private class TestLoggerFacade : ILoggerFacade
    {
      public void Log(string message, Category category, Priority priority)
      {
        count++;
      }
      internal int count = 0;
    }
    [Export(typeof(ViewModel.IAssociationServices))]
    [PartCreationPolicy(CreationPolicy.Shared)]
    private class TestAssociationServices : ViewModel.IAssociationServices
    {
      public IEnumerable<AssociationCouplerViewModel> GetAssociationCouplerViewModelEnumerator(IMessageHandlerConfigurationWrapper wrapper)
      {
        throw new NotImplementedException();
      }
      public IEnumerable<AssociationCouplerViewModel> GetAssociationCouplerViewModelEnumerator(DataSetConfigurationWrapper dataset)
      {
        return new AssociationCouplerViewModel[] { new AssociationCouplerViewModel(new AssociationCouple(() => false, x => { }, "MessageHandlerName")  )};
      }
    }
    private class TestView
    {
      public DataSetListViewModel DataContext
      {
        set
        {
          value.AddDataSetRequest.Raised += AddDataSetRequest_Raised;
        }
      }
      public bool CallbackIsNotNull = false;
      public bool ContextIsNotNull = false;
      public bool ContextType = false;
      public bool senderType = false;
      public bool DataSetConfigurationWrapperNotNull = false;
      public bool MessageHandlersNotNull = false;
      public bool MessageHandlersCount = false;
      public bool RaisedWasCalled = false;
      private void AddDataSetRequest_Raised(object sender, InteractionRequestedEventArgs e)
      {
        RaisedWasCalled = true;
        senderType = sender is InteractionRequest<IConfirmation>;
        CallbackIsNotNull = e.Callback != null;
        ContextIsNotNull = e.Context != null;
        ContextType = e.Context is DataSetItemConfirmation;
        DataSetItemConfirmation _context = e.Context as DataSetItemConfirmation;
        ContextType = _context != null;
        if (!ContextType)
          return;
        DataSetConfigurationWrapperNotNull = _context.DataSetConfigurationWrapper != null;
        MessageHandlersNotNull = _context.AssociationCouplersEnumerator != null;
        if (!MessageHandlersNotNull)
          return;
        MessageHandlersCount = _context.AssociationCouplersEnumerator.Count<AssociationCouplerViewModel>() > 0;
      }
    }
    #endregion

  }
}
