//_______________________________________________________________
//  Title   : UATypeInfoWrapper
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

using System.Xml;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel
{
  public class UATypeInfoWrapper : Wrapper<UATypeInfo>
  {
    public UATypeInfoWrapper(UATypeInfo item) : base(item) { }
    public string ArrayDimensions
    {
      get { return base.Item.ArrayDimensions == null ? "scalar" : $"[ { string.Join(", ", base.Item.ArrayDimensions)} ]"; }
    }
    public BuiltInType BuiltInType { get { return Item.BuiltInType; } }
    public XmlQualifiedName TypeName { get { return Item.TypeName; } }
    public int ValueRank { get { return Item.ValueRank; } }

  }
}