// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal abstract class BObjectType<T> : IBObject
    where T : IBObject
{
    public abstract T Parse(Stream stream, BHeader header);

    public BList<T> ParseList(Stream stream, BHeader header)
    {
        var length = header.Integer.Parse(stream, header);
        List<T> values = [];
        length.Iterate(() =>
        {
            values.Add(this.Parse(stream, header));
        });
        return new(length, values);
    }
}
