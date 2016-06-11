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

using Prism.Events;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure
{

  /// <summary>
  /// Class DataSetSelectedEvent -  it manage publication and subscription to DataSet selected events.
  /// </summary>
  /// <seealso cref="PubSubEvent{String}" />
  public class DataSetSelectedEvent : PubSubEvent<string>{ }

}
