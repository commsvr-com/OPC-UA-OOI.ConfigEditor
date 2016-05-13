
using CAS.CommServer.UAOOI.ConfigurationEditor.ConfigurationDataModel;
using Prism.Mvvm;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.MessageHandlerEditor
{
  public class MessageHandlerViewModel : BindableBase
  {


    internal MessageHandlerViewModel(IMessageHandlerConfigurationWrapper wrapper)
    {
      this.m_Wrapper = wrapper;
      Name = m_Wrapper.Name;
      AssociationRole = m_Wrapper.AssociationRole;
      MessageChannelConfiguration = m_Wrapper.MessageChannelConfiguration;

    }
    internal MessageChannelConfigurationWrapper MessageChannelConfiguration
    {
      get { return b_MessageChannelConfiguration; }
      set { SetProperty(ref b_MessageChannelConfiguration, value); }
    }
    internal AssociationRole AssociationRole
    {
      get { return b_AssociationRole; }
      set { SetProperty<AssociationRole>(ref b_AssociationRole, value); }
    }
    public string Name
    {
      get { return b_Name; }
      set { SetProperty<string>(ref b_Name, value); }
    }

    private MessageChannelConfigurationWrapper b_MessageChannelConfiguration;
    private AssociationRole b_AssociationRole;
    private string b_Name;
    private IMessageHandlerConfigurationWrapper m_Wrapper;

  }
}
