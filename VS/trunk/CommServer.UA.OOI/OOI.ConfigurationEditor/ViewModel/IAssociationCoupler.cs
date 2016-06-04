//_______________________________________________________________
//  Title   : IAssociationCoupler 
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

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ViewModel
{

  /// <summary>
  /// Interface IAssociationCoupler - define  basic functionality to manage association between <see cref="ConfigurationDataModel.DataSetConfigurationWrapper"/> and 
  /// <see cref="ConfigurationDataModel.MessageHandlerConfigurationWrapper{type}"/>
  /// </summary>
  internal interface IAssociationCoupler
  {

    /// <summary>
    /// Gets or sets a value indicating whether the parties are associated.
    /// </summary>
    /// <value><c>true</c> if associated; otherwise, <c>false</c>.</value>
    bool Associated { get; set; }
    /// <summary>
    /// Gets the title of the association.
    /// </summary>
    /// <value>The title.</value>
    string Title { get;  }
    /// <summary>
    /// Reverts the association to the initial state.
    /// </summary>
    void Revert();

  }
}
