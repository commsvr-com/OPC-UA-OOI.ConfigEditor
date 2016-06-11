//_______________________________________________________________
//  Title   : ParametersGroup
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

using System.Windows;
using System.Windows.Controls;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Controls
{
  /// <summary>
  /// Interaction logic for ParametersGroup.xaml implementing custom <see cref="ContentControl"/> and to be used to group a collection of parameters.
  /// </summary>
  public partial class ParametersGroup : ContentControl
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="ParametersGroup"/> class grouping a collection parameters.
    /// </summary>
    public ParametersGroup()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Gets or sets the group title.
    /// </summary>
    /// <value>The group title.</value>
    public string GroupTitle
    {
      get { return (string)GetValue(GroupTitleProperty); }
      set { SetValue(GroupTitleProperty, value); }
    }
    // Using a DependencyProperty as the backing store for GroupTitle.  This enables animation, styling, binding, etc...
    /// <summary>
    /// The group title property
    /// </summary>
    public static readonly DependencyProperty GroupTitleProperty = DependencyProperty.Register("GroupTitle", typeof(string), typeof(ParametersGroup));


  }
}
