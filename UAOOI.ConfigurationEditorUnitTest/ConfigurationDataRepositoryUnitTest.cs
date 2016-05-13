
using CAS.CommServer.UAOOI.ConfigurationEditor.ConfigurationDataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Networking = global::UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class ConfigurationDataRepositoryUnitTest
  {
    [TestMethod]
    public void ConfigurationDataRepositoryAfterCreationTest()
    {
      ConfigurationDataRepository.SetConfigurationData = null;
      ConfigurationDataRepository _newRepository = new ConfigurationDataRepository();
      Assert.IsNotNull(_newRepository.ConfigurationData);
      Assert.IsNotNull(_newRepository.ConfigurationData.DataSets);
      Assert.IsNotNull(_newRepository.ConfigurationData.MessageHandlers);
    }
    [TestMethod]
    public void ConfigurationDataRepositoryModelAssignTest()
    {
      Networking.ConfigurationData _newConfiguration = new Networking.ConfigurationData();
      ConfigurationDataRepository.SetConfigurationData = _newConfiguration;
      ConfigurationDataRepository _newRepository = new ConfigurationDataRepository();
      Assert.IsNotNull(_newRepository.ConfigurationData);
      Assert.AreSame(_newConfiguration, _newRepository.ConfigurationData);
      _newRepository = new ConfigurationDataRepository();
      Assert.AreSame(_newConfiguration, _newRepository.ConfigurationData);
    }
  }
}
