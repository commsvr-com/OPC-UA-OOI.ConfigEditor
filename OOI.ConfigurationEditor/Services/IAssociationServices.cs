//_______________________________________________________________
//  Title   : IAssociationServices
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate: 2016-06-07 16:00:49 +0200 (Wt, 07 cze 2016) $
//  $Rev: 12227 $
//  $LastChangedBy: mpostol $
//  $URL: svn://svnserver.hq.cas.com.pl/VS/trunk/CommServer.UA.OOI/OOI.ConfigurationEditor/ViewModel/IAssociationServices.cs $
//  $Id: IAssociationServices.cs 12227 2016-06-07 14:00:49Z mpostol $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;
using System.Collections.Generic;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Services
{
  /// <summary>
  /// Interface IAssociationServices - 
  /// </summary>
  internal interface IAssociationServices
  {

    /// <summary>
    /// Gets the array of all candidates <see cref="AssociationCouplerViewModel"/> that can be associated with <paramref name="wrapper"/>
    /// </summary>
    /// <param name="wrapper">The wrapper <see cref="DataSetConfigurationWrapper"/>.</param>
    /// <returns>All available <see cref="AssociationCouplerViewModel"/>.</returns>
    AssociationCouplerViewModel[] GetAssociationCouplerViewModelEnumerator(DataSetConfigurationWrapper wrapper);
    /// <summary>
    /// Gets the array of all candidates <see cref="AssociationCouplerViewModel"/> that can be associated with <paramref name="wrapper"/>
    /// </summary>
    /// <param name="wrapper">The wrapper <see cref="IMessageHandlerConfigurationWrapper"/>.</param>
    /// <returns>All available <see cref="AssociationCouplerViewModel"/>.</returns>
    AssociationCouplerViewModel[] GetAssociationCouplerViewModelEnumerator(IMessageHandlerConfigurationWrapper wrapper);
    /// <summary>
    /// Gets all associations defined in the configuration.
    /// </summary>
    /// <returns>Returns <see cref="IEnumerable{Association}"/> containing all association defined in the configuration.</returns>
    IEnumerable<Association> GetAssociations();

  }
}
