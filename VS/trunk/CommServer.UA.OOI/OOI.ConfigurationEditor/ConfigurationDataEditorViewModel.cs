//_______________________________________________________________
//  Title   : ConfigurationDataEditorViewModel
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

using CAS.Windows.Commands;
using Prism.Mvvm;
using System.ComponentModel.Composition;
using System.Reflection;
using System.Windows.Input;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor
{

  /// <summary>
  /// Class ConfigurationDataEditorViewModel.
  /// </summary>
  /// <seealso cref="Prism.Mvvm.BindableBase" />
  [Export]
  public class ConfigurationDataEditorViewModel : BindableBase
  {

    /// <summary>
    /// Initializes a new instance of the ConfigurationDataEditorViewModel class.
    /// </summary>
    public ConfigurationDataEditorViewModel()
    {

      b_Title = $"OPC UA Application Configuration Editor Rel: {Assembly.GetExecutingAssembly().GetName().Version}";
      SaveCommand = new Prism.Commands.DelegateCommand(() => { });
      HelpDocumentation = new WebDocumentationCommand(Properties.Resources.HelpDocumentationUrl);
      ReadMe = new  OpenFileCommand(Properties.Resources.ReadMeFileName);
      ViewLicense = new WebDocumentationCommand(Properties.Resources.ViewLicenseUrl);

    }

    #region menu
    /// <summary>
    /// Gets the save command.
    /// </summary>
    /// <value>The save command.</value>
    public ICommand SaveCommand { get; }
    /// <summary>
    /// Gets the help documentation.
    /// </summary>
    /// <value>The help documentation.</value>
    public ICommand HelpDocumentation { get; }
    /// <summary>
    /// Gets the read me.
    /// </summary>
    /// <value>The read me.</value>
    public ICommand ReadMe { get; }
    /// <summary>
    /// Gets the view license.
    /// </summary>
    /// <value>The view license.</value>
    public ICommand ViewLicense { get; }
    #endregion
    /// <summary>
    /// Gets or sets the title.
    /// </summary>
    /// <value>The title.</value>
    public string Title
    {
      get { return b_Title; }
      set { SetProperty<string>(ref b_Title, value); }
    }

    private string b_Title;

  }

}