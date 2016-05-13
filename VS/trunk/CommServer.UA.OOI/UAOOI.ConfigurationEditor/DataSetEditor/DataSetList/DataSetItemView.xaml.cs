using Prism.Interactivity.InteractionRequest;
using System;
using System.Windows;
using System.Windows.Controls;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.DataSetEditor.DataSetList
{
  /// <summary>
  /// Interaction logic for DataSetItemView.xaml
  /// </summary>
  public partial class DataSetItemView : UserControl
  {
    public DataSetItemView()
    {
      DataContext = new DataSetItemViewModel();
      InitializeComponent();
    }
  }
}
