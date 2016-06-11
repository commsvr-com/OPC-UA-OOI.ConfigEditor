//_______________________________________________________________
//  Title   : ProducerAssociationConfigurationWrapper
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

  internal class ProducerAssociationConfigurationWrapper : AssociationConfigurationWrapper<ProducerAssociationConfiguration>
  {

    public ProducerAssociationConfigurationWrapper(ProducerAssociationConfiguration configuration) : base(configuration) { }
    public FieldEncodingEnum FieldEncoding
    {

      get { return base.Item.FieldEncoding; }
      set { SetProperty<FieldEncodingEnum>(x => Item.FieldEncoding = x, value); }

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
