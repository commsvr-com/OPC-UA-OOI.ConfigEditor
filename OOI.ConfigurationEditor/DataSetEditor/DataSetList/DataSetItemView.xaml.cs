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

using CAS.Windows.ViewModel;
using System.Windows.Controls;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DataSetEditor.DataSetList
{
  /// <summary>
  /// Interaction logic for DataSetItemView.xaml
  /// </summary>
  public partial class DataSetItemView : UserControl
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DataSetItemView"/> class.
    /// </summary>
    public DataSetItemView()
    {
      DataContext = new InteractionRequestAwareBase();
      InitializeComponent();
    }
  }
}
