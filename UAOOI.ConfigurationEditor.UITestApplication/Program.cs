using System;
using System.IO;
using UAOOI.Configuration.Networking.Serialization;
using Networking = global::UAOOI.Configuration.Networking;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.UITestApplication
{
  class Program
  {
    [STAThread]
    static void Main(string[] args)
    {
      FileInfo _configFile = new FileInfo(@"TestData\ConfigurationDataConsumer.xml");
      if (!_configFile.Exists)
        throw new FileNotFoundException(_configFile.FullName);
      Networking.UANetworkingConfiguration<ConfigurationData> _newConfiguration = new Networking.UANetworkingConfiguration<ConfigurationData>();
      _newConfiguration.ReadConfiguration(_configFile);
      ConfigurationEditorBase _factory = new ConfigurationEditorBase();
      _factory.EditConfiguration(_newConfiguration.CurrentConfiguration);
    }
  }
}
