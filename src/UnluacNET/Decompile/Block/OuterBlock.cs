﻿// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class OuterBlock(LFunction function, int length) : Block(function, 0, length + 1)
{
    private readonly List<Statement> m_statements = new(length);

    public override bool Breakable => false;

    public override bool IsContainer => true;

    public override bool IsUnprotected => false;

    public override int ScopeEnd => this.End - 1 + this.Function.Header.Version.OuterBlockScopeAdjustment;

    public override void AddStatement(Statement statement)
        => this.m_statements.Add(statement);

    public override int GetLoopback()
        => throw new InvalidOperationException();

    public override void Print(Output output)
    {
        /* extra return statement */
        var last = this.m_statements.Count - 1;
        if (last < 0 || this.m_statements[last] is not Return)
        {
            throw new InvalidOperationException(this.m_statements[last].ToString());
        }

        // this doesn't seem like appropriate behavior???
        this.m_statements.RemoveAt(last);
        PrintSequence(output, this.m_statements);
    }
}
