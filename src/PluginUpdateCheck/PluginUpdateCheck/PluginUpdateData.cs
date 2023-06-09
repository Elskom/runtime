// Copyright (c) 2018-2023, Els_kom org.
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
    public string PluginName { get; internal set; }

    /// <summary>
    /// Gets the current version of the plugin that is pointed to by this instance.
    /// </summary>
    public string CurrentVersion { get; internal set; }

    /// <summary>
    /// Gets the installed version of the plugin that is pointed to by this instance.
    /// </summary>
    public string InstalledVersion { get; internal set; }

    /// <summary>
    /// Gets the url to download the files to the plugin from.
    /// </summary>
    public Uri DownloadUrl { get; internal set; }

    /// <summary>
    /// Gets the files to the plugin to download.
    /// </summary>
    public List<string?> DownloadFiles { get; internal set; }
}
