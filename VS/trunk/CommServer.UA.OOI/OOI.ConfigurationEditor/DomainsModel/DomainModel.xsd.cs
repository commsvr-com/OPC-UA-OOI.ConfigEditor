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
using System.Xml;
using System.Xml.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel
{
  /// <summary>
  /// Class DomainModel - domain description holder. 
  /// </summary>
  /// <remarks>
  /// Domain is a collection of data over which an owner has control. It may be used to describe:
  /// * a collection of package addresses used to push the message to the receiver.
  /// * a collection of data used to provide data semantic unique identifier and support subscription to receive copies of the data as the message payload based on the data semantics.
  /// </remarks>
  public partial class DomainModel
  {

    #region API
    /// <summary>
    /// Gets or sets the URI of the domain.
    /// </summary>
    /// <value>The URI.</value>
    [XmlIgnore]
    public Uri DomainModelUri
    {
      get
      {
        return new Uri(DomainModelUriString);
      }
      set
      {
        DomainModelUriString = value.ToString();
      }
    }
    /// <summary>
    /// Gets or sets the unique name of the domain.
    /// </summary>
    /// <value>The name of the unique.</value>
    [XmlIgnore]
    public Guid DomainModelGuid
    {
      get
      {
        return XmlConvert.ToGuid(DomainModelGuidString);
      }
      set
      {
        DomainModelGuidString = XmlConvert.ToString(value);
      }
    }

    #endregion

  }
}
