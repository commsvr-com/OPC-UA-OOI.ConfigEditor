//_______________________________________________________________
//  Title   : StructuredTypeFieldWrapper
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
using System.Xml;
using UAOOI.DataDiscovery.DiscoveryServices.Models;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel
{
  public class StructuredTypeFieldWrapper : Wrapper<StructuredTypeField>
  {

    public StructuredTypeFieldWrapper(StructuredTypeField item) : base(item) { }
    public string Name
    {
      get
      {
        return Item.Name;
      }
      set
      {
        SetProperty<string>(Item.Name, x => Item.Name = x, value);
      }
    }
    public XmlQualifiedName TypeName
    {
      get
      {
        return Item.TypeName;
      }
      set
      {
        SetProperty<XmlQualifiedName>(Item.TypeName, x => Item.TypeName = x, value);
      }
    }
    public string SwitchField
    {
      get
      {
        return Item.SwitchField;
      }
      set
      {
        SetProperty<string>(Item.SwitchField, x => Item.SwitchField = x, value);
      }
    }
    public uint? SwitchValue
    {
      get
      {
        return Item.SwitchValueSpecified ? Item.SwitchValue : new Nullable<uint>();
      }
      set
      {
        SetProperty<uint?>(Item.SwitchValue, x => { Item.SwitchValue = x.GetValueOrDefault(0); Item.SwitchValueSpecified = value.HasValue; }, value);
      }
    }
    public SwitchOperand? SwitchOperand
    {
      get
      {
        return Item.SwitchOperand;
      }
      set
      {
        SetProperty<SwitchOperand?>(Item.SwitchOperand, x => { Item.SwitchOperand = x.GetValueOrDefault(UAOOI.DataDiscovery.DiscoveryServices.Models.SwitchOperand.Equals); Item.SwitchOperandSpecified = x.HasValue; }, value);
      }
    }

  }

}

