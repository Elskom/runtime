// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class UpvalueSet(int line, string upvalue, Expression value) : Operation(line)
{
    private readonly UpvalueTarget m_target = new(upvalue);
    private readonly Expression m_value = value;

    public override Statement Process(Registers r, Block block)
        => new Assignment(this.m_target, this.m_value);
}
