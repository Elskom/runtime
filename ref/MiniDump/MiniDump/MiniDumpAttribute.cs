// Copyright (c) 2018-2022, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Attribute for creating MiniDumps.
///
/// This registers Unhandled exception handlers to do it.
/// For Thread Exceptions use register one manually then call the static method:
/// DumpException(/* exception object inside the event args*/, true);
///
/// This will then allow minidumps from them too.
///
/// The api was changed so that way the library would not need separate configurations
/// targeting Windows Forms to bring thread exception support and making build harder to maintain.
/// </summary>
[AttributeUsage(AttributeTargets.Class | AttributeTargets.Assembly | AttributeTargets.Method)]
public sealed class MiniDumpAttribute : Attribute
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MiniDumpAttribute"/> class.
    /// </summary>
    public MiniDumpAttribute()
        => throw null!;

    /// <summary>
    /// Occurs when a mini-dump is generated or fails.
    /// </summary>
    public static event EventHandler<MessageEventArgs> DumpMessage
    {
        add => throw null!;
        remove => throw null!;
    }

    /// <summary>
    /// Gets the current instance of this attribute.
    /// </summary>
    public static MiniDumpAttribute CurrentInstance
        => throw null!;

    /// <summary>
    /// Gets a value indicating whether the application should force close.
    /// <para>Lets the program know that it needs to close even if it is
    /// not wanted because a crash dump was created by this library and we
    /// do not want the system itself to produce a second one.</para>
    /// </summary>
    public static bool ForceClose
        => throw null!;

    /// <summary>
    /// Gets or sets the Exception message text.
    /// </summary>
    public string Text
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets or sets the mini-dump type.
    /// </summary>
    public MiniDumpType DumpType
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets or sets the title of the unhandled exception messagebox.
    /// </summary>
    public string ExceptionTitle
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets or sets the title of the unhandled thread exception messagebox.
    /// </summary>
    public string ThreadExceptionTitle
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets or sets the mini-dump file name.
    /// </summary>
    public string DumpFileName
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets or sets the mini-dump log file name.
    /// </summary>
    public string DumpLogFileName
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Dumps an exception into an minidump file.
    /// Perfect for unhandled to Thread Exceptions.
    ///
    /// Note: Attribute handles unhandled exceptions by default with the exception
    /// for any Thread Exceptions.
    /// </summary>
    /// <param name="exception">The exception to dump into the minidump.</param>
    /// <param name="threadException">Whether the exception is a thread exception or not.</param>
    /// <returns>The ExitCode for the application.</returns>
    public static int DumpException(Exception exception, bool threadException)
        => throw null!;
}
