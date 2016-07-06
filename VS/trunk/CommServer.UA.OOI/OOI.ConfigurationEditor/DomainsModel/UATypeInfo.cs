//_______________________________________________________________
//  Title   : UATypeInfo
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

using System;
using System.Linq;
using Serialization = UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel
{
  public partial class UATypeInfo
  {
    public static implicit operator UATypeInfo(Serialization.UATypeInfo typeInfo)
    {
      UATypeInfo _newUATypeInfo = typeInfo == null ? null : new UATypeInfo()
      {
        ArrayDimensions = typeInfo.ArrayDimensions == null ? null : typeInfo.ArrayDimensions.Select<int, int>(x => x).ToArray<int>(),
        BuiltInType = (BuiltInType)Convert.ToUInt16(typeInfo.BuiltInType),
        TypeName = typeInfo.TypeName == null ? null : new System.Xml.XmlQualifiedName(typeInfo.TypeName.Name, typeInfo.TypeName.Namespace),
        ValueRank = typeInfo.ValueRank
      };
      return _newUATypeInfo;
    }
    internal Serialization.UATypeInfo Clone()
    {
      Serialization.UATypeInfo _newUATypeInfo = new Serialization.UATypeInfo((Serialization.BuiltInType)Convert.ToUInt16(BuiltInType), ValueRank, ArrayDimensions.Select<int, int>(x => x).ToArray<int>())
      {
        TypeName = new System.Xml.XmlQualifiedName(TypeName.Name, TypeName.Namespace),
      };
      return _newUATypeInfo;
    }
  }
}
