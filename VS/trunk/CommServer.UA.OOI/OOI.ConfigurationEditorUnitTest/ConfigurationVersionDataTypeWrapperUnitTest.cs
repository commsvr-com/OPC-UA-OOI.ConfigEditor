
using Microsoft.VisualStudio.TestTools.UnitTesting;
using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class ConfigurationVersionDataTypeWrapperUnitTest
  {
    [TestMethod]
    public void MajorVersionTest()
    {
      ConfigurationVersionDataTypeWrapper _newWrapper = new ConfigurationVersionDataTypeWrapper(null);
      int count = 0;
      _newWrapper.PropertyChanged += (x, y) => count++;
      _newWrapper.MajorVersion = 0;
      Assert.AreEqual<int>(0, _newWrapper.MajorVersion);
      Assert.AreEqual<int>(0, count);
      _newWrapper.MajorVersion = byte.MaxValue;
      Assert.AreEqual<int>(byte.MaxValue, _newWrapper.MajorVersion);
      Assert.AreEqual<string>($"{byte.MaxValue}.0", _newWrapper.Version2Display);
      Assert.AreEqual<int>(2, count);
    }
    [TestMethod]
    public void MinorVersionTest()
    {
      ConfigurationVersionDataTypeWrapper _newWrapper = new ConfigurationVersionDataTypeWrapper(null);
      int count = 0;
      _newWrapper.PropertyChanged += (x, y) => count++;
      _newWrapper.MinorVersion = 0;
      Assert.AreEqual<int>(0, _newWrapper.MinorVersion);
      Assert.AreEqual<int>(0, count);
      _newWrapper.MinorVersion = byte.MaxValue;
      Assert.AreEqual<int>(byte.MaxValue, _newWrapper.MinorVersion);
      Assert.AreEqual<string>($"0.{byte.MaxValue}", _newWrapper.Version2Display);
      Assert.AreEqual<int>(2, count);
    }
    [TestMethod]
    public void AssignTest()
    {
      ConfigurationVersionDataTypeWrapper _newWrapper =
        new ConfigurationVersionDataTypeWrapper(new global::UAOOI.Configuration.Networking.Serialization.ConfigurationVersionDataType() { MajorVersion = byte.MaxValue, MinorVersion = byte.MaxValue });
      Assert.AreEqual<int>(byte.MaxValue, _newWrapper.MinorVersion);
      Assert.AreEqual<int>(byte.MaxValue, _newWrapper.MajorVersion);
    }
    [TestMethod]
    public void NewInstanceTest()
    {
      ConfigurationVersionDataTypeWrapper _newWrapper = ConfigurationVersionDataTypeWrapper.CreateDefault();
      Assert.IsNotNull(_newWrapper);
      Assert.AreEqual<int>(0, _newWrapper.MinorVersion);
      Assert.AreEqual<int>(0, _newWrapper.MajorVersion);
    }
    [TestMethod]
    public void ToStringTest()
    {
      ConfigurationVersionDataTypeWrapper _newWrapper = ConfigurationVersionDataTypeWrapper.CreateDefault();
      Assert.AreEqual<string>("0.0", _newWrapper.ToString());
    }

  }
}
