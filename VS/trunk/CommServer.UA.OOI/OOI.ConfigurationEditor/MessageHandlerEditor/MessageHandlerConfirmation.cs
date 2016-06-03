//_______________________________________________________________
//  Title   : MessageHandlerConfirmation
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
using CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel;
using CAS.Windows.ViewModel;
using System;
using System.Collections.Generic;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.MessageHandlerEditor
{
  internal class MessageHandlerConfirmation : ConfirmationBindable
  {
    public MessageHandlerConfirmation(Func<IMessageHandlerConfigurationWrapper, IEnumerable<AssociationCouplerViewModel>> enumerator) :
      this(MessageReaderConfigurationWrapper.CreateDefault(), enumerator, true)
    { }
    public MessageHandlerConfirmation(IMessageHandlerConfigurationWrapper wrapper, Func<IMessageHandlerConfigurationWrapper, IEnumerable<AssociationCouplerViewModel>> enumerator, bool associationRoleEditable)
    {
      b_MessageHandlerConfigurationWrapper = wrapper;
      m_AssociationCouplerViewModelEnumeratorFunc = enumerator;
      AssociationCouplersEnumerator = m_AssociationCouplerViewModelEnumeratorFunc(wrapper);
      AssociationRoleSelectorControlViewModel = new Controls.AssociationRoleSelectorControlViewModel
        (CreateDefault, MessageHandlerConfigurationWrapper.AssociationRole, associationRoleEditable);
    }


    #region ViewModel  API
    public AssociationRoleSelectorControlViewModel AssociationRoleSelectorControlViewModel { get; }
    public IMessageHandlerConfigurationWrapper MessageHandlerConfigurationWrapper
    {
      get
      {
        return b_MessageHandlerConfigurationWrapper;
      }
      set
      {
        SetProperty<IMessageHandlerConfigurationWrapper>(ref b_MessageHandlerConfigurationWrapper, value);
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
      if (AssociationCouplersEnumerator == null)
        return;
      foreach (var _item in AssociationCouplersEnumerator)
        _item.Revert();
    }

    #region private
    private Func<IMessageHandlerConfigurationWrapper, IEnumerable<AssociationCouplerViewModel>> m_AssociationCouplerViewModelEnumeratorFunc;
    private IMessageHandlerConfigurationWrapper b_MessageHandlerConfigurationWrapper;
    private IEnumerable<AssociationCouplerViewModel> b_AssociationCouplersEnumerator;
    private void CreateDefault(AssociationRole value)
    {
      switch (value)
      {
        case AssociationRole.Consumer:
          MessageHandlerConfigurationWrapper = MessageReaderConfigurationWrapper.CreateDefault();
          break;
        case AssociationRole.Producer:
          MessageHandlerConfigurationWrapper = MessageWriterConfigurationWrapper.CreateDefault();
          break;
      }
      AssociationCouplersEnumerator = m_AssociationCouplerViewModelEnumeratorFunc(MessageHandlerConfigurationWrapper);
    }
    #endregion

  }
}