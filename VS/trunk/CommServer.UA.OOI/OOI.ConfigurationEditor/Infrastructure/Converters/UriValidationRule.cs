//_______________________________________________________________
//  Title   : UriValidationRule
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
using System.Windows.Controls;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure.Converters
{
  /// <summary>
  /// Class UriValidationRule.
  /// </summary>
  /// <seealso cref="System.Windows.Controls.ValidationRule" />
  public class UriValidationRule : ValidationRule
  {
    /// <summary>
    /// When overridden in a derived class, performs validation checks on a value.
    /// </summary>
    /// <param name="value">The value from the binding target to check.</param>
    /// <param name="cultureInfo">The culture to use in this rule.</param>
    /// <returns>A <see cref="T:System.Windows.Controls.ValidationResult" /> object.</returns>
    public override ValidationResult Validate(object value, CultureInfo cultureInfo)
    {
      string _strValue = value as string;
      if (String.IsNullOrEmpty(_strValue))
        return new ValidationResult(false, $"The string representing URI cannot be empty");
      if (!Uri.IsWellFormedUriString(_strValue,  UriKind.Absolute))
        return new ValidationResult(false, $"The string doesn't represent absolute uri");
        return ValidationResult.ValidResult;
    }
  }
}
