// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal abstract class Operation(int line)
{
    public int Line { get; private set; } = line;

    public abstract Statement Process(Registers r, Block block);
}
