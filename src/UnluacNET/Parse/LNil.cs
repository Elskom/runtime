﻿// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class LNil : LObject
{
    public static readonly LNil NIL = new();

    private LNil()
    {
    }

    public override bool Equals(object obj)
        => this == obj;

    public override int GetHashCode()
        => throw new NotImplementedException();
}
