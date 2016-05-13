
using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using System.Collections.Generic;
using System.ComponentModel.Composition;
using System.Linq;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel
{
  [Export(typeof(IAssociationServices))]
  [PartCreationPolicy(CreationPolicy.Shared)]
  internal class AssociationServices : IAssociationServices
  {

    [ImportingConstructor]
    public AssociationServices(IDataSetModelServices dataSetsServices, IMessageHandlerServices messageHandlerModelServices)
    {
      m_DataSetsServices = dataSetsServices;
      m_MessageHandlerModelServices = messageHandlerModelServices;
    }

    #region IAssociationServices
    public IEnumerable<AssociationCouplerViewModel> GetAssociationCouplerViewModelEnumerator(DataSetConfigurationWrapper wrapper)
    {
      return m_MessageHandlerModelServices.GetMessageHandlers(wrapper.AssociationRole).
          Select<IMessageHandlerConfigurationWrapper, AssociationCouplerViewModel>
            (mhc => new AssociationCouplerViewModel(new AssociationCouple(() => mhc.Check(wrapper), associate => mhc.Associate(associate, wrapper), mhc.ToString())));
    }
    public IEnumerable<AssociationCouplerViewModel> GetAssociationCouplerViewModelEnumerator(IMessageHandlerConfigurationWrapper wrapper)
    {
      return m_DataSetsServices.GetDataSets(wrapper.AssociationRole).
        Select<DataSetConfigurationWrapper, AssociationCouplerViewModel>
          (dsc => new AssociationCouplerViewModel(new AssociationCouple(() => wrapper.Check(dsc), associated => wrapper.Associate(associated, dsc), dsc.ToString())));
    }
    #endregion

    private IDataSetModelServices m_DataSetsServices;
    private IMessageHandlerServices m_MessageHandlerModelServices;

  }
}
