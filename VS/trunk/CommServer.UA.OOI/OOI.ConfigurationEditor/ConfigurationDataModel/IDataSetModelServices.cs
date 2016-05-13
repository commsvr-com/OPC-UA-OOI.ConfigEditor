using System.Collections.Generic;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{
  internal interface IDataSetModelServices
  {

    bool DataSetExists(string dataSetIdentifier);
    DataSetConfigurationWrapper GetDescription(string dataSetIdentifier);
    IDataSetConfigurationCollection GetDataSets();
    IEnumerable<DataSetConfigurationWrapper> GetDataSets(AssociationRole associationRole);
    void AddDataSet(DataSetConfigurationWrapper _newDataSetItem);
    void Remove(string symbolicName);
    void Remove(DataSetConfigurationWrapper currentDataSetItem);
  }
}
