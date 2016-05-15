
//_______________________________________________________________
//  Title   : ConfigurationDataEditorView
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

using System.ComponentModel.Composition;
using System.Windows;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor
{
  /// <summary>
  /// Description for ConfigurationDataEditorView.
  /// </summary>
  [Export]
  public partial class ConfigurationDataEditorView : Window
  {
    /// <summary>
    /// Initializes a new instance of the ConfigurationDataEditorView class.
    /// </summary>
    public ConfigurationDataEditorView()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Gets or sets the view model.
    /// </summary>
    /// <value>The view model.</value>
    [Import]
    public ConfigurationDataEditorViewModel ViewModel
    {
      get { return (ConfigurationDataEditorViewModel)this.DataContext; }
      set { this.DataContext = value; }
    }
  }
}