//_______________________________________________________________
//  Title   : AssociationCouple
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

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel
{

  /// <summary>
  /// Class AssociationCoupler - provides functionality to manage the association between two entities.
  /// </summary>
  /// <seealso cref="CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel.IAssociationCoupler" />
  internal class AssociationCoupler : IAssociationCoupler
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="AssociationCoupler"/> class.
    /// </summary>
    /// <param name="check">The delegate to check if association is established already.</param>
    /// <param name="associate">The delegated to establish or remove association</param>
    /// <param name="title">The read only title of the association.</param>
    internal AssociationCoupler(Func<bool> check, Action<bool> associate, string title)
    {
      m_Check = check;
      m_Associate = associate;
      Title = title;
      m_InitialValue = m_Check();
    }

    #region IAssociationCoupler
    /// <summary>
    /// Gets or sets a value indicating whether the parties are associated.
    /// </summary>
    /// <value><c>true</c> if associated; otherwise, <c>false</c>.</value>
    public bool Associated
    {
      get
      {
        return m_Check();
      }
      set
      {
        m_Associate(value);
      }
    }
    /// <summary>
    /// Gets the title of the association.
    /// </summary>
    /// <value>The title.</value>
    public string Title { get; }
    /// <summary>
    /// Reverts the association to the initial state.
    /// </summary>
    public void Revert()
    {
      m_Associate(m_InitialValue);
    }
    #endregion

    #region private
    private bool m_InitialValue;
    private Action<bool> m_Associate;
    private Func<bool> m_Check;
    #endregion

  }
}
