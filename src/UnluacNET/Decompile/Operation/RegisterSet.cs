// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class RegisterSet(int line, int register, Expression value) : Operation(line)
{
    public int Register { get; private set; } = register;

    public Expression Value { get; private set; } = value;

    public override Statement Process(Registers r, Block block)
    {
        r.SetValue(this.Register, this.Line, this.Value);
        return r.IsAssignable(this.Register, this.Line) ? new Assignment(r.GetTarget(this.Register, this.Line), this.Value) : null;
    }
}
