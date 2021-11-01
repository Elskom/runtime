﻿// Copyright (c) 2018-2021, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

public class FunctionCall : Expression
{
    private readonly Expression m_function;
    private readonly Expression[] m_arguments;
    private readonly bool m_multiple;

    public FunctionCall(Expression function, Expression[] arguments, bool multiple)
        : base(PRECEDENCE_ATOMIC)
    {
        this.m_function = function;
        this.m_arguments = arguments;
        this.m_multiple = multiple;
    }

    public override bool BeginsWithParen
    {
        get
        {
            var obj = this.IsMethodCall ? this.m_function.GetTable() : this.m_function;
            return obj.IsClosure || obj.IsConstant || obj.BeginsWithParen;
        }
    }

    public override int ConstantIndex
    {
        get
        {
            var index = this.m_function.ConstantIndex;
            foreach (var argument in this.m_arguments)
            {
                index = Math.Max(argument.ConstantIndex, index);
            }

            return index;
        }
    }

    public override bool IsMultiple => this.m_multiple;

    private bool IsMethodCall
        => this.m_function.IsMemberAccess &&
           this.m_arguments.Length > 0 &&
           this.m_function.GetTable() == this.m_arguments[0];

    public override void Print(Output output)
    {
        List<Expression> args = new(this.m_arguments.Length);
        var obj = this.IsMethodCall ? this.m_function.GetTable() : this.m_function;
        if (obj.IsClosure || obj.IsConstant)
        {
            output.Print("(");
            obj.Print(output);
            output.Print(")");
        }
        else
        {
            obj.Print(output);
        }

        if (this.IsMethodCall)
        {
            output.Print(":");
            output.Print(this.m_function.GetField());
        }

        for (var i = this.IsMethodCall ? 1 : 0; i < this.m_arguments.Length; i++)
        {
            args.Add(this.m_arguments[i]);
        }

        output.Print("(");
        PrintSequence(output, args, false, true);
        output.Print(")");
    }

    public override void PrintMultiple(Output output)
    {
        if (!this.m_multiple)
        {
            output.Print("(");
        }

        this.Print(output);
        if (!this.m_multiple)
        {
            output.Print(")");
        }
    }
}
