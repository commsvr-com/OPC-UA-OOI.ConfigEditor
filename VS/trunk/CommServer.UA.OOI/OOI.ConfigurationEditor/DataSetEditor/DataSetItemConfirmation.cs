//_______________________________________________________________
//  Title   : DataSetItemConfirmation
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
using CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel;
using CAS.Windows.ViewModel;
using System;
using System.Collections.Generic;
using System.Windows;
using Serialization = global::UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DataSetEditor.DataSetList
{

  internal class DataSetItemConfirmation : ConfirmationBindable
  {

    internal DataSetItemConfirmation(DataSetConfigurationWrapper wrapper, Func<DataSetConfigurationWrapper, IEnumerable<AssociationCouplerViewModel>> enumerator, bool associationRoleEditable)
    {
      DataSetConfigurationWrapper = wrapper;
      m_GetMessageHandlers = enumerator;
      AssociationCouplersEnumerator = m_GetMessageHandlers(DataSetConfigurationWrapper);
      if (associationRoleEditable)
        b_AssociationRoleGroupBoxIsEnabled = Visibility.Visible;
      else
        b_AssociationRoleGroupBoxIsEnabled = Visibility.Visible;
      if (AssociationRole == Serialization.AssociationRole.Consumer)
      {
        b_ConsumerRoleSelected = true;
        b_ProducerRoleSelected = false;
      }
      else
      {
        b_ConsumerRoleSelected = false;
        b_ProducerRoleSelected = true;

      }
    }

    #region ViewModel API

    private bool? b_ProducerRoleSelected;

    public bool? ProducerRoleSelected
    {
      get
      {
        return b_ProducerRoleSelected;
      }
      set
      {
        if (SetProperty<bool?>(ref b_ProducerRoleSelected, value) && value.GetValueOrDefault(false))
          AssociationRole = Serialization.AssociationRole.Producer;
      }
    }
    private bool? b_ConsumerRoleSelected;

    public bool? ConsumerRoleSelected
    {
      get
      {
        return b_ConsumerRoleSelected;
      }
      set
      {
        if (SetProperty<bool?>(ref b_ConsumerRoleSelected, value) && value.GetValueOrDefault(false))
          AssociationRole = Serialization.AssociationRole.Consumer;
      }
    }
    private Visibility b_AssociationRoleGroupBoxIsEnabled;

    public Visibility AssociationRoleGroupBoxIsEnabled
    {
      get
      {
        return b_AssociationRoleGroupBoxIsEnabled;
      }
      set
      {
        SetProperty<Visibility>(ref b_AssociationRoleGroupBoxIsEnabled, value);
      }
    }
    public Serialization.AssociationRole AssociationRole
    {
      get
      {
        return DataSetConfigurationWrapper.AssociationRole;
      }
      set
      {
        if (base.SetProperty<Serialization.AssociationRole>(DataSetConfigurationWrapper.AssociationRole, x => DataSetConfigurationWrapper.AssociationRole = value, value))
          AssociationCouplersEnumerator = m_GetMessageHandlers(DataSetConfigurationWrapper);
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
    public IEnumerable<AssociationCouplerViewModel> AssociationCouplersEnumerator
    {
      get
      {
        return b_AssociationCouplersEnumerator;
      }
      set
      {
        SetProperty<IEnumerable<AssociationCouplerViewModel>>(ref b_AssociationCouplersEnumerator, value);
      }
    }
    #endregion

    internal void Revert()
    {
      foreach (AssociationCouplerViewModel _mh in AssociationCouplersEnumerator)
        _mh.Revert();
    }

    #region private
    private IEnumerable<AssociationCouplerViewModel> b_AssociationCouplersEnumerator;
    private DataSetConfigurationWrapper b_DataSetConfigurationWrapper;
    private Func<DataSetConfigurationWrapper, IEnumerable<AssociationCouplerViewModel>> m_GetMessageHandlers;
    #endregion

  }
}
