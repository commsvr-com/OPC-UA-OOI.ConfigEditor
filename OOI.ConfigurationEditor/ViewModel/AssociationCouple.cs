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

  internal class AssociationCouple : IAssociationCouple
  {

    public AssociationCouple(Func<bool> check, Action<bool> associate, string title)
    {
      m_Check = check;
      m_Associate = associate;
      m_InitialValue = m_Check();
      Title = title;
    }

    #region IAssociationCouple
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
    public string Title { get; }
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
