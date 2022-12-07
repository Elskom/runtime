// Copyright (c) 2018-2022, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Creates a Process with additional options.
/// </summary>
public sealed class ProcessStartOptions
{
    /// <summary>
    /// Gets a value indicating whether the process is executing or not.
    /// False if executed already.
    /// </summary>
    public bool Executing
        => throw null!;

    /// <summary>
    /// Gets a value indicating whether the process is running or not.
    /// False if not running yet or if the process terminated.
    /// </summary>
    public bool Running
        => throw null!;

    /// <summary>
    /// Gets a value indicating whether the process start information to use when executing the process.
    /// </summary>
    public ProcessStartInfo StartInfo
        => throw null!;

    /// <summary>
    /// Gets or sets a value indicating whether the process should wait indefinitely until exited.
    /// </summary>
    public bool WaitForProcessExit
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets where the standard input of the process is streamed to.
    /// </summary>
    public StreamWriter? Stdin
        => throw null!;

    /// <summary>
    /// Gets or sets where the standard output of the process is stream to.
    /// </summary>
    public StringBuilder? Stdout
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets or sets where the standard error of the process is stream to.
    /// </summary>
    public StringBuilder? Stderr
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Adds start information to this process options instance.
    /// </summary>
    /// <param name="fileName">The file name to execute.</param>
    /// <param name="arguments">The arguments to execute the file with.</param>
    /// <param name="redirectStandardInput">Redirect standard input on the executed process.</param>
    /// <param name="redirectStandardOutput">Redirect standard output on the executed process.</param>
    /// <param name="redirectStandardError">Redirect standard error on the executed process.</param>
    /// <param name="useShellExecute">To optionally use shell execute to execute the process.</param>
    /// <param name="createNoWindow">To optionally create no Window on the executed process.</param>
    /// <param name="windowStyle">The window style to use on the executed process.</param>
    /// <param name="workingDirectory">The working directory of the executed process.</param>
    /// <returns>This instance of <see cref="ProcessStartOptions" />.</returns>
    public ProcessStartOptions WithStartInformation(string fileName, string arguments, bool redirectStandardInput, bool redirectStandardOutput, bool redirectStandardError, bool useShellExecute, bool createNoWindow, ProcessWindowStyle windowStyle, string workingDirectory)
        => throw null!;

    /// <summary>
    /// Executes the process.
    /// </summary>
    /// <returns>The process's redirected outputs.</returns>
    /// <exception cref="InvalidOperationException">When the instance's startup information is null.</exception>
    /// <exception cref="FileNotFoundException">When the file to the process to execute does not exist on disk.</exception>
    public string Start()
        => throw null!;

    /// <summary>
    /// Executes the process.
    /// </summary>
    /// <param name="startInfo">The process start information to use to start the process.</param>
    /// <returns>The process's redirected outputs.</returns>
    /// <exception cref="InvalidOperationException">When the instance's startup information is null.</exception>
    /// <exception cref="FileNotFoundException">When the file to the process to execute does not exist on disk.</exception>
    public string Start(ProcessStartInfo startInfo)
        => throw null!;

    /// <summary>
    /// The string representation of the current output and/or error results from the process.
    /// </summary>
    /// <returns>string representation of the current output and/or error results from the process.</returns>
    public override string ToString()
        => throw null!;
}
