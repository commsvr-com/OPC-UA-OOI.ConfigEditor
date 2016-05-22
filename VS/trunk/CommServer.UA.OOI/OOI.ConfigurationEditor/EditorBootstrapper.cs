//_______________________________________________________________
//  Title   : Bootstrapper
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

using CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure.Behaviors;
using Microsoft.Practices.EnterpriseLibrary.ExceptionHandling;
using Prism.Logging;
using Prism.Mef;
using Prism.Regions;
using System;
using System.ComponentModel.Composition.Hosting;
using System.Windows;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor
{
  /// <summary>
  /// Class Bootstrapper.
  /// </summary>
  /// <seealso cref="Prism.Mef.MefBootstrapper" />
  public partial class EditorBootstrapper : MefBootstrapper
  {

    #region MefBootstrapper
    /// <summary>
    /// Configures the <see cref="P:Prism.Mef.MefBootstrapper.AggregateCatalog" /> used by MEF.
    /// </summary>
    /// <remarks>The base implementation does nothing.</remarks>
    protected override void ConfigureAggregateCatalog()
    {
      this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(EditorBootstrapper).Assembly));
      //this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(StockTraderRICommands).Assembly));
      //this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(MarketModule).Assembly));
      //this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(PositionModule).Assembly));
      //this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(WatchModule).Assembly));
      //this.AggregateCatalog.Catalogs.Add(new AssemblyCatalog(typeof(NewsModule).Assembly));
    }

    /// <summary>
    /// Configures the <see cref="T:System.ComponentModel.Composition.Hosting.CompositionContainer" />.
    /// May be overwritten in a derived class to add specific type mappings required by the application.
    /// </summary>
    /// <remarks>The base implementation registers all the types direct instantiated by the bootstrapper with the container.
    /// If the method is overwritten, the new implementation should call the base class version.</remarks>
    protected override void ConfigureContainer()
    {
      base.ConfigureContainer();
    }
    /// <summary>
    /// Initializes the shell.
    /// </summary>
    /// <remarks>The base implementation ensures the shell is composed in the container.</remarks>
    protected override void InitializeShell()
    {
      base.InitializeShell();
      ConfigurationDataEditorView _shell = (ConfigurationDataEditorView)this.Shell;
      _shell.ShowDialog();
      //Application.Current.MainWindow = (ConfigurationDataEditorView)this.Shell;
      //Application.Current.MainWindow.Show();
    }
    /// <summary>
    /// Configures the <see cref="T:Prism.Regions.IRegionBehaviorFactory" />.
    /// This will be the list of default behaviors that will be added to a region.
    /// </summary>
    /// <returns>IRegionBehaviorFactory.</returns>
    protected override IRegionBehaviorFactory ConfigureDefaultRegionBehaviors()
    {
      IRegionBehaviorFactory factory = base.ConfigureDefaultRegionBehaviors();
      factory.AddIfMissing("AutoPopulateExportedViewsBehavior", typeof(AutoPopulateExportedViewsBehavior));
      return factory;
    }
    /// <summary>
    /// Creates the shell or main window of the application.
    /// </summary>
    /// <returns>The shell of the application.</returns>
    /// <remarks>If the returned instance is a <see cref="T:System.Windows.DependencyObject" />, the
    /// <see cref="T:Prism.Bootstrapper" /> will attach the default <see cref="T:Prism.Regions.IRegionManager" /> of
    /// the application in its <see cref="F:Prism.Regions.RegionManager.RegionManagerProperty" /> attached property
    /// in order to be able to add regions by using the <see cref="F:Prism.Regions.RegionManager.RegionNameProperty" />
    /// attached property from XAML.</remarks>
    protected override DependencyObject CreateShell()
    {
      return this.Container.GetExportedValue<ConfigurationDataEditorView>();
    }
    /// <summary>
    /// Create the <see cref="T:Prism.Logging.ILoggerFacade" /> used by the bootstrapper.
    /// </summary>
    /// <returns>ILoggerFacade.</returns>
    /// <remarks>The base implementation returns a new TextLogger.</remarks>
    protected override ILoggerFacade CreateLogger()
    {
      return _logger;
    }
    #endregion

    internal static void RunInDebugMode()
    {
      EditorBootstrapper bootstrapper = new EditorBootstrapper();
      bootstrapper.Run();
    }
    internal static void RunInReleaseMode()
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

    #region private
    private readonly EnterpriseLibraryLoggerAdapter _logger = new EnterpriseLibraryLoggerAdapter();
    private static void AppDomainUnhandledException(object sender, UnhandledExceptionEventArgs e)
    {
      HandleException(e.ExceptionObject as Exception);
    }
    private static void HandleException(Exception ex)
    {
      if (ex == null)
        return;
      ExceptionPolicy.HandleException(ex, "Default Policy");
      MessageBox.Show(CAS.CommServer.UA.OOI.ConfigurationEditor.Properties.Resources.UnhandledException);
      //Environment.Exit(1);
    }
    #endregion

  }
}
