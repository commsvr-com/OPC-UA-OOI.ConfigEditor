
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Threading.Tasks;
using CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class DataDiscoveryServicesUnitTest
  {
    [TestMethod]
    public void ResolveDomainDescriptionAsyncTestMethod()
    {
      Uri _uri = new Uri(@"http://localhost/opc/DomainDescriptor.xml");
      Task<DomainDescriptor> _task = Services.DataDiscoveryServices.ResolveDomainDescriptionAsync<DomainDescriptor>(_uri);
      _task.Wait(TimeSpan.FromSeconds(10));
      DomainDescriptor _tc = _task.Result;
      Assert.IsNotNull(_tc);
      Assert.AreEqual<string>("UniversalAddressSpaceLocator1", _tc.UniversalAddressSpaceLocator);
      Assert.AreEqual<string>("UniversalAuthorizationServerLocator1", _tc.UniversalAuthorizationServerLocator);
      Assert.AreEqual<string>("UniversalDiscoveryServiceLocator1", _tc.UniversalDiscoveryServiceLocator);
      Assert.AreEqual<string>("43E55D02-B9C8-4265-9898-259628C69429", _tc.UniversalDomainName);
      Assert.AreEqual<string>("Description1", _tc.Description);
    }
  }
}
