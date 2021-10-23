// Copyright (c) 2018-2021, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// A generic plugin update checker.
/// </summary>
public sealed class PluginUpdateCheck : IDisposable
{
    /// <summary>
    /// Event that fires when a new message should show up.
    /// </summary>
    public static event EventHandler<MessageEventArgs> MessageEvent
    {
        add => throw null!;
        remove => throw null!;
    }

    /// <summary>
    /// Gets the plugin urls used in all instances.
    /// </summary>
    public static List<string> PluginUrls
        => throw null!;

    /// <summary>
    /// Gets a value indicating whether there are any pending updates and displays a message if there is.
    /// </summary>
    public bool ShowMessage
        => throw null!;

    /// <summary>
    /// Gets the plugin name this instance is pointing to.
    /// </summary>
    public string PluginName
        => throw null!;

    /// <summary>
    /// Gets the current version of the plugin that is pointed to by this instance.
    /// </summary>
    public string CurrentVersion
        => throw null!;

    /// <summary>
    /// Gets the installed version of the plugin that is pointed to by this instance.
    /// </summary>
    public string InstalledVersion
        => throw null!;

    /// <summary>
    /// Gets the url to download the files to the plugin from.
    /// </summary>
    public Uri DownloadUrl
        => throw null!;

    /// <summary>
    /// Gets the files to the plugin to download.
    /// </summary>
    public List<string> DownloadFiles
        => throw null!;

    /// <summary>
    /// Checks for plugin updates from the provided plugin source urls.
    /// </summary>
    /// <param name="pluginURLs">The repository urls to the plugins.</param>
    /// <param name="pluginTypes">A list of types to the plugins to check for updates to.</param>
    /// <param name="serviceprovider">The <see cref="IServiceProvider"/> to use.</param>
    /// <returns>A list of <see cref="PluginUpdateCheck"/> instances representing the plugins that needs updating or are to be installed.</returns>
    // catches the plugin urls and uses that cache to detect added urls, and only appends those to the list.
    public static List<PluginUpdateCheck> CheckForUpdates(string[] pluginURLs, List<Type> pluginTypes, IServiceProvider serviceprovider)
        => throw null!;

    /// <summary>
    /// Installs the files to the plugin pointed to by this instance.
    /// </summary>
    /// <param name="saveToZip">A bool indicating if the file should be installed to a zip file instead of a folder.</param>
    /// <returns>A bool indicating if anything changed.</returns>
    public bool Install(bool saveToZip)
        => throw null!;

    /// <summary>
    /// Uninstalls the files to the plugin pointed to by this instance.
    /// </summary>
    /// <param name="saveToZip">A bool indicating if the file should be uninstalled from a zip file instead of a folder. If the zip file after the operation becomes empty it is also deleted automatically.</param>
    /// <returns>A bool indicating if anything changed.</returns>
    public bool Uninstall(bool saveToZip)
        => throw null!;

    /// <summary>
    /// Cleans up the resources used by <see cref="PluginUpdateCheck"/>.
    /// </summary>
    public void Dispose()
        => throw null!;
}
