// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

internal static class ThrowHelpers
{
    internal static void ThrowArgumentNull(bool value, string paramName)
    {
        if (value)
        {
            throw new ArgumentNullException(paramName);
        }
    }

    internal static void ThrowInvalidOperation(bool value, string message)
    {
        if (value)
        {
            throw new InvalidOperationException(message);
        }
    }

    internal static void ThrowArgumentOutOfRange(bool value, string paramName)
    {
        if (value)
        {
            throw new ArgumentOutOfRangeException(paramName);
        }
    }

    internal static void ThrowArgumentOutOfRange(bool value, string paramName, string message)
    {
        if (value)
        {
            throw new ArgumentOutOfRangeException(paramName, message);
        }
    }

    internal static void ThrowFileNotFound(bool value, string message)
    {
        if (value)
        {
            throw new FileNotFoundException(message);
        }
    }

    internal static void ThrowObjectDisposed(bool value, string objectName)
    {
        if (value)
        {
            throw new ObjectDisposedException(objectName);
        }
    }
}
