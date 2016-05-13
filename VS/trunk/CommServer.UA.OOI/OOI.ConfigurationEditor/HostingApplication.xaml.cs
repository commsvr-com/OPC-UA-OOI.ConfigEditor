//_______________________________________________________________
//  Title   : HostingApplication
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

using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using System;
using System.Windows;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UAOOI.ConfigurationEditor
{
  /// <summary>
  /// Interaction logic for HostingApplication.xaml
  /// </summary>
  public partial class HostingApplication : Application
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="HostingApplication"/> class.
    /// </summary>
    public HostingApplication()
    {
      InitializeComponent();
    }
    /// <summary>
    /// Raises the <see cref="E:System.Windows.Application.Startup" /> event.
    /// </summary>
    /// <param name="e">A <see cref="T:System.Windows.StartupEventArgs" /> that contains the event data.</param>
    protected override void OnStartup(StartupEventArgs e)
    {
      base.OnStartup(e);
#if (DEBUG)
      RunInDebugMode();
#else
      RunInReleaseMode();
#endif
      this.ShutdownMode = ShutdownMode.OnMainWindowClose;
    }

    private static void RunInDebugMode()
    {
      EditorBootstrapper bootstrapper = new EditorBootstrapper();
      bootstrapper.Run();
    }
    private static void RunInReleaseMode()
    {
      AppDomain.CurrentDomain.UnhandledException += AppDomainUnhandledException;
      try
      {
        EditorBootstrapper bootstrapper = new EditorBootstrapper();
        bootstrapper.Run();
      }
      catch (Exception ex)
      {
        HandleException(ex);
      }
    }
    private static void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      HandleException(e.ExceptionObject as Exception);
    }
    private static void HandleException(Exception ex)
    {
      if (ex == null)
        return;
      ExceptionPolicy.HandleException(ex, "Default Policy");
      MessageBox.Show(CAS.CommServer.UAOOI.ConfigurationEditor.Properties.Resources.UnhandledException);
      //Environment.Exit(1);
    }

  }
}
