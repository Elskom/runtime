﻿// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Event that holds the message text and the caption.
/// </summary>
[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Ref assembly.")]
public class MessageEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="MessageEventArgs"/> class.
    /// </summary>
    /// <param name="text">The text for the message.</param>
    /// <param name="caption">The title (caption) for the message.</param>
    /// <param name="errorlevel">The error level for the message, or <see cref="Libs.ErrorLevel.None"/> for no error level information.</param>
    public MessageEventArgs(string text, string caption, ErrorLevel errorlevel)
        => throw null!;

    /// <summary>
    /// Gets the text for the message.
    /// </summary>
    public string Text
        => throw null!;

    /// <summary>
    /// Gets the caption (title) for the message.
    /// </summary>
    public string Caption
        => throw null!;

    /// <summary>
    /// Gets the <see cref="Libs.ErrorLevel"/> of the message.
    /// </summary>
    public ErrorLevel ErrorLevel
        => throw null!;

    /// <summary>
    /// Gets or sets the ExitCode for the application.
    ///
    /// Note: Only set if <see cref="MessageEventArgs.Text"/> does not represent
    /// a minidump failure.
    /// </summary>
    public int ExitCode
    {
        get => throw null!;
        set => throw null!;
    }
}
