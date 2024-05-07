// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Event that holds that data to call the apis for notifications.
/// </summary>
[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Ref assembly.")]
public class NotificationEventArgs : EventArgs
{
    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationEventArgs"/> class.
    /// </summary>
    /// <param name="timeout">The notification timeout.</param>
    /// <param name="title">The Notification or MessageBox title.</param>
    /// <param name="text">The Notification or MessageBox text.</param>
    /// <param name="icon">The notification icon.</param>
    /// <param name="useNotifications">Indicates whether the event should call into the platform's Notifications API, or the MessageBox API.</param>
    /// <param name="messageBoxButtons">The MessageBox Buttons.</param>
    /// <param name="messageBoxIcon">The MessageBox Icon.</param>
    public NotificationEventArgs(int timeout, string title, string text, int icon, bool useNotifications, int messageBoxButtons, int messageBoxIcon)
        => throw null!;

    /// <summary>
    /// Gets the timeout to use for the Notification.
    /// </summary>
    public int TimeOut
        => throw null!;

    /// <summary>
    /// Gets the title of the Notification or MessageBox.
    /// </summary>
    public string Title
        => throw null!;

    /// <summary>
    /// Gets the text of the Notification or MessageBox.
    /// </summary>
    public string Text
        => throw null!;

    /// <summary>
    /// Gets the icon to use for the Notification.
    /// </summary>
    public int Icon
        => throw null!;

    /// <summary>
    /// Gets a value indicating whether gets whether to use platform's specific Notification APIs, or it's MessageBox APIs.
    /// </summary>
    public bool UseNotifications
        => throw null!;

    /// <summary>
    /// Gets the Buttons to use for the platform's specific MessageBox APIs.
    /// </summary>
    public int MessageBoxButtons
        => throw null!;

    /// <summary>
    /// Gets the Icon to use for the MessageBox made using the platform's specific MessageBox APIs.
    /// </summary>
    public int MessageBoxIcon
        => throw null!;

    /// <summary>
    /// Gets or sets the Result from the platform's specific MessageBox.
    /// </summary>
    public int Result
    {
        get => throw null!;
        set => throw null!;
    }
}
