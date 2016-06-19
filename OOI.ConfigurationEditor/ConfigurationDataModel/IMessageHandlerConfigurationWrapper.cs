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

using System.Collections.Generic;
using CAS.CommServer.UA.OOI.ConfigurationEditor.Services;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  /// <summary>
  /// Interface IMessageHandlerConfigurationWrapper - defines basic functionality that must be provided by any message handler.
  /// </summary>
  public interface IMessageHandlerConfigurationWrapper
  {

    /// <summary>
    /// Gets or sets the transport role of the handler. <see cref="AssociationRole.Consumer"/> is considered ans the reader (receiver), 
    /// and <see cref="AssociationRole.Producer"/> is considered as the writer (transmitter).
    /// </summary>
    /// <value>The transport role <see cref="AssociationRole"/>.</value>
    AssociationRole TransportRole { get; set; }
    /// <summary>
    /// Gets or sets the message channel (protocols stack) configuration.
    /// </summary>
    /// <value>The message channel configuration <see cref="MessageChannelConfigurationWrapper"/>.</value>
    MessageChannelConfigurationWrapper MessageChannelConfiguration { get; set; }
    /// <summary>
    /// Gets or sets the name of the messages handler.
    /// </summary>
    /// <value>The name.</value>
    string Name { get; set; }
    /// <summary>
    /// Checks if the selected <paramref name="dataSet" /> is associated (handled) by this instance and returns 
    /// description of this association as an instance of <see cref="IAssociationConfigurationWrapper"/>.
    /// </summary>
    /// <param name="dataSet">The dataset to be checked against association.</param>
    /// <returns>If associated returns an instance of <see cref="IAssociationConfigurationWrapper"/>.</returns>
    IAssociationConfigurationWrapper Check(DataSetConfigurationWrapper dataSet);
    /// <summary>
    /// Creates or removes association described by the parameter <paramref name="association"/>.
    /// </summary>
    /// <param name="associate">if set to <c>true</c> the <paramref name="association" /> shall be added to the collection of associations.</param>
    /// <param name="association">The association instance of type <see cref="IAssociationConfigurationWrapper"/> to be added to the local collection.</param>
    void Associate(bool associate, IAssociationConfigurationWrapper association);
    IAssociationConfigurationWrapper[] GetAssociations();
  }
}