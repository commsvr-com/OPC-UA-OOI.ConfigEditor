//_______________________________________________________________
//  Title   : Name of Application
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

using CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel;
using System;
using System.Linq;
using UAOOI.DataDiscovery.DiscoveryServices.Models;
using Serialization = UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  public class DataSetConfigurationWrapper : Wrapper<Serialization.DataSetConfiguration>
  {

    #region creator
    /// <summary>
    /// Initializes a new instance of the <see cref="DataSetConfigurationWrapper" /> class using empty <see cref="DataSetConfiguration" />.
    /// </summary>
    /// <param name="configurationItem">The original <see cref="DataSetConfiguration"/>configuration item.</param>
    public DataSetConfigurationWrapper(Serialization.DataSetConfiguration configurationItem) : base(configurationItem)
    {
      DataSet = new FieldMetaDataCollection(configurationItem.DataSet.Select<Serialization.FieldMetaData, FieldMetaData>(x => x).ToArray<FieldMetaData>());
    }
    #endregion

    #region ViewModel
    public string AssociationName
    {
      get { return base.Item.AssociationName; }
      set { base.SetProperty<string>(base.Item.AssociationName, x => base.Item.AssociationName = x, value); }
    }
    public Serialization.AssociationRole AssociationRole
    {
      get { return base.Item.AssociationRole; }
      set { base.SetProperty<Serialization.AssociationRole>(base.Item.AssociationRole, x => base.Item.AssociationRole = x, value); }
    }
    public Guid ConfigurationGuid
    {
      get { return base.Item.ConfigurationGuid; }
      set { base.SetProperty<Guid>(base.Item.ConfigurationGuid, x => base.Item.ConfigurationGuid = x, value); }
    }
    public ConfigurationVersionDataTypeWrapper ConfigurationVersion
    {
      get { return new ConfigurationVersionDataTypeWrapper(base.Item.ConfigurationVersion); }
      set
      {
        base.SetProperty<ConfigurationVersionDataTypeWrapper>
          (x => base.Item.ConfigurationVersion = new Serialization.ConfigurationVersionDataType() { MajorVersion = x.MajorVersion, MinorVersion = x.MinorVersion }, value);
      }
    }
    public FieldMetaDataCollection DataSet
    {
      get
      {
        return b_DataSet;
      }
      set
      {
        SetProperty<FieldMetaDataCollection>(ref b_DataSet, value);
      }
    }
    public string SymbolicName
    {
      get { return base.Item.DataSymbolicName; }
      set
      {
        base.SetProperty<string>(base.Item.DataSymbolicName, x => base.Item.DataSymbolicName = x, value);
      }
    }
    public Guid Id
    {
      get
      {
        return base.Item.Id;
      }
      set
      {
        SetProperty<Guid>(String.IsNullOrEmpty(base.Item.Guid) ? Guid.Empty : base.Item.Id, x => base.Item.Id = x, value);
      }
    }
    public string InformationModelURI
    {
      get
      {
        return base.Item.InformationModelURI;
      }
      set
      {
        SetProperty<string>(base.Item.InformationModelURI, x => base.Item.InformationModelURI = x, value);
      }
    }
    public double MaxBufferTime
    {
      get { return base.Item.MaxBufferTime; }
      set { base.SetProperty<double>(base.Item.MaxBufferTime, x => base.Item.MaxBufferTime = x, value); }
    }
    public double PublishingInterval
    {
      get { return base.Item.PublishingInterval; }
      set { base.SetProperty<double>(base.Item.PublishingInterval, x => base.Item.PublishingInterval = x, value); }
    }
    public string PublishingIntervalToolTip { get { return Properties.Resources.PublishingIntervalToolTip; } }
    public string RepositoryGroup
    {
      get
      {
        return base.Item.RepositoryGroup;
      }
      set
      {
        SetProperty<string>(base.Item.RepositoryGroup, x => base.Item.RepositoryGroup = x, value);
      }
    }
    public ushort DefaultDataSetWriterId
    {
      get
      {
        return b_DefaultDataSetWriterId;
      }
      set
      {
        SetProperty<ushort>(ref b_DefaultDataSetWriterId, value);
      }
    }
    #endregion

    internal static DataSetConfigurationWrapper CreateDefault()
    {
      return new DataSetConfigurationWrapper()
      {
        AssociationName = $"AssociationName{m_UniqueNameId++}",
        AssociationRole = Serialization.AssociationRole.Consumer,
        ConfigurationGuid = Guid.NewGuid(),
        ConfigurationVersion = ConfigurationVersionDataTypeWrapper.CreateDefault(),
        DataSet = new FieldMetaDataCollection(new FieldMetaData[] { }),
        Id = Guid.NewGuid(),
        InformationModelURI = "wwww.tempuri.com",
        MaxBufferTime = -1,
        PublishingInterval = -1,
        RepositoryGroup = $"RepositoryGroup{m_UniqueNameId++}",
        SymbolicName = $"SymbolicName{m_UniqueNameId++}",
      };
    }
    internal void UpdateDataSet(DomainModelWrapper domainMode, SemanticsDataIndexWrapper selectedIndex, bool newVersion)
    {
      InformationModelURI = domainMode.URI.ToString();
      Id = domainMode.UniqueName;
      ConfigurationGuid = Guid.NewGuid();
      if (newVersion)
        ConfigurationVersion.IncrementMajorVersion();
      DataSet = CreateDataSet(selectedIndex);
      DefaultDataSetWriterId = Convert.ToUInt16(domainMode.SemanticsDataCollection.IndexOf(selectedIndex));
      MaxBufferTime = -1;
      RepositoryGroup = String.Empty;
      SymbolicName = selectedIndex.SymbolicName;
    }

    #region Wrapper<DataSetConfiguration>
    public override Serialization.DataSetConfiguration Item
    {
      get
      {
        base.Item.DataSet = DataSet.Select<FieldMetaDataWrapper, Serialization.FieldMetaData>(wrapper => wrapper.Item.Clone()).ToArray<Serialization.FieldMetaData>();
        return base.Item;
      }
    }
    #endregion

    #region override Object
    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    public override string ToString()
    {
      return $"DataSet {SymbolicName} with the {AssociationRole} role";
    }
    #endregion

    #region private
    private ushort b_DefaultDataSetWriterId;
    private FieldMetaDataCollection b_DataSet;
    private DataSetConfigurationWrapper() : base(new Serialization.DataSetConfiguration()) { }
    private static int m_UniqueNameId = Convert.ToInt32(new Random().NextDouble() * int.MaxValue);
    private FieldMetaDataCollection CreateDataSet(SemanticsDataIndexWrapper semanticsDataIndexWrapper)
    {
      FieldMetaData[] _fields = semanticsDataIndexWrapper.DataSet.Select<FieldMetaDataWrapper, FieldMetaData>(x => x.Item.Clone()).ToArray<FieldMetaData>();
      return new FieldMetaDataCollection(_fields);
    }
    #endregion

  }

}