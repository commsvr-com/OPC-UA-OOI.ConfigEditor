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
using CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel;
using CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel;
using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainEditor
{

  /// <summary>
  /// Class DomainsManagementServices - provides API to manage the collection of well known domains.
  /// </summary>
  [Export(typeof(IDomainsManagementServices))]
  public class DomainsManagementServices : IDomainsManagementServices
  {

    #region ImportingConstructor
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainsManagementServices"/> class.
    /// </summary>
    [ImportingConstructor()]
    internal DomainsManagementServices(DataSetConfigurationCollection configurationRepository)
    {
      m_DomainsObservableCollection = new DomainsObservableCollection(new DomainWrapper[] { CreateDefault() });
      foreach (DataSetConfigurationWrapper _wrpr in configurationRepository)
      {
        if (m_DomainsObservableCollection.Where<DomainWrapper>(x => x.URI.ToString() == _wrpr.InformationModelURI).Any<DomainWrapper>())
          continue;
        DomainModel _dm = new DomainModel();
        DomainWrapper _new = new DomainWrapper(_dm)
        {
          AliasName = _wrpr.SymbolicName,
          Description = $"URI recovered from the DataSet AssociationName: {_wrpr.AssociationName}, SymbolicName: {_wrpr.SymbolicName}",
          UniqueName = _wrpr.Id,
          URI = new Uri(_wrpr.InformationModelURI)
        };
        m_DomainsObservableCollection.Add(_new);
      }
    }
    #endregion

    #region IDomainsManagementServices
    /// <summary>
    /// Gets the available domains.
    /// </summary>
    /// <returns>Returns an instance of <see cref="IDomainsObservableCollection" />.</returns>
    public IDomainsObservableCollection GetAvailableDomains()
    {
      return m_DomainsObservableCollection;
    }
    /// <summary>
    /// Removes the specified domain from the well known domains.
    /// </summary>
    /// <param name="domain">The domain to be removed from the list of available domains.</param>
    public void Remove(DomainWrapper domain)
    {
      m_DomainsObservableCollection.Remove(domain);
    }
    /// <summary>
    /// Adds the domain to the collection of well known domains.
    /// </summary>
    /// <param name="domain">The domain to be added to the list of available domains.</param>
    /// <exception cref="NotImplementedException"></exception>
    public bool AddDomain(DomainWrapper domain)
    {
      if (Contains(domain))
        return false;
      m_DomainsObservableCollection.Add(domain);
      return true;
    }
    /// <summary>
    /// Creates a default domain descriptor.
    /// </summary>
    /// <returns>New <see cref="DomainWrapper" />.</returns>
    public DomainWrapper CreateDefault()
    {
      DomainModel _model = new DomainModel();
      DomainWrapper _ret = new DomainWrapper(_model)
      {
        AliasName = "TempuriOrg",
        Description = "meaningless temporal uri to used and a default",
        UniqueName = new Guid("3653281C-A77F-4A98-ACA4-C87A560EC124"),
        URI = new Uri(@"http://tempuri.org/DefaultDomainSegment")
      };
      int _i = 0;
      while (Contains(_ret))
      {
        _ret.AliasName = $"TempuriOrg.{_i}";
        _ret.UniqueName = Guid.NewGuid();
        _ret.URI = new Uri($"http://tempuri.org/DefaultDomainSegment/{_i}");
        _i++;
      }
      return _ret;
    }
    /// <summary>
    /// Determines whether the specified domain has bee registered already.
    /// </summary>
    /// <param name="domain">The domain to check.</param>
    /// <returns><c>true</c> if the local dictionary contains the specified domain; otherwise, <c>false</c>.</returns>
    public bool Contains(DomainWrapper domain)
    {
      if (m_DomainsObservableCollection == null)
        return false;
      return m_DomainsObservableCollection.Where<DomainWrapper>(x => x.AliasName == domain.AliasName).Any<DomainWrapper>();
    }
    #endregion

    private DomainsObservableCollection m_DomainsObservableCollection;

  }
}
