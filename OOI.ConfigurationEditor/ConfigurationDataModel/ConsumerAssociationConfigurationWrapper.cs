
using System;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  public class ConsumerAssociationConfigurationWrapper : AssociationConfigurationWrapper<ConsumerAssociationConfiguration>
  {

    public ConsumerAssociationConfigurationWrapper(ConsumerAssociationConfiguration configuration) : base(configuration) { }

    public Guid PublisherId
    {
      get { return base.Item.PublisherId; }
      set { SetProperty<Guid>(x => base.Item.PublisherId = x, value); }
    }
    public override string ToString()
    {
      return PublisherId.ToString();
    }
    internal static ConsumerAssociationConfigurationWrapper GetDefault(DataSetConfigurationWrapper dataSet)
    {
      ConsumerAssociationConfiguration _newConsumerAssociation = new ConsumerAssociationConfiguration()
      {
        AssociationName = dataSet.AssociationName,
        DataSetWriterId = dataSet.DefaultDataSetWriterId,
        PublisherId = dataSet.Id,
      };
      return new ConsumerAssociationConfigurationWrapper(_newConsumerAssociation);
    }
  }

}
