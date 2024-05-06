// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class LUpvalueType : BObjectType<LUpvalue>
{
    public override LUpvalue Parse(Stream stream, BHeader header)
        => new()
        {
            InStack = stream.ReadByte() != 0,
            Index = stream.ReadByte(),
        };
}
