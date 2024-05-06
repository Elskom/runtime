// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class LString(BSizeT size, string value) : LObject
{
    public BSizeT Size { get; } = size;

    public string Value { get; } = value.Length is 0 ? string.Empty : value.AsSpan().Slice(0, value.Length - 1).ToString();

    public override string DeRef()
        => this.Value;

    public override bool Equals(object obj)
        => obj is LString lstring && this.Value == lstring.Value;

    public override int GetHashCode()
        => throw new NotImplementedException();

    public override string ToString()
        => $"\"{this.Value}\"";
}
