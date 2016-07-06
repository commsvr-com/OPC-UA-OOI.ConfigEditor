//_______________________________________________________________
//  Title   : DomainsManagementServices
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate: 2016-06-11 23:18:56 +0200 (So, 11 cze 2016) $
//  $Rev: 12229 $
//  $LastChangedBy: mpostol $
//  $URL: svn://svnserver.hq.cas.com.pl/VS/trunk/CommServer.UA.OOI/OOI.ConfigurationEditor/DomainEditor/DomainsManagementServices.cs $
//  $Id: DomainsManagementServices.cs 12229 2016-06-11 21:18:56Z mpostol $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel;
using System;
using System.ComponentModel.Composition;
using System.Linq;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Services
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
    internal DomainsManagementServices(IAssociationServices services)
    {
      m_IAssociationServices = services;
      m_DomainsObservableCollection = new DomainsObservableCollection(new DomainModelWrapper[] { CreateDefault() });
      foreach (Association _as in services.GetAssociations())
      {
        DomainModelWrapper _dw = m_DomainsObservableCollection.Where<DomainModelWrapper>(x => x.UniqueName == _as.AssociationConfigurationWrapper.PublisherId).FirstOrDefault<DomainModelWrapper>();
        if (_dw == null)
        {
          DomainsModel.DomainModel _new = new DomainsModel.DomainModel()
          {
            AliasName = _as.DataSet.SymbolicName,
            Description = $"URI recovered from the DataSet AssociationName: {_as.DataSet.AssociationName}, SymbolicName: {_as.DataSet.SymbolicName}",
            UniqueName = _as.AssociationConfigurationWrapper.PublisherId,
            URI = new Uri(_as.DataSet.InformationModelURI),
            SemanticsDataCollection = new SemanticsDataIndex[] { NewSemanticsDataIndex(_as) }
          };
          m_DomainsObservableCollection.Add(new DomainModelWrapper(_new));
        }
        else
          _dw.SemanticsDataCollection.Add(new SemanticsDataIndexWrapper(NewSemanticsDataIndex(_as)));
      };
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
    public void Remove(DomainModelWrapper domain)
    {
      m_DomainsObservableCollection.Remove(domain);
    }
    /// <summary>
    /// Adds the domain to the collection of well known domains.
    /// </summary>
    /// <param name="domain">The domain to be added to the list of available domains.</param>
    /// <exception cref="NotImplementedException"></exception>
    public bool AddDomain(DomainModelWrapper domain)
    {
      if (Contains(domain))
        return false;
      m_DomainsObservableCollection.Add(domain);
      return true;
    }
    /// <summary>
    /// Creates a default domain descriptor.
    /// </summary>
    /// <returns>New <see cref="DomainModelWrapper" />.</returns>
    public DomainModelWrapper CreateDefault()
    {
      DomainModel _model = new DomainModel()
      {
        AliasName = "TempuriOrg",
        Description = "meaningless temporal uri to used and a default",
        UniqueName = new Guid("3653281C-A77F-4A98-ACA4-C87A560EC124"),
        URI = new Uri(@"http://tempuri.org/DefaultDomainSegment"),
        SemanticsDataCollection = new SemanticsDataIndex[] { }
      };
      DomainModelWrapper _ret = new DomainModelWrapper(_model);
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
    public bool Contains(DomainModelWrapper domain)
    {
      if (m_DomainsObservableCollection == null)
        return false;
      return m_DomainsObservableCollection.Where<DomainModelWrapper>(x => x.AliasName == domain.AliasName).Any<DomainModelWrapper>();
    }
    #endregion

    #region private
    private DomainsObservableCollection m_DomainsObservableCollection;
    private IAssociationServices m_IAssociationServices;
    private static SemanticsDataIndex NewSemanticsDataIndex(Association _as)
    {
      return new SemanticsDataIndex()
      {
        Index = _as.AssociationConfigurationWrapper.DataSetWriterId,
        SymbolicName = _as.DataSet.SymbolicName,
        DataSet = _as.DataSet.DataSet
      };
    }
    #endregion

  }
}

