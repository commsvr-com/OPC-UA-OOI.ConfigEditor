
using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure;
using CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure.Behaviors;
using CAS.CommServer.UA.OOI.ConfigurationEditor.MessageHandlerEditor;
using CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism.Logging;
using Prism.Regions;
using System;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class MessageHandlerEditorUnitTest
  {
    [TestMethod]
    public void MessageHandlersListViewCreatorTest()
    {
      MessageHandlersListView _newView = new MessageHandlersListView() { MessageHandlersListViewModel = 
        new MessageHandlersListViewModel(new TestAssociationServices(), new MessageHandlerServices(new MessageHandlerConfigurationCollection(new ConfigurationDataRepository())), new EmptyLogger()) };
    }
    [TestMethod]
    public void MessageHandlersListViewCompositionTest()
    {
      var catalog = new AggregateCatalog();
      catalog.Catalogs.Add(new AssemblyCatalog(typeof(AutoPopulateExportedViewsBehavior).Assembly));
      catalog.Catalogs.Add(new TypeCatalog(typeof(ExportedEmptyLogger)));
      using (CompositionContainer container = new CompositionContainer(catalog))
      {
        MessageHandlersListViewModel _viewModel = container.GetExportedValue<MessageHandlersListViewModel>();
        Assert.IsNotNull(_viewModel);
        MessageHandlersListView _newView = new MessageHandlersListView() { MessageHandlersListViewModel = _viewModel };
        Assert.IsNotNull(_newView);
        IEnumerable<Lazy<object, IViewRegionRegistration>> _newView2 = container.GetExports<object, IViewRegionRegistration>();
        Assert.IsNotNull(_newView2);
        Assert.AreEqual(1, _newView2.Count());
        Assert.IsTrue(_newView2.Any<Lazy<object, IViewRegionRegistration>>(x => !x.IsValueCreated));
        Assert.IsFalse(_newView2.Any<Lazy<object, IViewRegionRegistration>>(x => x.Metadata.RegionName != RegionNames.MainRegion));
        MessageHandlersListView _newViewInstance =
          _newView2.Where<Lazy<object, IViewRegionRegistration>>(x => x.Metadata.RegionName == RegionNames.MainRegion).Select<Lazy<object, IViewRegionRegistration>, object>(x => x.Value).Cast<MessageHandlersListView>().First<MessageHandlersListView>();
        Assert.IsNotNull(_newViewInstance);
        Assert.IsNotNull(_newViewInstance.MessageHandlersListViewModel);
      }
    }
    [TestMethod]
    public void MessageHandlersListViewRegionCompositionTest()
    {
      var catalog = new AggregateCatalog();
      catalog.Catalogs.Add(new AssemblyCatalog(typeof(AutoPopulateExportedViewsBehavior).Assembly));
      catalog.Catalogs.Add(new TypeCatalog(typeof(ExportedEmptyLogger)));
      using (CompositionContainer container = new CompositionContainer(catalog))
      {
        AutoPopulateExportedViewsBehavior behavior = container.GetExportedValue<AutoPopulateExportedViewsBehavior>();
        Region region = new Region() { Name = RegionNames.MainRegion };
        region.Behaviors.Add("AutoPopulateExportedViewsBehavior", behavior);
        Assert.AreEqual<int>(1, region.Views.Cast<object>().Count());
        Assert.IsTrue(region.Views.Cast<object>().Any(e => e.GetType() == typeof(MessageHandlersListView)));
      }
    }

    #region instrumentation
    [Export(typeof(IAssociationServices))]
    private class TestAssociationServices : IAssociationServices
    {
      public IEnumerable<AssociationCouplerViewModel> GetAssociationCouplerViewModelEnumerator(IMessageHandlerConfigurationWrapper wrapper)
      {
        throw new NotImplementedException();
      }

      public IEnumerable<AssociationCouplerViewModel> GetAssociationCouplerViewModelEnumerator(DataSetConfigurationWrapper wrapper)
      {
        throw new NotImplementedException();
      }
    }
    [Export(typeof(ILoggerFacade))]
    private class ExportedEmptyLogger : EmptyLogger { }
    [ImportMany(AllowRecomposition = true)]
    public Lazy<object, IViewRegionRegistration>[] RegisteredViews { get; set; }
    #endregion

  }
}

