using Microsoft.VisualStudio.TestTools.UnitTesting;
using CAS.CommServer.UA.OOI.ConfigurationEditor.mvvm;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class BindableUnitTest
  {
    [TestMethod]
    public void ConditionalEventRaiseTest()
    {
      TestClass _bindableClass = new TestClass();
      int _count = 0;
      _bindableClass.PropertyChanged += (x, y) => { _count++; Assert.AreEqual<string>("SymbolicName", y.PropertyName); };
      _bindableClass.SymbolicName = "Value";
      Assert.AreEqual<int>(1, _count);
      _bindableClass.SymbolicName = "Value";
      Assert.AreEqual<int>(1, _count);
      _bindableClass.SymbolicName = "NewValue";
      Assert.AreEqual<int>(2, _count);
    }
    public void UnconditionalEventRaiseTest()
    {
      TestClass _bindableClass = new TestClass();
      int _count = 0;
      _bindableClass.PropertyChanged += (x, y) => { _count++; Assert.AreEqual<string>("SymbolicName", y.PropertyName); };
      _bindableClass.SymbolicName2 = "Value";
      Assert.AreEqual<int>(1, _count);
      _bindableClass.SymbolicName2 = "Value";
      Assert.AreEqual<int>(2, _count);
      _bindableClass.SymbolicName2 = "NewValue";
      Assert.AreEqual<int>(3, _count);
    }
    private class TestClass : Bindable
    {
      private string m_ConfigurationItem;

      public string SymbolicName
      {
        get { return m_ConfigurationItem; }
        set { base.AssignProperty<string>(m_ConfigurationItem, x => m_ConfigurationItem = x, value); }
      }
      public string SymbolicName2
      {
        get { return m_ConfigurationItem; }
        set { base.AssignProperty<string>( x => m_ConfigurationItem = x, value); }
      }

    }
  }
}
