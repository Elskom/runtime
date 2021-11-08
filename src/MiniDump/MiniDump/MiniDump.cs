// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

internal static class MiniDump
{
    internal static int ExceptionEventHandlerCode(Exception e, bool threadException)
    {
        var exceptionData = PrintExceptions(e);

        // do not dump or close if in a debugger.
        if (!Debugger.IsAttached)
        {
            if (!MiniDumpAttribute.ForceClose)
            {
                MiniDumpAttribute.ForceClose = true;
            }

            if (string.IsNullOrEmpty(MiniDumpAttribute.CurrentInstance!.DumpLogFileName))
            {
                MiniDumpAttribute.CurrentInstance.DumpLogFileName = SettingsFile.ErrorLogPath;
            }

            if (string.IsNullOrEmpty(MiniDumpAttribute.CurrentInstance.DumpFileName))
            {
                MiniDumpAttribute.CurrentInstance.DumpFileName = SettingsFile.MiniDumpPath;
            }

            File.WriteAllText(MiniDumpAttribute.CurrentInstance.DumpLogFileName, exceptionData);
            MessageEventArgs args;
            var dumpArgs = new MiniDumpEventArgs(
                SettingsFile.ThisProcessId,
                MiniDumpAttribute.CurrentInstance.DumpFileName,
                MiniDumpAttribute.CurrentInstance.DumpType);
            var dumpResult = MiniDumpAttribute.InvokeDump(ref dumpArgs);
            args = new(
                dumpResult ? string.Format(
                    CultureInfo.InvariantCulture,
                    MiniDumpAttribute.CurrentInstance.Text,
                    MiniDumpAttribute.CurrentInstance.DumpLogFileName) : dumpArgs.ErrorMessage!,
                threadException ? MiniDumpAttribute.CurrentInstance.ThreadExceptionTitle : MiniDumpAttribute.CurrentInstance.ExceptionTitle,
                ErrorLevel.Error);
            MiniDumpAttribute.InvokeDumpMessage(ref args);
            return args.ExitCode;
        }

        return 1;
    }

    private static string PrintExceptions(Exception exception)
    {
        StringBuilder sb = new();
        sb.AppendLine(CultureInfo.InvariantCulture, $"{exception.GetType()}: {exception.Message}{Environment.NewLine}{exception.StackTrace}");
        var currException = exception.InnerException;
        while (currException is not null)
        {
            sb.AppendLine(CultureInfo.InvariantCulture, $"{currException.GetType()}: {currException.Message}{Environment.NewLine}{currException.StackTrace}");
            currException = currException.InnerException;
        }

        return sb.ToString();
    }
}
