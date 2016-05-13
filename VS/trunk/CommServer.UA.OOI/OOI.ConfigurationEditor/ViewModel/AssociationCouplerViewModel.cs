//_______________________________________________________________
//  Title   : MessageHandlerDataSetViewModel
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

using CAS.CommServer.UAOOI.ConfigurationEditor.mvvm;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.ViewModel
{
  public class AssociationCouplerViewModel : Bindable
  {

    internal AssociationCouplerViewModel(IAssociationCouple coupler)
    {
      m_Coupler = coupler;
    }

    #region ViewModel API.
    public bool Associated
    {
      get
      {
        return m_Coupler.Associated;
      }
      set
      {
        AssignProperty<bool>(m_Coupler.Associated, x => m_Coupler.Associated = value, value);
      }
    }
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