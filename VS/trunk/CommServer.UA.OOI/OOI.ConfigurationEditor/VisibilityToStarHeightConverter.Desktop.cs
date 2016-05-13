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
using System.Windows;
using System.Windows.Data;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor
{
  public class VisibilityToStarHeightConverter : IValueConverter
  {
    /// <summary>
    /// Converts a value.
    /// </summary>
    /// <param name="value">The value produced by the binding source.</param>
    /// <param name="targetType">The type of the binding target property.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
    /// <exception cref="System.ArgumentNullException">parameter</exception>
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
    {
      if ((Visibility)value == Visibility.Collapsed)
      {
        return new GridLength(0, GridUnitType.Star);
      }
      else
      {
        if (parameter == null)
        {
          throw new ArgumentNullException("parameter");
        }
        return new GridLength(double.Parse(parameter.ToString(), culture), GridUnitType.Star);
      }
    }
    /// <summary>
    /// Converts a value.
    /// </summary>
    /// <param name="value">The value that is produced by the binding target.</param>
    /// <param name="targetType">The type to convert to.</param>
    /// <param name="parameter">The converter parameter to use.</param>
    /// <param name="culture">The culture to use in the converter.</param>
    /// <returns>A converted value. If the method returns null, the valid null value is used.</returns>
    /// <exception cref="System.NotImplementedException"></exception>
    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
      throw new NotImplementedException();
    }
  }
}
