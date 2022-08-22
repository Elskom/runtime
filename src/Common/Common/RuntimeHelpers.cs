// Copyright (c) 2018-2022, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Internal Runtime Helpers.
/// </summary>
public static class RuntimeHelpers
{
    /// <summary>
    /// Gets the runtime identifier for the current process,
    /// that is it transforms the operating system and the process architecture
    /// of the current process into an valid runtime identifier that the .NET SDK has.
    /// </summary>
    /// <returns>
    /// An Runtime Identifier string, or null if it cannot be converted into an runtime identifier.
    /// </returns>
    public static string GetCurrentRuntimeIdentifier()
        => (

            // Desktop Operating Systems.
            OperatingSystem.IsWindows(),
            OperatingSystem.IsLinux(),
            OperatingSystem.IsMacOS(),
            OperatingSystem.IsMacCatalyst(),
            OperatingSystem.IsFreeBSD(),

            // Phone Operting Systems.
            OperatingSystem.IsAndroid(),
            OperatingSystem.IsIOS(),
            OperatingSystem.IsWatchOS(),
            OperatingSystem.IsTvOS(),

            // Web Browser.
            OperatingSystem.IsBrowser()) switch
        {
            (true, false, false, false, false, false, false, false, false, false) => $"win-{RuntimeInformation.ProcessArchitecture}",
            (false, true, false, false, false, false, false, false, false, false) => $"linux-{RuntimeInformation.ProcessArchitecture}",
            (false, false, true, false, false, false, false, false, false, false) => $"osx-{RuntimeInformation.ProcessArchitecture}",
            (false, false, false, true, false, false, false, false, false, false) => $"maccatalyst-{RuntimeInformation.ProcessArchitecture}",
            (false, false, false, false, true, false, false, false, false, false) => $"freebsd-{RuntimeInformation.ProcessArchitecture}",
            (false, false, false, false, false, true, false, false, false, false) => $"android-{RuntimeInformation.ProcessArchitecture}",
            (false, false, false, false, false, false, true, false, false, false) => "ios-arm64",
            (false, false, false, false, false, false, false, false, true, false) => $"tvos-{RuntimeInformation.ProcessArchitecture}",
            (false, false, false, false, false, false, false, false, false, true) => "browser-wasm",

            // The WatchOS operating system does not seem to have an RID.
            _ => null,
        };
}
