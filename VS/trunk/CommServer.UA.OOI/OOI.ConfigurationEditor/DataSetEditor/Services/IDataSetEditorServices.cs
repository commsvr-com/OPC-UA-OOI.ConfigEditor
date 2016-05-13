// Copyright (c) Microsoft Corporation. All rights reserved. See License.txt in the project root for license information.

using System.Collections.ObjectModel;
using System.Windows.Input;

namespace CAS.CommServer.UAOOI.ConfigurationEditor.DataSetEditor.Services
{
    internal interface IDataSetEditorServices
    {
        ObservableCollection<string> RetrieveList();
        ICommand AddCommand { get; set; }
    }
}