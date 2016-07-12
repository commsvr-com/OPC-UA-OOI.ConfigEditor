using System;
using System.Collections.ObjectModel;
using CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class DomainModelWrapperUnitTest
  {
    [TestMethod]
    public void CreatorTestMethod()
    {
      DomainModelWrapper _newWrapper = new DomainModelWrapper(TestData.ReferenceDomainModel.GerReferenceDomainModel());
      Assert.IsFalse(String.IsNullOrEmpty(_newWrapper.AliasName));
      Assert.IsFalse(String.IsNullOrEmpty(_newWrapper.Description));
      Assert.IsNotNull(_newWrapper.SemanticsDataCollection);
      Assert.AreEqual<int>(1, _newWrapper.SemanticsDataCollection.Count);
      Assert.IsFalse(String.IsNullOrEmpty(_newWrapper.UniversalAddressSpaceLocator));
      Assert.IsFalse(String.IsNullOrEmpty(_newWrapper.UniversalAuthorizationServerLocator));
      Assert.IsFalse(String.IsNullOrEmpty(_newWrapper.UniversalDiscoveryServiceLocator));
      Assert.IsNotNull(_newWrapper.URI);
      Test(_newWrapper.SemanticsDataCollection);
    }
    private void Test(ObservableCollection<SemanticsDataIndexWrapper> semanticsDataCollection)
    {
      foreach (SemanticsDataIndexWrapper _cd in semanticsDataCollection)
      {
        Assert.IsNotNull(_cd.DataSet);
        foreach (FieldMetaDataWrapper _field in _cd.DataSet)
          Test(_field);
        Assert.IsNotNull(_cd.SymbolicName);
        Assert.IsFalse(String.IsNullOrEmpty(_cd.SymbolicName));
      }
    }
    private void Test(FieldMetaDataWrapper field)
    {
      Assert.IsTrue(String.IsNullOrEmpty(field.ProcessValueName));
      Assert.IsFalse(String.IsNullOrEmpty(field.SymbolicName));
      Test(field.TypeInformation) ;
    }
    private void Test(UATypeInfoWrapper typeInformation)
    {
      Assert.AreEqual<string>("scalar",typeInformation.ArrayDimensions);
    }
  }
}
