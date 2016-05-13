//_______________________________________________________________
//  Title   : DataSetModelServices
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate:  $
//  $Rev: $
//  $LastChangedBy: $
//  $URL: $
//  $Id:  $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.ConfigurationDataModel
{

  [Export(typeof(IDataSetModelServices))]
  [PartCreationPolicy(CreationPolicy.Shared)]
  internal class DataSetModelServices : IDataSetModelServices
  {
    //creator
    [ImportingConstructor]
    public DataSetModelServices(DataSetConfigurationCollection configurationRepository)
    {
      m_Configuration = configurationRepository;
    }

    #region IDataSetModelServices
    public bool DataSetExists(string dataSetIdentifier)
    {

      return m_Configuration.DataSetExists(dataSetIdentifier);
    }
    public DataSetConfigurationWrapper GetDescription(string symbolicName)
    {
      return m_Configuration[symbolicName];
    }
    public IDataSetConfigurationCollection GetDataSets()
    {
      return m_Configuration;
    }
    public IEnumerable<DataSetConfigurationWrapper> GetDataSets(AssociationRole associationRole)
    {
      return m_Configuration.Where<DataSetConfigurationWrapper>(x => x.AssociationRole == associationRole);
    }
    public void AddDataSet(DataSetConfigurationWrapper item)
    {
      m_Configuration.Add(item);
    }
    public void Remove(string symbolicName)
    {
      m_Configuration.Remove(symbolicName);
    }
    public void Remove(DataSetConfigurationWrapper item)
    {
      m_Configuration.Remove(item);
    }
    #endregion

    private readonly DataSetConfigurationCollection m_Configuration;

  }

}
