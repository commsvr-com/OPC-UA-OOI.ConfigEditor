
using CAS.CommServer.UAOOI.ConfigurationEditor.ConfigurationDataModel;
using CAS.CommServer.UAOOI.ConfigurationEditor.DataSetEditor.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using CAS.CommServer.UAOOI.ConfigurationEditor.DataSetEditor;
using System.Collections;
using System.Collections.Generic;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class DataSetEditorServicesUnitTest
  {
    [TestMethod]
    [ExpectedException(typeof(ArgumentNullException))]
    public void CreationWithNullArgumentTest()
    {
      DataSetEditorServices _service = new DataSetEditorServices(null);
    }
    [TestMethod]
    public void AfterCreationTestMethod1()
    {
      DataSetEditorServices _service = new DataSetEditorServices(new DataSetModelServices());
      Assert.IsNotNull(_service.AddCommand);
      Assert.IsTrue(_service.AddCommand.CanExecute(null));
      Assert.IsNotNull(_service.RetrieveList());
    }
    private class DataSetModelServices : ConfigurationDataModel.IDataSetModelServices
    {
      public void AddDataSet(DataSetConfigurationWrapper _newDataSetItem)
      {
        throw new NotImplementedException();
      }
      public bool DataSetExists(string dataSetIdentifier)
      {
        throw new NotImplementedException();
      }
      public DataSetConfigurationWrapper GetDescription(string dataSetIdentifier)
      {
        throw new NotImplementedException();
      }
      public IDataSetConfigurationCollection GetDataSets()
      {
        return new DataSetConfigurationCollection(new ConfigurationDataRepository());
      }
      public IEnumerable<DataSetConfigurationWrapper> GetDataSets(AssociationRole associationRole)
      {
        throw new NotImplementedException();
      }
      public void Remove(string symbolicName)
      {
        throw new NotImplementedException();
      }
      public void Remove(DataSetConfigurationWrapper currentDataSetItem)
      {
        throw new NotImplementedException();
      }
    }
  }
}
