//_______________________________________________________________
//  Title   : MessageReaderConfigurationWrapper
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

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  /// <summary>
  /// Class MessageReaderConfigurationWrapper.
  /// </summary>
  /// <seealso cref="MessageHandlerConfigurationWrapper{MessageReaderConfiguration}" />
  public class MessageReaderConfigurationWrapper : MessageHandlerConfigurationWrapper<MessageReaderConfiguration>
  {

    #region constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageReaderConfigurationWrapper"/> class.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    public MessageReaderConfigurationWrapper(MessageReaderConfiguration configuration) : base(configuration) { }
    #endregion

    #region API
    /// <summary>
    /// Gets or sets the associations of this instance.
    /// </summary>
    /// <value>The associations established for this instance.</value>
    public ConsumerAssociationConfigurationWrapper[] AssociationConfiguration
    {
      get
      {
        return base.Item.ConsumerAssociationConfigurations.
        Select<ConsumerAssociationConfiguration, ConsumerAssociationConfigurationWrapper>(x => new ConsumerAssociationConfigurationWrapper(x)).
        ToArray<ConsumerAssociationConfigurationWrapper>();
      }
      set
      {
        base.SetProperty<ConsumerAssociationConfigurationWrapper[]>(x => base.Item.ConsumerAssociationConfigurations = x.
                                                                         Cast<IWrapper<ConsumerAssociationConfiguration>>().
                                                                         Select<IWrapper<ConsumerAssociationConfiguration>, ConsumerAssociationConfiguration>(y => y.Item).
                                                                         ToArray<ConsumerAssociationConfiguration>(),
                                                                         value
                                                                       );
      }
    }
    /// <summary>
    /// Creates the default instance of the <see cref="MessageReaderConfigurationWrapper"/>.
    /// </summary>
    /// <returns>MessageReaderConfigurationWrapper.</returns>
    internal static MessageReaderConfigurationWrapper CreateDefault()
    {
      MessageReaderConfiguration _ReaderConfig = new MessageReaderConfiguration
      {
        Configuration = null,
        Name = "Message Reader",
        ConsumerAssociationConfigurations = new ConsumerAssociationConfiguration[] { },
        TransportRole = AssociationRole.Consumer
      };
      return new MessageReaderConfigurationWrapper(_ReaderConfig);
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
        ConsumerAssociationConfigurationWrapper _wrapper = ConsumerAssociationConfigurationWrapper.GetDefault(dataset);
        List<ConsumerAssociationConfigurationWrapper> _associations = new List<ConsumerAssociationConfigurationWrapper>(AssociationConfiguration);
        _associations.Add(_wrapper);
        AssociationConfiguration = _associations.ToArray<ConsumerAssociationConfigurationWrapper>();
      }
      else
        AssociationConfiguration = AssociationConfiguration.Where<ConsumerAssociationConfigurationWrapper>(x => x.AssociationName != dataset.AssociationName).ToArray<ConsumerAssociationConfigurationWrapper>();
    }
    /// <summary>
    /// Checks if the selected <paramref name="dataSet" /> is associated (handled) by this instance.
    /// </summary>
    /// <param name="dataSet">The dataset.</param>
    /// <returns><c>true</c> if the selected <paramref name="dataSet" /> is in collection handled by this instance, <c>false</c> otherwise.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public override bool Check(DataSetConfigurationWrapper dataSet)
    {
      return AssociationConfiguration.Where<ConsumerAssociationConfigurationWrapper>(x => x.AssociationName == dataSet.AssociationName).Any<ConsumerAssociationConfigurationWrapper>();
    }
    #endregion

  }
}
