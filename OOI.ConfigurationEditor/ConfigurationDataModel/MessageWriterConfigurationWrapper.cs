
using UAOOI.Configuration.Networking.Serialization;
using System.Linq;
using System.Collections.Generic;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  internal class MessageWriterConfigurationWrapper : MessageHandlerConfigurationWrapper<MessageWriterConfiguration>
  {

    internal MessageWriterConfigurationWrapper(MessageWriterConfiguration configurationItem) : base(configurationItem) { }
    public ProducerAssociationConfigurationWrapper[] AssociationConfiguration
    {
      get { return Item.ProducerAssociationConfigurations.Select<ProducerAssociationConfiguration, ProducerAssociationConfigurationWrapper>
                                                            (x => new ProducerAssociationConfigurationWrapper(x)).ToArray<ProducerAssociationConfigurationWrapper>(); }
      set
      {
        AssignProperty<ProducerAssociationConfiguration[]>
          (
             x => base.Item.ProducerAssociationConfigurations = x,
             value.Cast<IWrapper<ProducerAssociationConfiguration>>().
                   Select<IWrapper<ProducerAssociationConfiguration>, ProducerAssociationConfiguration>(y => y.Item).
                   ToArray<ProducerAssociationConfiguration>()
          );
      }
    }
    internal static MessageWriterConfigurationWrapper CreateDefault()
    {
      MessageWriterConfiguration _ReaderConfig = new MessageWriterConfiguration
      {
        Configuration = null,
        Name = "MessageReaderConfigurationName",
        ProducerAssociationConfigurations = new ProducerAssociationConfiguration[] { },
        TransportRole = AssociationRole.Producer
      };
      return new MessageWriterConfigurationWrapper(_ReaderConfig);
    }
    #region MessageHandlerConfigurationWrapper<MessageReaderConfiguration>
    public override void Associate(bool associate, DataSetConfigurationWrapper dataset)
    {
      if (associate)
      {
        if (Check(dataset))
          return;
        ProducerAssociationConfigurationWrapper _wrapper = ProducerAssociationConfigurationWrapper.GetDefault(dataset.AssociationName);
        List<ProducerAssociationConfigurationWrapper> _associations = new List<ProducerAssociationConfigurationWrapper>(AssociationConfiguration);
        _associations.Add(_wrapper);
        AssociationConfiguration = _associations.ToArray<ProducerAssociationConfigurationWrapper>();
      }
      else
        AssociationConfiguration = AssociationConfiguration.Where<ProducerAssociationConfigurationWrapper>(x => x.AssociationName != dataset.AssociationName).ToArray<ProducerAssociationConfigurationWrapper>();
    }
    public override bool Check(DataSetConfigurationWrapper dataset)
    {
      return AssociationConfiguration.Where<ProducerAssociationConfigurationWrapper>(x => x.AssociationName == dataset.AssociationName).Any<ProducerAssociationConfigurationWrapper>();
    }
    #endregion

  }
}