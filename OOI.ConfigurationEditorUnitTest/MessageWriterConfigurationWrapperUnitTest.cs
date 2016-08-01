using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
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
      Assert.AreEqual<AssociationRole>(AssociationRole.Producer, _mw.TransportRole);
      Assert.AreSame(_channel, _mw.MessageChannelConfiguration.GetConfiguration());
      Assert.AreEqual<string>("Name", _mw.Name);
      Assert.IsNotNull(_mw.Check(new DataSetConfigurationWrapper(new DataSetConfiguration() { AssociationName = "AssociationName", DataSet = new FieldMetaData[] { } })));
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
      ProducerAssociationConfiguration _newAssociation = new ProducerAssociationConfiguration()
      {
        AssociationName = "AssociationName",
        PublisherId = Guid.NewGuid(),
        DataSetWriterId = 0,
        FieldEncoding = FieldEncodingEnum.CompressedFieldEncoding
      };
      ProducerAssociationConfigurationWrapper _newWrapper = new ProducerAssociationConfigurationWrapper(_newAssociation);
      _mw.Associate(true, _newWrapper);
      Assert.AreEqual<int>(2, _mw.AssociationConfiguration.Length);
      ProducerAssociationConfigurationWrapper _addedAssociation = _mw.AssociationConfiguration.Where(x => x.AssociationName == _newAssociation.AssociationName).FirstOrDefault();
      Assert.IsNotNull(_addedAssociation);
      Assert.AreEqual<string>(_newWrapper.AssociationName, _addedAssociation.AssociationName);
      Assert.AreEqual<int>(_newWrapper.DataSetWriterId, _addedAssociation.DataSetWriterId);
      Assert.AreEqual<Guid>(_newWrapper.PublisherId, _addedAssociation.PublisherId);
      Assert.AreSame(_newAssociation, _addedAssociation.Item);
      //Assert.AreSame(_newWrapper, _addedAssociation); TODO check why the returned wrapper is not the same.
    }
    [TestMethod]
    public void CreateDefaultTest()
    {
      MessageWriterConfigurationWrapper _default = MessageWriterConfigurationWrapper.CreateDefault();
      Assert.IsNotNull(_default);
      Assert.IsNotNull(_default.AssociationConfiguration);
      Assert.AreEqual<AssociationRole>(AssociationRole.Producer, _default.TransportRole);
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
