﻿// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class LTNode(int left, int right, bool invert, int line, int begin, int end) : Branch(line, begin, end)
{
    private readonly int m_left = left;
    private readonly int m_right = right;
    private readonly bool m_invert = invert;

    public override Expression AsExpression(Registers registers)
    {
        var leftExpr = registers.GetKExpression(this.m_left, this.Line);
        var rightExpr = registers.GetKExpression(this.m_right, this.Line);
        var transpose = ((this.m_left | this.m_right) & 256) == 0
            ? registers.GetUpdated(this.m_left, this.Line) > registers.GetUpdated(this.m_right, this.Line)
            : rightExpr.ConstantIndex < leftExpr.ConstantIndex;
        var op = !transpose ? "<" : ">";
        Expression rtn = new BinaryExpression(op, !transpose ? leftExpr : rightExpr, !transpose ? rightExpr : leftExpr, Expression.PRECEDENCE_COMPARE, Expression.ASSOCIATIVITY_LEFT);
        if (this.m_invert)
        {
            rtn = Expression.MakeNOT(rtn);
        }

        return rtn;
    }

    public override int GetRegister()
        => -1;

    public override Branch Invert()
        => new LTNode(this.m_left, this.m_right, !this.m_invert, this.Line, this.End, this.Begin);

    public override void UseExpression(Expression expression)
    {
        // Do nothing
    }
}
