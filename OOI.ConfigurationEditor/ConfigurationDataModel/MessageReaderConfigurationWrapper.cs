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
  /// <seealso cref="CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel.MessageHandlerConfigurationWrapper{UAOOI.Configuration.Networking.Serialization.MessageReaderConfiguration}" />
  public class MessageReaderConfigurationWrapper : MessageHandlerConfigurationWrapper<MessageReaderConfiguration>
  {

    public MessageReaderConfigurationWrapper(MessageReaderConfiguration configuration) : base(configuration) { }
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

    #region MessageHandlerConfigurationWrapper<MessageReaderConfiguration>
    public override void Associate(bool associate, DataSetConfigurationWrapper dataset)
    {
      if (associate)
      {
        if (Check(dataset))
          return;
        ConsumerAssociationConfigurationWrapper _wrapper = ConsumerAssociationConfigurationWrapper.GetDefault(dataset.AssociationName);
        List<ConsumerAssociationConfigurationWrapper> _associations = new List<ConsumerAssociationConfigurationWrapper>(AssociationConfiguration);
        _associations.Add(_wrapper);
        AssociationConfiguration = _associations.ToArray<ConsumerAssociationConfigurationWrapper>();
      }
      else
        AssociationConfiguration = AssociationConfiguration.Where<ConsumerAssociationConfigurationWrapper>(x => x.AssociationName != dataset.AssociationName).ToArray<ConsumerAssociationConfigurationWrapper>();
    }
    public override bool Check(DataSetConfigurationWrapper dataset)
    {
      return AssociationConfiguration.Where<ConsumerAssociationConfigurationWrapper>(x => x.AssociationName == dataset.AssociationName).Any<ConsumerAssociationConfigurationWrapper>();
    }
    #endregion
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

  }
}
