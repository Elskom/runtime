﻿// Copyright (c) 2018-2021, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

public class DoEndBlock : Block
{
    private readonly List<Statement> m_statements;

    public DoEndBlock(LFunction function, int begin, int end)
        : base(function, begin, end)
        => this.m_statements = new(end - begin + 1);

    public override bool Breakable => false;

    public override bool IsContainer => true;

    public override bool IsUnprotected => false;

    public override void AddStatement(Statement statement)
        => this.m_statements.Add(statement);

    public override int GetLoopback()
        => throw new InvalidOperationException();

    public override void Print(Output output)
    {
        output.PrintLine("do");
        output.IncreaseIndent();
        PrintSequence(output, this.m_statements);
        output.DecreaseIndent();
        output.Print("end");
    }
}
