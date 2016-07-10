
using CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest.TestData
{
  internal static class RootDomainDescriptorFactory
  {
    internal static DomainDescriptor GetRootDomainDescriptor()
    {
      return new DomainDescriptor()
      {
        Description = "Starting point for discovery propcess with the purpose of resolving Uri and get DomainModel record",
        NextStepRecordType = RecordType.DomainDescriptor,
        UrlPattern = "http://localhost/opc/#authority#/DomainDescriptor.xml"
      };
    }
  }
}
