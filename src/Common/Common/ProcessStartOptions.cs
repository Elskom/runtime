// Copyright (c) 2018-2024, Els_kom org.
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
    public bool Executing { get; internal set; }

    /// <summary>
    /// Gets a value indicating whether the process is running or not.
    /// False if not running yet or if the process terminated.
    /// </summary>
    public bool Running { get; internal set; }

    /// <summary>
    /// Gets a value indicating whether the process start information to use when executing the process.
    /// </summary>
    public ProcessStartInfo StartInfo { get; private set; } = null!;

    /// <summary>
    /// Gets or sets a value indicating whether the process should wait indefinitely until exited.
    /// </summary>
    public bool WaitForProcessExit { get; set; }

    /// <summary>
    /// Gets where the standard input of the process is streamed to.
    /// </summary>
    public StreamWriter? Stdin { get; private set; }

    /// <summary>
    /// Gets or sets where the standard output of the process is stream to.
    /// </summary>
    public StringBuilder? Stdout { get; set; }

    /// <summary>
    /// Gets or sets where the standard error of the process is stream to.
    /// </summary>
    public StringBuilder? Stderr { get; set; }

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
    {
        this.StartInfo = new ProcessStartInfo
        {
            FileName = fileName,
            Arguments = arguments,
            RedirectStandardInput = redirectStandardInput,
            RedirectStandardOutput = redirectStandardOutput,
            RedirectStandardError = redirectStandardError,
            UseShellExecute = useShellExecute,
            CreateNoWindow = createNoWindow,
            WindowStyle = windowStyle,
            WorkingDirectory = workingDirectory,
        };
        return this;
    }

    /// <summary>
    /// Executes the process.
    /// </summary>
    /// <returns>The process's redirected outputs.</returns>
    /// <exception cref="ArgumentNullException">When the instance's startup information is null.</exception>
    /// <exception cref="FileNotFoundException">When the file to the process to execute does not exist on disk.</exception>
    public string Start()
        => this.Start(this.StartInfo);

    /// <summary>
    /// Executes the process.
    /// </summary>
    /// <param name="startInfo">The process start information to use to start the process.</param>
    /// <returns>The process's redirected outputs.</returns>
    /// <exception cref="ArgumentNullException">When the instance's startup information is null.</exception>
    /// <exception cref="FileNotFoundException">When the file to the process to execute does not exist on disk.</exception>
    public string Start(ProcessStartInfo startInfo)
    {
        ArgumentNullException.ThrowIfNull(startInfo);
        ThrowHelpers.ThrowFileNotFound(!File.Exists(startInfo!.FileName), "File to execute does not exist.");
        this.Executing = true;
        using var proc = new Process();
        proc.StartInfo = startInfo;
        _ = proc.Start();
        proc.OutputDataReceived += (_, e) =>
        {
            if (this.Stdout is null)
            {
                this.Stdout = new StringBuilder();
                this.Stdout.Append(e.Data);
                this.Stdout.AppendLine();
            }
            else
            {
                this.Stdout.AppendLine(e.Data);
            }
        };
        proc.ErrorDataReceived += (_, e) =>
        {
            if (this.Stderr is null)
            {
                this.Stderr = new StringBuilder();
                this.Stderr.Append(e.Data);
                this.Stderr.AppendLine();
            }
            else
            {
                this.Stderr.AppendLine(e.Data);
            }
        };
        this.Running = true;
        this.Executing = false;
        if (this.StartInfo.RedirectStandardInput)
        {
            this.Stdin = proc.StandardInput;
        }

        if (this.StartInfo.RedirectStandardOutput)
        {
            proc.BeginOutputReadLine();
        }

        if (this.StartInfo.RedirectStandardError)
        {
            proc.BeginErrorReadLine();
        }

        if (this.WaitForProcessExit)
        {
            proc.WaitForExit();
        }

        this.Running = false;
        var output = this.ToString();
        this.Stdin = null;
        this.Stdout = null;
        this.Stderr = null;
        return output;
    }

    /// <summary>
    /// The string representation of the current output and/or error results from the process.
    /// </summary>
    /// <returns>string representation of the current output and/or error results from the process.</returns>
    public override string ToString()
        => (this.Stdout is not null, this.Stderr is not null) switch
        {
            (true, false) => $"{this.Stdout}",
            (true, true) => $@"{this.Stdout}
{this.Stderr}",
            (false, false) => string.Empty,
            (false, true) => $"{this.Stderr}",
        };
}
