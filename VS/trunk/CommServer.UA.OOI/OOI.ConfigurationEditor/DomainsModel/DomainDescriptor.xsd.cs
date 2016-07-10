
using System;
using System.Linq;
using System.Text.RegularExpressions;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel
{
  public partial class DomainDescriptor
  {
    internal Uri ResolveUri(Uri modelUri)
    {
      Regex _regex = new Regex("#authority#");
      string _resolution = _regex.Replace(UrlPattern, modelUri.Authority);
      string _path = String.Join(@"", modelUri.Segments.Skip<string>(1).ToArray<string>());
      _regex = new Regex("#path#");
      _resolution = _regex.Replace(_resolution, _path);
      return new Uri(_resolution);
    }
  }
}
