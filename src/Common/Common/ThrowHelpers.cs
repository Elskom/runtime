// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

internal static class ThrowHelpers
{
    [StackTraceHidden]
    internal static void ThrowInvalidOperation(bool value, string message)
    {
        if (value)
        {
            ThrowInvalidOperationCore(message);
        }
    }

    [StackTraceHidden]
    internal static void ThrowFileNotFound(bool value, string message)
    {
        if (value)
        {
            ThrowFileNotFoundCore(message);
        }
    }

    [StackTraceHidden]
    [DoesNotReturn]
    private static void ThrowInvalidOperationCore(string message)
        => throw new InvalidOperationException(message);

    [StackTraceHidden]
    [DoesNotReturn]
    private static void ThrowFileNotFoundCore(string message)
        => throw new FileNotFoundException(message);
}
