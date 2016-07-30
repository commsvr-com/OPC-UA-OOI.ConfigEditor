
using CAS.CommServer.UA.OOI.ConfigurationEditor.DomainsModel;
using CAS.CommServer.UA.OOI.ConfigurationEditor.Infrastructure.Converters;
using CAS.Windows.ViewModel;
using Prism.Commands;
using Prism.Logging;
using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using UAOOI.DataDiscovery.DiscoveryServices;
using UAOOI.DataDiscovery.DiscoveryServices.Models;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainEditor
{
  /// <summary>
  /// Class DomainModelResolveViewModel - provides functionality supporting InformationMode Uri resolve functionality.
  /// </summary>
  public class DomainModelResolveViewModel : ConfirmationBindable
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainModelResolveViewModel"/> class.
    /// </summary>
    /// <param name="log">The log.</param>
    public DomainModelResolveViewModel(Action<string, Category, Prism.Logging.Priority> log)
    {
      LookupDNSCommand = DelegateCommand.FromAsyncHandler(DomainDiscoveryAsync);
      ResolvedDomainModel = null;
      InformationModelURI = new Uri("http://commsvr.com/UA/Examples/BoilersSet");
      m_Logger = log;
      m_LoggerAction = (x, y, z) => { LogList.Add(x); m_Logger(x, y, z); };
    }
    public Uri InformationModelURI
    {
      get
      {
        return b_InformationModelURI;
      }
      set
      {
        SetProperty<Uri>(ref b_InformationModelURI, value);
      }
    }
    public DomainModelWrapper ResolvedDomainModel
    {
      get
      {
        return b_ResolvedDomainModel;
      }
      set
      {
        SetProperty<DomainModelWrapper>(ref b_ResolvedDomainModel, value);
      }
    }
    public ICommand LookupDNSCommand { get; }
    public bool? CurrentIsEnabled
    {
      get
      {
        return b_CurrentIsEnabled;
      }
      set
      {
        SetProperty<bool?>(ref b_CurrentIsEnabled, value);
      }
    }
    public Cursor CurrentCursor
    {
      get
      {
        return b_CurrentCursor;
      }
      set
      {
        SetProperty<Cursor>(ref b_CurrentCursor, value);
      }
    }
    public ObservableCollection<string> LogList { get; } = new ObservableCollection<string>();
    #region private
    //vars
    private DomainModelWrapper b_ResolvedDomainModel;
    private Uri b_InformationModelURI;
    private Cursor b_CurrentCursor;
    private bool? b_CurrentIsEnabled;
    private readonly Action<string, Category, Prism.Logging.Priority> m_Logger;
    private Action<string, Category, Prism.Logging.Priority> m_LoggerAction;
    //methods
    private async Task DomainDiscoveryAsync()
    {
      ResolvedDomainModel = null;
      LogList.Clear();
      Cursor _currentCursor = CurrentCursor;
      bool? _currentIsEnabled = CurrentIsEnabled;
      try
      {
        CurrentCursor = Cursors.Wait;
        CurrentIsEnabled = false;
        DomainModel _newDomainModel = null;
        using (UAOOI.DataDiscovery.DiscoveryServices.DataDiscoveryServices _service = new DataDiscoveryServices())
        {
          _newDomainModel = await _service.ResolveDomainModelAsync
            (InformationModelURI, new Uri(Properties.Settings.Default.DataDiscoveryRootServiceUrl), (x, y, z) => m_LoggerAction(x, y.TraceEventType2Category(), z.Priority2Priority()));
        }
        string[] _segments = InformationModelURI.Segments;
        string _aliasName = String.Empty;
        if (_segments.Length >= 1)
        {
          _segments[0] = InformationModelURI.Host;
          _aliasName = String.Join(".", _segments).Replace("/", "");
        }
        else
          _aliasName = "Enter alias for this domain";
        ResolvedDomainModel = new DomainModelWrapper(_newDomainModel);
      }
      catch (System.Exception _e)
      {
        MessageBox.Show($"Error while resolving the domain description {_e}", "Resolving of Semantics Data", MessageBoxButton.OK, MessageBoxImage.Warning);
      }
      finally
      {
        CurrentCursor = _currentCursor;
        CurrentIsEnabled = _currentIsEnabled;
      }
    }
    #endregion

  }
}
