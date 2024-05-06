// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

// This file replaced with System.Runtime.InteropServices.RuntimeInformation.RuntimeIdentifier.
// For more information visit: https://docs.microsoft.com/en-us/dotnet/api/system.runtime.interopservices.runtimeinformation.runtimeidentifier?view=net-6.0
internal static class RuntimeHelpers
{
    /// <summary>
    /// Gets the runtime identifier for the current process,
    /// that is it transforms the operating system and the process architecture
    /// of the current process into an valid runtime identifier that the .NET SDK has.
    /// </summary>
    /// <returns>
    /// An Runtime Identifier <see langword="string" />, or <see cref="string.Empty" /> if it cannot be converted into a runtime identifier.
    /// </returns>
    public static string GetCurrentRuntimeIdentifier()
        => (OperatingSystem.IsWindows(), /* Desktop Operating Systems. */
            OperatingSystem.IsLinux(),
            OperatingSystem.IsMacOS(),
            OperatingSystem.IsMacCatalyst(),
            OperatingSystem.IsFreeBSD(),
            OperatingSystem.IsAndroid(), /* Phone Operating Systems. */
            OperatingSystem.IsIOS(),
            OperatingSystem.IsWatchOS(),
            OperatingSystem.IsTvOS(),
            OperatingSystem.IsBrowser() /* Web Browser. */) switch
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
            _ => string.Empty,
        };
}
