﻿//_______________________________________________________________
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
  /// <summary>
  /// Interface IAssociationServices - 
  /// </summary>
  internal interface IAssociationServices
  {

    /// <summary>
    /// Gets the <see cref="IEnumerable{T}"/> of all candidates <see cref="AssociationCouplerViewModel"/> that can be associated with <paramref name="wrapper"/>
    /// </summary>
    /// <param name="wrapper">The wrapper.</param>
    /// <returns>All available <see cref="AssociationCouplerViewModel"/> as the <see cref="IEnumerable{T}"/>.</returns>
    IEnumerable<AssociationCouplerViewModel> GetAssociationCouplerViewModelEnumerator(DataSetConfigurationWrapper wrapper);
    /// <summary>
    /// Gets the <see cref="IEnumerable{T}"/> of all candidates <see cref="AssociationCouplerViewModel"/> that can be associated with <paramref name="wrapper"/>
    /// </summary>
    /// <param name="wrapper">The wrapper.</param>
    /// <returns>All available <see cref="AssociationCouplerViewModel"/> as the <see cref="IEnumerable{T}"/>.</returns>
    IEnumerable<AssociationCouplerViewModel> GetAssociationCouplerViewModelEnumerator(IMessageHandlerConfigurationWrapper wrapper);

  }
}
