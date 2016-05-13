
using System;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  internal class ProducerAssociationConfigurationWrapper : AssociationConfigurationWrapper<ProducerAssociationConfiguration>
  {

    public ProducerAssociationConfigurationWrapper(ProducerAssociationConfiguration configuration) : base(configuration) { }
    public FieldEncodingEnum FieldEncoding
    {

      get { return base.Item.FieldEncoding; }
      set { AssignProperty<FieldEncodingEnum>(x => Item.FieldEncoding = x, value); }

    }

    internal static ProducerAssociationConfigurationWrapper GetDefault(string associationName)
    {
      ProducerAssociationConfiguration _producerAssociation = new ProducerAssociationConfiguration()
      {
        AssociationName = associationName,
        DataSetWriterId = 0,
        FieldEncoding = FieldEncodingEnum.CompressedFieldEncoding
      };
      return new ProducerAssociationConfigurationWrapper(_producerAssociation);
    }
  }
}
