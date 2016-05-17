//_______________________________________________________________
//  Title   : ConfigurationVersionDataTypeWrapper
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

using CAS.Windows.mvvm;
using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{
  /// <summary>
  /// Class ConfigurationVersionDataTypeWrapper.
  /// </summary>
  /// <seealso cref="CAS.Windows.mvvm.Bindable" />
  public class ConfigurationVersionDataTypeWrapper : Bindable
  {

    internal ConfigurationVersionDataTypeWrapper(ConfigurationVersionDataType versionInformation)
    {
      m_ConfigurationVersionDataType = versionInformation == null ? new ConfigurationVersionDataType() : versionInformation;
    }
    public byte MajorVersion
    {
      get { return m_ConfigurationVersionDataType.MajorVersion; }
      set
      {
        SetProperty(m_ConfigurationVersionDataType.MajorVersion, x => m_ConfigurationVersionDataType.MajorVersion = x, value);
      }
    }
    public byte MinorVersion
    {
      get { return m_ConfigurationVersionDataType.MinorVersion; }
      set
      {
        SetProperty(m_ConfigurationVersionDataType.MinorVersion, x => m_ConfigurationVersionDataType.MinorVersion = x, value);
      }
    }
    /// <summary>
    /// Returns a <see cref="System.String" /> that represents this instance.
    /// </summary>
    /// <returns>A <see cref="System.String" /> that represents this instance.</returns>
    public override string ToString()
    {
      return $"{MajorVersion}.{MinorVersion}";
    }
    internal static ConfigurationVersionDataTypeWrapper CreateDefault()
    {
      return new ConfigurationVersionDataTypeWrapper() { MajorVersion = 0, MinorVersion = 0 };
    }

    #region private
    private ConfigurationVersionDataType m_ConfigurationVersionDataType;
    private ConfigurationVersionDataTypeWrapper()
    {
      m_ConfigurationVersionDataType = new ConfigurationVersionDataType();
    }
    #endregion

  }
}