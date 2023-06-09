// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Load assemblies from a zip file.
/// </summary>
[Serializable]
public sealed class ZipAssembly : Assembly
{
    /// <summary>
    /// Gets the location of the assembly in the zip file.
    /// </summary>
    public override string Location
        => throw null!;

    /// <summary>
    /// Loads the assembly with it’s debugging symbols
    /// from the specified zip file.
    /// </summary>
    /// <param name="zipFileName">The zip file for which to look for the assembly in.</param>
    /// <param name="assemblyName">The assembly file name to load.</param>
    /// <param name="context">The context to load the assemblies into.</param>
    /// <returns>A new <see cref="ZipAssembly"/> that represents the loaded assembly.</returns>
    /// <exception cref="ArgumentException">
    /// When <paramref name="zipFileName"/> is null, Empty, or does not exist.
    /// Or <paramref name="assemblyName"/> is null, Empty or does not end with the '.dll' extension.
    /// </exception>
    /// <exception cref="ZipAssemblyLoadException">
    /// When the assembly name specified was not found in the input zip file.
    /// </exception>
    /// <exception cref="Exception">
    /// Any other exception not documented here indirectly thrown by this
    /// If any other exceptions other than the ones above is thrown from a call to this, it exposes a bug.
    /// </exception>
    public static ZipAssembly? LoadFromZip(string zipFileName, string assemblyName, AssemblyLoadContext context)
        => throw null!;
}
