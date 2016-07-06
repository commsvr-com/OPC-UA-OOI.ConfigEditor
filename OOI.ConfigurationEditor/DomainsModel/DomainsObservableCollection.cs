//_______________________________________________________________
//  Title   : Name of Application
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate: 2016-06-11 21:25:44 +0200 (So, 11 cze 2016) $
//  $Rev: 12228 $
//  $LastChangedBy: mpostol $
//  $URL: svn://svnserver.hq.cas.com.pl/VS/trunk/CommServer.UA.OOI/OOI.ConfigurationEditor/ViewModel/DomainsObservableCollection.cs $
//  $Id: DomainsObservableCollection.cs 12228 2016-06-11 19:25:44Z mpostol $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using System.Collections.ObjectModel;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel
{
  /// <summary>
  /// Class DomainsObservableCollection - Represents a dynamic data collection that provides notifications 
  /// when items get added, removed, or when the whole list of <see cref="DomainModelWrapper"/> items is refreshed.
  /// </summary>
  /// <seealso cref="ObservableCollection{DomainWrapper}" />
  public class DomainsObservableCollection : ObservableCollection<DomainModelWrapper>, IDomainsObservableCollection
  {

    internal DomainsObservableCollection(DomainModelWrapper[] domains) : base(domains) { }

  }
}
