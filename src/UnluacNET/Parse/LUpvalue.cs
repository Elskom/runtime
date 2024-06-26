﻿// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class LUpvalue : IBObject
{
    public int Index { get; set; }

    public bool InStack { get; set; }

    public string Name { get; set; }

    public override bool Equals(object obj)
    {
        if (obj is LUpvalue upVal)
        {
            if (!(this.InStack == upVal.InStack && this.Index == upVal.Index))
            {
                return false;
            }
            else if (this.Name == upVal.Name)
            {
                return true;
            }

            return this.Name != null && this.Name == upVal.Name;
        }

        return false;
    }

    public override int GetHashCode()
        => throw new NotImplementedException();
}
