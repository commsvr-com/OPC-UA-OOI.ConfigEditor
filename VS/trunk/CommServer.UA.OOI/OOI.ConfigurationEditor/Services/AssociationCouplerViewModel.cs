//_______________________________________________________________
//  Title   : MessageHandlerDataSetViewModel
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate: 2016-06-04 15:42:29 +0200 (So, 04 cze 2016) $
//  $Rev: 12225 $
//  $LastChangedBy: mpostol $
//  $URL: svn://svnserver.hq.cas.com.pl/VS/trunk/CommServer.UA.OOI/OOI.ConfigurationEditor/ViewModel/AssociationCouplerViewModel.cs $
//  $Id: AssociationCouplerViewModel.cs 12225 2016-06-04 13:42:29Z mpostol $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using CAS.Windows.mvvm;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Services
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
    internal AssociationCouplerViewModel(AssociationCoupler coupler)
    {
      m_Coupler = coupler;
      b_Association = coupler.AssociationWrapper;
      b_Associated = m_Coupler.Associated;
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
        return b_Associated;
      }
      set
      {
        SetProperty<bool>(ref b_Associated, value);
      }
    }
    /// <summary>
    /// Gets or sets the association.
    /// </summary>
    /// <value>The association.</value>
    public IAssociationConfigurationWrapper Association
    {
      get
      {
        return b_Association;
      }
      set
      {
        SetProperty<IAssociationConfigurationWrapper>(ref b_Association, value);
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

    internal void ApplyChanges()
    {
      m_Coupler.ApplayChanges(b_Associated);
    }

    #region private
    private bool b_Associated;
    private IAssociationConfigurationWrapper b_Association;
    private AssociationCoupler m_Coupler;
    #endregion

  }
}