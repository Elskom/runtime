// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class UnaryExpression(string op, Expression expression, int precedence) : Expression(precedence)
{
    private readonly string m_op = op;
    private readonly Expression m_expression = expression;

    public override int ConstantIndex => this.m_expression.ConstantIndex;

    public override void Print(Output output)
    {
        var isPrecedence = this.Precedence > this.m_expression.Precedence;
        output.Print(this.m_op);
        if (isPrecedence)
        {
            output.Print("(");
        }

        this.m_expression.Print(output);
        if (isPrecedence)
        {
            output.Print(")");
        }
    }
}
