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

using System;
using System.Linq;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  public class DataSetConfigurationWrapper : Wrapper<DataSetConfiguration>
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="DataSetConfigurationWrapper" /> class using empty <see cref="DataSetConfiguration" />.
    /// </summary>
    /// <param name="configurationItem">The original <see cref="DataSetConfiguration"/>configuration item.</param>
    public DataSetConfigurationWrapper(DataSetConfiguration configurationItem) : base(configurationItem)
    {
      DataSet = new FieldMetaDataCollection(configurationItem.DataSet);
    }

    #region ViewModel
    public string AssociationName
    {
      get { return base.Item.AssociationName; }
      set { base.SetProperty<string>(base.Item.AssociationName, x => base.Item.AssociationName = x, value); }
    }
    public AssociationRole AssociationRole
    {
      get { return base.Item.AssociationRole; }
      set { base.SetProperty<AssociationRole>(base.Item.AssociationRole, x => base.Item.AssociationRole = x, value); }
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
          (x => base.Item.ConfigurationVersion = new ConfigurationVersionDataType() { MajorVersion = x.MajorVersion, MinorVersion = x.MinorVersion }, value);
      }
    }
    public FieldMetaDataCollection DataSet { get; private set; }
    public string SymbolicName
    {
      get { return base.Item.DataSymbolicName; }
      set
      {
        if (base.SetProperty<string>(base.Item.DataSymbolicName, x => base.Item.DataSymbolicName = x, value))
          DefaultDataSetWriterId = GetDefaultDataSetWriterId();
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
        AssociationRole = AssociationRole.Consumer,
        ConfigurationGuid = Guid.NewGuid(),
        ConfigurationVersion = ConfigurationVersionDataTypeWrapper.CreateDefault(),
        DataSet = new FieldMetaDataCollection(new FieldMetaData[] { }),
        Id = Guid.NewGuid(),
        InformationModelURI = "wwww.tempuri.com",
        MaxBufferTime = -1,
        PublishingInterval = -1,
        RepositoryGroup = $"RepositoryGroup{m_UniqueNameId++}",
        SymbolicName = $"SymbolicName{m_UniqueNameId++}"
      };
    }

    #region Wrapper<DataSetConfiguration>
    public override DataSetConfiguration Item
    {
      get
      {
        base.Item.DataSet = DataSet.Select<FieldMetaDataWrapper, FieldMetaData>(wrapper => wrapper.Item).ToArray<FieldMetaData>();
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

    //private
    private DataSetConfigurationWrapper() : base(new DataSetConfiguration()) { }
    private static int m_UniqueNameId = Convert.ToInt32(new Random().NextDouble() * int.MaxValue);
    private ushort b_DefaultDataSetWriterId;
    private ushort GetDefaultDataSetWriterId()
    {
      int _hashLong = Math.Abs(SymbolicName.GetHashCode());
      DefaultDataSetWriterId = Convert.ToUInt16(_hashLong < ushort.MaxValue ? _hashLong : _hashLong / ushort.MaxValue);
      return DefaultDataSetWriterId;
    }
  }

}