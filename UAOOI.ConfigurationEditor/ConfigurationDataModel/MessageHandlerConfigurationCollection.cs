//_______________________________________________________________
//  Title   : Name of Application
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate:  $
//  $Rev: $
//  $LastChangedBy: $
//  $URL: $
//  $Id:  $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Linq;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.ConfigurationDataModel
{
  [Export]
  internal class MessageHandlerConfigurationCollection : ObservableCollection<IMessageHandlerConfigurationWrapper>
  {

    [ImportingConstructor]
    internal MessageHandlerConfigurationCollection(ConfigurationDataRepository repository)
    {
      m_Repository = repository;
      foreach (MessageHandlerConfiguration _configurationItem in m_Repository.ConfigurationData.MessageHandlers)
        if (_configurationItem is MessageReaderConfiguration)
          this.Add(new MessageReaderConfigurationWrapper((MessageReaderConfiguration)_configurationItem));
        else
          this.Add(new MessageWriterConfigurationWrapper((MessageWriterConfiguration)_configurationItem));
    }
    /// <summary>
    /// Removes the specified title.
    /// </summary>
    /// <param name="title">The title.</param>
    /// <exception cref="System.Collections.Generic.KeyNotFoundException"> No <see cref="IMessageHandlerConfigurationWrapper.Name"/> of collection items is equal <paramref name="title"/>.</exception>
    internal void Remove(string title)
    {
      IMessageHandlerConfigurationWrapper _wrapper = this.Where<IMessageHandlerConfigurationWrapper>(wrapper => wrapper.Name == title).FirstOrDefault<IMessageHandlerConfigurationWrapper>();
      if (_wrapper == null)
        throw new KeyNotFoundException($"{nameof(title)} cannot be found in the collection");
      this.Remove(_wrapper);
    }
    internal bool Exists(string title)
    {
      return this.Where<IMessageHandlerConfigurationWrapper>(wrapper => wrapper.Name == title).Any<IMessageHandlerConfigurationWrapper>();
    }

    private ConfigurationDataRepository m_Repository;

  }
}
