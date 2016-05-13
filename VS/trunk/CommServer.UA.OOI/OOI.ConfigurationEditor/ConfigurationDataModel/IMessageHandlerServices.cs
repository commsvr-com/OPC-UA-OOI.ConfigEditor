//_______________________________________________________________
//  Title   : Name of Application
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate:  $
//  $Rev: $
//  $LastChangedBy: $
//  $URL: $
//  $Id:  $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using System.Collections.Generic;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.ConfigurationDataModel
{

  internal interface IMessageHandlerServices
  {
    MessageHandlerConfigurationCollection GetMessageHandlers();
    IEnumerable<IMessageHandlerConfigurationWrapper> GetMessageHandlers(AssociationRole associationRole);
    void AddMessageHandler(IMessageHandlerConfigurationWrapper wrapper);
    bool Exist(string title);
    void Remove(string title);
    void Remove(IMessageHandlerConfigurationWrapper wrapper);
  }

}
