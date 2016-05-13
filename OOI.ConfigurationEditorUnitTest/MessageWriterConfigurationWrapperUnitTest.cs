using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest
{

  [TestClass]
  public class MessageWriterConfigurationWrapperUnitTest
  {

    [TestMethod]
    public void AfterCreationStateTestMethod()
    {
      MessageChannelConfiguration _channel = new MessageChannelConfiguration() { };
      MessageWriterConfiguration _configuration = new MessageWriterConfiguration()
      {
        Configuration = _channel,
        Name = "Name",
        ProducerAssociationConfigurations = new ProducerAssociationConfiguration[]
           { new ProducerAssociationConfiguration() { AssociationName = "AssociationName", DataSetWriterId = 0, FieldEncoding = FieldEncodingEnum.CompressedFieldEncoding } },
        TransportRole = AssociationRole.Producer
      };
      MessageWriterConfigurationWrapper _mw = new MessageWriterConfigurationWrapper(_configuration);
      Assert.IsNotNull(_mw.AssociationConfiguration);
      Assert.AreEqual<int>(1, _mw.AssociationConfiguration.Length);
      Assert.AreEqual<AssociationRole>(AssociationRole.Producer, _mw.AssociationRole);
      Assert.AreSame(_channel, _mw.MessageChannelConfiguration.GetConfiguration());
      Assert.AreEqual<string>("Name", _mw.Name);
      Assert.IsTrue(_mw.Check(new DataSetConfigurationWrapper(new DataSetConfiguration() { AssociationName = "AssociationName" })));
    }
    [TestMethod]
    public void AssociateTestMethod()
    {
      MessageChannelConfiguration _channel = new MessageChannelConfiguration() { };
      MessageWriterConfiguration _configuration = new MessageWriterConfiguration()
      {
        Configuration = _channel,
        Name = "Name",
        ProducerAssociationConfigurations = new ProducerAssociationConfiguration[]
           { new ProducerAssociationConfiguration() { AssociationName = "OldAssociationName", DataSetWriterId = 0, FieldEncoding = FieldEncodingEnum.CompressedFieldEncoding } },
        TransportRole = AssociationRole.Producer
      };
      MessageWriterConfigurationWrapper _mw = new MessageWriterConfigurationWrapper(_configuration);
      _mw.Associate(true, new DataSetConfigurationWrapper(new DataSetConfiguration() { AssociationName = "AssociationName" }));
      Assert.AreEqual<int>(2, _mw.AssociationConfiguration.Length);
    }
    [TestMethod]
    public void CreateDefaultTest()
    {
      MessageWriterConfigurationWrapper _default = MessageWriterConfigurationWrapper.CreateDefault();
      Assert.IsNotNull(_default);
      Assert.IsNotNull(_default.AssociationConfiguration);
      Assert.AreEqual<AssociationRole>(AssociationRole.Producer, _default.AssociationRole);
      Assert.IsNotNull(_default.Item);
      Assert.IsNotNull(_default.MessageChannelConfiguration);
      Assert.IsFalse(string.IsNullOrEmpty(_default.Name));
    }
    [TestMethod]
    public void MessageChannelConfigurationCreatesNewInstanceTest()
    {
      MessageWriterConfigurationWrapper _default = MessageWriterConfigurationWrapper.CreateDefault();
      Assert.IsNotNull(_default.MessageChannelConfiguration);
      MessageChannelConfigurationWrapper _newConfig = new MessageChannelConfigurationWrapper(new MessageChannelConfiguration() { });
      _default.MessageChannelConfiguration = _newConfig;
      Assert.AreNotSame(_newConfig, _default.MessageChannelConfiguration);
    }

  }
}
