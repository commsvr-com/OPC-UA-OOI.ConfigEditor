//_______________________________________________________________
//  Title   : DataSetConfigurationCollection
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

using Prism.Logging;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Linq;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  /// <summary>
  /// Class DataSetConfigurationCollection.
  /// </summary>
  /// <seealso cref="ObservableCollection{DataSetConfigurationWrapper}" />
  /// <seealso cref="IDataSetConfigurationCollection" />
  /// <seealso cref="IWarningsContainer" />
  [Export]
  [PartCreationPolicy(CreationPolicy.Shared)]
  internal class DataSetConfigurationCollection : ObservableCollection<DataSetConfigurationWrapper>, IDataSetConfigurationCollection, IWarningsContainer
  {

    #region creator
    [ImportingConstructor()]
    public DataSetConfigurationCollection(ConfigurationDataRepository configurationDataRepository, ILoggerFacade logger)
    {
      m_Repository = configurationDataRepository;
      m_Logger = logger;
      logger.Log($"Enering DataSetConfigurationCollection", Category.Info, Priority.None);
      this.CollectionChanged += DataSetConfigurationCollection_CollectionChanged;
      foreach (DataSetConfiguration _configurationItem in m_Repository.ConfigurationData.DataSets)
      {
        Warning _warning = null;
        if (string.IsNullOrEmpty(_configurationItem.DataSymbolicName))
        {
          _configurationItem.DataSymbolicName = GetUniqueName("DataSymbolicName");
          _warning = new Warning($"{nameof(_configurationItem.DataSymbolicName)} cannot be null or empty; replaced by {_configurationItem.DataSymbolicName}", Category.Warn, Priority.High);
        }
        else if (m_StringDictionary.ContainsKey(_configurationItem.DataSymbolicName))
        {
          string _oldDataSymbolicName = _configurationItem.DataSymbolicName;
          _configurationItem.DataSymbolicName = GetUniqueName(_oldDataSymbolicName);
          _warning = new Warning($"The {nameof(_configurationItem.DataSymbolicName)} = {_oldDataSymbolicName} must be unique; replaced by {_configurationItem.DataSymbolicName}", Category.Warn, Priority.High);
        }
        if (_warning != null)
        {
          m_WarningsList.Add(_warning);
          logger.Log($"Configuration error: {_warning}", Category.Warn, Priority.Medium);
        }
        DataSetConfigurationWrapper _newDataSetConfigurationWrapper = new DataSetConfigurationWrapper(_configurationItem);
        this.Add(_newDataSetConfigurationWrapper);
      }
      logger.Log($"Finisching DataSetConfigurationCollection creation with {m_WarningsList.Count} warnings", Category.Info, Priority.None);
    }
    #endregion

    #region internal API
    internal bool DataSetExists(string dataSetIdentifier)
    {
      return this.Where<DataSetConfigurationWrapper>(x => x.SymbolicName == dataSetIdentifier).Any<DataSetConfigurationWrapper>();
    }
    internal void Remove(string symbolicName)
    {
      if (!m_StringDictionary.ContainsKey(symbolicName))
        return;
      DataSetConfigurationWrapper _itemToRemove = m_StringDictionary[symbolicName];
      this.Remove(_itemToRemove);
    }
    internal DataSetConfigurationWrapper this[string SymbolicName]
    {
      get { return m_StringDictionary[SymbolicName]; }
    }
    internal void CommitChanges()
    {
      if (!m_CollectionChanged)
        return;
      m_Repository.ConfigurationData.DataSets = this.Select<DataSetConfigurationWrapper, DataSetConfiguration>(x => x.Item).ToArray<DataSetConfiguration>();
    }
    #endregion

    #region IWarningsContainer
    public IEnumerable<Warning> WarningsEnumerable
    {
      get
      {
        return m_WarningsList;
      }
    }
    #endregion

    #region private
    private Dictionary<string, DataSetConfigurationWrapper> m_StringDictionary = new Dictionary<string, DataSetConfigurationWrapper>();
    private ConfigurationDataRepository m_Repository;
    private bool m_CollectionChanged = false;
    private ILoggerFacade m_Logger;
    private List<Warning> m_WarningsList = new List<Warning>();
    private string GetUniqueName(string namePrefix)
    {
      int _suffix = 0;
      string _ret = namePrefix;
      while (m_StringDictionary.ContainsKey(_ret))
        _ret = $"{namePrefix}{_suffix++}";
      return _ret;
    }
    private void DataSetConfigurationCollection_CollectionChanged(object sender, NotifyCollectionChangedEventArgs e)
    {
      m_CollectionChanged = true;
      if (e.NewItems != null)
        foreach (DataSetConfigurationWrapper _item in e.NewItems)
          m_StringDictionary.Add(_item.SymbolicName, _item);
      if (e.OldItems != null)
        foreach (DataSetConfigurationWrapper _item in e.OldItems)
          m_StringDictionary.Remove(_item.SymbolicName);
    }
    #endregion

  }
}
