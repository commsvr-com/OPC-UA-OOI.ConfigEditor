//_______________________________________________________________
//  Title   : BindableBase
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
using System;
using System.Runtime.CompilerServices;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.mvvm
{
  public class Bindable : BindableBase
  {
    /// <summary>
    /// Checks if a property already matches a desired value. Sets the property and notifies listeners only when necessary.
    /// </summary>
    /// <typeparam name="T">Type of the property.</typeparam>
    /// <param name="storage">Current value of the storage.</param>
    /// <param name="assign">A delegate capturing functionality to assign a new value to the storage.</param>
    /// <param name="value">Desired value for the property.</param>
    /// <param name="propertyName">Name of the property used to notify listeners. This
    /// value is optional and can be provided automatically when invoked from compilers that
    /// support CallerMemberName.</param>
    /// <returns>True if the value was changed, false if the existing value matched the desired value.</returns>
    protected virtual bool AssignProperty<T>(T storage, Action<T> assign, T value, [CallerMemberName] string propertyName = "")
    {
      if (object.Equals(storage, value))
        return false;
      assign(value);
      this.OnPropertyChanged(propertyName);
      return true;
    }
    /// <summary>
    /// Sets the property and notifies listeners unconditionally.
    /// </summary>
    /// <typeparam name="T">Type of the property.</typeparam>
    /// <param name="assign">A delegate capturing functionality to assign a new value to the storage.</param>
    /// <param name="value">Desired value for the property.</param>
    /// <param name="propertyName">Name of the property used to notify listeners. This
    /// value is optional and can be provided automatically when invoked from compilers that
    /// support CallerMemberName.</param>
    /// <returns>True if the value was changed, false if the existing value matched the desired value.</returns>
    protected virtual void AssignProperty<T>(Action<T> assign, T value, [CallerMemberName] string propertyName = "")
    {
      assign(value);
      this.OnPropertyChanged(propertyName);
    }

  }
}
