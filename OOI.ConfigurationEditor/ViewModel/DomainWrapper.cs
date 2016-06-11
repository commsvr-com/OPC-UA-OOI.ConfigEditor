//_______________________________________________________________
//  Title   : DomainsWrapper
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
using CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel;
using System;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel
{
  /// <summary>
  /// Class DomainWrapper - provides ViewModel to edit <see cref="DomainModel"/> instances
  /// </summary>
  /// <seealso cref="Wrapper{DomainModel}"/>
  public class DomainWrapper : Wrapper<DomainModel>
  {

    internal DomainWrapper(DomainsModel.DomainModel item) : base(item) { }

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
        SetProperty<string>(ref b_AliasName, value);
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
        SetProperty<Uri>(ref b_URI, value);
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
        SetProperty<Guid>(ref b_UniqueName, value);
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
        SetProperty<string>(ref b_Description, value);
      }
    }
    #endregion

    #region private
    private string b_AliasName;
    private Uri b_URI;
    private Guid b_UniqueName;
    private string b_Description;
    #endregion

  }
}
