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
using CAS.CommServer.UA.OOI.ConfigurationEditor.Services;
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

  /// <summary>
  /// Class MessageHandlersListViewModel - view model used as the interface to access the data by the GUI.
  /// </summary>
  /// <seealso cref="Prism.Mvvm.BindableBase" />
  [Export(typeof(MessageHandlersListViewModel))]
  internal class MessageHandlersListViewModel : MainRegionViewModel
  {

    #region Importing Constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageHandlersListViewModel"/> class.
    /// </summary>
    /// <param name="associationServices">The association services.</param>
    /// <param name="messageHandlerServices">The message handler services.</param>
    /// <param name="loggerFacade">The logger services.</param>
    [ImportingConstructor()]
    public MessageHandlersListViewModel(IAssociationServices associationServices, IMessageHandlerServices messageHandlerServices, ILoggerFacade loggerFacade) :
      base(Properties.Resources.MessageHandlersListPanelHeader)
    {
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
    #endregion

    #region GUI API
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
    public ICommand RemoveCommand { get; private set; }
    public IInteractionRequest AddRequest { get { return b_AddRequest; } }
    public IInteractionRequest EditRequest { get { return b_EditRequest; } }
    /// <summary>
    /// Gets or sets the buttons panel view model.
    /// </summary>
    /// <value>The buttons panel view model <see cref="ButtonsViewModel" />.</value>
    public override ButtonsViewModel ButtonsPanelViewModel
    {
      get; protected set;
    }
    #endregion

    #region private
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
      MessageHandlerConfirmation _confirmation = new MessageHandlerConfirmation(m_AssociationServices.GetAssociationCouplerViewModelEnumerator) { Title = "New Message Handler" };
      bool _confirmed = false;
      b_AddRequest.Raise(_confirmation, x => _confirmed = x.Confirmed);
      if (_confirmed)
      {
        m_MessageHandlerServices.AddMessageHandler(_confirmation.MessageHandlerConfigurationWrapper);
        _confirmation.ApplyChanges();
      }
    }
    private void EditCommandHandler()
    {
      if (CurrentMessageHandler == null) //double check
        return;
      MessageHandlerConfirmation _confirmation = new MessageHandlerConfirmation(CurrentMessageHandler, m_AssociationServices.GetAssociationCouplerViewModelEnumerator, false) { Title = "Edit Message Handler" };
      bool _confirmed = false;
      b_AddRequest.Raise(_confirmation, x => _confirmed = x.Confirmed);
      if (_confirmed)
        _confirmation.ApplyChanges();
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
    #endregion

  }
}
