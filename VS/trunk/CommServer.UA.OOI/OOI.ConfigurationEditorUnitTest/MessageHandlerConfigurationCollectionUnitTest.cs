
using CAS.CommServer.UAOOI.ConfigurationEditor.ConfigurationDataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using Serialization = global::UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class MessageHandlerConfigurationCollectionUnitTest
  {

    [TestMethod]
    [ExpectedException(typeof(KeyNotFoundException))]
    public void AfterConstructionStateTest()
    {
      ConfigurationDataRepository _newRepository = new ConfigurationDataRepository();
      MessageHandlerConfigurationCollection _newInstance = new MessageHandlerConfigurationCollection(_newRepository);
      Assert.AreEqual<int>(0, _newInstance.Count);
      Assert.IsFalse(_newInstance.Exists("Not existing Item"));
      _newInstance.Remove("Not existing Item");
    }
    [TestMethod]
    public void ExistsMethod()
    {
      MessageHandlerConfigurationCollection _newCollection = CreateTestCollection();
      Assert.AreEqual<int>(2, _newCollection.Count);
      _newCollection.Exists(_MessageReaderName);
      _newCollection.Exists(_MessageWriterName);
    }

    #region private test instrumentation
    private static readonly string _MessageReaderName = "Message Reader Configuration";
    private static readonly string _MessageWriterName = "Message Writer Configuration";
    private static readonly Serialization.MessageReaderConfiguration _ReaderConfig = new Serialization.MessageReaderConfiguration
    {
      Configuration = new Serialization.MessageChannelConfiguration() { },
      Name = _MessageReaderName,
      ConsumerAssociationConfigurations = new Serialization.ConsumerAssociationConfiguration[]
        { new Serialization.ConsumerAssociationConfiguration() { AssociationName = "AssociationName", DataSetWriterId = 0, PublisherId = Guid.NewGuid() } },
      TransportRole = Serialization.AssociationRole.Consumer
    };
    private static readonly Serialization.MessageWriterConfiguration _WriterConfig = new Serialization.MessageWriterConfiguration
    {
      Configuration = new Serialization.MessageChannelConfiguration() { },
      Name = _MessageWriterName,
       ProducerAssociationConfigurations = new Serialization.ProducerAssociationConfiguration[]
        { new Serialization.ProducerAssociationConfiguration() { AssociationName = "AssociationName", DataSetWriterId = 0,  FieldEncoding = Serialization.FieldEncodingEnum.CompressedFieldEncoding } },
      TransportRole = Serialization.AssociationRole.Consumer
    };
    private MessageHandlerConfigurationCollection CreateTestCollection()
    {
      ConfigurationDataRepository.SetConfigurationData = new Serialization.ConfigurationData()
      {
        DataSets = new Serialization.DataSetConfiguration[] { },
        MessageHandlers = new Serialization.MessageHandlerConfiguration[] { _ReaderConfig, _WriterConfig }
      };
      ConfigurationDataRepository _newConfigurationDataRepository = new ConfigurationDataRepository();
      MessageHandlerConfigurationCollection _newInstance = new MessageHandlerConfigurationCollection(_newConfigurationDataRepository);
      return _newInstance;
    }
    #endregion

  }
}
