// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class BinaryExpression(string op, Expression left, Expression right, int precedence, int associativity) : Expression(precedence)
{
    private readonly string m_op = op;
    private readonly Expression m_left = left;
    private readonly Expression m_right = right;
    private readonly int m_associativity = associativity;

    public override int ConstantIndex
        => Math.Max(this.m_left.ConstantIndex, this.m_right.ConstantIndex);

    public override bool BeginsWithParen
        => this.LeftGroup || this.m_left.BeginsWithParen;

    public bool LeftGroup
        => this.Precedence > this.m_left.Precedence ||
        (this.Precedence == this.m_left.Precedence && this.m_associativity == ASSOCIATIVITY_RIGHT);

    public bool RightGroup
        => this.Precedence > this.m_right.Precedence ||
        (this.Precedence == this.m_right.Precedence && this.m_associativity == ASSOCIATIVITY_LEFT);

    public override void Print(Output output)
    {
        var leftGroup = this.LeftGroup;
        var rightGroup = this.RightGroup;
        if (leftGroup)
        {
            output.Print("(");
        }

        this.m_left.Print(output);
        if (leftGroup)
        {
            output.Print(")");
        }

        output.Print(" ");
        output.Print(this.m_op);
        output.Print(" ");
        if (rightGroup)
        {
            output.Print("(");
        }

        this.m_right.Print(output);
        if (rightGroup)
        {
            output.Print(")");
        }
    }
}
