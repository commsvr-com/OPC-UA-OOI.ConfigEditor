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

    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="AssociationCouplerViewModel"/> class.
    /// </summary>
    /// <param name="coupler">The coupler.</param>
    internal AssociationCouplerViewModel(IAssociationCoupler coupler)
    {
      m_Coupler = coupler;
    }
    #endregion

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
        SetProperty<bool>(m_Coupler.Associated, x => m_Coupler.Associated = x, value);
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

    /// <summary>
    /// Reverts the associated <see cref="IAssociationCoupler"/> instance to the initial state.
    /// </summary>
    internal void Revert()
    {
      m_Coupler.Revert();
    }

    #region private
    private IAssociationCoupler m_Coupler;
    #endregion

  }
}