//_______________________________________________________________
//  Title   : AssociationServicesUnitTest
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
using CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.UnitTest
{

  [TestClass]
  public class AssociationServicesUnitTest
  {
    [TestMethod]
    public void GetAssociationCouplerViewModelEnumerator4DataSetTest()
    {
      DataSetConfigurationWrapper _dsw = DataSetConfigurationWrapper.CreateDefault();
      IMessageHandlerConfigurationWrapper _mhc = MessageReaderConfigurationWrapper.CreateDefault();
      AssociationServices _as = new AssociationServices(new TestDataSetModelServices(_dsw), new TestMessageHandlerServices(_mhc));
      Assert.IsTrue(_as.GetAssociationCouplerViewModelEnumerator(_dsw).Any<AssociationCouplerViewModel>());
    }
    [TestMethod]
    public void GetAssociationCouplerViewModelEnumerator4MessageHandlerTest()
    {
      DataSetConfigurationWrapper _dsw = DataSetConfigurationWrapper.CreateDefault();
      IMessageHandlerConfigurationWrapper _mhc = MessageReaderConfigurationWrapper.CreateDefault();
      AssociationServices _as = new AssociationServices(new TestDataSetModelServices(_dsw), new TestMessageHandlerServices(_mhc));
      Assert.IsTrue(_as.GetAssociationCouplerViewModelEnumerator(_mhc).Any<AssociationCouplerViewModel>());
    }

    private class TestDataSetModelServices : IDataSetModelServices
    {
      private DataSetConfigurationWrapper m_Wrapper;

      public TestDataSetModelServices(DataSetConfigurationWrapper wrapper)
      {
        this.m_Wrapper = wrapper;
      }
      #region IDataSetModelServices
      public void AddDataSet(DataSetConfigurationWrapper _newDataSetItem)
      {
        throw new NotImplementedException();
      }
      public bool DataSetExists(string dataSetIdentifier)
      {
        throw new NotImplementedException();
      }
      public IDataSetConfigurationCollection GetDataSets()
      {
        throw new NotImplementedException();
      }
      public IEnumerable<DataSetConfigurationWrapper> GetDataSets(AssociationRole associationRole)
      {
        if (associationRole != m_Wrapper.AssociationRole)
          throw new ArgumentOutOfRangeException(nameof(associationRole));
        return new DataSetConfigurationWrapper[] { m_Wrapper };
      }
      public DataSetConfigurationWrapper GetDescription(string dataSetIdentifier)
      {
        throw new NotImplementedException();
      }
      public void Remove(DataSetConfigurationWrapper currentDataSetItem)
      {
        throw new NotImplementedException();
      }
      public void Remove(string symbolicName)
      {
        throw new NotImplementedException();
      }
      #endregion

    }
    private class TestMessageHandlerServices : IMessageHandlerServices
    {
      private IMessageHandlerConfigurationWrapper m_Wrapper;

      public TestMessageHandlerServices(IMessageHandlerConfigurationWrapper _mhc)
      {
        this.m_Wrapper = _mhc;
      }

      #region IMessageHandlerServices
      public void AddMessageHandler(IMessageHandlerConfigurationWrapper dataSetConfigurationWrapper)
      {
        throw new NotImplementedException();
      }
      public bool Exist(string title)
      {
        throw new NotImplementedException();
      }
      public MessageHandlerConfigurationCollection GetMessageHandlers()
      {
        throw new NotImplementedException();
      }

      public IEnumerable<IMessageHandlerConfigurationWrapper> GetMessageHandlers(AssociationRole associationRole)
      {
        if (associationRole != m_Wrapper.TransportRole)
          throw new ArgumentOutOfRangeException(nameof(associationRole));
        return new IMessageHandlerConfigurationWrapper[] { m_Wrapper };
      }
      public void Remove(IMessageHandlerConfigurationWrapper currentMessageHandler)
      {
        throw new NotImplementedException();
      }
      public void Remove(string title)
      {
        throw new NotImplementedException();
      }
      #endregion

    }

  }
}
