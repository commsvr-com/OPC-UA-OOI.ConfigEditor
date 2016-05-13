
using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using CAS.CommServer.UA.OOI.ConfigurationEditor.mvvm;
using CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using Serialization = global::UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DataSetEditor.DataSetList
{

  public class DataSetItemConfirmation : Bindable, IConfirmation
  {

    internal DataSetItemConfirmation(DataSetConfigurationWrapper wrapper, Func<DataSetConfigurationWrapper, IEnumerable<AssociationCouplerViewModel>> getMessageHandlers, bool associationRoleEditable)
    {
      m_GetMessageHandlers = getMessageHandlers;
      DataSetConfigurationWrapper = wrapper;
      AssociationRoleEditable = associationRoleEditable;
      MessageHandlers = m_GetMessageHandlers(DataSetConfigurationWrapper);
    }

    #region ViewModel API
    public bool AssociationRoleEditable { get; private set; }
    public Serialization.AssociationRole AssociationRole
    {
      get
      {
        return DataSetConfigurationWrapper.AssociationRole;
      }
      set
      {
        if (base.AssignProperty<Serialization.AssociationRole>(DataSetConfigurationWrapper.AssociationRole, x => DataSetConfigurationWrapper.AssociationRole = value, value))
          MessageHandlers = m_GetMessageHandlers(DataSetConfigurationWrapper);
      }
    }
    public DataSetConfigurationWrapper DataSetConfigurationWrapper
    {
      get
      {
        return b_DataSetConfigurationWrapper;
      }
      set
      {
        base.SetProperty<DataSetConfigurationWrapper>(ref b_DataSetConfigurationWrapper, value);
      }
    }
    public IEnumerable<AssociationCouplerViewModel> MessageHandlers
    {
      get
      {
        return b_MessageHandlers;
      }
      set
      {
        SetProperty<IEnumerable<AssociationCouplerViewModel>>(ref b_MessageHandlers, value);
      }
    }
    #endregion

    #region IConfirmation
    public bool Confirmed
    {
      get; set;
    }
    public object Content
    {
      get; set;
    }
    public string Title
    {
      get; set;
    }
    #endregion

    internal void Revert()
    {
      foreach (AssociationCouplerViewModel _mh in MessageHandlers)
        _mh.Revert();
    }

    #region private
    private IEnumerable<AssociationCouplerViewModel> b_MessageHandlers;
    private DataSetConfigurationWrapper b_DataSetConfigurationWrapper;
    private Func<DataSetConfigurationWrapper, IEnumerable<AssociationCouplerViewModel>> m_GetMessageHandlers;
    #endregion

  }
}
