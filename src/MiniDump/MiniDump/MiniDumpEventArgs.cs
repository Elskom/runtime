// Copyright (c) 2018-2021, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Event that holds the information needed to create a dump.
/// </summary>
public class MiniDumpEventArgs
{
    internal MiniDumpEventArgs(string fileName, MiniDumpType dumpType)
    {
        this.FileName = fileName;
        this.DumpType = dumpType;
    }

    /// <summary>
    /// Gets the name to use to generate the dump.
    /// </summary>
    public string FileName { get; }

    /// <summary>
    /// Gets the dump type.
    /// </summary>
    public MiniDumpType DumpType { get; }

    /// <summary>
    /// Gets or sets a value indicating whether the event that creates the dump was a success.
    /// </summary>
    public bool Success { get; set; }
}
