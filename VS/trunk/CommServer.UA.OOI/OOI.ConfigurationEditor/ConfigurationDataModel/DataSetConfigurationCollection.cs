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

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Collections.Specialized;
using System.ComponentModel.Composition;
using System.Linq;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.ConfigurationDataModel
{
  [Export]
  [PartCreationPolicy(CreationPolicy.Shared)]
  internal class DataSetConfigurationCollection : ObservableCollection<DataSetConfigurationWrapper>, IDataSetConfigurationCollection
  {

    //creator
    [ImportingConstructor()]
    public DataSetConfigurationCollection(ConfigurationDataRepository configurationDataRepository)
    {
      m_Repository = configurationDataRepository;
      this.CollectionChanged += DataSetConfigurationCollection_CollectionChanged;
      foreach (DataSetConfiguration _configurationItem in m_Repository.ConfigurationData.DataSets)
      {
        if (string.IsNullOrEmpty(_configurationItem.DataSymbolicName))
          throw new System.ArgumentNullException($"{nameof(_configurationItem.DataSymbolicName)} cannot be null or empty");
        if (m_StringDictionary.ContainsKey(_configurationItem.DataSymbolicName))
          throw new System.ArgumentOutOfRangeException($"all symbolic names in the {nameof(m_Repository.ConfigurationData.DataSets)} must be unique");
        DataSetConfigurationWrapper _newDataSetConfigurationWrapper = new DataSetConfigurationWrapper(_configurationItem);
        this.Add(_newDataSetConfigurationWrapper);
      }
    }

    //internal API
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
      m_Repository.ConfigurationData.DataSets = this.Select<DataSetConfigurationWrapper, DataSetConfiguration>(x => x.DataSetConfiguration).ToArray<DataSetConfiguration>();
    }

    //private
    private Dictionary<string, DataSetConfigurationWrapper> m_StringDictionary = new Dictionary<string, DataSetConfigurationWrapper>();
    private ConfigurationDataRepository m_Repository;
    private bool m_CollectionChanged = false;
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

  }
}
