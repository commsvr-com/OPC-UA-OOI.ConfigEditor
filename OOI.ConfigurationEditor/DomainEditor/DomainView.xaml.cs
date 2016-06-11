//_______________________________________________________________
//  Title   : DomainView
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

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainEditor
{
  /// <summary>
  /// Interaction logic for DomainView.xaml
  /// </summary>
  public partial class DomainView : UserControl
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainView"/> class provisioning the GUI to the user..
    /// </summary>
    public DomainView()
    {
      InitializeComponent();
      DataContext = new InteractionRequestAwareBase();
    }
  }
}
