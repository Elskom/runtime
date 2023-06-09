// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Extensions to <see cref="IServiceCollection"/>.
/// </summary>
public static class PluginUpdateServiceCollectionExtensions
{
    /// <summary>
    /// Adds an instance of <see cref="PluginUpdateCheck"/> to the target <see cref="IServiceCollection"/>.
    /// </summary>
    /// <param name="collection">
    /// The target <see cref="IServiceCollection"/> to add an instance of
    /// <see cref="PluginUpdateCheck"/> to.
    /// </param>
    /// <returns>The target <see cref="IServiceCollection"/> to allow call chains.</returns>
    public static IServiceCollection AddPluginUpdateCheck(this IServiceCollection collection)
        => collection.AddSingleton<PluginUpdateCheck>();
}
