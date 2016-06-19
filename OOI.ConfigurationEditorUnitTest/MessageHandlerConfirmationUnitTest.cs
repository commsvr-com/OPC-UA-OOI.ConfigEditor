
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CAS.CommServer.UA.OOI.ConfigurationEditor.MessageHandlerEditor;
using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using UAOOI.Configuration.Networking.Serialization;
using System.Linq;
using CAS.CommServer.UA.OOI.ConfigurationEditor.Services;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class MessageHandlerConfirmationUnitTest
  {
    [TestMethod]
    public void CreationStateTest()
    {
      MessageReaderConfigurationWrapper _reader = MessageReaderConfigurationWrapper.CreateDefault();
      MessageHandlerConfirmation _confirmation = new MessageHandlerConfirmation(_reader, wrapper => new AssociationCouplerViewModel[] { }, true)
      {
        Confirmed = true,
        Content = null,
        Title = "Title"
      };
      Assert.IsNotNull(_confirmation.AssociationCouplersEnumerator);
      Assert.AreEqual<int>(0, _confirmation.AssociationCouplersEnumerator.Count<AssociationCouplerViewModel>());
      Assert.IsTrue(_confirmation.AssociationRoleSelectorControlViewModel.ConsumerRoleSelected.GetValueOrDefault(false));
      Assert.IsFalse(_confirmation.AssociationRoleSelectorControlViewModel.ProducerRoleSelected.GetValueOrDefault(false));
      Assert.IsTrue(_confirmation.AssociationRoleSelectorControlViewModel.AssociationRoleGroupBoxIsEnabled);
      Assert.IsTrue(_confirmation.Confirmed);
      Assert.IsNull(_confirmation.Content);
      Assert.IsNotNull(_confirmation.MessageHandlerConfigurationWrapper);
      Assert.AreEqual<string>("Title", _confirmation.Title);
    }
    [TestMethod]
    public void TitleRaisesPropertyChangedTest()
    {
      bool _raised = false;
      MessageHandlerConfirmation _confirmation = new MessageHandlerConfirmation(wrapper => new AssociationCouplerViewModel[] { })
      {
        Confirmed = true,
        Content = null,
        MessageHandlerConfigurationWrapper = null,
        Title = "Title"
      };
      _confirmation.PropertyChanged += (x, y) => { Assert.AreEqual<string>("Title", y.PropertyName); _raised = true; };
      _confirmation.Title = "New title";
      Assert.IsTrue(_raised);
    }
    [TestMethod]
    public void AssociationRoleMustChangeMessageHandlerConfigurationWrapperTest()
    {
      MessageReaderConfigurationWrapper _reader = MessageReaderConfigurationWrapper.CreateDefault();
      int _enumeratorCalled = 0;
      MessageHandlerConfirmation _confirmation = new MessageHandlerConfirmation(_reader, wrapper => { _enumeratorCalled++;  return new AssociationCouplerViewModel[] { };  }, true) { };
      int _raised = 0;
      _confirmation.PropertyChanged += (x, y) => _raised++;
      Assert.IsNotNull(_confirmation.MessageHandlerConfigurationWrapper);
      Assert.AreEqual<AssociationRole>(AssociationRole.Consumer, _confirmation.MessageHandlerConfigurationWrapper.TransportRole);
      Assert.IsInstanceOfType(_confirmation.MessageHandlerConfigurationWrapper, typeof(MessageReaderConfigurationWrapper));
      _confirmation.AssociationRoleSelectorControlViewModel.ConsumerRoleSelected = true;
      _confirmation.AssociationRoleSelectorControlViewModel.ProducerRoleSelected = false;
      Assert.AreEqual<int>(0, _raised); //the same value assigned to AssociationRole must not raise the event
      Assert.AreEqual<int>(1, _enumeratorCalled);
      Assert.AreEqual<AssociationRole>(AssociationRole.Consumer, _confirmation.MessageHandlerConfigurationWrapper.TransportRole);
      Assert.IsInstanceOfType(_confirmation.MessageHandlerConfigurationWrapper, typeof(MessageReaderConfigurationWrapper));
      _confirmation.AssociationRoleSelectorControlViewModel.ConsumerRoleSelected = false;
      _confirmation.AssociationRoleSelectorControlViewModel.ProducerRoleSelected = true;
      Assert.AreEqual<int>(2, _raised); //new value of AssociationRole must raise the event
      Assert.AreEqual<int>(2, _enumeratorCalled);
      Assert.AreEqual<AssociationRole>(AssociationRole.Producer, _confirmation.MessageHandlerConfigurationWrapper.TransportRole);
      Assert.IsInstanceOfType(_confirmation.MessageHandlerConfigurationWrapper, typeof(MessageWriterConfigurationWrapper));
    }
    [TestMethod]
    public void RevertTestMethod()
    {
      MessageReaderConfigurationWrapper _reader = MessageReaderConfigurationWrapper.CreateDefault();
      int _enumeratorCalled = 0;
      int _raised = 0;
      MessageHandlerConfirmation _confirmation = new MessageHandlerConfirmation(_reader, wrapper => { _enumeratorCalled++; return new AssociationCouplerViewModel[] { }; }, true) { };
      Assert.AreEqual<int>(0, _raised); 
      Assert.AreEqual<int>(1, _enumeratorCalled);
      _confirmation.ApplyChanges();
    }
    [TestMethod]
    public void RevertTestAssociationCouplersEnumeratorIsNullMethod()
    {
      MessageReaderConfigurationWrapper _reader = MessageReaderConfigurationWrapper.CreateDefault();
      int _enumeratorCalled = 0;
      int _raised = 0;
      MessageHandlerConfirmation _confirmation = new MessageHandlerConfirmation(_reader, wrapper => { _enumeratorCalled++; return null; }, true) { };
      Assert.AreEqual<int>(0, _raised);
      Assert.AreEqual<int>(1, _enumeratorCalled);
      _confirmation.ApplyChanges();
    }

  }
}
