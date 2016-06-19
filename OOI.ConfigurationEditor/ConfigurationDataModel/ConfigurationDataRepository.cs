
using System.ComponentModel.Composition;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{
  /// <summary>
  /// Class ConfigurationDataRepository - wrapps the configuration that is edited by the tool.
  /// </summary>
  [Export]
  [PartCreationPolicy(CreationPolicy.Shared)]
  public class ConfigurationDataRepository
  {
    /// <summary>
    /// Gets or sets the <see cref="ConfigurationData"/>.
    /// </summary>
    /// <value>The set configuration data.</value>
    internal static ConfigurationData SetConfigurationData { private get; set; }
    /// <summary>
    /// Initializes a new instance of the <see cref="ConfigurationDataRepository"/> class.
    /// </summary>
    public ConfigurationDataRepository()
    {
      if (ConfigurationData == null)
        SetConfigurationData = new ConfigurationData() { DataSets = new DataSetConfiguration[] { }, MessageHandlers = new MessageHandlerConfiguration[] { } };
      SetConfigurationData.OnChanged?.Invoke();
    }
    internal ConfigurationData ConfigurationData
    {
      get { return SetConfigurationData; }
      set { SetConfigurationData = value; }
    }

  }
}
