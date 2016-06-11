
//_______________________________________________________________
//  Title   : IDataSetConfigurationCollection
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

using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{
  internal interface IDataSetConfigurationCollection : IList<DataSetConfigurationWrapper>, INotifyCollectionChanged, INotifyPropertyChanged { }
}
