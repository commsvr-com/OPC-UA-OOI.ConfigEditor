
using CAS.CommServer.UA.ModelDesigner.Configuration;
using CAS.UA.IServerConfiguration;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Reflection;
using UAOOI.Configuration.DataBindings;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.UnitTest
{

  [TestClass]
  public class ServerWrapperUnitTest
  {
    [DeploymentItem(@"TestData\", @"TestData\")]
    [DeploymentItem(@"CAS.CommServer.UAOOI.ConfigurationEditor.dll")]
    [TestMethod]
    public void UANetworkingConfigurationEditorCreationStateTest()
    {
      UANetworkingConfigurationEditor _editor = new UANetworkingConfigurationEditor();
      Assert.IsNotNull(_editor.ConfigurationData);
      Assembly _pluginAssembly;
      IConfiguration _serverConfiguration;
      AssemblyHelpers.CreateInstance(@"UAOOI.Configuration.DataBindings.dll", out _pluginAssembly, out _serverConfiguration);
      Assert.AreEqual<string>("UANetworkingConfiguration.uasconfig", _serverConfiguration.DefaultFileName);
      bool _configurationChanged = false;
      _serverConfiguration.OnModified += (x, y) => _configurationChanged = y.ConfigurationFileChanged;
      _serverConfiguration.CreateDefaultConfiguration();
      Assert.IsTrue(_configurationChanged);
      _configurationChanged = false;
      ServerWrapper _sw = new ServerWrapper(_serverConfiguration, _pluginAssembly, _ConfigurationBaseFileName);
      Assert.IsNotNull(_sw);
      Assert.IsTrue(_configurationChanged);

    }
    private const string _ConfigurationBaseFileName = @"TestData\ConfigurationDataConsumer.xml";

  }
}
