//_______________________________________________________________
//  Title   : IViewRegionRegistration
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

namespace CAS.CommServer.UAOOI.ConfigurationEditor.Infrastructure.Behaviors
{

  /// <summary>
  /// Interface IViewRegionRegistration
  /// </summary>
  public interface IViewRegionRegistration
  {
    /// <summary>
    /// Gets the name of the region.
    /// </summary>
    /// <value>The name of the region.</value>
    string RegionName { get; }
  }
}
