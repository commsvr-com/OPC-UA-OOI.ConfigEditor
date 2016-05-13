using CAS.CommServer.UA.OOI.ConfigurationEditor.mvvm;
using Prism.Commands;
using Prism.Interactivity.InteractionRequest;
using System;
using System.Windows.Input;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DataSetEditor.DataSetList
{
  internal class DataSetItemViewModel : Bindable, IInteractionRequestAware
  {

    public DataSetItemViewModel()
    {
      OKButtonCommand = new DelegateCommand(AcceptInteraction);
      CancelCommand = new DelegateCommand(CancelInteraction);
    }

    #region IInteractionRequestAware
    public Action FinishInteraction
    {
      get; set;
    }
    public INotification Notification
    {
      get
      {
        return b_Notification;
      }
      set
      {
        if (SetProperty<INotification>(ref b_Notification, value))
          m_DataSetItemConfirmation = value as DataSetItemConfirmation;
      }
    }
    #endregion

    public ICommand OKButtonCommand { get; private set; }
    public ICommand CancelCommand { get; private set; }

    #region private
    private INotification b_Notification;
    private DataSetItemConfirmation m_DataSetItemConfirmation;
    private void CancelInteraction()
    {
      this.m_DataSetItemConfirmation.Confirmed = false;
      this.FinishInteraction();
    }
    private void AcceptInteraction()
    {
      if (this.m_DataSetItemConfirmation == null)
        return;
      this.m_DataSetItemConfirmation.Confirmed = true;
      this.FinishInteraction();
    }
    #endregion

  }
}
