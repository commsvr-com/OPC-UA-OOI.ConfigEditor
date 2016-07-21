//_______________________________________________________________
//  Title   : PrismLoggerConverters
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate:  $
//  $Rev: $
//  $LastChangedBy: $
//  $URL: $
//  $Id:  $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using Prism.Logging;
using System;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure.Converters
{
  internal static class PrismLoggerConverters
  {
    internal static Category TraceEventType2Category(this System.Diagnostics.TraceEventType type)
    {
      Category _ret = Category.Debug;
      switch (type)
      {
        case System.Diagnostics.TraceEventType.Critical:
        case System.Diagnostics.TraceEventType.Error:
        case System.Diagnostics.TraceEventType.Warning:
          _ret = Category.Warn;
          break;
        case System.Diagnostics.TraceEventType.Information:
          _ret = Category.Info;
          break;
        case System.Diagnostics.TraceEventType.Verbose:
          _ret = Category.Debug;
          break;
        case System.Diagnostics.TraceEventType.Start:
        case System.Diagnostics.TraceEventType.Stop:
        case System.Diagnostics.TraceEventType.Suspend:
        case System.Diagnostics.TraceEventType.Resume:
        case System.Diagnostics.TraceEventType.Transfer:
          throw new ArgumentOutOfRangeException($"Imposible to convert {type} to equvalent value of {nameof(Category)}");
      }
      return _ret;
    }
    internal static Priority Priority2Priority (this UAOOI.DataDiscovery.DiscoveryServices.Priority priority)
    {
      Priority _return = Priority.None;
      switch (priority)
      {
        case UAOOI.DataDiscovery.DiscoveryServices.Priority.None:
          _return = Priority.None;
          break;
        case UAOOI.DataDiscovery.DiscoveryServices.Priority.High:
          _return = Priority.High;
          break;
        case UAOOI.DataDiscovery.DiscoveryServices.Priority.Medium:
          _return = Priority.Medium;
          break;
        case UAOOI.DataDiscovery.DiscoveryServices.Priority.Low:
          _return = Priority.Low;
          break;
      }
      return _return;
    }
  }
}
