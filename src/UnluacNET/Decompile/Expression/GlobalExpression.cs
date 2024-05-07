// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class GlobalExpression(string name, int index) : Expression(PRECEDENCE_ATOMIC)
{
    private readonly string m_name = name;
    private readonly int m_index = index;

    public override int ConstantIndex => this.m_index;

    public override bool IsBrief => true;

    public override bool IsDotChain => true;

    public override void Print(Output output)
        => output.Print(this.m_name);
}
