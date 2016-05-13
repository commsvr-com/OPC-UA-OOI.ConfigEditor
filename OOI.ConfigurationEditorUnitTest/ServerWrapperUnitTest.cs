namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest
{

  //TODO - move to the ModelDesigner after creating NuGetPackage of the OOI
  //[TestClass]
  //public class ServerWrapperUnitTest
  //{
  //  [DeploymentItem(@"TestData\", @"TestData\")]
  //  [DeploymentItem(@"CAS.CommServer.UA.OOI.ConfigurationEditor.dll")]
  //  [TestMethod]
  //  public void UANetworkingConfigurationEditorCreationStateTest()
  //  {
  //    UANetworkingConfigurationEditor _editor = new UANetworkingConfigurationEditor();
  //    Assert.IsNotNull(_editor.ConfigurationData);
  //    Assembly _pluginAssembly;
  //    IConfiguration _serverConfiguration;
  //    AssemblyHelpers.CreateInstance(@"UAOOI.Configuration.DataBindings.dll", out _pluginAssembly, out _serverConfiguration);
  //    Assert.AreEqual<string>("UANetworkingConfiguration.uasconfig", _serverConfiguration.DefaultFileName);
  //    bool _configurationChanged = false;
  //    _serverConfiguration.OnModified += (x, y) => _configurationChanged = y.ConfigurationFileChanged;
  //    _serverConfiguration.CreateDefaultConfiguration();
  //    Assert.IsTrue(_configurationChanged);
  //    _configurationChanged = false;
  //    ServerWrapper _sw = new ServerWrapper(_serverConfiguration, _pluginAssembly, _ConfigurationBaseFileName);
  //    Assert.IsNotNull(_sw);
  //    Assert.IsTrue(_configurationChanged);

  //  }
  //  private const string _ConfigurationBaseFileName = @"TestData\ConfigurationDataConsumer.xml";

  //}
}
