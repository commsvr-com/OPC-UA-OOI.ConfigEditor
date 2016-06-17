//_______________________________________________________________
//  Title   : Name of Application
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

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  /// <summary>
  /// Interface IAssociationConfigurationWrapper - basic definition of the Association Configuration
  /// </summary>
  public interface IAssociationConfigurationWrapper
  {
    /// <summary>
    /// Gets or sets the name of the association.
    /// </summary>
    /// <value>The name of the association.</value>
    string AssociationName { get; set; }
    /// <summary>
    /// Gets or sets the identifier of the data unique in the domain defined by the <see cref="IAssociationConfigurationWrapper.PublisherId"/>.
    /// </summary>
    /// <value>The data set writer identifier.</value>
    ushort DataSetWriterId { get; set; }
    /// <summary>
    /// Gets or sets the publisher identifier.
    /// </summary>
    /// <value>The globally unique identifier of the data domain.</value>
    Guid PublisherId { get; set; }

  }
}