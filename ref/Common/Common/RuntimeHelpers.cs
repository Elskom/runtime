// Copyright (c) 2018-2022, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Internal Runtime Helpers.
/// </summary>
public static class RuntimeHelpers
{
    /// <summary>
    /// Gets the runtime identifier for the current process,
    /// that is it transforms the operating system and the process architecture
    /// of the current process into an valid runtime identifier that the .NET SDK has.
    /// </summary>
    /// <returns>
    /// An Runtime Identifier string, or null if it cannot be converted into an runtime identifier.
    /// </returns>
    public static string GetCurrentRuntimeIdentifier()
        => throw null;
}
