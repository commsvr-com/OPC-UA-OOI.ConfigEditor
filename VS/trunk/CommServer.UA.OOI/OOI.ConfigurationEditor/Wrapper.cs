//_______________________________________________________________
//  Title   : Wrapper
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

using CAS.Windows.mvvm;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor
{

  /// <summary>
  /// Class Wrapper - used to wrapp an instance of type <typeparamref name="type"/>
  /// </summary>
  /// <typeparam name="type">The type of the wrapped instance type.</typeparam>
  /// <seealso cref="CAS.Windows.mvvm.Bindable" />
  /// <seealso cref="CAS.CommServer.UA.OOI.ConfigurationEditor.IWrapper{type}" />
  public class Wrapper<type> : Bindable, IWrapper<type>
  {
    /// <summary>
    /// Initializes a new instance of the <see cref="Wrapper{type}"/> class.
    /// </summary>
    /// <param name="item">The item.</param>
    /// <exception cref="System.ArgumentNullException"></exception>
    public Wrapper(type item)
    {
      if (item == null)
        throw new System.ArgumentNullException(nameof(item));
      Item = item;
    }
    /// <summary>
    /// Gets the item.
    /// </summary>
    /// <value>The item.</value>
    public virtual type Item
    {
      get; private set;
    }

  }
}
