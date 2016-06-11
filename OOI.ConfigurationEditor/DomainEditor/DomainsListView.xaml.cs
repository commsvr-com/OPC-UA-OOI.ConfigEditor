//_______________________________________________________________
//  Title   : DomainsListView
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

using CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure;
using CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure.Behaviors;
using System.ComponentModel.Composition;
using System.Windows.Controls;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainEditor
{
  /// <summary>
  /// Interaction logic for DomainsListView.xaml
  /// </summary>
  [ViewExport(RegionName = RegionNames.MainRegion)]
  [PartCreationPolicy(CreationPolicy.NonShared)]
  public partial class DomainsListView : UserControl
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainsListView"/> class.
    /// </summary>
    public DomainsListView()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Sets the ViewModel.
    /// </summary>
    /// <remarks>
    /// This property is annotated with the <see cref="ImportAttribute"/> so it is injected by MEF with
    /// the appropriate view model.
    /// </remarks>
    [Import]
    internal DomainsListViewModel ViewModel
    {
      set { this.DataContext = value; }
      get { return (DomainsListViewModel)this.DataContext; }
    }

  }
}
