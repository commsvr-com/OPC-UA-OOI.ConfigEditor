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

using UAOOI.Configuration.Networking.Serialization;

namespace CAS.CommServer.UA.OOI.ConfigurationEditor.ConfigurationDataModel
{
  /// <summary>
  /// Class ConfigurationVersionDataTypeWrapper.
  /// </summary>
  /// <seealso cref="CAS.Windows.mvvm.Bindable" />
  public class ConfigurationVersionDataTypeWrapper : Wrapper<ConfigurationVersionDataType>
  {

    internal ConfigurationVersionDataTypeWrapper(ConfigurationVersionDataType versionInformation) :
      base(versionInformation == null ? new ConfigurationVersionDataType() : versionInformation)
    {
      b_Version2Display = ToString();
    }
    /// <summary>
    /// Gets or sets the major version.
    /// </summary>
    /// <value>The major version.</value>
    public byte MajorVersion
    {
      get { return Item.MajorVersion; }
      set
      {
        if ( SetProperty(Item.MajorVersion, x => Item.MajorVersion = x, value))
          Version2Display = ToString();
      }
    }
    /// <summary>
    /// Gets or sets the minor version.
    /// </summary>
    /// <value>The minor version.</value>
    public byte MinorVersion
    {
      get { return Item.MinorVersion; }
      set
      {
        if (SetProperty(Item.MinorVersion, x => Item.MinorVersion = x, value))
          Version2Display = ToString();
      }
    }
    /// <summary>
    /// Gets the version2 display.
    /// </summary>
    /// <value>The version2 display.</value>
    public string Version2Display
    {
      get
      {
        return b_Version2Display;
      }
      private set
      {
        SetProperty<string>(ref b_Version2Display, value);
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
      return new ConfigurationVersionDataTypeWrapper(new ConfigurationVersionDataType() { MajorVersion = 0, MinorVersion = 0 });
    }
    internal void IncrementMajorVersion()
    {
      MajorVersion++;
      MinorVersion = 0;
    }

    #region private
    private string b_Version2Display;
    #endregion

  }
}