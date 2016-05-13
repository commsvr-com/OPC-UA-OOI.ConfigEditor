//_______________________________________________________________
//  Title   : IAssociationServices
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
using System.Collections.Generic;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel
{
  internal interface IAssociationServices
  {

    IEnumerable<AssociationCouplerViewModel> GetAssociationCouplerViewModelEnumerator(DataSetConfigurationWrapper wrapper);
    IEnumerable<AssociationCouplerViewModel> GetAssociationCouplerViewModelEnumerator(IMessageHandlerConfigurationWrapper wrapper);

  }
}
