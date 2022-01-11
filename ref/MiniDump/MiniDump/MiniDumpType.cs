// Copyright (c) 2018-2022, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Represents the type of dump that can be requested.
/// </summary>
public enum MiniDumpType
{
    /// <summary>
    /// Include just the information necessary to capture stack traces for all existing traces for all existing threads in a process. Limited GC heap memory and information.
    /// </summary>
    Normal = 1,

    /// <summary>
    /// Includes the GC heaps and information necessary to capture stack traces for all existing threads in a process.
    /// </summary>
    WithHeap = 2,

    /// <summary>
    /// Include just the information necessary to capture stack traces for all existing traces for all existing threads in a process. Limited GC heap memory and information.
    /// </summary>
    Triage = 3,

    /// <summary>
    /// Include all accessible memory in the process. The raw memory data is included at the end, so that the initial structures can be mapped directly without the raw memory information. This option can result in a very large dump file.
    /// </summary>
    Full = 4,
}
