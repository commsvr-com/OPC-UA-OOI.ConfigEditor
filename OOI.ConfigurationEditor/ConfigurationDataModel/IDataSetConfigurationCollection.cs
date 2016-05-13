
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.ConfigurationDataModel
{
  internal interface IDataSetConfigurationCollection : IList<DataSetConfigurationWrapper>, INotifyCollectionChanged, INotifyPropertyChanged { }
}
