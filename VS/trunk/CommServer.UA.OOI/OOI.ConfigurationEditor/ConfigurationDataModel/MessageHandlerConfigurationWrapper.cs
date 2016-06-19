
//_______________________________________________________________
//  Title   : MessageHandlerConfigurationWrapper{type}
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

using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  /// <summary>
  /// Class MessageHandlerConfigurationWrapper.
  /// </summary>
  /// <typeparam name="type">The type of the handler.</typeparam>
  /// <seealso cref="CAS.CommServer.UA.OOI.ConfigurationEditor.Wrapper{type}" />
  /// <seealso cref="CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel.IMessageHandlerConfigurationIdentity" />
  /// <seealso cref="CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel.IMessageHandlerConfigurationWrapper" />
  public abstract class MessageHandlerConfigurationWrapper<type> : Wrapper<type>, IMessageHandlerConfigurationIdentity, IMessageHandlerConfigurationWrapper
    where type : MessageHandlerConfiguration
  {

    #region creator
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageHandlerConfigurationWrapper{type}"/> class.
    /// </summary>
    /// <param name="item">The configuration.</param>
    public MessageHandlerConfigurationWrapper(type item) : base(item) { }
    #endregion

    #region IMessageHandlerConfigurationIdentity
    /// <summary>
    /// Creates or removes association described by the parameter <paramref name="association" />.
    /// </summary>
    /// <param name="associate">if set to <c>true</c> the <paramref name="association" /> shall be added to the collection of associations.</param>
    /// <param name="association">The association instance of type <see cref="IAssociationConfigurationWrapper" /> to be added to the local collection.</param>
    public abstract void Associate(bool associate, IAssociationConfigurationWrapper association);
    /// <summary>
    /// Checks if the selected <paramref name="dataSet" /> is associated (handled) by this instance and returns
    /// description of this association as an instance of <see cref="IAssociationConfigurationWrapper" />.
    /// </summary>
    /// <param name="dataSet">The dataset to be checked against association.</param>
    /// <returns>If associated returns an instance of <see cref="IAssociationConfigurationWrapper" />.</returns>
    public abstract IAssociationConfigurationWrapper Check(DataSetConfigurationWrapper dataSet);
    /// <summary>
    /// Gets or sets the message channel (protocols stack) configuration.
    /// </summary>
    /// <value>The message channel configuration <see cref="MessageChannelConfigurationWrapper" />.</value>
    public MessageChannelConfigurationWrapper MessageChannelConfiguration
    {
      get { return new MessageChannelConfigurationWrapper(Item.Configuration); }
      set { SetProperty<MessageChannelConfigurationWrapper>(wrapper => Item.Configuration = wrapper.GetConfiguration(), value); }
    }
    /// <summary>
    /// Gets or sets the transport role of the handler. <see cref="AssociationRole.Consumer" /> is considered ans the reader (receiver),
    /// and <see cref="AssociationRole.Producer" /> is considered as the writer (transmitter).
    /// </summary>
    /// <value>The transport role <see cref="AssociationRole" />.</value>
    public AssociationRole TransportRole
    {
      get { return Item.TransportRole; }
      set { SetProperty<AssociationRole>(Item.TransportRole, x => Item.TransportRole = x, value); }
    }
    /// <summary>
    /// Gets or sets the name.
    /// </summary>
    /// <value>The name.</value>
    public string Name
    {
      get { return Item.Name; }
      set { SetProperty<string>(Item.Name, x => Item.Name = x, value); }
    }
    /// <summary>
    /// Gets all associations defined for this instance of .
    /// </summary>
    /// <returns>IAssociationConfigurationWrapper[].</returns>
    public abstract IAssociationConfigurationWrapper[] GetAssociations();
    #endregion

    #region override object 
    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    public override string ToString()
    {
      return $"Message Handler {Name} with {TransportRole} role";
    }
    #endregion

  }

}