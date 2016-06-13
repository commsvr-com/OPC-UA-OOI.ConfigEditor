//_______________________________________________________________
//  Title   : DomainsWrapper
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate: 2016-06-11 21:25:44 +0200 (So, 11 cze 2016) $
//  $Rev: 12228 $
//  $LastChangedBy: mpostol $
//  $URL: svn://svnserver.hq.cas.com.pl/VS/trunk/CommServer.UA.OOI/OOI.ConfigurationEditor/ViewModel/DomainWrapper.cs $
//  $Id: DomainWrapper.cs 12228 2016-06-11 19:25:44Z mpostol $
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
  /// Class DomainWrapper - provides ViewModel to edit <see cref="DomainModel"/> instances
  /// </summary>
  /// <seealso cref="Wrapper{DomainModel}"/>
  public class DomainWrapper : Wrapper<DomainModel>
  {

    #region creator
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainWrapper"/> class.
    /// </summary>
    /// <param name="item">The item.</param>
    internal DomainWrapper(DomainsModel.DomainModel item) : base(item) { }
    #endregion

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

    #region override
    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    public override string ToString()
    {
      return this.URI.ToString();
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
