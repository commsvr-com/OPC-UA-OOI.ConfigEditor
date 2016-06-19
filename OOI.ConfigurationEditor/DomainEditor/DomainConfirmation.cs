//_______________________________________________________________
//  Title   : DomainConfirmation
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
using CAS.Windows.ViewModel;
using Prism.Commands;
using System.Windows.Input;
using System.Windows;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.DomainEditor
{
  internal class DomainConfirmation : ConfirmationBindable
  {

    /// <summary>
    /// Initializes a new instance of the <see cref="DomainConfirmation"/> class.
    /// </summary>
    /// <param name="domain">The domain.</param>
    internal DomainConfirmation(DomainWrapper domain)
    {
      DomainConfigurationWrapper = domain;
      LookupDNSCommand = new DelegateCommand(OnLookupDNSRaised);
    }
    #region DataContext
    /// <summary>
    /// Gets the domain configuration wrapper.
    /// </summary>
    /// <remarks>
    /// It is to be used by the GUI.
    /// </remarks>
    /// <value>The domain configuration wrapper <see cref="DomainWrapper"/>.</value>
    public DomainWrapper DomainConfigurationWrapper { get; private set; }
    public ICommand LookupDNSCommand { get; }
    #endregion
    internal void ApplyChanges()
    {
      DomainConfigurationWrapper.ApplyChanges();
    }
    private void OnLookupDNSRaised()
    {
      MessageBox.Show("Not implemented, send request to mpostol@cas.eu", "Lookup DNS to discover Semantics Data", MessageBoxButton.OK, MessageBoxImage.Warning);
    }

  }
}
