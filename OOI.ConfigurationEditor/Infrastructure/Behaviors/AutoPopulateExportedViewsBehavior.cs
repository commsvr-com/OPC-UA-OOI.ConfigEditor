//_______________________________________________________________
//  Title   : AutoPopulateExportedViewsBehavior
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

using Prism.Regions;
using System;
using System.ComponentModel.Composition;
using System.Diagnostics.CodeAnalysis;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure.Behaviors
{
  /// <summary>
  /// Class AutoPopulateExportedViewsBehavior.
  /// </summary>
  /// <seealso cref="RegionBehavior" />
  /// <seealso cref="IPartImportsSatisfiedNotification" />
  [Export(typeof(AutoPopulateExportedViewsBehavior))]
  [PartCreationPolicy(CreationPolicy.NonShared)]
  public class AutoPopulateExportedViewsBehavior : RegionBehavior, IPartImportsSatisfiedNotification
  {

    #region IPartImportsSatisfiedNotification
    /// <summary>
    /// Called when a part's imports have been satisfied and it is safe to use.
    /// </summary>
    public void OnImportsSatisfied()
    {
      AddRegisteredViews();
    }
    #endregion

    [SuppressMessage("Microsoft.Performance", "CA1819:PropertiesShouldNotReturnArrays", Justification = "MEF injected values")]
    [ImportMany(AllowRecomposition = true)]
    public Lazy<object, IViewRegionRegistration>[] RegisteredViews { get; set; }
    /// <summary>
    /// Override this method to perform the logic after the behavior has been attached.
    /// </summary>
    protected override void OnAttach()
    {
      AddRegisteredViews();
    }
    private void AddRegisteredViews()
    {
      if (this.Region == null)
        return;
      foreach (Lazy<object, IViewRegionRegistration> _viewEntry in this.RegisteredViews)
        if (_viewEntry.Metadata.RegionName == this.Region.Name)
        {
          object view = _viewEntry.Value;
          if (!this.Region.Views.Contains(view))
            this.Region.Add(view);
        }
    }

  }
}
