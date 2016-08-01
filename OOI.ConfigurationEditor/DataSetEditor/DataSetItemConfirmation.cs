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
using CAS.CommServer.UA.OOI.ConfigurationEditor.Controls;
using CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel;
using CAS.CommServer.UA.OOI.ConfigurationEditor.Services;
using CAS.Windows.ViewModel;
using System;
using System.Collections.Generic;
using Serialization = global::UAOOI.Configuration.Networking.Serialization;
using System.Collections.ObjectModel;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DataSetEditor
{

  internal class DataSetItemConfirmation : ConfirmationBindable
  {

    internal DataSetItemConfirmation
      (DataSetConfigurationWrapper wrapper, Func<DataSetConfigurationWrapper, IEnumerable<AssociationCouplerViewModel>> enumerator, bool associationRoleEditable, IEnumerable<DomainModelWrapper> domainsEnumerable)
    {
      DataSetConfigurationWrapper = wrapper;
      m_GetMessageHandlers = enumerator;
      Domains = domainsEnumerable;
      DomainsSelectedIndex = 0;
      AssociationCouplersEnumerator = m_GetMessageHandlers(DataSetConfigurationWrapper);
      AssociationRoleSelectorControlViewModel = new AssociationRoleSelectorControlViewModel(x => AssociationRole = x, AssociationRole, associationRoleEditable);
    }

    #region ViewModel API
    public IEnumerable<DomainModelWrapper> Domains { get; }
    public int DomainsSelectedIndex { get; set; }
    public DomainModelWrapper CurrentDomain
    {
      get
      {
        return b_CurrentDomain;
      }
      set
      {
        if (SetProperty<DomainsModel.DomainModelWrapper>(ref b_CurrentDomain, value))
          SemanticDataCollection = value.SemanticsDataCollection;
      }
    }
    public ObservableCollection<SemanticsDataIndexWrapper> SemanticDataCollection
    {
      get
      {
        return b_SemanticDataCollection;
      }
      set
      {
        SetProperty<ObservableCollection<SemanticsDataIndexWrapper>>(ref b_SemanticDataCollection, value);
      }
    }
    public SemanticsDataIndexWrapper CurrentSemanticsDataIndexWrapper
    {
      get
      {
        return b_CurrentSemanticsDataIndexWrapper;
      }
      set
      {
        if (!SetProperty<SemanticsDataIndexWrapper>(ref b_CurrentSemanticsDataIndexWrapper, value))
          return;
        if (value == null)
          return;
        DataSetConfigurationWrapper.UpdateDataSet(CurrentDomain, value, m_NewVersion);
        m_NewVersion = false;
      }
    }
    public AssociationRoleSelectorControlViewModel AssociationRoleSelectorControlViewModel { get; }
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

    internal void ApplyChanges()
    {
      foreach (AssociationCouplerViewModel _mh in AssociationCouplersEnumerator)
        _mh.ApplyChanges(this.DataSetConfigurationWrapper);
    }

    #region private
    private DomainModelWrapper b_CurrentDomain;
    private IEnumerable<AssociationCouplerViewModel> b_AssociationCouplersEnumerator;
    private DataSetConfigurationWrapper b_DataSetConfigurationWrapper;
    private ObservableCollection<SemanticsDataIndexWrapper> b_SemanticDataCollection;
    private SemanticsDataIndexWrapper b_CurrentSemanticsDataIndexWrapper;
    private Func<DataSetConfigurationWrapper, IEnumerable<AssociationCouplerViewModel>> m_GetMessageHandlers;
    private bool m_NewVersion = true;
    #endregion

  }
}
