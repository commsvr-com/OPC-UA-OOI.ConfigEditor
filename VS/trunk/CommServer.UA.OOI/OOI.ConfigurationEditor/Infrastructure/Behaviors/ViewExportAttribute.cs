//_______________________________________________________________
//  Title   : ViewExportAttribute
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
using System.ComponentModel.Composition;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.Infrastructure.Behaviors
{
  [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
  [MetadataAttribute]
  public sealed class ViewExportAttribute : ExportAttribute, IViewRegionRegistration
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="ViewExportAttribute"/> class.
    /// </summary>
    public ViewExportAttribute()
        : base(typeof(object))
    { }
    /// <summary>
    /// Initializes a new instance of the <see cref="ViewExportAttribute"/> class.
    /// </summary>
    /// <param name="viewName">Name of the view.</param>
    public ViewExportAttribute(string viewName)
        : base(viewName, typeof(object))
    { }
    /// <summary>
    /// Gets the name of the view.
    /// </summary>
    /// <value>The name of the view.</value>
    public string ViewName { get { return base.ContractName; } }
    /// <summary>
    /// Gets the name of the region.
    /// </summary>
    /// <value>The name of the region.</value>
    public string RegionName { get; set; }
  }
}
