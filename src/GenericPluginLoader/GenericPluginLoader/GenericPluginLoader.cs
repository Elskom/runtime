// Copyright (c) 2018-2022, Els_kom org.
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
public sealed class GenericPluginLoader
{
    /// <summary>
    /// Triggers when the Plugin Loader has a message to send to the application.
    /// </summary>
    public static event EventHandler<MessageEventArgs>? PluginLoaderMessage;

    internal Dictionary<string, List<PluginLoadContext>> Contexts { get; } = new();

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
        => this.LoadPlugins<T>(path, false);

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
    {
        List<string>? dllFileNames = null;
        if (Directory.Exists(path))
        {
            // First search for plugins under the any (universal) runtime identifier.
            dllFileNames = Directory.EnumerateFiles(
                    $"{path}{Path.DirectorySeparatorChar}any",
                    "*.dll").ToList();

            // Next, search for plugins under the current process's runtime identifier.
            // This is needed as native C++ plugins are runtime identifier (and cpu) specific.
            dllFileNames.AddRange(Directory.EnumerateFiles(
                $"{path}{Path.DirectorySeparatorChar}{RuntimeHelpers.GetCurrentRuntimeIdentifier()}",
                "*.dll"));
        }

        // try to load from a zip as well if plugins are installed in both places.
        var zippath = $"{path}.zip";
        List<T> plugins = new();
        List<PluginLoadContext> contexts = new();

        // handle when path points to a zip file.
        if (Directory.Exists(path) || File.Exists(zippath))
        {
            if (dllFileNames is not null)
            {
                foreach (var dllFile in dllFileNames)
                {
                    PluginLoadContext context = new($"Plugin#{dllFileNames.IndexOf(dllFile)}", path);
                    var instances = context.CreateInstancesFromInterface<T>(
                        dllFile,
                        dllFile.Replace(".dll", ".pdb", StringComparison.InvariantCulture));
                    context.UnloadIfNoInstances(instances);
                    if (instances.Any())
                    {
                        contexts.Add(context);
                    }
                }
            }

            if (saveToZip && File.Exists(zippath))
            {
                Dictionary<string, int> filesInZip = new();
                using (var zipFile = ZipFile.OpenRead(zippath))
                {
                    foreach (var entry in zipFile.Entries)
                    {
                        if (entry.FullName.Contains(RuntimeHelpers.GetCurrentRuntimeIdentifier(), StringComparison.OrdinalIgnoreCase)
                            || entry.FullName.Contains("any", StringComparison.OrdinalIgnoreCase))
                        {
                            filesInZip.Add(entry.FullName, zipFile.Entries.IndexOf(entry));
                        }
                    }
                }

                // just lookup the dlls here. The LoadFromZip method will load the pdb’s if they are deemed needed.
                foreach (var entry in filesInZip.Keys.Where(entry => entry.EndsWith(".dll", StringComparison.Ordinal)))
                {
                    PluginLoadContext context = new($"ZipPlugin#{filesInZip[entry]}", path);
                    var instances = RuntimeExtensions.CreateInstancesFromInterface<T>(ZipAssembly.LoadFromZip(zippath, entry, context));
                    context.UnloadIfNoInstances(instances);
                    if (instances.Any())
                    {
                        contexts.Add(context);
                    }
                }
            }
        }

        _ = this.Contexts.TryAdd(typeof(T).Name, contexts);
        return plugins;
    }

    /// <summary>
    /// Unloads all of the loaded plugins of the input type.
    /// </summary>
    /// <typeparam name="T">The type to use when unloading plugins.</typeparam>
    public void UnloadPlugins<T>()
    {
        this.UnloadPluginsInternal(typeof(T).Name);
        this.Contexts.Remove(typeof(T).Name);
    }

    /// <summary>
    /// Unloads all of the loaded plugins.
    /// </summary>
    public void UnloadPlugins()
    {
        foreach (var key in this.Contexts.Keys)
        {
            this.UnloadPluginsInternal(key);
        }

        this.Contexts.Clear();
    }

    internal static void InvokeLoaderMessage(MessageEventArgs args)
        => PluginLoaderMessage?.Invoke(null, args);

    private void UnloadPluginsInternal(string key)
    {
        foreach (var context in this.Contexts[key].Where(context => context.IsCollectible))
        {
            context.Unload();
        }

        this.Contexts[key].Clear();
    }
}
