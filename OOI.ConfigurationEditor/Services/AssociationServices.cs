//_______________________________________________________________
//  Title   : Name of Application
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate: 2016-06-04 17:57:32 +0200 (So, 04 cze 2016) $
//  $Rev: 12226 $
//  $LastChangedBy: mpostol $
//  $URL: svn://svnserver.hq.cas.com.pl/VS/trunk/CommServer.UA.OOI/OOI.ConfigurationEditor/ViewModel/AssociationServices.cs $
//  $Id: AssociationServices.cs 12226 2016-06-04 15:57:32Z mpostol $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using CAS.CommServer.UA.OOI.ConfigurationEditor.Services;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel
{

  /// <summary>
  /// Class AssociationServices implements <see cref="IAssociationServices"/>
  /// </summary>
  /// <seealso cref="IAssociationServices" />
  [Export(typeof(IAssociationServices))]
  [PartCreationPolicy(CreationPolicy.Shared)]
  internal class AssociationServices : IAssociationServices
  {

    #region Importing Constructors
    /// <summary>
    /// Initializes a new instance of the <see cref="AssociationServices"/> class.
    /// </summary>
    /// <param name="dataSetsServices">The data sets services.</param>
    /// <param name="messageHandlerModelServices">The message handler model services.</param>
    [ImportingConstructor]
    public AssociationServices(IDataSetModelServices dataSetsServices, IMessageHandlerServices messageHandlerModelServices)
    {
      m_DataSetsServices = dataSetsServices;
      m_MessageHandlerModelServices = messageHandlerModelServices;
    }
    #endregion

    #region IAssociationServices
    /// <summary>
    /// Gets the array of all candidates <see cref="AssociationCouplerViewModel" /> that can be associated with <paramref name="dscWrapper" />
    /// </summary>
    /// <param name="dscWrapper">The wrapper <see cref="DataSetConfigurationWrapper" />.</param>
    /// <returns>All available <see cref="AssociationCouplerViewModel" />.</returns>
    public AssociationCouplerViewModel[] GetAssociationCouplerViewModelEnumerator(DataSetConfigurationWrapper dscWrapper)
    {
      return m_MessageHandlerModelServices.GetMessageHandlers(dscWrapper.AssociationRole).
        Select<IMessageHandlerConfigurationWrapper, AssociationCouplerViewModel>
          (mhcWrapper => new AssociationCouplerViewModel(new AssociationCoupler(mhcWrapper.Check(dscWrapper),
                                                         (associated, association) => mhcWrapper.Associate(associated, association),
                                                         mhcWrapper.ToString(),
                                                         DefaultAssociation(mhcWrapper.TransportRole, dscWrapper)))).
          ToArray<AssociationCouplerViewModel>();
    }

    /// <summary>
    /// Gets the <see cref="IEnumerable{T}" /> of all candidates <see cref="AssociationCouplerViewModel" /> that can be associated with <paramref name="mhcWrapper" />
    /// </summary>
    /// <param name="mhcWrapper">The wrapper.</param>
    /// <remarks>
    /// Implements <see cref="IAssociationServices"/>
    /// </remarks>
    /// <returns>All available <see cref="AssociationCouplerViewModel" /> as the <see cref="IEnumerable{T}" />.</returns>
    public AssociationCouplerViewModel[] GetAssociationCouplerViewModelEnumerator(IMessageHandlerConfigurationWrapper mhcWrapper)
    {
      return m_DataSetsServices.GetDataSets(mhcWrapper.TransportRole).
        Select<DataSetConfigurationWrapper, AssociationCouplerViewModel>
          (dscWrapper => new AssociationCouplerViewModel(new AssociationCoupler(mhcWrapper.Check(dscWrapper),
                                                         (associated, association) => mhcWrapper.Associate(associated, association),
                                                         dscWrapper.ToString(),
                                                         DefaultAssociation(mhcWrapper.TransportRole, dscWrapper)))).
          ToArray<AssociationCouplerViewModel>();
    }
    public IEnumerable<Association> GetAssociations()
    {
      List<Association> _ret = new List<Association>();
      foreach (IMessageHandlerConfigurationWrapper _wrx in m_MessageHandlerModelServices.GetMessageHandlers())
      {
        IEnumerable<Association> _ac = _wrx.GetAssociations().Join<IAssociationConfigurationWrapper, DataSetConfigurationWrapper, string, Association>
          (
            m_DataSetsServices.GetDataSets(),
            x => x.AssociationName,
            y => y.AssociationName,
            (_association, _dataSet) => new Association() { AssociationConfigurationWrapper = _association, DataSet = _dataSet }
          );
        _ret.AddRange(_ac);
      }
      return _ret;
    }
    #endregion

    #region private
    private IDataSetModelServices m_DataSetsServices;
    private IMessageHandlerServices m_MessageHandlerModelServices;
    private IAssociationConfigurationWrapper DefaultAssociation(AssociationRole transportRole, DataSetConfigurationWrapper dsc)
    {
      IAssociationConfigurationWrapper _ret = null;
      switch (transportRole)
      {
        case AssociationRole.Consumer:
          _ret = ConsumerAssociationConfigurationWrapper.GetDefault(dsc);
          break;
        case AssociationRole.Producer:
          _ret = ProducerAssociationConfigurationWrapper.GetDefault(dsc);
          break;
      }
      return _ret;
    }
    #endregion

  }
}
