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
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel
{

  /// <summary>
  /// Class AssociationServices implements <see cref="IAssociationServices"/>
  /// </summary>
  /// <seealso cref="CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel.IAssociationServices" />
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
    /// Gets the array of all candidates <see cref="AssociationCouplerViewModel" /> that can be associated with <paramref name="wrapper" />
    /// </summary>
    /// <param name="wrapper">The wrapper <see cref="DataSetConfigurationWrapper" />.</param>
    /// <returns>All available <see cref="AssociationCouplerViewModel" />.</returns>
    public AssociationCouplerViewModel[] GetAssociationCouplerViewModelEnumerator(DataSetConfigurationWrapper wrapper)
    {
      return m_MessageHandlerModelServices.GetMessageHandlers(wrapper.AssociationRole).
        Select<IMessageHandlerConfigurationWrapper, AssociationCouplerViewModel>(mhc => new AssociationCouplerViewModel(new AssociationCoupler(() => mhc.Check(wrapper), associate => mhc.Associate(associate, wrapper), mhc.ToString()))).
        ToArray<AssociationCouplerViewModel>();
    }
    /// <summary>
    /// Gets the <see cref="IEnumerable{T}" /> of all candidates <see cref="AssociationCouplerViewModel" /> that can be associated with <paramref name="wrapper" />
    /// </summary>
    /// <param name="wrapper">The wrapper.</param>
    /// <remarks>
    /// Implements <see cref="IAssociationServices"/>
    /// </remarks>
    /// <returns>All available <see cref="AssociationCouplerViewModel" /> as the <see cref="IEnumerable{T}" />.</returns>
    public AssociationCouplerViewModel[] GetAssociationCouplerViewModelEnumerator(IMessageHandlerConfigurationWrapper wrapper)
    {
      return m_DataSetsServices.GetDataSets(wrapper.TransportRole).
        Select<DataSetConfigurationWrapper, AssociationCouplerViewModel>(dsc => new AssociationCouplerViewModel(new AssociationCoupler(() => wrapper.Check(dsc), associated => wrapper.Associate(associated, dsc), dsc.ToString()))).
        ToArray<AssociationCouplerViewModel>();
    }
    #endregion

    #region private
    private IDataSetModelServices m_DataSetsServices;
    private IMessageHandlerServices m_MessageHandlerModelServices;
    #endregion

  }
}
