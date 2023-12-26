// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Event that holds the information needed to create a dump.
/// </summary>
[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Ref assembly which must match ABI of runtime.")]
public class MiniDumpEventArgs : EventArgs
{
    /// <summary>
    /// Gets the process id of the current process that the dump is to be made on.
    /// </summary>
    public int ProcessId
        => throw null!;

    /// <summary>
    /// Gets the name to use to generate the dump.
    /// </summary>
    public string FileName
        => throw null!;

    /// <summary>
    /// Gets or sets the error message when generating the dump.
    /// </summary>
    public string? ErrorMessage
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets the dump type.
    /// </summary>
    public MiniDumpType DumpType
        => throw null!;

    /// <summary>
    /// Gets or sets a value indicating whether the event that creates the dump was a success.
    /// </summary>
    public bool Success
    {
        get => throw null!;
        set => throw null!;
    }
}
