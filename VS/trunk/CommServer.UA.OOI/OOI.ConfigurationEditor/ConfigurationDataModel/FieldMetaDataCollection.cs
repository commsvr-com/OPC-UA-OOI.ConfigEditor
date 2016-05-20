
//_______________________________________________________________
//  Title   : FieldMetaDataCollection
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

using System.Collections.ObjectModel;
using System.Linq;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{

  public class FieldMetaDataCollection : ObservableCollection<FieldMetaDataWrapper>
  {

    public FieldMetaDataCollection
      (FieldMetaData[] dataSet): base(dataSet.Select<FieldMetaData, FieldMetaDataWrapper>(item => new FieldMetaDataWrapper(item))){}

  }

}
