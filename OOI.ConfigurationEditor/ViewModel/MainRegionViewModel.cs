//_______________________________________________________________
//  Title   : MainRegionViewModel
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

using CAS.Windows.Controls;
using Prism.Mvvm;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel
{

  /// <summary>
  /// Class MainRegionViewModel ViewModel of the main region of the UI
  /// </summary>
  /// <seealso cref="Prism.Mvvm.BindableBase" />
  public abstract class MainRegionViewModel : BindableBase
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="MainRegionViewModel"/> class.
    /// </summary>
    /// <param name="headerInfo">The header information.</param>
    public MainRegionViewModel(string headerInfo)
    {
      HeaderInfo = headerInfo;
    }
    /// <summary>
    /// Gets or sets the buttons panel view model.
    /// </summary>
    /// <value>The buttons panel view model <see cref="ButtonsViewModel"/>.</value>
    public abstract ButtonsViewModel ButtonsPanelViewModel { get; protected set; }
    /// <summary>
    /// Gets the header information.
    /// </summary>
    /// <value>The header information.</value>
    public string HeaderInfo { get; private set; }
  }
}
