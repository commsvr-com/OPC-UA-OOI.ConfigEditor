using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CAS.CommServer.UA.OOI.ConfigurationEditor.MessageHandlerEditor;
using CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel;
using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using UAOOI.Configuration.Networking.Serialization;
using System.Linq;

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
      Assert.AreEqual<AssociationRole>(AssociationRole.Consumer, _confirmation.AssociationRole);
      Assert.IsTrue(_confirmation.AssociationRoleEditable);
      Assert.IsTrue(_confirmation.Confirmed);
      Assert.IsNull(_confirmation.Content);
      Assert.IsNotNull(_confirmation.MessageHandlerConfigurationWrapper);
      Assert.AreEqual<string>("Title", _confirmation.Title);
    }
    [TestMethod]
    public void TitleRaisesPropertyChangedTest()
    {
      bool _raised = false;
      MessageHandlerConfirmation _confirmation = new MessageHandlerConfirmation(null, wrapper => new AssociationCouplerViewModel[] { }, false)
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
      Assert.AreEqual<AssociationRole>(AssociationRole.Consumer, _confirmation.AssociationRole);
      Assert.IsInstanceOfType(_confirmation.MessageHandlerConfigurationWrapper, typeof(MessageReaderConfigurationWrapper));
      _confirmation.AssociationRole = AssociationRole.Consumer;
      Assert.AreEqual<int>(0, _raised); //the same value assigned to AssociationRole must not raise the event
      Assert.AreEqual<int>(1, _enumeratorCalled);
      Assert.AreEqual<AssociationRole>(AssociationRole.Consumer, _confirmation.AssociationRole);
      Assert.IsInstanceOfType(_confirmation.MessageHandlerConfigurationWrapper, typeof(MessageReaderConfigurationWrapper));
      _confirmation.AssociationRole = AssociationRole.Producer;
      Assert.AreEqual<int>(2, _raised); //new value of AssociationRole must raise the event
      Assert.AreEqual<int>(2, _enumeratorCalled);
      Assert.AreEqual<AssociationRole>(AssociationRole.Producer, _confirmation.AssociationRole);
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
      _confirmation.Revert();
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
      _confirmation.Revert();
    }

  }
}
