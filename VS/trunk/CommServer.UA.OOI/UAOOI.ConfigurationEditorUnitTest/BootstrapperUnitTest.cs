
using System;
using System.Windows;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Prism.Logging;
using Prism.Regions;
using System.Collections.Generic;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.UnitTest
{
  [TestClass]
  public class BootstrapperUnitTest
  {
    [TestMethod]
    public void DefaultIRegionManagerTestMethod()
    {
      List<string> _logBuffer = new List<string>();
      TestBootstrapper _bs = new TestBootstrapper(new LoggerFacade((x, y, z) => { _logBuffer.Add($"{x}, {y}, {z} "); Assert.AreEqual<Priority>(Priority.Low, z); }));
      _bs.Run();
      _bs.Test();
      Assert.AreEqual<int>(15, _logBuffer.Count);
    }
    private class TestBootstrapper : EditorBootstrapper
    {

      public TestBootstrapper(ILoggerFacade logger)
      {
        m_Logger = logger;
      }
      public void Test()
      {
        IRegionManager _rm = this.Container.GetExport<IRegionManager>().Value;
        Assert.IsNotNull(_rm);
        ILoggerFacade _lf = this.Container.GetExport<ILoggerFacade>().Value;
        Assert.IsNotNull(_lf);
      }
      protected override DependencyObject CreateShell()
      {
        return null;
      }
      protected override void InitializeShell()
      {
      }
      protected override ILoggerFacade CreateLogger()
      {
        return m_Logger;
      }

      private ILoggerFacade m_Logger;

    }
    private class LoggerFacade : ILoggerFacade
    {

      public LoggerFacade(Action<string, Category, Priority> log)
      {
        m_Log = log;
      }
      public void Log(string message, Category category, Priority priority)
      {
        m_Log(message, category, priority);
      }

      private Action<string, Category, Priority> m_Log;

    }
  }
}
