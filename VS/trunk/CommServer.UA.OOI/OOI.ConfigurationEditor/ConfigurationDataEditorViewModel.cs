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

using Prism.Mvvm;
using System.ComponentModel.Composition;
using System.Reflection;

namespace CAS.CommServer.UAOOI.ConfigurationEditor
{

  [Export]
  public class ConfigurationDataEditorViewModel : BindableBase
  {

    /// <summary>
    /// Initializes a new instance of the ConfigurationDataEditorViewModel class.
    /// </summary>
    public ConfigurationDataEditorViewModel()
    {
      b_Title = $"OPC UA Application Configuration Editor Rel: {Assembly.GetExecutingAssembly().GetName().Version}";
    }
    private string b_Title;
    public string Title
    {
      get { return b_Title; }
      set { SetProperty<string>(ref b_Title, value); }
    }

  }

}