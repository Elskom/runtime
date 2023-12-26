// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

/*
 Credits to this file goes to the C# plugin
 loader & interface examples.
*/

namespace Elskom.Generic.Libs;

/// <summary>
/// A generic loader for plugins.
/// </summary>
[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Ref assembly which must match ABI of runtime.")]
public sealed class GenericPluginLoader
{
    /// <summary>
    /// Triggers when the Plugin Loader has a message to send to the application.
    /// </summary>
    public static event EventHandler<MessageEventArgs>? PluginLoaderMessage
    {
        add => throw null!;
        remove => throw null!;
    }

    /// <summary>
    /// Loads plugins with the specified plugin interface type.
    /// </summary>
    /// <param name="path">
    /// The path to look for plugins to load.
    /// </param>
    /// <returns>
    /// A list of plugins loaded that derive from the specified type.
    /// </returns>
    /// <typeparam name="T">The type to look for when loading plugins.</typeparam>
    public ICollection<T> LoadPlugins<T>(string path)
        => throw null!;

    /// <summary>
    /// Loads plugins with the specified plugin interface type.
    /// </summary>
    /// <param name="path">
    /// The path to look for plugins to load.
    /// </param>
    /// <param name="saveToZip">
    /// Tells this function to see if the plugin was saved to a zip file and it's pdb file as well.
    /// </param>
    /// <returns>
    /// A list of plugins loaded that derive from the specified type.
    /// </returns>
    /// <typeparam name="T">The type to look for when loading plugins.</typeparam>
    public ICollection<T> LoadPlugins<T>(string path, bool saveToZip)
        => throw null!;

    /// <summary>
    /// Unloads all of the loaded plugins of the input type.
    /// </summary>
    /// <typeparam name="T">The type to use when unloading plugins.</typeparam>
    public void UnloadPlugins<T>()
        => throw null!;

    /// <summary>
    /// Unloads all of the loaded plugins.
    /// </summary>
    public void UnloadPlugins()
        => throw null!;
}
