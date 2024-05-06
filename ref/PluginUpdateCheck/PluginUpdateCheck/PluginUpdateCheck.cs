// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// A generic plugin update checker.
/// </summary>
[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Ref assembly which must match ABI of runtime.")]
public sealed class PluginUpdateCheck : IDisposable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PluginUpdateCheck"/> class.
    /// </summary>
    /// <param name="serviceprovider">The serviceprovider to use for this instance.</param>
    public PluginUpdateCheck(IServiceProvider serviceprovider)
        => throw null!;

    /// <summary>
    /// Event that fires when a new message should show up.
    /// </summary>
    public static event EventHandler<MessageEventArgs>? MessageEvent
    {
        add => throw null!;
        remove => throw null!;
    }

    /// <summary>
    /// Gets the plugin urls used in all instances.
    /// </summary>
    public IList<string>? PluginUrls
        => throw null!;

    /// <summary>
    /// Gets a value indicating whether there are any pending updates and displays a message if there is.
    /// </summary>
    public bool ShowMessage
        => throw null!;

    /// <summary>
    /// Gets a list of <see cref="PluginUpdateData"/> instances representing the plugins that needs updating or are to be installed.
    /// </summary>
    public IList<PluginUpdateData> PluginUpdateDatas
        => throw null!;

    /// <summary>
    /// Checks for plugin updates from the provided plugin source urls.
    /// </summary>
    /// <param name="pluginURLs">The repository urls to the plugins.</param>
    /// <param name="pluginTypes">A list of types to the plugins to check for updates to.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="pluginURLs"/> or <paramref name="pluginTypes"/> are <see langword="null"/>.</exception>
    /// <returns>A value indicating if the operation was successful or not.</returns>
    // catches the plugin urls and uses that cache to detect added urls, and only appends those to the list.
    public bool CheckForUpdates(string[] pluginURLs, IList<Type> pluginTypes)
        => throw null!;

    /// <summary>
    /// Installs the files to the plugin pointed to by the passed in plugin update data.
    /// </summary>
    /// <param name="pluginUpdateData">The plugin update data for the plugin to install.</param>
    /// <param name="saveToZip">A bool indicating if the file should be installed to a zip file instead of a folder.</param>
    /// <returns>A bool indicating if anything changed.</returns>
    public bool Install(PluginUpdateData pluginUpdateData, bool saveToZip)
        => throw null!;

    /// <summary>
    /// Uninstalls the files to the plugin pointed to by the passed in plugin update data.
    /// </summary>
    /// <param name="pluginUpdateData">The plugin update data for the plugin to uninstall.</param>
    /// <param name="saveToZip">A bool indicating if the file should be uninstalled from a zip file instead of a folder. If the zip file after the operation becomes empty it is also deleted automatically.</param>
    /// <returns>A bool indicating if anything changed.</returns>
    public bool Uninstall(PluginUpdateData pluginUpdateData, bool saveToZip)
        => throw null!;

    /// <summary>
    /// Cleans up the resources used by <see cref="PluginUpdateCheck"/>.
    /// </summary>
    public void Dispose()
        => throw null!;
}
