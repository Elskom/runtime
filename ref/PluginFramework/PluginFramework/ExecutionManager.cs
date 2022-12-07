// Copyright (c) 2018-2022, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Class that allows executing Elsword directly or it's launcher.
/// </summary>
public static class ExecutionManager
{
    /// <summary>
    /// Gets a value indicating whether the launcher to Elsword is running.
    /// </summary>
    /// <returns>A value indicating if Elsword is running.</returns>
    public static bool RunningElsword
        => throw null!;

    /// <summary>
    /// Gets a value indicating whether Elsword is running Directly.
    /// </summary>
    /// <returns>A value indicating if Elsword is running directly.</returns>
    public static bool RunningElswordDirectly
        => throw null!;

    /// <summary>
    /// Gets if Els_kom.exe is already Running. If So, Helps with Closing any new Instances.
    /// </summary>
    /// <returns>Boolean.</returns>
    public static bool IsElsKomRunning()
        => throw null!;

    /// <summary>
    /// Gets if Elsword or the launcher is currently running.
    /// </summary>
    /// <param name="launcher">Get if the launcher is currently running.</param>
    /// <returns>If the specified program is currently running.</returns>
    public static bool IsExecuting(bool launcher)
        => throw null!;

    /// <summary>
    /// Runs Elsword Directly.
    /// This is an blocking call that has to run in an separate thread from Els_kom's main thread.
    /// NEVER UNDER ANY CIRCUMSTANCES RUN THIS IN THE MAIN THREAD, YOU WILL DEADLOCK ELS_KOM!!!.
    /// </summary>
    public static void RunElswordDirectly()
        => throw null!;

    /// <summary>
    /// Runs Elsword Launcher.
    /// This is an blocking call that has to run in an separate thread from Els_kom's main thread.
    /// NEVER UNDER ANY CIRCUMSTANCES RUN THIS IN THE MAIN THREAD, YOU WILL DEADLOCK ELS_KOM!!!.
    /// </summary>
    public static void RunElswordLauncher()
        => throw null!;
}
