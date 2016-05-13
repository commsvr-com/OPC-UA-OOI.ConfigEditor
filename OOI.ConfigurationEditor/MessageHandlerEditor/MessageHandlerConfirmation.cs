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

using CAS.CommServer.UAOOI.ConfigurationEditor.ConfigurationDataModel;
using CAS.CommServer.UAOOI.ConfigurationEditor.mvvm;
using CAS.CommServer.UAOOI.ConfigurationEditor.ViewModel;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Collections.Generic;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.MessageHandlerEditor
{
  internal class MessageHandlerConfirmation : Bindable, IConfirmation
  {

    public MessageHandlerConfirmation(IMessageHandlerConfigurationWrapper wrapper, Func<IMessageHandlerConfigurationWrapper, IEnumerable<AssociationCouplerViewModel>> enumerator, bool associationRoleEditable)
    {
      this.b_MessageHandlerConfigurationWrapper = wrapper;
      this.m_AssociationCouplerViewModelEnumeratorFunc = enumerator;
      AssociationCouplersEnumerator = m_AssociationCouplerViewModelEnumeratorFunc(wrapper);
      AssociationRoleEditable = associationRoleEditable;
    }

    #region ViewModel  API
    public bool AssociationRoleEditable { get; private set; }
    public AssociationRole AssociationRole
    {
      get
      {
        return MessageHandlerConfigurationWrapper.AssociationRole;
      }
      set
      {
        if (value == MessageHandlerConfigurationWrapper.AssociationRole)
          return;
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
    }
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
      get
      {
        return b_Title;
      }
      set
      {
        SetProperty<string>(ref b_Title, value);
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
    private string b_Title;
    private IMessageHandlerConfigurationWrapper b_MessageHandlerConfigurationWrapper;
    private IEnumerable<AssociationCouplerViewModel> b_AssociationCouplersEnumerator;
    #endregion

  }
}