
//_______________________________________________________________
//  Title   : SemanticsDataIndex
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

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel
{
  /// <summary>
  /// Class SemanticsDataId - identifier unique in context of the selected domain
  /// </summary>
  [Serializable]
  public class SemanticsDataIndex
  {

    #region API
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
    /// Gets or sets the index of the data in context of the domain. Index is used to replace the symbolic name with the purpose of optimization of the data transfer.
    /// </summary>
    /// <value>The data index.</value>
    public UInt16 Index
    {
      get { return b_Index; }
      set { b_Index = value; }
    }
    #endregion

    #region private
    private string b_SymbolicName;
    private UInt16 b_Index;
    #endregion

  }
}
