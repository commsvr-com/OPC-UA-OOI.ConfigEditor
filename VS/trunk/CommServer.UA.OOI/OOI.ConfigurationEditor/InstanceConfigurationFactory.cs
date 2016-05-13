﻿
using CAS.UA.IServerConfiguration;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.ComponentModel.Composition;
using System.Linq;
using UAOOI.Configuration.DataBindings;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UAOOI.ConfigurationEditor
{
  [Export(typeof(IInstanceConfigurationFactory))]
  public class InstanceConfigurationFactory : IInstanceConfigurationFactory
  {
    /// <summary>
    /// Gets an object providing <see cref="T:CAS.UA.IServerConfiguration.IInstanceConfiguration" /> interface which is to be displayed in the main editor window.
    /// </summary>
    /// <param name="dataSet">The object <see cref="T:UAOOI.Configuration.Networking.Serialization.DataSetConfiguration" /> to be edited.</param>
    /// <param name="availableHandlers">The available handlers that can be associated with the <paramref name="dataSet" />.</param>
    /// <param name="trace">The delegate encapsulating the trace operation.</param>
    /// <param name="onModification">The delegate encapsulating operation used to notify the caller about data modification.</param>
    /// <returns>IInstanceConfiguration.</returns>
    public IInstanceConfiguration GetIInstanceConfiguration(DataSetConfiguration dataSet, ObservableCollection<MessageHandlerConfiguration> availableHandlers, TraceEvent trace, Action onModification)
    {
      return new InstanceConfiguration(dataSet, availableHandlers, trace, onModification);
    }
    private class InstanceConfiguration : IInstanceConfiguration, INotifyPropertyChanged
    {

      public InstanceConfiguration(DataSetConfiguration dataSet, ObservableCollection<MessageHandlerConfiguration> availableHandlers, TraceEvent trace, Action onModification)
      {
        AvailableMessageHandlers = availableHandlers;
        AssociatedMessageHandlers = new ObservableCollection<MessageHandlerConfiguration>(availableHandlers.Where<MessageHandlerConfiguration>(x => x.Associated(dataSet.AssociationName)).ToArray<MessageHandlerConfiguration>());
        DataSetConfiguration = dataSet;
        PropertyChanged += (x, y) => onModification();
      }
      /// <summary>
      /// Occurs when a property value changes.
      /// </summary>
      public event PropertyChangedEventHandler PropertyChanged;

      #region IInstanceConfiguration
      public void ClearConfiguration()
      {
        throw new NotImplementedException("ClearConfiguration for IInstanceConfigurations is not implemented yet");
        //MessageBox.Show("ClearConfiguration for IInstanceConfigurations is not implemented yet", "Library functionality", MessageBoxButton.OK, MessageBoxImage.Question);
      }
      public void Edit()
      {
        throw new NotImplementedException("Edit for IInstanceConfigurations is not implemented yet");
        //MessageBox.Show("Edit for IInstanceConfigurations is not implemented yet", "Library functionality", MessageBoxButton.OK, MessageBoxImage.Question);
      }
      #endregion

      #region properties for view interface
      [DisplayName("Available Handlers")]
      [Description("Available massage handlers collection - use the provided row editor to add, remove or modify available data sources.")]
      [Category("Message Handlers")]
      [ReadOnly(false)]
      [TypeConverterAttribute(typeof(CollectionConverter))]
      public ObservableCollection<MessageHandlerConfiguration> AvailableMessageHandlers { get; set; }
      [DisplayName("Associated Handlers")]
      [Description("Associated massage handlers collection - use the provided row editor to add, remove or modify available data sources.")]
      [Category("Message Handlers")]
      [ReadOnly(true)]
      [TypeConverterAttribute(typeof(CollectionConverter))]
      public ObservableCollection<MessageHandlerConfiguration> AssociatedMessageHandlers { get; set; }
      [DisplayName("DataSet")]
      [Description("Selected node DataSet that is to be used by a process data binding manager at run time to couple the instantiated object with the message centric communication.")]
      [Category("Data Set")]
      [ReadOnly(false)]
      [NotifyParentProperty(true)]
      [TypeConverterAttribute(typeof(ExpandableObjectConverter))]
      public DataSetConfiguration DataSetConfiguration { get; set; }
      public override string ToString()
      {
        return $"Configuration of: {DataSetConfiguration} associated with {String.Join(", ", AssociatedMessageHandlers.Select<MessageHandlerConfiguration, string>(x => x.Name))}";
      }
      #endregion

    }

  }
}
