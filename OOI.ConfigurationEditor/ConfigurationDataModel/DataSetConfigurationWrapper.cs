using CAS.Windows.mvvm;
using System;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  public class DataSetConfigurationWrapper : Bindable
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DataSetConfigurationWrapper"/> class using empty <see cref="DataSetConfiguration"/>.
    /// </summary>
    public DataSetConfigurationWrapper(DataSetConfiguration configurationItem)
    {
      if (configurationItem == null)
        throw new System.ArgumentNullException(nameof(configurationItem));
      this.DataSetConfiguration = configurationItem;
    }
    public string SymbolicName
    {
      get { return DataSetConfiguration.DataSymbolicName; }
      set { base.SetProperty<string>(DataSetConfiguration.DataSymbolicName, x => DataSetConfiguration.DataSymbolicName = x, value); }
    }
    public AssociationRole AssociationRole
    {
      get { return DataSetConfiguration.AssociationRole; }
      set { base.SetProperty<AssociationRole>(DataSetConfiguration.AssociationRole, x => DataSetConfiguration.AssociationRole = x, value); }
    }
    public double PublishingInterval
    {
      get { return DataSetConfiguration.PublishingInterval; }
      set { base.SetProperty<double>(DataSetConfiguration.PublishingInterval, x => DataSetConfiguration.PublishingInterval = x, value); }
    }
    public string AssociationName
    {
      get { return DataSetConfiguration.AssociationName; }
      set { base.SetProperty<string>(DataSetConfiguration.AssociationName, x => DataSetConfiguration.AssociationName = x, value); }
    }
    public Guid ConfigurationGuid
    {
      get { return DataSetConfiguration.ConfigurationGuid; }
      set { base.SetProperty<Guid>(DataSetConfiguration.ConfigurationGuid, x => DataSetConfiguration.ConfigurationGuid = x, value); }
    }
    public ConfigurationVersionDataTypeWrapper ConfigurationVersion
    {
      get { return new ConfigurationVersionDataTypeWrapper(DataSetConfiguration.ConfigurationVersion); }
      set
      {
        base.SetProperty<ConfigurationVersionDataTypeWrapper>
      (x => DataSetConfiguration.ConfigurationVersion = new ConfigurationVersionDataType() { MajorVersion = x.MajorVersion, MinorVersion = x.MinorVersion }, value);
      }
    }
    public double MaxBufferTime
    {
      get { return DataSetConfiguration.MaxBufferTime; }
      set { base.SetProperty<double>(DataSetConfiguration.MaxBufferTime, x => DataSetConfiguration.MaxBufferTime = x, value); }
    }
    internal DataSetConfiguration DataSetConfiguration { get; private set; }
    internal static DataSetConfigurationWrapper CreateDefault()
    {
      return new DataSetConfigurationWrapper()
      {
        AssociationName = $"AssociationName{m_UniqueNameId++}",
        AssociationRole = AssociationRole.Consumer,
        ConfigurationGuid = Guid.NewGuid(),
        ConfigurationVersion = ConfigurationVersionDataTypeWrapper.CreateDefault(),
        MaxBufferTime = -1,
        PublishingInterval = -1,
        SymbolicName = $"SymbolicName{m_UniqueNameId++}"
      };
    }

    #region override Object
    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    public override string ToString()
    {
      return $"DataSet {SymbolicName} with the {AssociationRole} role";
    }
    #endregion    
    
    //private
    private DataSetConfigurationWrapper()
    {
      this.DataSetConfiguration = new DataSetConfiguration();
    }
    private static int m_UniqueNameId = Convert.ToInt32(new Random().NextDouble() * int.MaxValue);
  }

}