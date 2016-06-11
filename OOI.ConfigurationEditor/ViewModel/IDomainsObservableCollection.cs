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

using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel
{
  
  /// <summary>
  /// Interface IDomainsObservableCollection - Represents a collection of <see cref="DomainWrapper"/> instances that can be individually accessed by index. Implements <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/>
  /// </summary>
  /// <seealso cref="IList{DomainWrapper}" />
  /// <seealso cref="INotifyCollectionChanged" />
  /// <seealso cref="INotifyPropertyChanged" />
  public interface IDomainsObservableCollection: IList<DomainWrapper>, INotifyCollectionChanged, INotifyPropertyChanged { }

}
