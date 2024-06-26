﻿// Copyright (c) 2018-2024, Els_kom org.
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
    {
        ArgumentNullException.ThrowIfNull(ms);
        ArgumentOutOfRangeException.ThrowIfLessThan(capacity, 0);
        var len = ms.GetBuffer().Length;
        var changeCapacity = len != capacity;
        Array.Clear(ms.GetBuffer(), 0, len);
        ms.Position = 0;
        ms.SetLength(0);
        ms.Capacity = 0; // ensure buffer's bytes are cleared (0 bytes long).

        // avoid setting to the same value twice.
        if (changeCapacity && capacity != 0)
        {
            // resize to passed in capacity to avoid allocating a new array that will
            // be resized on demand when the user keeps using the stream after clearing
            // it as it will hurt performance a lot because it will be resized many times.
            ms.Capacity = capacity;
        }
    }
}
