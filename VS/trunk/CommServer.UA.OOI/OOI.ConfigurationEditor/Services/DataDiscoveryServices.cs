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

using CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel;
using System;
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
    public static async Task<T> ResolveDomainDescriptionAsync<T>(Uri address)
      where T : class, new()
    {
      using (HttpClient _client = new HttpClient())
      {
        //_client.BaseAddress = address;
        _client.MaxResponseContentBufferSize = Int32.MaxValue;
        _client.DefaultRequestHeaders.Add("user-agent", "Mozilla/5.0 (compatible; MSIE 10.0; Windows NT 6.2; WOW64; Trident/6.0)");
        //_client.DefaultRequestHeaders.Accept.Clear();
        //_client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("opc/application/json"));
        using (HttpResponseMessage _Message = await _client.GetAsync(address))
        {
          _Message.EnsureSuccessStatusCode();
          using (Task<Stream> _descriptionStream = _Message.Content.ReadAsStreamAsync())
          {
            XmlSerializer _serializer = new XmlSerializer(typeof(T));
            Stream _description = await _descriptionStream;
            T _newDescription = (T)_serializer.Deserialize(_description);
            return _newDescription;
          }
        }
      }
    }
    public static async Task<DomainModel> ResolveDomainModelAsync(Uri modelUri)
    {
      DomainDescriptor _lastDomainDescriptor = new DomainDescriptor() { NextStepRecordType = RecordType.DomainDescriptor };
      Uri _nextUri = new Uri(Properties.Settings.Default.DataDiscoveryRootServiceUrl);
      int _iteration = 0;
      do
      {
        _iteration++;
        if (_iteration > 16)
          throw new InvalidOperationException("Too many iteration in the resolve process.");
        Task<DomainDescriptor> _DomainDescriptorTask = Services.DataDiscoveryServices.ResolveDomainDescriptionAsync<DomainDescriptor>(_nextUri);
        _lastDomainDescriptor = await _DomainDescriptorTask;
        _nextUri = _lastDomainDescriptor.ResolveUri(modelUri);
      } while (_lastDomainDescriptor.NextStepRecordType == RecordType.DomainDescriptor);
      Task<DomainModel> _DomainModelTask = Services.DataDiscoveryServices.ResolveDomainDescriptionAsync<DomainModel>(_nextUri);
      return await _DomainModelTask;
    }

  }
}
