//_______________________________________________________________
//  Title   : Name of Application
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

using System;
using System.Globalization;
using System.Windows.Data;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure.Converters
{
  /// <summary>
  /// Class Uri2StringConverter - Provides a custom logic to a binding - converts <see cref="Uri"/> to <see cref="string"/>/>
  /// </summary>
  /// <seealso cref="System.Windows.Data.IValueConverter" />
  public class Uri2StringConverter : IValueConverter
  {
    /// <summary>
    /// Converts a value.
    /// </summary>
    /// <param name="value">The value produced by the binding source.</param>
    /// <param name="targetType">The type of the binding target property.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if (value == null)
        return "Empty Uri";
      return value.ToString();
    }
    /// <summary>
    /// Converts a value.
    /// </summary>
    /// <param name="value">The value that is produced by the binding target.</param>
    /// <param name="targetType">The type to convert to.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      string _uriString = value as string;
      return new Uri(_uriString);
    }
  }
}
