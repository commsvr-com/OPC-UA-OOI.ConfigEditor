﻿//_______________________________________________________________
//  Title   : AssociationConfigurationWrapper
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

using CAS.CommServer.UA.OOI.ConfigurationEditor.mvvm;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  internal class AssociationConfigurationWrapper<type> : Bindable, IWrapper<type>
      where type : AssociationConfiguration
  {

    public AssociationConfigurationWrapper(type configuration)
    {
      Item = configuration;
    }
    public string AssociationName
    {
      get { return Item.AssociationName; }
      set { AssignProperty<string>(x => Item.AssociationName = x, value); }
    }
    public ushort DataSetWriterId
    {
      get { return Item.DataSetWriterId; }
      set { AssignProperty<ushort>(x => Item.DataSetWriterId = x, value); }
    }
    public type Item { get; set; }

  }
}
