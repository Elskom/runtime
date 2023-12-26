// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// The Plugin Update data for a plugin.
/// </summary>
[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Ref assembly which must match ABI of runtime.")]
public struct PluginUpdateData : IEquatable<PluginUpdateData>
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
    public IList<string?> DownloadFiles
        => throw null!;

    public static bool operator ==(PluginUpdateData left, PluginUpdateData right)
        => throw null!;

    public static bool operator !=(PluginUpdateData left, PluginUpdateData right)
        => throw null!;

    /// <inheritdoc/>
    public override readonly bool Equals(object? obj)
        => throw null!;

    /// <inheritdoc/>
    public readonly bool Equals(PluginUpdateData other)
        => throw null!;

    /// <inheritdoc/>
    public override readonly int GetHashCode()
        => throw null!;
}
