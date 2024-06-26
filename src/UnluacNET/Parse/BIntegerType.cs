﻿// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class BIntegerType(int intSize) : BObjectType<BInteger>
{
    public int IntSize { get; } = intSize;

    public override BInteger Parse(Stream stream, BHeader header)
    {
        var value = this.RawParse(stream, header);
        if (header.Debug)
        {
            Debug.WriteLine($"-- parsed <integer> {value.AsInteger()}");
        }

        return value;
    }

    internal BInteger RawParse(Stream stream, BHeader header)
    {
        // HACK HACK HACK
        var bigEndian = header.BigEndian;
        BInteger value;
        switch (this.IntSize)
        {
            case 0:
            {
                value = new(0);
                break;
            }

            case 1:
            {
                value = new(stream.ReadByte());
                break;
            }

            case 2:
            {
                value = new(stream.ReadInt16(bigEndian));
                break;
            }

            case 4:
            {
                value = new(stream.ReadInt32(bigEndian));
                break;
            }

            case 8:
            {
                value = new(stream.ReadInt64(bigEndian));
                break;
            }

            default:
                throw new InvalidOperationException("Bad IntSize, cannot parse data");
        }

        return value;
    }
}
