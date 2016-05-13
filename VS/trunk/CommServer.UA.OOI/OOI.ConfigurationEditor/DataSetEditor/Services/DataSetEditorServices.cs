//_______________________________________________________________
//  Title   : DataSetEditorServices
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

using CAS.CommServer.UAOOI.ConfigurationEditor.ConfigurationDataModel;
using Prism.Commands;
using System;
using System.Collections.ObjectModel;
using System.ComponentModel.Composition;
using System.Globalization;
using System.Windows.Input;
using System.Linq;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.DataSetEditor.Services
{
  [Export(typeof(IDataSetEditorServices))]
  [PartCreationPolicy(CreationPolicy.Shared)]
  internal class DataSetEditorServices : IDataSetEditorServices
  {
    [ImportingConstructor]
    internal DataSetEditorServices(IDataSetModelServices dataSetModelServices)
    {
      if (dataSetModelServices == null)
        throw new ArgumentNullException(nameof(dataSetModelServices));
      this.m_IDataSetServices = dataSetModelServices;
      m_DataSetItems = new ObservableCollection<string>(dataSetModelServices.GetDataSets().Select<DataSetConfigurationWrapper, string>(x => x.SymbolicName));
      AddCommand = new DelegateCommand<string>(AddDataSet);
    }
    public ObservableCollection<string> RetrieveList()
    {
      return m_DataSetItems;
    }
    public ICommand AddCommand
    {
      get; set;
    }
    private void AddDataSet(string dataSetIdentifier)
    {
      if (String.IsNullOrEmpty(dataSetIdentifier))
        return;
      string _upperCasedTrimmedSymbol = dataSetIdentifier.ToUpper(CultureInfo.InvariantCulture).Trim();
      if (!m_DataSetItems.Contains(_upperCasedTrimmedSymbol) && !m_IDataSetServices.DataSetExists(_upperCasedTrimmedSymbol))
        m_DataSetItems.Add(_upperCasedTrimmedSymbol);
    }
    private ObservableCollection<string> m_DataSetItems { get; set; }
    private readonly IDataSetModelServices m_IDataSetServices;

  }
}
