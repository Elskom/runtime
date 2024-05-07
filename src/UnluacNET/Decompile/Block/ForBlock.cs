// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class ForBlock(LFunction function, int begin, int end, int register, Registers r) : Block(function, begin, end)
{
    private readonly int m_register = register;
    private readonly Registers m_r = r;
    private readonly List<Statement> m_statements = new(end - begin + 1);

    public override bool Breakable => true;

    public override bool IsContainer => true;

    public override bool IsUnprotected => false;

    public override int ScopeEnd => this.End - 2;

    public override void AddStatement(Statement statement)
        => this.m_statements.Add(statement);

    public override int GetLoopback()
        => throw new InvalidOperationException();

    public override void Print(Output output)
    {
        output.Print("for ");
        this.m_r.GetTarget(this.m_register + 3, this.Begin - 1).Print(output);
        output.Print(" = ");
        this.m_r.GetValue(this.m_register, this.Begin - 1).Print(output);
        output.Print(", ");
        this.m_r.GetValue(this.m_register + 1, this.Begin - 1).Print(output);
        var step = this.m_r.GetValue(this.m_register + 2, this.Begin - 1);
        if (!step.IsInteger || step.AsInteger() != 1)
        {
            output.Print(", ");
            step.Print(output);
        }

        output.Print(" do");
        output.PrintLine();
        output.IncreaseIndent();
        PrintSequence(output, this.m_statements);
        output.DecreaseIndent();
        output.Print("end");
    }
}
