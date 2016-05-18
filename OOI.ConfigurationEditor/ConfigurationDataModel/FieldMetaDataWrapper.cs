//_______________________________________________________________
//  Title   : Name of Application
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

using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{
  public class FieldMetaDataWrapper : Wrapper<FieldMetaData>
  {

    public FieldMetaDataWrapper(FieldMetaData item) : base(item) { }

    #region Wrapper<FieldMetaData>
    public override FieldMetaData Item
    {
      get
      {
        return base.Item;
      }
      protected set
      {
        base.Item = value;
      }
    }
    #endregion

  }
}
