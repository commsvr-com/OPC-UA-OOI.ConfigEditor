//_______________________________________________________________
//  Title   : MessageHandlerItemView
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

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.MessageHandlerEditor
{

  /// <summary>
  /// Interaction logic for MessageHandlerItemView.xaml
  /// </summary>
  public partial class MessageHandlerItemView : UserControl
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageHandlerItemView"/> class.
    /// </summary>
    public MessageHandlerItemView()
    {
      DataContext = new InteractionRequestAwareBase();
      InitializeComponent();
    }
  }

}
