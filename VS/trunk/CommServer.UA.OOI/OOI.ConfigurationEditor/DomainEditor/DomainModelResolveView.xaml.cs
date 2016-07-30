using CAS.Windows.ViewModel;
using System.Windows.Controls;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainEditor
{
  /// <summary>
  /// Interaction logic for DomainModelResolveView.xaml
  /// </summary>
  public partial class DomainModelResolveView : UserControl
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainModelResolveView"/> class.
    /// </summary>
    public DomainModelResolveView()
    {
      InitializeComponent();
      DataContext = new InteractionRequestAwareBase();
    }
  }
}
