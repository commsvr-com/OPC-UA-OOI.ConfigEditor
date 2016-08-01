//_______________________________________________________________
//  Title   : ConsumerAssociationConfigurationWrapper
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  public class ConsumerAssociationConfigurationWrapper : AssociationConfigurationWrapper<ConsumerAssociationConfiguration>
  {

    public ConsumerAssociationConfigurationWrapper(ConsumerAssociationConfiguration configuration) : base(configuration) { }

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
