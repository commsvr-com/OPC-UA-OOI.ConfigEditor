//_______________________________________________________________
//  Title   : AssociationConfigurationWrapper
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
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  /// <summary>
  /// Class AssociationConfigurationWrapper.
  /// </summary>
  /// <typeparam name="type">The type of the type.</typeparam>
  /// <seealso cref="Wrapper{type}" />
  /// <seealso cref="IAssociationConfigurationWrapper" />
  public class AssociationConfigurationWrapper<type> : Wrapper<type>, IAssociationConfigurationWrapper
    where type : AssociationConfiguration
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="AssociationConfigurationWrapper{type}"/> class.
    /// </summary>
    /// <param name="configuration">The configuration.</param>
    public AssociationConfigurationWrapper(type configuration) : base(configuration) { }
    /// <summary>
    /// Gets or sets the name of the association.
    /// </summary>
    /// <value>The name of the association.</value>
    public string AssociationName
    {
      get { return Item.AssociationName; }
      set { SetProperty<string>(x => Item.AssociationName = x, value); }
    }
    /// <summary>
    /// Gets or sets the data set writer identifier.
    /// </summary>
    /// <value>The data set writer identifier.</value>
    public ushort DataSetWriterId
    {
      get { return Item.DataSetWriterId; }
      set { SetProperty<ushort>(x => Item.DataSetWriterId = x, value); }
    }
    /// <summary>
    /// Gets or sets the publisher identifier.
    /// </summary>
    /// <value>The publisher identifier.</value>
    public Guid PublisherId
    {
      get { return Item.PublisherId; }
      set { SetProperty<Guid>(x => Item.PublisherId = x, value); }
    }

  }
}
