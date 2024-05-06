// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Event that holds the message text and the caption.
/// </summary>
/// <param name="text">The text for the message.</param>
/// <param name="caption">The title (caption) for the message.</param>
/// <param name="errorlevel">The error level for the message, or <see cref="Libs.ErrorLevel.None"/> for no error level information.</param>
public class MessageEventArgs(string text, string caption, ErrorLevel errorlevel) : EventArgs
{
    /// <summary>
    /// Gets the text for the message.
    /// </summary>
    public string Text { get; } = text;

    /// <summary>
    /// Gets the caption (title) for the message.
    /// </summary>
    public string Caption { get; } = caption;

    /// <summary>
    /// Gets the <see cref="Libs.ErrorLevel"/> of the message.
    /// </summary>
    public ErrorLevel ErrorLevel { get; } = errorlevel;

    /// <summary>
    /// Gets or sets the ExitCode for the application.
    ///
    /// Note: Only set if <see cref="MessageEventArgs.Text"/> does not represent
    /// a minidump failure.
    /// </summary>
    public int ExitCode { get; set; }
}
