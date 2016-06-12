//_______________________________________________________________
//  Title   : Name of Application
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate: 2016-06-11 21:25:44 +0200 (So, 11 cze 2016) $
//  $Rev: 12228 $
//  $LastChangedBy: mpostol $
//  $URL: svn://svnserver.hq.cas.com.pl/VS/trunk/CommServer.UA.OOI/OOI.ConfigurationEditor/ViewModel/IDomainsObservableCollection.cs $
//  $Id: IDomainsObservableCollection.cs 12228 2016-06-11 19:25:44Z mpostol $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using System.Collections.Generic;
using System.Collections.Specialized;
using System.ComponentModel;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel
{
  
  /// <summary>
  /// Interface IDomainsObservableCollection - Represents a collection of <see cref="DomainWrapper"/> instances that can be individually accessed by index. Implements <see cref="INotifyCollectionChanged"/> and <see cref="INotifyPropertyChanged"/>
  /// </summary>
  /// <seealso cref="IList{DomainWrapper}" />
  /// <seealso cref="INotifyCollectionChanged" />
  /// <seealso cref="INotifyPropertyChanged" />
  public interface IDomainsObservableCollection: IList<DomainWrapper>, INotifyCollectionChanged, INotifyPropertyChanged { }

}
