﻿// Copyright (c) 2018-2021, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

public class AlwaysLoop : Block
{
    private readonly List<Statement> m_statements;

    public AlwaysLoop(LFunction function, int begin, int end)
        : base(function, begin, end)
        => this.m_statements = new();

    public override bool Breakable => true;

    public override bool IsContainer => true;

    public override bool IsUnprotected => true;

    public override int ScopeEnd => this.End - 2;

    public override int GetLoopback()
        => this.Begin;

    public override void AddStatement(Statement statement)
        => this.m_statements.Add(statement);

    public override void Print(Output output)
    {
        output.PrintLine("while true do");
        output.IncreaseIndent();
        PrintSequence(output, this.m_statements);
        output.DecreaseIndent();
        output.Print("end");
    }
}
