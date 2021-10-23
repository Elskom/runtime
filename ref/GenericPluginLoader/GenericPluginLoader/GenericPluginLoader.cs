// Copyright (c) 2018-2021, Els_kom org.
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
/// <typeparam name="T">The type to look for when loading plugins.</typeparam>
public class GenericPluginLoader<T>
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
    /// Gets the list of <see cref="PluginLoadContext"/>s loaded by this instance.
    /// </summary>
    public List<PluginLoadContext> Contexts
        => throw null!;

    /// <summary>
    /// Loads plugins with the specified plugin interface type.
    /// </summary>
    /// <param name="path">
    /// The path to look for plugins to load.
    /// </param>
    /// <returns>
    /// A list of plugins loaded that derive from the specified type.
    /// </returns>
    public ICollection<T> LoadPlugins(string path)
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
    public ICollection<T> LoadPlugins(string path, bool saveToZip)
        => throw null!;

    /// <summary>
    /// Unloads all of the loaded plugins.
    /// </summary>
    public void UnloadPlugins()
        => throw null!;
}
