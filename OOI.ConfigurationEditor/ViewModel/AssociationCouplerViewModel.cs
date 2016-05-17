//_______________________________________________________________
//  Title   : MessageHandlerDataSetViewModel
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

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel
{
  /// <summary>
  /// Class AssociationCouplerViewModel.
  /// </summary>
  /// <seealso cref="CAS.Windows.mvvm.Bindable" />
  public class AssociationCouplerViewModel : Bindable
  {

    internal AssociationCouplerViewModel(IAssociationCouple coupler)
    {
      m_Coupler = coupler;
    }

    #region ViewModel API.
    /// <summary>
    /// Gets or sets a value indicating whether this <see cref="AssociationCouplerViewModel"/> is associated.
    /// </summary>
    /// <value><c>true</c> if associated; otherwise, <c>false</c>.</value>
    public bool Associated
    {
      get
      {
        return m_Coupler.Associated;
      }
      set
      {
        SetProperty<bool>(m_Coupler.Associated, x => m_Coupler.Associated = value, value);
      }
    }
    /// <summary>
    /// Gets the association coupler title.
    /// </summary>
    /// <value>The association coupler title.</value>
    public string AssociationCouplerTitle
    {
      get
      {
        return m_Coupler.Title;
      }
    }
    #endregion

    internal void Revert()
    {
      m_Coupler.Revert();
    }

    #region private
    private IAssociationCouple m_Coupler;
    #endregion

  }
}