//_______________________________________________________________
//  Title   : MessageChannelConfigurationWrapper
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

using CAS.CommServer.UAOOI.ConfigurationEditor.mvvm;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.ConfigurationDataModel
{
  public class MessageChannelConfigurationWrapper: Bindable
  {

    internal MessageChannelConfigurationWrapper(MessageChannelConfiguration configuration)
    {
      m_configuration = configuration;
    }
    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    public override string ToString()
    {
      return $"{nameof(MessageChannelConfiguration)}";
    }
    internal MessageChannelConfiguration GetConfiguration()
    {
     return m_configuration;
    }

    private MessageChannelConfiguration m_configuration;

  }
}
