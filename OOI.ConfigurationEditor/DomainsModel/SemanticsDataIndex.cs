
using System;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel
{
  /// <summary>
  /// Class SemanticsDataId - identifier unique in context of the selected domain
  /// </summary>
  [Serializable]
  public class SemanticsDataIndex
  {

    /// <summary>
    /// Gets or sets the data symbolic name.
    /// </summary>
    /// <remarks>
    /// Each Semantic data belongs to the only one domain and must have symbolic name unique in context of the domain.
    /// </remarks>
    /// <value>Return the data symbolic name.</value>
    public string SymbolicName
    {
      get { return b_SymbolicName; }
      set { b_SymbolicName = value; }
    }
    /// <summary>
    /// Gets or sets the index of the data in context of the domai. Index is used to replace the symbolic name with the purpose of optimization of the data transfer..
    /// </summary>
    /// <value>The data index.</value>
    public UInt16 Index
    {
      get { return b_Index; }
      set { b_Index = value; }
    }

    private string b_SymbolicName;
    private UInt16 b_Index;

  }
}
