
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

    #region constructor
    /// <summary>
    /// Initializes a new instance of the <see cref="DomainModelResolveViewModel"/> class.
    /// </summary>
    /// <param name="log">The log.</param>
    public DomainModelResolveViewModel(Action<string, Category, Prism.Logging.Priority> log)
    {
      ClearUserInterface();
      LookupDNSCommand = DelegateCommand.FromAsyncHandler(DomainDiscoveryAsync);
      InformationModelURI = new Uri(Properties.Settings.Default.DefaultInformationModelUri);
      m_Logger = log;
      m_LoggerAction = (x, y, z) => { LogList.Add(x); m_Logger(x, y, z); };
    }
    #endregion    

    #region context
    /// <summary>
    /// Gets or sets the information model URI to be resolved.
    /// </summary>
    /// <value>The information model URI.</value>
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
    /// <summary>
    /// Gets or sets the resolved domain model.
    /// </summary>
    /// <value>The resolved domain model.</value>
    public DomainModelWrapper ResolvedDomainModel
    {
      get
      {
        return b_ResolvedDomainModel;
      }
      set
      {
        SetProperty<DomainModelWrapper>(ref b_ResolvedDomainModel, value);
        if (value != null)
        {
          ResolvedResultDescriptor = $"{value.ToString()} has been resolved";
          ResolvedResultIconSourcePath = @"../Resources/StatusOK_32x.png";
        }
        else
        {
          ResolvedResultDescriptor = "Not yet resolved";
          ResolvedResultIconSourcePath = @"../Resources/StatusWarning_cyan_31x32.png";
        }
      }
    }
    /// <summary>
    /// Gets the lookup DNS command.
    /// </summary>
    /// <value>The lookup DNS command.</value>
    public ICommand LookupDNSCommand { get; }
    /// <summary>
    /// Gets or sets a value indicating whether the current control is enabled.
    /// </summary>
    /// <value><c>null</c> or <c>true</c> if current control is enabled; otherwise, <c>false</c>.</value>
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
    /// <summary>
    /// Gets or sets the current cursor.
    /// </summary>
    /// <value>The current cursor.</value>
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
    /// <summary>
    /// Gets the log list.
    /// </summary>
    /// <value>The log list.</value>
    public ObservableCollection<string> LogList { get; } = new ObservableCollection<string>();
    /// <summary>
    /// Gets or sets the resolved result descriptor to be displayed on the user interface.
    /// </summary>
    /// <value>The resolved result descriptor.</value>
    public string ResolvedResultDescriptor
    {
      get
      {
        return b_ResolvedResultDescriptor;
      }
      set
      {
        SetProperty<string>(ref b_ResolvedResultDescriptor, value);
      }
    }

    private string b_ResolvedResultIconSourcePath;
    public string ResolvedResultIconSourcePath
    {
      get
      {
        return b_ResolvedResultIconSourcePath;
      }
      set
      {
        SetProperty<string>(ref b_ResolvedResultIconSourcePath, value);
      }
    }
    #endregion

    #region private
    //vars
    private DomainModelWrapper b_ResolvedDomainModel;
    private Uri b_InformationModelURI;
    private Cursor b_CurrentCursor;
    private bool? b_CurrentIsEnabled;
    private string b_ResolvedResultDescriptor;
    private readonly Action<string, Category, Prism.Logging.Priority> m_Logger;
    private Action<string, Category, Prism.Logging.Priority> m_LoggerAction;
    //methods
    private async Task DomainDiscoveryAsync()
    {
      ClearUserInterface();
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
    private void ClearUserInterface()
    {
      ResolvedDomainModel = null;
    }
    #endregion

  }
}
