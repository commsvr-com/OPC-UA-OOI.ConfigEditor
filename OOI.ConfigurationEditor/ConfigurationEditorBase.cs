using CAS.UA.IServerConfiguration;
using System;
using System.ComponentModel.Composition;
using UAOOI.Configuration.DataBindings;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor
{

  /// <summary>
  /// Class ConfigurationEditorBase - a simple implementation of the <see cref="IConfigurationEditor"/>.
  /// </summary>
  [Export(typeof(IConfigurationEditor))]
  public class ConfigurationEditorBase : IConfigurationEditor
  {
    /// <summary>
    /// Creates the instance configurations.
    /// </summary>
    /// <param name="descriptors">The descriptors.</param>
    /// <param name="SkipOpeningConfigurationFile">if set to <c>true</c> skip opening configuration file.</param>
    /// <param name="CancelWasPressed">The cancel was pressed.</param>
    public virtual void CreateInstanceConfigurations(INodeDescriptor[] descriptors, bool SkipOpeningConfigurationFile, Action<bool> CancelWasPressed)
    {
      throw new NotImplementedException("CreateInstanceConfigurations is not implemented yet");
      //MessageBox.Show("CreateInstanceConfigurations is not implemented yet", "Library functionality", MessageBoxButton.OK, MessageBoxImage.Question);
    }
    /// <summary>
    /// Edits the configuration - method used by the UT to unit test the configuration parameter propagation.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    /// <param name="runUI">if set to <c>true</c> [run UI].</param>
    /// <exception cref="System.ArgumentNullException"></exception>
    internal virtual void EditConfiguration(ConfigurationData configuration, bool runUI)
    {
      if (configuration == null)
        throw new ArgumentNullException(nameof(configuration));
      ConfigurationDataModel.ConfigurationDataRepository.SetConfigurationData = configuration;
      if (!runUI)
        return;
      HostingApplication _app = new HostingApplication();
      _app.Run();
    }
    /// <summary>
    /// Open configuration editor.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    public virtual void EditConfiguration(ConfigurationData configuration)
    {
      EditConfiguration(configuration, true);
    }
  }

}
