// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// The Plugin Update data for a plugin.
/// </summary>
public struct PluginUpdateData : IEquatable<PluginUpdateData>
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
    public IList<string?> DownloadFiles { get; internal set; }

    public static bool operator ==(PluginUpdateData left, PluginUpdateData right)
        => left.Equals(right);

    public static bool operator !=(PluginUpdateData left, PluginUpdateData right)
        => !(left == right);

    /// <inheritdoc/>
    public override readonly bool Equals(object? obj)
        => obj is PluginUpdateData data
        && this.PluginName == data.PluginName
        && this.CurrentVersion == data.CurrentVersion
        && this.InstalledVersion == data.InstalledVersion
        && EqualityComparer<Uri>.Default.Equals(this.DownloadUrl, data.DownloadUrl)
        && EqualityComparer<IList<string?>>.Default.Equals(this.DownloadFiles, data.DownloadFiles);

    /// <inheritdoc/>
    public readonly bool Equals(PluginUpdateData other)
        => this.Equals((object)other);

    /// <inheritdoc/>
    public override readonly int GetHashCode()
        => HashCode.Combine(this.PluginName, this.CurrentVersion, this.InstalledVersion, this.DownloadUrl, this.DownloadFiles);
}
