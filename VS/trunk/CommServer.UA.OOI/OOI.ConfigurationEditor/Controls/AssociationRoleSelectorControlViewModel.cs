//_______________________________________________________________
//  Title   : AssociationRoleSelectorControlViewModel
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

using CAS.Windows.mvvm;
using System;
using Serialization = global::UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Controls
{
  /// <summary>
  /// Class AssociationRoleSelectorControlViewModel - View Model of the control.
  /// </summary>
  public class AssociationRoleSelectorControlViewModel: Bindable
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="AssociationRoleSelectorControlViewModel"/> class.
    /// </summary>
    /// <param name="associationRoleChangeAction">The association role change action encapsulating inverting control to change the value of the role.</param>
    public AssociationRoleSelectorControlViewModel( Action<Serialization.AssociationRole> associationRoleChangeAction, Serialization.AssociationRole role, bool isEnabled)
    {
      m_AssociationRoleChangeAction = associationRoleChangeAction;
      b_AssociationRoleGroupBoxIsEnabled = isEnabled;
      if (role == Serialization.AssociationRole.Consumer)
      {
        b_ConsumerRoleSelected = true;
        b_ProducerRoleSelected = false;
      }
      else
      {
        b_ConsumerRoleSelected = false;
        b_ProducerRoleSelected = true;
      }
    }
    #region UI API
    /// <summary>
    /// Gets or sets a value indicating whether producer role is selected.
    /// </summary>
    /// <value><c>true</c> if the producer role is selected; otherwise, <c>false</c>.</value>
    public bool? ProducerRoleSelected
    {
      get
      {
        return b_ProducerRoleSelected;
      }
      set
      {
        if (SetProperty<bool?>(ref b_ProducerRoleSelected, value) && value.GetValueOrDefault(false))
          m_AssociationRoleChangeAction(Serialization.AssociationRole.Producer);
      }
    }
    /// <summary>
    /// Gets or sets a value indicating whether the consumer role is selected.
    /// </summary>
    /// <c>true</c> if consumer role is selected; otherwise, <c>false</c>.</value>
    public bool? ConsumerRoleSelected
    {
      get
      {
        return b_ConsumerRoleSelected;
      }
      set
      {
        if (SetProperty<bool?>(ref b_ConsumerRoleSelected, value) && value.GetValueOrDefault(false))
          m_AssociationRoleChangeAction(Serialization.AssociationRole.Consumer);
      }
    }
    /// <summary>
    /// Gets or sets the association role group box is enabled.
    /// </summary>
    /// <value>The association role group box is enabled.</value>
    public bool AssociationRoleGroupBoxIsEnabled
    {
      get
      {
        return b_AssociationRoleGroupBoxIsEnabled;
      }
      set
      {
        SetProperty<bool>(ref b_AssociationRoleGroupBoxIsEnabled, value);
      }
    }
    #endregion

    #region private
    private bool? b_ProducerRoleSelected;
    private bool? b_ConsumerRoleSelected;
    private bool b_AssociationRoleGroupBoxIsEnabled;
    private Action<Serialization.AssociationRole> m_AssociationRoleChangeAction;
    #endregion

  }
}
