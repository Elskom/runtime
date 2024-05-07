// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class EQNode(int left, int right, bool invert, int line, int begin, int end) : Branch(line, begin, end)
{
    private readonly int m_left = left;
    private readonly int m_right = right;
    private readonly bool m_invert = invert;

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
