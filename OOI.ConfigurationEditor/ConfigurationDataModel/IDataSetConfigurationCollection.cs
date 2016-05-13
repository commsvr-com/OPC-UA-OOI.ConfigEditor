
using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{
  internal interface IDataSetConfigurationCollection : IList<DataSetConfigurationWrapper>, INotifyCollectionChanged, INotifyPropertyChanged { }
}
