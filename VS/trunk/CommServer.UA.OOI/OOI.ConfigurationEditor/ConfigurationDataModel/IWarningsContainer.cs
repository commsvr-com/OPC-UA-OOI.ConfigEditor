//_______________________________________________________________
//  Title   : IWarningsContainer
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

using System.Collections.Generic;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  /// <summary>
  /// Interface IWarningsContainer
  /// </summary>
  public interface IWarningsContainer
  {
    /// <summary>
    /// Gets the warnings enumerable.
    /// </summary>
    /// <value>The warnings enumerable.</value>
    IEnumerable<Warning> WarningsEnumerable { get; }
  }
}
