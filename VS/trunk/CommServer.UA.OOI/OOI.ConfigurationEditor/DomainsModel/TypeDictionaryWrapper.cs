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

using System.Collections.ObjectModel;
using System.Linq;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel
{
  /// <summary>
  /// Class TypeDictionaryWrapper.
  /// </summary>
  /// <seealso cref="Wrapper{TypeDictionary}" />
  public class TypeDictionaryWrapper : Wrapper<TypeDictionary>
  {
    public TypeDictionaryWrapper(TypeDictionary item) : base(item)
    {
      StructuredType = new ObservableCollection<StructuredTypeWrapper>(item.StructuredType.Select<StructuredType, StructuredTypeWrapper>(x => new StructuredTypeWrapper(x)));
    }
    public ObservableCollection<StructuredTypeWrapper> StructuredType { get; }
    public string TargetNamespace
    {
      get
      {
        return Item.TargetNamespace;
      }
      set
      {
        SetProperty<string>(Item.TargetNamespace, x => Item.TargetNamespace = x, value);
      }
    }

  }
}
