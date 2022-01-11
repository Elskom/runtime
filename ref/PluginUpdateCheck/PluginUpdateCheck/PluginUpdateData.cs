// Copyright (c) 2018-2022, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// The Plugin Update data for a plugin.
/// </summary>
public struct PluginUpdateData
{
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
}
