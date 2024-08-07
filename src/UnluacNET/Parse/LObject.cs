﻿// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal abstract class LObject : IBObject, IEqualityComparer<LObject>
{
    public new abstract bool Equals(object obj);

    public virtual string DeRef()
        => throw new NotImplementedException();

    public bool Equals(LObject x, LObject y)
        => x.Equals(y);

    public int GetHashCode(LObject obj)
        => throw new NotImplementedException();
}
