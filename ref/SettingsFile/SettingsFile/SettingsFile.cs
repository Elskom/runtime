// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// A class that handles the settings for any application.
/// </summary>
public static class SettingsFile
{
    static SettingsFile()
        => throw null!;

    /// <summary>
    /// Gets or sets the Json settings file instance.
    ///
    /// This is designed so there is globally only
    /// a single instance to save time, and memory.
    /// </summary>
    /// <value>
    /// The Json settings file instance.
    ///
    /// This is designed so there is globally only
    /// a single instance to save time, and memory.
    /// </value>
    public static JsonSettings? SettingsJson
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets or sets the Application's name to use for Resolving the paths for the
    /// Settings file, error logs, and minidumps.
    /// </summary>
    public static string ApplicationName
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets the path to the Application Settings file.
    ///
    /// Creates the folder if needed.
    /// </summary>
    /// <value>
    /// The path to the Application Settings file.
    ///
    /// Creates the folder if needed.
    /// </value>
    public static string SettingsPath
        => throw null!;

    /// <summary>
    /// Gets the path to the Application Error Log file.
    ///
    /// Creates the Error Log file if needed.
    /// </summary>
    public static string ErrorLogPath
        => throw null!;

    /// <summary>
    /// Gets the path to the Application Mini-Dump file.
    /// </summary>
    // On Non-Windows OS's all crash dumps must be named "core.{PID}"!!!
    public static string MiniDumpPath
        => throw null!;
}
