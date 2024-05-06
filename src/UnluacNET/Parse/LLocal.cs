// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class LLocal(LString name, BInteger start, BInteger end) : IBObject
{
    public LString Name { get; private set; } = name;

    public int Start { get; private set; } = start.AsInteger();

    public int End { get; private set; } = end.AsInteger();

    /* Used by the decompiler for annotation. */
    internal bool ForLoop { get; set; }

    public override string ToString()
        => this.Name.DeRef();
}
