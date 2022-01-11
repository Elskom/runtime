// Copyright (c) 2018-2022, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Extensions to <see cref="IServiceCollection"/>.
/// </summary>
public static class PluginLoaderServiceCollectionExtensions
{
    /// <summary>
    /// Adds an instance of <see cref="GenericPluginLoader"/> to the target <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="collection">
    /// The target <see cref="IServiceCollection"/> to add an instance of
    /// <see cref="GenericPluginLoader"/> to.
    /// </param>
    /// <returns>The target <see cref="IServiceCollection"/> to allow call chains.</returns>
    public static IServiceCollection AddGenericPluginLoader(this IServiceCollection collection)
        => collection.AddSingleton<GenericPluginLoader>();
}
