﻿// Copyright (c) 2018-2021, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

internal enum ZlibFlushStrategy
{
    NoFlush,
    PartialFlush,
    SyncFlush,
    FullFlush,
    Finish,
}