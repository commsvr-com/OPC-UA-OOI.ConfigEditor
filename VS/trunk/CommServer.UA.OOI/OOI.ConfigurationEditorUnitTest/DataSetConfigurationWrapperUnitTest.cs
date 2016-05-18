using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UAOOISerialization = UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class DataSetConfigurationWrapperUnitTest
  {
    [TestMethod]
    public void CreatorTestMethod1()
    {
      global::UAOOI.Configuration.Networking.Serialization.DataSetConfiguration _dsc = new global::UAOOI.Configuration.Networking.Serialization.DataSetConfiguration();
      DataSetConfigurationWrapper _newWrapper = new DataSetConfigurationWrapper(_dsc);
      Assert.AreSame(_dsc, _newWrapper.Item);
      _newWrapper.AssociationName = m_TestString;
      Assert.AreEqual<string>(m_TestString, _newWrapper.AssociationName);
      Assert.AreEqual<string>(m_TestString, _newWrapper.Item.AssociationName);
      _newWrapper.ConfigurationGuid = m_TestGuid;
      Assert.AreEqual<Guid>(m_TestGuid, _newWrapper.ConfigurationGuid);
      Assert.AreEqual<Guid>(m_TestGuid, _newWrapper.Item.ConfigurationGuid);
      _newWrapper.ConfigurationVersion = m_TestVersionWrapper;
      Assert.AreNotSame(m_TestVersionWrapper, _newWrapper.ConfigurationVersion);
      Assert.AreEqual<byte>(byte.MaxValue, _newWrapper.ConfigurationVersion.MajorVersion);
      Assert.AreEqual<byte>(byte.MaxValue, _newWrapper.ConfigurationVersion.MinorVersion);
    }
    [TestMethod]
    public void ConfigurationVersionTestMethod1()
    {
      UAOOISerialization.ConfigurationVersionDataType m_TestVersion = new UAOOISerialization.ConfigurationVersionDataType { MajorVersion = byte.MaxValue, MinorVersion = byte.MaxValue };
      global::UAOOI.Configuration.Networking.Serialization.DataSetConfiguration _dsc = new UAOOISerialization.DataSetConfiguration() { ConfigurationVersion = m_TestVersion };
      DataSetConfigurationWrapper _newWrapper = new DataSetConfigurationWrapper(_dsc);
      Assert.AreSame(m_TestVersion, _newWrapper.Item.ConfigurationVersion);
      _newWrapper.ConfigurationVersion = m_TestVersionWrapper;
      Assert.AreNotSame(m_TestVersion, _newWrapper.Item.ConfigurationVersion);
    }
    [TestMethod]
    public void CreateDefaultTestMethod()
    {
      DataSetConfigurationWrapper _value1 = DataSetConfigurationWrapper.CreateDefault();
      DataSetConfigurationWrapper _value2 = DataSetConfigurationWrapper.CreateDefault();
      Assert.AreNotEqual<string>(_value1.AssociationName, _value2.AssociationName);
      Assert.IsTrue(_value1.AssociationName.Contains("AssociationName"));
      Assert.AreNotEqual<string>(_value1.SymbolicName, _value2.SymbolicName);
      Assert.IsTrue(_value1.SymbolicName.Contains("SymbolicName"));
      Assert.AreNotEqual<Guid>(_value1.ConfigurationGuid, _value2.ConfigurationGuid);
    }
    //
    private readonly string m_TestString = "o@kSDxgH|f4k0s";
    private readonly Guid m_TestGuid = Guid.NewGuid();
    private readonly ConfigurationVersionDataTypeWrapper m_TestVersionWrapper = new ConfigurationVersionDataTypeWrapper
      (new UAOOISerialization.ConfigurationVersionDataType() { MajorVersion = byte.MaxValue, MinorVersion = byte.MaxValue });
  }
}
