﻿// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class RepeatBlock(LFunction function, Branch branch, Registers r) : Block(function, branch.End, branch.Begin)
{
    private readonly Branch m_branch = branch;
    private readonly Registers m_r = r;
    private readonly List<Statement> m_statements = new(branch.Begin - branch.End + 1);

    public override bool Breakable => true;

    public override bool IsContainer => true;

    public override bool IsUnprotected => false;

    public override void AddStatement(Statement statement)
        => this.m_statements.Add(statement);

    public override int GetLoopback()
        => throw new InvalidOperationException();

    public override void Print(Output output)
    {
        output.Print("repeat");
        output.PrintLine();
        output.IncreaseIndent();
        PrintSequence(output, this.m_statements);
        output.DecreaseIndent();
        output.Print("until ");
        this.m_branch.AsExpression(this.m_r).Print(output);
    }
}
