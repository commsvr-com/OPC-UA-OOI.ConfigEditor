//_______________________________________________________________
//  Title   : MessageHandlersListViewModel
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
using CAS.CommServer.UA.OOI.ConfigurationEditor.mvvm;
using CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel;
using CAS.Windows.Controls;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using Prism.Logging;
using System;
using System.ComponentModel.Composition;
using System.Windows.Input;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.MessageHandlerEditor
{
  [Export(typeof(MessageHandlersListViewModel))]
  internal class MessageHandlersListViewModel : Bindable
  {

    [ImportingConstructor()]
    public MessageHandlersListViewModel(IAssociationServices associationServices, IMessageHandlerServices messageHandlerServices, ILoggerFacade loggerFacade)
    {
      HeaderInfo = Properties.Resources.MessageHandlersListPanelHeader;
      MessageHandlesList = messageHandlerServices.GetMessageHandlers();
      m_AssociationServices = associationServices;
      m_MessageHandlerServices = messageHandlerServices;
      m_loggerFacade = loggerFacade;
      this.RemoveCommand = new DelegateCommand<string>(this.RemoveCommandHandler);
      Action[] m_ButtonsActions = new Action[] { AddCommandHandler, EditCommandHandler, RemoveSelectedCommandHandler, () => { } };
      ButtonsPanelViewModel = new ButtonsViewModel("Add", "Edit", "Delete", "", m_ButtonsActions);
      SetCanExecuteButtonState();
      loggerFacade.Log($"Created {nameof(MessageHandlersListViewModel)}", Category.Debug, Priority.Low);
    }


    public MessageHandlerConfigurationCollection MessageHandlesList
    {
      get { return b_MessageHandlesList; }
      set { base.SetProperty<MessageHandlerConfigurationCollection>(ref b_MessageHandlesList, value); }
    }
    public IMessageHandlerConfigurationWrapper CurrentMessageHandler
    {
      get { return b_CurrentMessageHandler; }
      set
      {
        if (!base.SetProperty<IMessageHandlerConfigurationWrapper>(ref b_CurrentMessageHandler, value))
          return;
        SetCanExecuteButtonState();
      }
    }
    public ButtonsViewModel ButtonsPanelViewModel { get; private set; }
    public string HeaderInfo { get; private set; }
    public ICommand RemoveCommand { get; private set; }
    public IInteractionRequest AddRequest { get { return b_AddRequest; } }
    public IInteractionRequest EditRequest { get { return b_EditRequest; } }

    //vars
    private readonly IAssociationServices m_AssociationServices;
    private IMessageHandlerServices m_MessageHandlerServices;
    private readonly ILoggerFacade m_loggerFacade;
    //backing fields
    private MessageHandlerConfigurationCollection b_MessageHandlesList;
    private IMessageHandlerConfigurationWrapper b_CurrentMessageHandler;
    private readonly InteractionRequest<IConfirmation> b_AddRequest = new InteractionRequest<IConfirmation>();
    private readonly InteractionRequest<IConfirmation> b_EditRequest = new InteractionRequest<IConfirmation>();
    //methods
    private void SetCanExecuteButtonState()
    {
      bool _selectedOne = CurrentMessageHandler != null;
      this.ButtonsPanelViewModel.SetCanExecuteState(true, _selectedOne, _selectedOne, false);
    }
    //handlers
    private void AddCommandHandler()
    {
      MessageReaderConfigurationWrapper _wrapper = MessageReaderConfigurationWrapper.CreateDefault();
      MessageHandlerConfirmation _confirmation = new MessageHandlerConfirmation(_wrapper, m_AssociationServices.GetAssociationCouplerViewModelEnumerator, true) { Title = "New Message Handler" };
      bool _confirmed = false;
      b_AddRequest.Raise(_confirmation, x => { _confirmed = x.Confirmed; });
      if (_confirmed)
        m_MessageHandlerServices.AddMessageHandler(_confirmation.MessageHandlerConfigurationWrapper);
      else
        _confirmation.Revert();
    }
    private void EditCommandHandler()
    {
      if (CurrentMessageHandler == null) //double check
        return;
      MessageHandlerConfirmation _confirmation = new MessageHandlerConfirmation(CurrentMessageHandler, m_AssociationServices.GetAssociationCouplerViewModelEnumerator, false) { Title = "New Message Handler" };
      bool _confirmed = false;
      b_AddRequest.Raise(_confirmation, x => { _confirmed = x.Confirmed; });
      if (!_confirmed)
        _confirmation.Revert();
    }
    private void RemoveCommandHandler(string title)
    {
      if (!m_MessageHandlerServices.Exist(title))
        return;
      this.m_MessageHandlerServices.Remove(title);
    }
    private void RemoveSelectedCommandHandler()
    {
      if (CurrentMessageHandler == null) //double check
        return;
      this.m_MessageHandlerServices.Remove(CurrentMessageHandler);
    }

  }
}
