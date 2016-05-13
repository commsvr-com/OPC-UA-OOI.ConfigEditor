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
    [Import]
    public ConfigurationDataEditorViewModel ViewModel
    {
      get { return (ConfigurationDataEditorViewModel)this.DataContext; }
      set { this.DataContext = value; }
    }
  }
}