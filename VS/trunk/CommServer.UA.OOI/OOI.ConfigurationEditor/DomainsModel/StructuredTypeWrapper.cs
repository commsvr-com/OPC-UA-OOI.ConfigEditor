//_______________________________________________________________
//  Title   : StructuredTypeWrapper
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
using UAOOI.DataDiscovery.DiscoveryServices.Models;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel
{
  public class StructuredTypeWrapper : Wrapper<StructuredType>
  {

    public StructuredTypeWrapper(StructuredType item) : base(item)
    {
      Field = new ObservableCollection<StructuredTypeFieldWrapper>(Item.Field.Select<StructuredTypeField, StructuredTypeFieldWrapper>(x => new StructuredTypeFieldWrapper(x)));
    }
    public ObservableCollection<StructuredTypeFieldWrapper> Field { get; }
    public StructureKindEnum StructureKind
    {
      get
      {
        return Item.StructureKind;
      }
      set
      {
        SetProperty<StructureKindEnum>(Item.StructureKind, x => Item.StructureKind = x, value);
      }
    }

  }
}
