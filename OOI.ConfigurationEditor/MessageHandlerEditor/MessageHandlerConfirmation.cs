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

    #region creators
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageHandlerConfirmation"/> class.
    /// </summary>
    /// <param name="enumerator">The enumerator.</param>
    internal MessageHandlerConfirmation(Func<IMessageHandlerConfigurationWrapper, AssociationCouplerViewModel[]> enumerator) :
      this(MessageReaderConfigurationWrapper.CreateDefault(), enumerator, true)
    { }
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageHandlerConfirmation"/> class.
    /// </summary>
    /// <param name="wrapper">The wrapper.</param>
    /// <param name="enumerator">The enumerator.</param>
    /// <param name="associationRoleEditable">if set to <c>true</c> [association role editable].</param>
    internal MessageHandlerConfirmation(IMessageHandlerConfigurationWrapper wrapper, Func<IMessageHandlerConfigurationWrapper, AssociationCouplerViewModel[]> enumerator, bool associationRoleEditable)
    {
      b_MessageHandlerConfigurationWrapper = wrapper;
      m_AssociationCouplerViewModelEnumeratorFunc = enumerator;
      AssociationCouplersEnumerator = m_AssociationCouplerViewModelEnumeratorFunc(wrapper);
      AssociationRoleSelectorControlViewModel = new Controls.AssociationRoleSelectorControlViewModel(CreateDefault, MessageHandlerConfigurationWrapper.TransportRole, associationRoleEditable);
    }
    #endregion

    #region ViewModel  API
    /// <summary>
    /// Gets the association role selector control view model.
    /// </summary>
    /// <value>The association role selector control view model.</value>
    public AssociationRoleSelectorControlViewModel AssociationRoleSelectorControlViewModel { get; }
    /// <summary>
    /// Gets or sets the message handler configuration wrapper.
    /// </summary>
    /// <value>The message handler configuration wrapper.</value>
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
    /// <summary>
    /// Gets or sets the association couplers enumerator.
    /// </summary>
    /// <value>The association couplers enumerator.</value>
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

    #region internal API
    /// <summary>
    /// Reverts this instance to the initial state.
    /// </summary>
    internal void Revert()
    {
      if (AssociationCouplersEnumerator == null)
        return;
      foreach (var _item in AssociationCouplersEnumerator)
        _item.Revert();
    }
    #endregion

    #region private
    //backing variables
    private IMessageHandlerConfigurationWrapper b_MessageHandlerConfigurationWrapper;
    private IEnumerable<AssociationCouplerViewModel> b_AssociationCouplersEnumerator;
    private Func<IMessageHandlerConfigurationWrapper, IEnumerable<AssociationCouplerViewModel>> m_AssociationCouplerViewModelEnumeratorFunc;
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