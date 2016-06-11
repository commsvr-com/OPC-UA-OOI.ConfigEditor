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

using CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel;
using CAS.Windows.ViewModel;

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
    }
    /// <summary>
    /// Gets the domain configuration wrapper.
    /// </summary>
    /// <remarks>
    /// It is to be used by the GUI.
    /// </remarks>
    /// <value>The domain configuration wrapper <see cref="DomainWrapper"/>.</value>
    public DomainWrapper DomainConfigurationWrapper { get; private set; }
    /// <summary>
    /// Reverts this instance to the initial state.
    /// </summary>
    /// <exception cref="System.NotImplementedException"></exception>
    internal void Revert()
    {
      //TODO Must be implemented
    }

  }
}
