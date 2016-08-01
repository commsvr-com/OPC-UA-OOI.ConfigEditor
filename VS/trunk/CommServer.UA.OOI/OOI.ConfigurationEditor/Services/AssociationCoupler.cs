//_______________________________________________________________
//  Title   : AssociationCouple
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate: 2016-06-04 15:42:29 +0200 (So, 04 cze 2016) $
//  $Rev: 12225 $
//  $LastChangedBy: mpostol $
//  $URL: svn://svnserver.hq.cas.com.pl/VS/trunk/CommServer.UA.OOI/OOI.ConfigurationEditor/ViewModel/AssociationCoupler.cs $
//  $Id: AssociationCoupler.cs 12225 2016-06-04 13:42:29Z mpostol $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using System;
using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Services
{

  /// <summary>
  /// Class AssociationCoupler - provides functionality to manage the association between two entities.
  /// </summary>
  internal class AssociationCoupler
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="AssociationCoupler" /> class.
    /// </summary>
    /// <param name="existingAssociation">The existing association.</param>
    /// <param name="associate">The delegated to establish or remove association</param>
    /// <param name="title">The read only title of the association.</param>
    /// <param name="defaultAssociation">The association configuration wrapper.</param>
    public AssociationCoupler(IAssociationConfigurationWrapper existingAssociation, Action<bool, IAssociationConfigurationWrapper> associate, string title, IAssociationConfigurationWrapper defaultAssociation)
    {
      Associated = existingAssociation != null;
      m_Associate = associate;
      Title = title;
      AssociationWrapper = existingAssociation != null ? existingAssociation : defaultAssociation;
    }

    #region IAssociationCoupler
    /// <summary>
    /// Gets or sets a value indicating whether the parties are associated.
    /// </summary>
    /// <value><c>true</c> if associated; otherwise, <c>false</c>.</value>
    public bool Associated { get; }
    public IAssociationConfigurationWrapper AssociationWrapper { get; private set; }
    /// <summary>
    /// Gets the title of the association.
    /// </summary>
    /// <value>The title.</value>
    public string Title { get; }
    /// <summary>
    /// Applies the changes.
    /// </summary>
    /// <param name="associated">if set to <c>true</c> [associated].</param>
    public void ApplyChanges(bool associated)
    {
      m_Associate(associated, AssociationWrapper);
    }
    #endregion

    #region private
    private Action<bool, IAssociationConfigurationWrapper> m_Associate;
    #endregion

  }
}
