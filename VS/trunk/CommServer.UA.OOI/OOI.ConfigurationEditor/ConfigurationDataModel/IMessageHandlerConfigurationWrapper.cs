//_______________________________________________________________
//  Title   : IMessageHandlerConfigurationWrapper
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
  public interface IMessageHandlerConfigurationWrapper
  {

    AssociationRole AssociationRole { get; set; }
    MessageChannelConfigurationWrapper MessageChannelConfiguration { get; set; }
    string Name { get; set; }
    bool Check(DataSetConfigurationWrapper dataset);
    void Associate(bool associate, DataSetConfigurationWrapper dataset);

  }
}