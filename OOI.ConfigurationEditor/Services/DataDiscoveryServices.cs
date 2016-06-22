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

using System.IO;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Services
{
  internal class DataDiscoveryServices
  {
    internal static async Task<IPAddress[]> Resolve(string url)
    {
      return await Dns.GetHostAddressesAsync(url);
    }
    internal static async Task<T> ResolveDomainDescriptionAsync<T>(string address)
      where T : class, new()
    {
      using (HttpClient _client = new HttpClient())
      {
        Task<Stream> _toDo = _client.GetStreamAsync(address);
        XmlSerializer _serializer = new XmlSerializer(typeof(T));
        using (Stream _content = await _toDo)
        {
          return (T)_serializer.Deserialize(_content);
        }
      }
    }
  }
}
