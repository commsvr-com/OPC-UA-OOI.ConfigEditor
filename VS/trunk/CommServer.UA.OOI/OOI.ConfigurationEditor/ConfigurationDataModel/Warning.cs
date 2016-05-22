//_______________________________________________________________
//  Title   : Warning
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

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{
  /// <summary>
  /// Struct Warning
  /// </summary>
  public class Warning
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="Warning"/> struct.
    /// </summary>
    /// <param name="message">The message.</param>
    /// <param name="category">The category.</param>
    /// <param name="priority">The priority.</param>
    public Warning(string message, Category category, Priority priority)
    {
      Message = message;
      Category = category;
      Priority = priority;
    }
    /// <summary>
    /// Gets the message.
    /// </summary>
    /// <value>The message.</value>
    string Message { get; }
    /// <summary>
    /// Gets the category.
    /// </summary>
    /// <value>The category.</value>
    Category Category { get; }
    /// <summary>
    /// Gets the priority.
    /// </summary>
    /// <value>The priority.</value>
    Priority Priority { get; }
    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    public override string ToString()
    {
      return $"Configuration Warning: {Message}, {Category}, {Priority}";
    }

  }
}
