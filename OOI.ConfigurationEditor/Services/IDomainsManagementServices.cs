//_______________________________________________________________
//  Title   : IDomainsManagementServices
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

using CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Services
{
  /// <summary>
  /// Interface IDomainsManagementServices - defines API to manage the collection of well known domains.
  /// </summary>
  public interface IDomainsManagementServices
  {

    /// <summary>
    /// Gets the available domains.
    /// </summary>
    /// <returns>Returns an instance of <see cref="IDomainsObservableCollection"/>.</returns>
    IDomainsObservableCollection GetAvailableDomains();
    /// <summary>
    /// Removes the specified domain from the well known domains.
    /// </summary>
    /// <param name="domain">The domain to be removed from the list of available domains.</param>
    void Remove(DomainWrapper domain);
    /// <summary>
    /// Adds the domain to the collection of well known domains.
    /// </summary>
    /// <param name="domain">The domain to be added to the list of available domains.</param>
    /// <returns><c>true</c> if domain has been added successfully, <c>false</c> otherwise.</returns>
    bool AddDomain(DomainWrapper domain);
    /// <summary>
    /// Creates a default domain descriptor.
    /// </summary>
    /// <returns>New <see cref="DomainWrapper"/>.</returns>
    DomainWrapper CreateDefault();
    /// <summary>
    /// Determines whether the specified domain has bee registered already.
    /// </summary>
    /// <param name="domain">The domain to check.</param>
    /// <returns><c>true</c> if the local dictionary contains the specified domain; otherwise, <c>false</c>.</returns>
    bool Contains(DomainWrapper domain);

  }
}