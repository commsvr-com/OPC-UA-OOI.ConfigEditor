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

using System;
using System.Collections.Generic;
using System.Linq;
using UAOOI.Configuration.Networking.Serialization;

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
    /// Creates or removes association described by the parameter <paramref name="association" />.
    /// </summary>
    /// <param name="associate">if set to <c>true</c> the <paramref name="association" /> shall be added to the collection of associations.</param>
    /// <param name="association">The association instance of type <see cref="IAssociationConfigurationWrapper" /> to be added to the local collection.</param>
    /// <exception cref="InvalidCastException"> if the <paramref name="association"/> cannot be casted on the <see cref="ConsumerAssociationConfigurationWrapper"/></exception>
    public override void Associate(bool associate, IAssociationConfigurationWrapper association)
    {
      if (association == null)
        throw new ArgumentNullException(nameof(association));
      ConsumerAssociationConfigurationWrapper _wrapper = association as ConsumerAssociationConfigurationWrapper;
      if (_wrapper == null)
        throw new InvalidCastException($"Imposible to cast {nameof(association)}");
      if (associate)
      {
        if (AssociationConfiguration.Where<ConsumerAssociationConfigurationWrapper>(x => x.AssociationName == association.AssociationName).Any<ConsumerAssociationConfigurationWrapper>())
          return;
        List<ConsumerAssociationConfigurationWrapper> _associations = new List<ConsumerAssociationConfigurationWrapper>(AssociationConfiguration);
        _associations.Add(_wrapper);
        AssociationConfiguration = _associations.ToArray<ConsumerAssociationConfigurationWrapper>();
      }
      else
        AssociationConfiguration = AssociationConfiguration.Where<ConsumerAssociationConfigurationWrapper>(x => x.AssociationName != association.AssociationName).ToArray<ConsumerAssociationConfigurationWrapper>();
    }
    /// <summary>
    /// Checks if the selected <paramref name="dataSet" /> is associated (handled) by this instance.
    /// </summary>
    /// <param name="dataSet">The dataset.</param>
    /// <returns><c>true</c> if the selected <paramref name="dataSet" /> is in collection handled by this instance, <c>false</c> otherwise.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public override IAssociationConfigurationWrapper Check(DataSetConfigurationWrapper dataSet)
    {
      return AssociationConfiguration.Where<ConsumerAssociationConfigurationWrapper>(x => x.AssociationName == dataSet.AssociationName).FirstOrDefault<ConsumerAssociationConfigurationWrapper>();
    }
    #endregion

  }
}
