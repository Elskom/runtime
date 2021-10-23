// Copyright (c) 2018-2021, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <inheritdoc/>
public class PluginLoadContext : AssemblyLoadContext
{
    /// <summary>
    /// Initializes a new instance of the <see cref="PluginLoadContext"/> class.
    /// </summary>
    /// <param name="name">The name of the load context.</param>
    /// <param name="pluginPath">The path the the plugins.</param>
    public PluginLoadContext(string name, string pluginPath)
        : base(name, true)
        => throw null!;

    /// <inheritdoc/>
    protected override Assembly? Load(AssemblyName assemblyName)
        => throw null!;

    /// <inheritdoc/>
    protected override IntPtr LoadUnmanagedDll(string unmanagedDllName)
        => throw null!;
}
