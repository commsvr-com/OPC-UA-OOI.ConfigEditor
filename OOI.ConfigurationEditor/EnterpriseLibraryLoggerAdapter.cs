//_______________________________________________________________
//  Title   : EnterpriseLibraryLoggerAdapter
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

using Microsoft.Practices.EnterpriseLibrary.Logging;
using Microsoft.Practices.EnterpriseLibrary.Logging.Filters;
using Microsoft.Practices.EnterpriseLibrary.Logging.Formatters;
using Microsoft.Practices.EnterpriseLibrary.Logging.TraceListeners;
using Prism.Logging;
using System.Collections.Generic;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor
{
  /// <summary>
  /// Class EnterpriseLibraryLoggerAdapter - implements <see cref="ILoggerFacade"/>initializes <see cref="Logger"/> 
  /// that is the facade for writing a log entry to one or more <see cref="System.Diagnostics.TraceListeners"/>.
  /// </summary>
  public class EnterpriseLibraryLoggerAdapter : ILoggerFacade
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="EnterpriseLibraryLoggerAdapter"/> class.
    /// </summary>
    public EnterpriseLibraryLoggerAdapter()
    {
      TextFormatter _extendedFormatter = new TextFormatter("Timestamp: {timestamp}{newline}Message: {message}{newline}Category: {category}{newline}Priority: {priority}{newline}EventId: {eventid}{newline}Severity: {severity}{newline}Title: {title}{newline}Activity ID: {property(ActivityId)}{newline}Machine: {localMachine}{newline}App Domain: {localAppDomain}{newline}ProcessId: {localProcessId}{newline}Process Name: {localProcessName}{newline}Thread Name: {threadName}{newline}Win32 ThreadId:{win32ThreadId}{newline}Extended Properties: {dictionary({key} - {value}{newline})}");
      TextFormatter _briefFormatter = new TextFormatter("{timestamp(local)};{message};{category};{priority};{eventid};{severity};{title}");

      // Category Filters
      ICollection<string> categories = new List<string>();
      categories.Add("BlockedByFilter");

      // Log Filters
      PriorityFilter _priorityFilter = new PriorityFilter("Priority Filter", -1, 99);
      LogEnabledFilter _logEnabledFilter = new LogEnabledFilter("LogEnabled Filter", true);
      CategoryFilter _categoryFilter = new CategoryFilter("Category Filter", categories, CategoryFilterMode.AllowAllExceptDenied);

      FlatFileTraceListener _flatFileTraceListener = new FlatFileTraceListener($"{nameof(ConfigurationEditorBase)}.log", string.Empty, string.Empty, _briefFormatter);
      LoggingConfiguration _configuration = new LoggingConfiguration();
      _configuration.Filters.Add(_priorityFilter);
      _configuration.Filters.Add(_logEnabledFilter);
      _configuration.Filters.Add(_categoryFilter);
      _configuration.AddLogSource("Debug", System.Diagnostics.SourceLevels.All, true, _flatFileTraceListener);
      FlatFileTraceListener unprocessedFlatFileTraceListener = new FlatFileTraceListener(@"Unprocessed.log", "----------------------------------------", "----------------------------------------", _extendedFormatter);
      _configuration.SpecialSources.Unprocessed.AddTraceListener(unprocessedFlatFileTraceListener);
      FlatFileTraceListener _LoggingErrorsAndWarningsTraceListener = new FlatFileTraceListener(@"LoggingErrorsAndWarnings.log", "----------------------------------------", "----------------------------------------", _extendedFormatter);
      _configuration.SpecialSources.LoggingErrorsAndWarnings.AddTraceListener(_LoggingErrorsAndWarningsTraceListener);
      Logger.SetLogWriter(new LogWriter(_configuration));

    }

    #region ILoggerFacade Members
    /// <summary>
    /// Write a new log entry with the specified category and priority.
    /// </summary>
    /// <param name="message">Message body to log.</param>
    /// <param name="category">Category of the entry.</param>
    /// <param name="priority">The priority of the entry.</param>
    public void Log(string message, Category category, Priority priority)
    {
      Logger.Write(message, category.ToString(), (int)priority);
    }
    #endregion

  }
}
