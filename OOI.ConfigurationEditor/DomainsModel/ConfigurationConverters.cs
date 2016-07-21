
using System;
using System.Linq;
using UAOOI.DataDiscovery.DiscoveryServices.Models;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel
{
  internal static class ConfigurationConverters
  {
    /// <summary>
    /// Performs an explicit conversion from <see cref="UAOOI.Configuration.Networking.Serialization.FieldMetaData"/> to <see cref="FieldMetaData"/>.
    /// </summary>
    /// <param name="fieldMetaData">The field meta data.</param>
    /// <returns>An instance of this type - the result of the conversion.</returns>
    public static FieldMetaData FieldMetaDataConvert(this UAOOI.Configuration.Networking.Serialization.FieldMetaData fieldMetaData)
    {
      FieldMetaData _ret = new FieldMetaData()
      {
        ExtensionData = null,
        ProcessValueName = fieldMetaData.ProcessValueName,
        SymbolicName = fieldMetaData.SymbolicName,
        TypeInformation = fieldMetaData.TypeInformation.UATypeInfoConvert()
      };
      return _ret;
    }
    /// <summary>
    /// Clones this instance.
    /// </summary>
    /// <returns>An instance of the <see cref="UAOOI.Configuration.Networking.Serialization.FieldMetaData"/> derived from this instance.</returns>
    public static UAOOI.Configuration.Networking.Serialization.FieldMetaData FieldMetaDataConvert(this FieldMetaData value)
    {
      UAOOI.Configuration.Networking.Serialization.FieldMetaData _ret = new UAOOI.Configuration.Networking.Serialization.FieldMetaData()
      {
        ExtensionData = null,
        ProcessValueName = value.ProcessValueName,
        SymbolicName = value.SymbolicName,
        TypeInformation = value.TypeInformation == null ? null : value.TypeInformation.UATypeInfoConvert()
      };
      return _ret;
    }
    /// <summary>
    /// Performs an implicit conversion from <see cref="UAOOI.Configuration.Networking.Serialization.UATypeInfo"/> to <see cref="UATypeInfo"/>.
    /// </summary>
    /// <param name="typeInfo">The type information.</param>
    /// <returns>The result of the conversion.</returns>
    public static UATypeInfo UATypeInfoConvert(this UAOOI.Configuration.Networking.Serialization.UATypeInfo typeInfo)
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
    /// <summary>
    /// Clones this instance and factor the object of <see cref="UAOOI.Configuration.Networking.Serialization.UATypeInfo"/>.
    /// </summary>
    /// <returns>An instance of the <see cref="UAOOI.Configuration.Networking.Serialization.UATypeInfo"/> derived from this instance.</returns>
    public static UAOOI.Configuration.Networking.Serialization.UATypeInfo UATypeInfoConvert(this UATypeInfo value)
    {
      UAOOI.Configuration.Networking.Serialization.UATypeInfo _newUATypeInfo = new UAOOI.Configuration.Networking.Serialization.UATypeInfo(value.BuiltInType.ToBuiltInType(),
                                                                              value.ValueRank,
                                                                              value.ArrayDimensions == null ? null : value.ArrayDimensions.Select<int, int>(x => x).ToArray<int>())
      {
        TypeName = value.TypeName == null ? null : new System.Xml.XmlQualifiedName(value.TypeName.Name, value.TypeName.Namespace),
      };
      return _newUATypeInfo;

    }
    private static UAOOI.Configuration.Networking.Serialization.BuiltInType ToBuiltInType(this BuiltInType value)
    {
      return (UAOOI.Configuration.Networking.Serialization.BuiltInType)Convert.ToUInt16(value);
    }

  }
}
