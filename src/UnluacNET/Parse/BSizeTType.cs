// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class BSizeTType(int sizeTSize) : BObjectType<BSizeT>
{
    private readonly BIntegerType integerType = new(sizeTSize);

    public int SizeTSize { get; } = sizeTSize;

    public override BSizeT Parse(Stream stream, BHeader header)
    {
        BSizeT value = new(this.integerType.RawParse(stream, header));
        if (header.Debug)
        {
            Debug.WriteLine($"-- parsed <size_t> {value.AsInteger()}");
        }

        return value;
    }
}
