// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class WhileBlock(LFunction function, Branch branch, int loopback, Registers registers) : Block(function, branch.Begin, branch.End)
{
    private readonly Branch m_branch = branch;
    private readonly int m_loopback = loopback;
    private readonly Registers m_registers = registers;
    private readonly List<Statement> m_statements = new(branch.End - branch.Begin + 1);

    public override int ScopeEnd => this.End - 2;

    public override bool Breakable => true;

    public override bool IsContainer => true;

    public override bool IsUnprotected => true;

    public override void AddStatement(Statement statement)
        => this.m_statements.Add(statement);

    public override int GetLoopback()
        => this.m_loopback;

    public override void Print(Output output)
    {
        output.Print("while ");
        this.m_branch.AsExpression(this.m_registers).Print(output);
        output.Print(" do");
        output.PrintLine();
        output.IncreaseIndent();
        PrintSequence(output, this.m_statements);
        output.DecreaseIndent();
        output.Print("end");
    }
}
