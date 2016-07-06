using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
    public Serialization.FieldMetaData Clone()
    { 
      Serialization.FieldMetaData _ret = new Serialization.FieldMetaData()
      {
        ExtensionData = null, 
        ProcessValueName = ProcessValueName,
        SymbolicName = SymbolicName,
        TypeInformation = TypeInformation.Clone()
      };
      return _ret;
    }
}
}
