//_______________________________________________________________
//  Title   : Name of Application
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate: 2016-05-17 22:14:57 +0200 (Wt, 17 maj 2016) $
//  $Rev: 12202 $
//  $LastChangedBy: mpostol $
//  $URL: svn://svnserver.hq.cas.com.pl/VS/trunk/CommServer.UA.OOI/OOI.ConfigurationEditor/DataSetEditor/DataSetList/DataSetItemView.xaml.cs $
//  $Id: DataSetItemView.xaml.cs 12202 2016-05-17 20:14:57Z mpostol $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using CAS.Windows.ViewModel;
using System.Windows.Controls;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DataSetEditor
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
