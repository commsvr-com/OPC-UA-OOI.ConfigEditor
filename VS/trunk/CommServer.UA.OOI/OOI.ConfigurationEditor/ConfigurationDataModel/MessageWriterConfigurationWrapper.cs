//_______________________________________________________________
//  Title   : MessageWriterConfigurationWrapper
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
using System.Linq;
using System.Collections.Generic;
using System;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  /// <summary>
  /// Class MessageWriterConfigurationWrapper - intermediate storage for an instance of the <see cref="MessageWriterConfiguration"/>
  /// </summary>
  /// <seealso cref="MessageHandlerConfigurationWrapper{MessageWriterConfiguration}" />
  internal class MessageWriterConfigurationWrapper : MessageHandlerConfigurationWrapper<MessageWriterConfiguration>
  {

    #region Creator
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageWriterConfigurationWrapper"/> class.
    /// </summary>
    /// <param name="configurationItem">The configuration item.</param>
    internal MessageWriterConfigurationWrapper(MessageWriterConfiguration configurationItem) : base(configurationItem) { }
    #endregion

    #region API
    /// <summary>
    /// Gets or sets the associations with the message handlers.
    /// </summary>
    /// <value>The array of associations established with the message handlers.</value>
    public ProducerAssociationConfigurationWrapper[] AssociationConfiguration
    {
      get
      {
        return Item.ProducerAssociationConfigurations.Select<ProducerAssociationConfiguration, ProducerAssociationConfigurationWrapper>(x => new ProducerAssociationConfigurationWrapper(x)).
                                                      ToArray<ProducerAssociationConfigurationWrapper>();
      }
      set
      {
        SetProperty<ProducerAssociationConfiguration[]>
          (
             x => base.Item.ProducerAssociationConfigurations = x,
             value.Select<IWrapper<ProducerAssociationConfiguration>, ProducerAssociationConfiguration>(y => y.Item).
                   ToArray<ProducerAssociationConfiguration>()
          );
      }
    }
    /// <summary>
    /// Creates the default instance of <see cref="MessageWriterConfigurationWrapper"/>.
    /// </summary>
    /// <returns>MessageWriterConfigurationWrapper.</returns>
    internal static MessageWriterConfigurationWrapper CreateDefault()
    {
      MessageWriterConfiguration _ReaderConfig = new MessageWriterConfiguration
      {
        Configuration = null,
        Name = "Message Writer",
        ProducerAssociationConfigurations = new ProducerAssociationConfiguration[] { },
        TransportRole = AssociationRole.Producer
      };
      return new MessageWriterConfigurationWrapper(_ReaderConfig);
    }
    #endregion

    #region MessageHandlerConfigurationWrapper<MessageReaderConfiguration>
    /// <summary>
    /// Creates or removes association with the specified <paramref name="dataset" />.
    /// </summary>
    /// <param name="associate">if set to <c>true</c> the <paramref name="dataset" /> shall be associated.</param>
    /// <param name="dataset">The dataset to be associated.</param>
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
        AssociationConfiguration = AssociationConfiguration.Where<ProducerAssociationConfigurationWrapper>(x => x.AssociationName != dataset.AssociationName).
                                   ToArray<ProducerAssociationConfigurationWrapper>();
    }
    /// <summary>
    /// Checks if the selected <paramref name="dataSet" /> is associated (handled) by this instance.
    /// </summary>
    /// <param name="dataSet">The dataset.</param>
    /// <returns><c>true</c> if the selected <paramref name="dataSet" /> is in collection handled by this instance, <c>false</c> otherwise.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public override bool Check(DataSetConfigurationWrapper dataSet)
    {
      return AssociationConfiguration.Where<ProducerAssociationConfigurationWrapper>(x => x.AssociationName == dataSet.AssociationName).Any<ProducerAssociationConfigurationWrapper>();
    }
    #endregion

  }
}