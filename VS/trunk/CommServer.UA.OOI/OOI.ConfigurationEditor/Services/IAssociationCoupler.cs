//_______________________________________________________________
//  Title   : IAssociationCoupler 
//  System  : Microsoft VisualStudio 2015 / C#
//  $LastChangedDate: 2016-06-04 15:42:29 +0200 (So, 04 cze 2016) $
//  $Rev: 12225 $
//  $LastChangedBy: mpostol $
//  $URL: svn://svnserver.hq.cas.com.pl/VS/trunk/CommServer.UA.OOI/OOI.ConfigurationEditor/ViewModel/IAssociationCoupler.cs $
//  $Id: IAssociationCoupler.cs 12225 2016-06-04 13:42:29Z mpostol $
//
//  Copyright (C) 2016, CAS LODZ POLAND.
//  TEL: +48 (42) 686 25 47
//  mailto://techsupp@cas.eu
//  http://www.cas.eu
//_______________________________________________________________

using CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.Services
{

  /// <summary>
  /// Interface IAssociationCoupler - define  basic functionality to manage association between <see cref="ConfigurationDataModel.DataSetConfigurationWrapper"/> and 
  /// <see cref="MessageHandlerConfigurationWrapper{type}"/>
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
