// Copyright (c) 2018-2021, Els_kom org.
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
    /// Adds an instance of <see cref="GenericPluginLoader{T}"/> to the target <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="collection">
    /// The target <see cref="IServiceCollection"/> to add an instance of
    /// <see cref="GenericPluginLoader{T}"/> to.
    /// </param>
    /// <typeparam name="T">The type to use with the PluginLoader.</typeparam>
    /// <returns>The target <see cref="IServiceCollection"/> to allow call chains.</returns>
    public static IServiceCollection AddGenericPluginLoader<T>(this IServiceCollection collection)
        => throw null!;
}
