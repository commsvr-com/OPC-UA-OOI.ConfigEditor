
using CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure.Behaviors;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism.Regions;
using System.ComponentModel.Composition.Hosting;
using System.Linq;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class AutoPopulateExportedViewsBehaviorFixture
  {
    [TestMethod]
    public void WhenAttached_ThenAddsViewsRegisteredToTheRegion()
    {
      var catalog = new AggregateCatalog();
      catalog.Catalogs.Add(new AssemblyCatalog(typeof(AutoPopulateExportedViewsBehavior).Assembly));
      catalog.Catalogs.Add(new TypeCatalog(typeof(View1), typeof(View2)));
      using (CompositionContainer container = new CompositionContainer(catalog))
      {
        AutoPopulateExportedViewsBehavior behavior = container.GetExportedValue<AutoPopulateExportedViewsBehavior>();
        Region region = new Region() { Name = "region1" };
        region.Behaviors.Add("AutoPopulateExportedViewsBehavior", behavior);
        Assert.AreEqual(1, region.Views.Cast<object>().Count());
        Assert.IsTrue(region.Views.Cast<object>().Any(e => e.GetType() == typeof(View1)));
      }
    }
    [TestMethod]
    public void WhenRecomposed_ThenAddsNewViewsRegisteredToTheRegion()
    {
      AggregateCatalog catalog = new AggregateCatalog();
      catalog.Catalogs.Add(new AssemblyCatalog(typeof(AutoPopulateExportedViewsBehavior).Assembly));
      catalog.Catalogs.Add(new TypeCatalog(typeof(View1), typeof(View2)));
      using (CompositionContainer container = new CompositionContainer(catalog))
      {
        AutoPopulateExportedViewsBehavior behavior = container.GetExportedValue<AutoPopulateExportedViewsBehavior>();
        Region region = new Region() { Name = "region1" };
        region.Behaviors.Add("", behavior);
        catalog.Catalogs.Add(new TypeCatalog(typeof(View3), typeof(View4)));
        Assert.AreEqual(2, region.Views.Cast<object>().Count());
        Assert.IsTrue(region.Views.Cast<object>().Any(e => e.GetType() == typeof(View1)));
        Assert.IsTrue(region.Views.Cast<object>().Any(e => e.GetType() == typeof(View3)));
      }
    }
  }

  [ViewExport(RegionName = "region1")]
  public class View1 { }

  [ViewExport(RegionName = "region2")]
  public class View2 { }

  [ViewExport(RegionName = "region1")]
  public class View3 { }

  [ViewExport(RegionName = "region2")]
  public class View4 { }
}
