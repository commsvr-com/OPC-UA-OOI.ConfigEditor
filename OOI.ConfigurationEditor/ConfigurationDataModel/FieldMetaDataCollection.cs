using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{
  public class FieldMetaDataCollection : ObservableCollection<FieldMetaDataWrapper>
  {
    private FieldMetaData[] dataSet;

    public FieldMetaDataCollection(FieldMetaData[] dataSet)
    {
      this.dataSet = dataSet;
    }
  }
}
