using System.IO;
using System.Windows;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UITestApplication
{
  /// <summary>
  /// Interaction logic for App.xaml
  /// </summary>
  public partial class App : Application
  {

    private void Application_Startup(object sender, StartupEventArgs e)
    {
      FileInfo _configFile = new FileInfo(@"TestData\ConfigurationDataConsumer.xml");
      if (!_configFile.Exists)
        throw new FileNotFoundException(_configFile.FullName);
      UAOOI.Configuration.DataBindings.UANetworkingConfigurationEditor _editor = new UAOOI.Configuration.DataBindings.UANetworkingConfigurationEditor();
      _editor.ReadConfiguration(_configFile);
      _editor.EditConfiguration();
    }
  }
}
