//_______________________________________________________________
//  Title   : FieldMetaData
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

using Serialization = UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel
{
  public partial class FieldMetaData
  {
    /// <summary>
    /// Performs an explicit conversion from <see cref="Serialization.FieldMetaData"/> to <see cref="FieldMetaData"/>.
    /// </summary>
    /// <param name="fieldMetaData">The field meta data.</param>
    /// <returns>The result of the conversion.</returns>
    public static implicit operator FieldMetaData(Serialization.FieldMetaData fieldMetaData)
    {
      FieldMetaData _ret = new FieldMetaData()
      {
        ExtensionData = null,
        ProcessValueName = fieldMetaData.ProcessValueName,
        SymbolicName = fieldMetaData.SymbolicName,
        TypeInformation = fieldMetaData.TypeInformation
      };
      return _ret;
    }
    internal Serialization.FieldMetaData Clone()
    {
      Serialization.FieldMetaData _ret = new Serialization.FieldMetaData()
      {
        ExtensionData = null,
        ProcessValueName = ProcessValueName,
        SymbolicName = SymbolicName,
        TypeInformation = TypeInformation == null ? null : TypeInformation.Clone()
      };
      return _ret;
    }
  }
}
