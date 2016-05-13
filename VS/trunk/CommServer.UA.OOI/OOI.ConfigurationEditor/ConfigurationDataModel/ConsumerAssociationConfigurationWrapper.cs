
using System;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  internal class ConsumerAssociationConfigurationWrapper : AssociationConfigurationWrapper<ConsumerAssociationConfiguration>
  {

    public ConsumerAssociationConfigurationWrapper(ConsumerAssociationConfiguration configuration) : base(configuration) { }

    public Guid PublisherId
    {
      get { return base.Item.PublisherId; }
      set { AssignProperty<Guid>(x => base.Item.PublisherId = x, value); }
    }
    public override string ToString()
    {
      return PublisherId.ToString();
    }
    internal static ConsumerAssociationConfigurationWrapper GetDefault(string associationName)
    {
      ConsumerAssociationConfiguration _newConsumerAssociation = new ConsumerAssociationConfiguration()
      {
        AssociationName = associationName,
        DataSetWriterId = 0,
        PublisherId = Guid.NewGuid()
      };
      return new ConsumerAssociationConfigurationWrapper(_newConsumerAssociation);
    }
  }

}
