// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class UpvalueExpression(string name) : Expression(PRECEDENCE_ATOMIC)
{
    private readonly string m_name = name;

    public override int ConstantIndex => -1;

    public override bool IsBrief => true;

    public override bool IsDotChain => true;

    public override void Print(Output output)
        => output.Print(this.m_name);
}
