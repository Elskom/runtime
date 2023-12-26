﻿// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class AndBranch : Branch
{
    private readonly Branch m_left;
    private readonly Branch m_right;

    public AndBranch(Branch left, Branch right)
        : base(right.Line, right.Begin, right.End)
    {
        this.m_left = left;
        this.m_right = right;
    }

    public override Expression AsExpression(Registers registers)
        => Expression.MakeAND(this.m_left.AsExpression(registers), this.m_right.AsExpression(registers));

    public override int GetRegister()
    {
        var rLeft = this.m_left.GetRegister();
        var rRight = this.m_right.GetRegister();
        return rLeft == rRight ? rLeft : -1;
    }

    public override Branch Invert()
        => new OrBranch(this.m_left.Invert(), this.m_right.Invert());

    public override void UseExpression(Expression expression)
    {
        this.m_left.UseExpression(expression);
        this.m_right.UseExpression(expression);
    }
}
