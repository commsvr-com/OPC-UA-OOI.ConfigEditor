//_______________________________________________________________
//  Title   : Name of Application
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
using System.Collections.Generic;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Services
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
