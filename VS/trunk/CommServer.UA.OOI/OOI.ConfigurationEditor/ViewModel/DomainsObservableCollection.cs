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

using System.Collections.ObjectModel;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel
{
  /// <summary>
  /// Class DomainsObservableCollection - Represents a dynamic data collection that provides notifications 
  /// when items get added, removed, or when the whole list of <see cref="DomainWrapper"/> items is refreshed.
  /// </summary>
  /// <seealso cref="ObservableCollection{DomainWrapper}" />
  public class DomainsObservableCollection : ObservableCollection<DomainWrapper>, IDomainsObservableCollection
  {

    internal DomainsObservableCollection(DomainWrapper[] domains) : base(domains) { }

  }
}
