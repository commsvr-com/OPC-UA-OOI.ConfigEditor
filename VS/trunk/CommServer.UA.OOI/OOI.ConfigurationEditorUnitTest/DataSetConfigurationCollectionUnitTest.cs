//_______________________________________________________________
//  Title   : DataSetConfigurationCollectionUnitTest
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
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UAOOI.Configuration.Networking.Serialization;
using Serialization = global::UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class DataSetConfigurationCollectionUnitTest
  {
    [TestMethod]
    public void AfterConstructionStateTest()
    {
      ConfigurationDataRepository _newRepository = new ConfigurationDataRepository();
      DataSetConfigurationCollection _newInstance = new DataSetConfigurationCollection(_newRepository);
      Assert.IsNotNull(_newRepository.ConfigurationData.DataSets);
      Assert.AreEqual<int>(0, _newRepository.ConfigurationData.DataSets.Length);
    }
    [TestMethod]
    public void CommitChangesTestMethod()
    {
      ConfigurationDataRepository _newRepository = new ConfigurationDataRepository();
      DataSetConfigurationCollection _newInstance = new DataSetConfigurationCollection(_newRepository);
      Assert.AreEqual<int>(0, _newRepository.ConfigurationData.DataSets.Length);
      _newInstance.CommitChanges();
      Assert.AreEqual<int>(0, _newRepository.ConfigurationData.DataSets.Length);
      DataSetConfigurationWrapper _default = DataSetConfigurationWrapper.CreateDefault();
      _newInstance.Add(_default);
      Assert.AreEqual<int>(0, _newRepository.ConfigurationData.DataSets.Length);
      _newInstance.CommitChanges();
      Assert.AreEqual<int>(1, _newRepository.ConfigurationData.DataSets.Length);
      _newInstance = new DataSetConfigurationCollection(new ConfigurationDataRepository());
      DataSetConfigurationWrapper _recoveredDefault = _newInstance[_default.SymbolicName];
      Assert.AreNotSame(_default, _recoveredDefault);
      Assert.AreEqual<Guid>(_default.ConfigurationGuid, _recoveredDefault.ConfigurationGuid);
    }
    [TestMethod]
    public void IndexerTestMethod()
    {
      DataSetConfigurationCollection _newInstance = CreateTestCollection();
      DataSetConfigurationWrapper _originalItem = _newInstance[_DataSymbolicName];
      Assert.IsNotNull(_originalItem);
      Assert.AreSame(_originalItem.Item, _TestDataSet);
    }
    [TestMethod]
    public void DataSetExistsTest()
    {
      DataSetConfigurationCollection _newInstance = CreateTestCollection();
      Assert.IsTrue(_newInstance.DataSetExists(_DataSymbolicName));
      Assert.IsFalse(_newInstance.DataSetExists("Not existing symbolic name"));
    }
    [TestMethod]
    [ExpectedException(typeof(System.Collections.Generic.KeyNotFoundException))]
    public void RemoveTestMethod()
    {
      DataSetConfigurationCollection _newInstance = CreateTestCollection();
      DataSetConfigurationWrapper _originalItem = _newInstance[_DataSymbolicName];
      Assert.IsNotNull(_originalItem);
      _newInstance.Remove(_originalItem);
      _originalItem = _newInstance[_DataSymbolicName];
    }
    [TestMethod]
    [ExpectedException(typeof(System.Collections.Generic.KeyNotFoundException))]
    public void RemoveUsingStringKeyTestMethod()
    {
      DataSetConfigurationCollection _newInstance = CreateTestCollection();
      DataSetConfigurationWrapper _originalItem = _newInstance[_DataSymbolicName];
      Assert.IsNotNull(_originalItem);
      _newInstance.Remove(_DataSymbolicName);
      DataSetConfigurationWrapper _result = _newInstance[_DataSymbolicName];
    }
    [TestMethod]
    public void RemoveIsNotPropagatingTestMethod()
    {
      DataSetConfigurationCollection _newInstance = CreateTestCollection();
      DataSetConfigurationWrapper _originalItem = _newInstance[_DataSymbolicName];
      Assert.IsNotNull(_originalItem);
      _newInstance.Remove(_originalItem);
      _newInstance = new DataSetConfigurationCollection(new ConfigurationDataRepository());
      _originalItem = _newInstance[_DataSymbolicName];
      Assert.IsNotNull(_originalItem);
    }
    [TestMethod]
    [ExpectedException(typeof(System.Collections.Generic.KeyNotFoundException))]
    public void RemoveIsPropagatingTestMethod()
    {
      DataSetConfigurationCollection _newInstance = CreateTestCollection();
      DataSetConfigurationWrapper _originalItem = _newInstance[_DataSymbolicName];
      Assert.IsNotNull(_originalItem);
      _newInstance.Remove(_originalItem);
      _newInstance.CommitChanges();
      _newInstance = new DataSetConfigurationCollection(new ConfigurationDataRepository());
      _originalItem = _newInstance[_DataSymbolicName];
    }

    #region private test instrumentation
    private DataSetConfigurationCollection CreateTestCollection()
    {
      ConfigurationDataRepository.SetConfigurationData = new Serialization.ConfigurationData()
      {
        DataSets = new Serialization.DataSetConfiguration[] { _TestDataSet },
        MessageHandlers = new Serialization.MessageHandlerConfiguration[] { }
      };
      ConfigurationDataRepository _newConfigurationDataRepository = new ConfigurationDataRepository();
      DataSetConfigurationCollection _newInstance = new DataSetConfigurationCollection(_newConfigurationDataRepository);
      return _newInstance;
    }
    private readonly static string _AssociationName = "AssociationName";
    private readonly static string _DataSymbolicName = "DataSymbolicName";
    private readonly Serialization.DataSetConfiguration _TestDataSet = new Serialization.DataSetConfiguration
    {
      AssociationName = _AssociationName,
      DataSymbolicName = _DataSymbolicName,
      DataSet = new FieldMetaData[] { }
    };
    #endregion

  }
}
