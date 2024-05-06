// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class AssignNode(int line, int begin, int end) : Branch(line, begin, end)
{
    private Expression m_expression;

    public override Expression AsExpression(Registers registers)
        => this.m_expression;

    public override int GetRegister()
        => throw new InvalidOperationException();

    public override Branch Invert()
        => throw new InvalidOperationException();

    public override void UseExpression(Expression expression)
        => this.m_expression = expression;
}
