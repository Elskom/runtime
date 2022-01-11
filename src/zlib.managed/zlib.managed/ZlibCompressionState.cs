// Copyright (c) 2018-2022, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

internal enum ZlibCompressionState
{
    VersionError = -6,
    BufError,
    MemError,
    DataError,
    StreamError,
    Errno,
    Ok,
    StreamEnd,
    NeedDict,
}
