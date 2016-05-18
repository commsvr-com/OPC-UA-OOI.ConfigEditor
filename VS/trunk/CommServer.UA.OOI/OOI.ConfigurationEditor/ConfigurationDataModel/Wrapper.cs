//_______________________________________________________________
//  Title   : Wrapper
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

using CAS.Windows.mvvm;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{
  public class Wrapper<type> : Bindable, IWrapper<type>
  {
    public Wrapper(type item)
    {
      if (item == null)
        throw new System.ArgumentNullException(nameof(item));
      Item = item;
    }
    public virtual type Item
    {
      get; protected set;
    }

  }
}
