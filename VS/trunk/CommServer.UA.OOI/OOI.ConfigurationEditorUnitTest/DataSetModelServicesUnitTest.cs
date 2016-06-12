//_______________________________________________________________
//  Title   : DataSetModelServicesUnitTest
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate$
//  $Rev$
//  $LastChangedBy$
//  $URL$
//  $Id$
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using CAS.CommServer.UA.OOI.ConfigurationEditor.Services;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism.Logging;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class DataSetModelServicesUnitTest
  {
    [TestMethod]
    public void CreationStateTest()
    {
      ConfigurationDataRepository.SetConfigurationData = new ConfigurationData() { DataSets = new DataSetConfiguration[] { }, MessageHandlers = new MessageHandlerConfiguration[] { } };
      DataSetModelServices _newDataSetModelServices = new DataSetModelServices(new DataSetConfigurationCollection(new ConfigurationDataRepository(), new LoggerFacade()));
      Assert.IsFalse(_newDataSetModelServices.DataSetExists("Dummy name"));
      IDataSetConfigurationCollection _DataSets = _newDataSetModelServices.GetDataSets();
      Assert.IsNotNull(_DataSets);
      Assert.AreEqual<int>(0, _DataSets.Count);
    }
    [TestMethod]
    [ExpectedException(typeof(System.Collections.Generic.KeyNotFoundException))]
    public void GetDescriptionForNotExistingKeyTest()
    {
      ConfigurationDataRepository.SetConfigurationData = new ConfigurationData() { DataSets = new DataSetConfiguration[] { }, MessageHandlers = new MessageHandlerConfiguration[] { } };
      DataSetModelServices _newDataSetModelServices = new DataSetModelServices(new DataSetConfigurationCollection(new ConfigurationDataRepository(), new LoggerFacade()));
      Assert.IsFalse(_newDataSetModelServices.DataSetExists("Dummy name"));
      DataSetConfigurationWrapper _config = _newDataSetModelServices.GetDescription("Dummy name");
    }
    [TestMethod]
    public void AddDataSetTest()
    {
      ConfigurationDataRepository.SetConfigurationData = new ConfigurationData() { DataSets = new DataSetConfiguration[] { }, MessageHandlers = new MessageHandlerConfiguration[] { } };
      DataSetModelServices _newDataSetModelServices = new DataSetModelServices(new DataSetConfigurationCollection(new ConfigurationDataRepository(), new LoggerFacade()));
      IDataSetConfigurationCollection _collection = _newDataSetModelServices.GetDataSets();
      Assert.AreEqual<int>(0, _collection.Count);
      _newDataSetModelServices.AddDataSet(DataSetConfigurationWrapper.CreateDefault());
      Assert.AreEqual<int>(1, _collection.Count);
    }
    private class LoggerFacade : Prism.Logging.ILoggerFacade
    {
      public int LogCounter = 0;
      public void Log(string message, Category category, Priority priority)
      {
        LogCounter++;
      }
    }
  }
}
