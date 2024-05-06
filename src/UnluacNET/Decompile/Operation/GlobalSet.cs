// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class GlobalSet(int line, string global, Expression value) : Operation(line)
{
    private readonly string m_global = global;
    private readonly Expression m_value = value;

    public override Statement Process(Registers r, Block block)
        => new Assignment(new GlobalTarget(this.m_global), this.m_value);
}
