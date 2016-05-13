// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure.Interfaces
{
  public interface IMarketFeedServiceToRemove
  {
    decimal GetPrice(string tickerSymbol);
    long GetVolume(string tickerSymbol);
    bool SymbolExists(string tickerSymbol);
  }
}
