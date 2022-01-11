// Copyright (c) 2018-2022, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal abstract class Operation
{
    protected Operation(int line)
        => this.Line = line;

    public int Line { get; private set; }

    public abstract Statement Process(Registers r, Block block);
}
