// Copyright (c) 2018-2022, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// A extension class for extensions to <see cref="MemoryStream"/>.
/// </summary>
public static class MemoryStreamExtensions
{
    /// <summary>
    /// Clears the data in the <see cref="MemoryStream"/>.
    /// </summary>
    /// <param name="ms">The input <see cref="MemoryStream"/>.</param>
    /// <param name="capacity">The capacity to set the capacity of the stream to.</param>
    /// <exception cref="ArgumentNullException">When the input <see cref="MemoryStream"/> is <see langword="null"/>.</exception>
    /// <exception cref="ArgumentOutOfRangeException">When capacity is negative.</exception>
    public static void Clear(this MemoryStream ms, int capacity)
        => throw null!;
}
