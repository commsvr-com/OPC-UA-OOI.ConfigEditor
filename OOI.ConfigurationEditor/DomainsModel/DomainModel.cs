//_______________________________________________________________
//  Title   : Name of Application
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

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel
{
  /// <summary>
  /// Class DomainModel - domain description holder. 
  /// </summary>
  /// <remarks>
  /// Domain is a collection of data over which an owner has control. It may be used to describe:
  /// * a collection of package addresses used to push the message to the receiver.
  /// * a collection of data used to provide data semantic unique identifier and support subscription to receive copies of the data as the message payload based on the data semantics.
  /// </remarks>
  public class DomainModel
  {

    #region API
    /// <summary>
    /// Gets or sets the name of the alias.
    /// </summary>
    /// <value>The name of the alias.</value>
    public string AliasName
    {
      get
      {
        return b_AliasName;
      }
      set
      {
        b_AliasName = value;
      }
    }
    /// <summary>
    /// Gets or sets the URI of the domain.
    /// </summary>
    /// <value>The URI.</value>
    public Uri URI
    {
      get
      {
        return b_URI;
      }
      set
      {
        b_URI = value;
      }
    }
    /// <summary>
    /// Gets or sets the unique name of the domain.
    /// </summary>
    /// <value>The name of the unique.</value>
    public Guid UniqueName
    {
      get
      {
        return b_UniqueName;
      }
      set
      {
        b_UniqueName = value;
      }
    }
    /// <summary>
    /// Gets or sets the description of the domain.
    /// </summary>
    /// <value>The description.</value>
    public string Description
    {
      get
      {
        return b_Description;
      }
      set
      {
        b_Description = value;
      }
    }

    /// <summary>
    /// Gets or sets the array of <see cref="SemanticsDataIndex"/> items belonging to this domain.
    /// </summary>
    /// <value>Returns the array <see cref="SemanticsDataIndex"/> items belonging to this domain.</value>
    public SemanticsDataIndex[] SemanticsDataCollection
    {
      get { return b_SemanticsDataCollection; }
      set { b_SemanticsDataCollection = value; }
    }
    #endregion

    #region private backing fields
    private string b_AliasName;
    private Uri b_URI;
    private Guid b_UniqueName;
    private string b_Description;
    private SemanticsDataIndex[] b_SemanticsDataCollection;
    #endregion

  }
}
