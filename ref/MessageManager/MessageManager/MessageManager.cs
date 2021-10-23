// Copyright (c) 2018-2021, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// A generic MessageBox manager.
/// </summary>
public static class MessageManager
{
    /// <summary>
    /// Occurs when the ShowError(), ShowInfo(), or ShowWarning() methods is told to use Notifications.
    /// </summary>
    public static event EventHandler<NotificationEventArgs> Notification
    {
        add => throw null!;
        remove => throw null!;
    }

    /// <summary>
    /// Shows an MessageBox that is for an Question.
    /// </summary>
    /// <param name="text">The text on the messagebox.</param>
    /// <param name="caption">The title of the messagebox.</param>
    /// <param name="useNotifications">Indicates if this function should show notifications.</param>
    /// <returns>A new DialogResult returned as an <see cref="int"/>.</returns>
    public static int ShowQuestion(string text, string caption, bool useNotifications)
        => throw null!;

    /// <summary>
    /// Shows an MessageBox that is for an Error.
    /// </summary>
    /// <param name="text">The text on the messagebox.</param>
    /// <param name="caption">The title of the messagebox.</param>
    /// <param name="useNotifications">Indicates if this function should show notifications.</param>
    /// <returns>A new DialogResult returned as an <see cref="int"/>.</returns>
    public static int ShowError(string text, string caption, bool useNotifications)
        => throw null!;

    /// <summary>
    /// Shows an MessageBox that is for information.
    /// </summary>
    /// <param name="text">The text on the messagebox.</param>
    /// <param name="caption">The title of the messagebox.</param>
    /// <param name="useNotifications">Indicates if this function should show notifications.</param>
    /// <returns>A new DialogResult returned as an <see cref="int"/>.</returns>
    public static int ShowInfo(string text, string caption, bool useNotifications)
        => throw null!;

    /// <summary>
    /// Shows an MessageBox that is for an Warning.
    /// </summary>
    /// <param name="text">The text on the messagebox.</param>
    /// <param name="caption">The title of the messagebox.</param>
    /// <param name="useNotifications">Indicates if this function should show notifications.</param>
    /// <returns>A new DialogResult returned as an <see cref="int"/>.</returns>
    public static int ShowWarning(string text, string caption, bool useNotifications)
        => throw null!;
}
