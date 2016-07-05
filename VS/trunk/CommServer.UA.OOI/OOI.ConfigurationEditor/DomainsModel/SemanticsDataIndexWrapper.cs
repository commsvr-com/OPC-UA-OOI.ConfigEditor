
//_______________________________________________________________
//  Title   : SemanticsDataIndexWrapper
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

using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using System;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel
{

  /// <summary>
  /// Class SemanticsDataIndexWrapper - represents index of the DataSet inside the domain.
  /// </summary>
  /// <seealso cref="Wrapper{SemanticsDataIndex}" />
  public class SemanticsDataIndexWrapper : Wrapper<SemanticsDataIndex>
  {

    #region creator
    /// <summary>
    /// Initializes a new instance of the <see cref="SemanticsDataIndexWrapper"/> class.
    /// </summary>
    /// <param name="item">The item.</param>
    public SemanticsDataIndexWrapper(SemanticsDataIndex item) : base(item) { }
    #endregion

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
      get
      {
        return Item.SymbolicName;
      }
      set
      {
        SetProperty<string>(Item.SymbolicName, x => Item.SymbolicName = x, value);
      }
    }
    /// <summary>
    /// Gets or sets the index of the data in context of the domai. Index is used to replace the symbolic name with the purpose of optimization of the data transfer..
    /// </summary>
    /// <value>The data index.</value>
    public UInt16 Index
    {
      get { return Item.Index; }
      set { SetProperty(Item.Index, x => Item.Index = x, value); }
    }
    public FieldMetaDataCollection DataSet { get { return Item.DataSet; } }
    #endregion
    public override string ToString()
    {
      return $"{SymbolicName} / Index: {Index}";
    }

  }
}
