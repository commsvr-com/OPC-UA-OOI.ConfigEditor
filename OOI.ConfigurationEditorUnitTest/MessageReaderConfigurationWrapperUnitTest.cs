
using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class MessageReaderConfigurationWrapperUnitTest
  {

    [TestMethod]
    public void AfterCreationStateTestMethod()
    {
      MessageChannelConfiguration _channel = new MessageChannelConfiguration() { };
      MessageReaderConfiguration _configuration = new MessageReaderConfiguration()
      {
        Configuration = _channel,
        Name = "Name",
        ConsumerAssociationConfigurations = new ConsumerAssociationConfiguration[]
           { new ConsumerAssociationConfiguration() { AssociationName = "AssociationName", DataSetWriterId = 0,  PublisherId = Guid.NewGuid() } },
        TransportRole = AssociationRole.Consumer
      };
      MessageReaderConfigurationWrapper _mw = new MessageReaderConfigurationWrapper(_configuration);
      Assert.IsNotNull(_mw.AssociationConfiguration);
      Assert.AreEqual<int>(1, _mw.AssociationConfiguration.Length);
      Assert.AreEqual<AssociationRole>(AssociationRole.Consumer, _mw.TransportRole);
      Assert.AreSame(_channel, _mw.MessageChannelConfiguration.GetConfiguration());
      Assert.AreEqual<string>("Name", _mw.Name);
      Assert.IsNotNull(_mw.Check(new DataSetConfigurationWrapper(new DataSetConfiguration() { AssociationName = "AssociationName", DataSet = new FieldMetaData[] { } })));
    }
    [TestMethod]
    public void AssociateTestMethod()
    {
      MessageChannelConfiguration _channel = new MessageChannelConfiguration() { };
      MessageReaderConfiguration _configuration = new MessageReaderConfiguration()
      {
        Configuration = null,
        Name = "Name",
        ConsumerAssociationConfigurations = new ConsumerAssociationConfiguration[]
           { new ConsumerAssociationConfiguration() { AssociationName = "OldAssociationName", DataSetWriterId = 0, PublisherId = Guid.NewGuid() } },
        TransportRole = AssociationRole.Producer
      };
      MessageReaderConfigurationWrapper _mw = new MessageReaderConfigurationWrapper(_configuration);
      _mw.Associate(true, new ConsumerAssociationConfigurationWrapper( new ConsumerAssociationConfiguration()
        {
          AssociationName = "AssociationName",
          PublisherId = Guid.NewGuid(),
          DataSetWriterId = 0,
         }));
      Assert.AreEqual<int>(2, _mw.AssociationConfiguration.Length);
    }
    [TestMethod]
    public void CreateDefaultTest()
    {
      MessageReaderConfigurationWrapper _default = MessageReaderConfigurationWrapper.CreateDefault();
      Assert.IsNotNull(_default);
      Assert.IsNotNull(_default.AssociationConfiguration);
      Assert.AreEqual<AssociationRole>(AssociationRole.Consumer, _default.TransportRole);
      Assert.IsNotNull(_default.Item);
      Assert.IsNotNull(_default.MessageChannelConfiguration);
      Assert.IsFalse(string.IsNullOrEmpty(_default.Name));
    }
    [TestMethod]
    public void MessageChannelConfigurationCreatesNewInstanceTest()
    {
      MessageReaderConfigurationWrapper _default = MessageReaderConfigurationWrapper.CreateDefault();
      Assert.IsNotNull(_default.MessageChannelConfiguration);
      MessageChannelConfigurationWrapper _newConfig = new MessageChannelConfigurationWrapper(new MessageChannelConfiguration() { });
      _default.MessageChannelConfiguration = _newConfig;
      Assert.AreNotSame(_newConfig, _default.MessageChannelConfiguration);
    }
    private class AssociationConfigurationWrapper : IAssociationConfigurationWrapper
    {
      public string AssociationName
      {
        get; set;
      }
      public ushort DataSetWriterId
      {
        get; set;
      }
      public Guid PublisherId
      {
        get; set;
      }
    }

  }
}
