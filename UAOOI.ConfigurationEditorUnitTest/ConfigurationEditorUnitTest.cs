
using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Networking = global::UAOOI.Configuration.Networking;
using CAS.CommServer.UAOOI.ConfigurationEditor.ConfigurationDataModel;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class ConfigurationEditorUnitTest
  {
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void EditConfigurationNullConfigurationTestMethod()
    {
      ConfigurationEditorBase _editor = new ConfigurationEditorBase();
      _editor.EditConfiguration(null);
    }
    [TestMethod]
    public void EditConfigurationConfigurationAssignTest()
    {
      Networking.Serialization.ConfigurationData _newConfiguration = new Networking.Serialization.ConfigurationData();
      ConfigurationEditorBase _editor = new ConfigurationEditorBase();
      _editor.EditConfiguration(_newConfiguration, false);
      ConfigurationDataRepository _newRepository = new ConfigurationDataRepository();
      Assert.IsNotNull(_newRepository.ConfigurationData);
      Assert.AreSame(_newConfiguration, _newRepository.ConfigurationData);
      Assert.IsNull(_newRepository.ConfigurationData.MessageHandlers);
      Assert.IsNull(_newConfiguration.MessageHandlers);
      _newRepository.ConfigurationData.MessageHandlers = new Networking.Serialization.MessageHandlerConfiguration[] { new Networking.Serialization.MessageReaderConfiguration() };
      Assert.IsNotNull(_newRepository.ConfigurationData.MessageHandlers);
      Assert.IsNotNull(_newConfiguration.MessageHandlers);
    }
  }
}
