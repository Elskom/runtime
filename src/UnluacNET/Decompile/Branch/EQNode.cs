﻿// Copyright (c) 2018-2021, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

public class EQNode : Branch
{
    private readonly int m_left;
    private readonly int m_right;
    private readonly bool m_invert;

    public EQNode(int left, int right, bool invert, int line, int begin, int end)
        : base(line, begin, end)
    {
        this.m_left = left;
        this.m_right = right;
        this.m_invert = invert;
    }

    public override Branch Invert()
        => new EQNode(this.m_left, this.m_right, !this.m_invert, this.Line, this.End, this.Begin);

    public override int GetRegister()
        => -1;

    public override Expression AsExpression(Registers registers)
    {
        var transpose = false;
        var op = this.m_invert ? "~=" : "==";
        return new BinaryExpression(
            op,
            registers.GetKExpression(!transpose ? this.m_left : this.m_right, this.Line),
            registers.GetKExpression(!transpose ? this.m_right : this.m_left, this.Line),
            Expression.PRECEDENCE_COMPARE,
            Expression.ASSOCIATIVITY_LEFT);
    }

    public override void UseExpression(Expression expression)
    {
        /* Do nothing */
    }
}
