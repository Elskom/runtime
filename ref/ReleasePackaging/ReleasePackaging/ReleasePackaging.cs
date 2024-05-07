// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Handles application's release packaging command line.
/// </summary>
public static class ReleasePackaging
{
    /// <summary>
    /// Packages an application's Release build to a zip file.
    /// </summary>
    /// <param name="args">The command line arguments passed into the calling process.</param>
    /// <exception cref="ArgumentOutOfRangeException">When the length of args is greater than or less than 2.</exception>
    public static void PackageRelease(ReadOnlySpan<string> args)
        => throw null!;
}
