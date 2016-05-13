// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.Generic;
using Prism.Events;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure
{
  public class MarketPricesUpdatedEvent : PubSubEvent<IDictionary<string, decimal>>
  { }

}
