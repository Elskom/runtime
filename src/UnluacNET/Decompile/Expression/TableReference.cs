﻿// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class TableReference(Expression table, Expression index) : Expression(PRECEDENCE_ATOMIC)
{
    private readonly Expression m_table = table;
    private readonly Expression m_index = index;

    public override int ConstantIndex => Math.Max(this.m_table.ConstantIndex, this.m_index.ConstantIndex);

    public override bool IsDotChain => this.m_index.IsIdentifier && this.m_table.IsDotChain;

    public override bool IsMemberAccess => this.m_index.IsIdentifier;

    public override string GetField()
        => this.m_index.AsName();

    public override Expression GetTable()
        => this.m_table;

    public override void Print(Output output)
    {
        this.m_table.Print(output);
        if (this.m_index.IsIdentifier)
        {
            output.Print(".");
            output.Print(this.m_index.AsName());
        }
        else
        {
            output.Print("[");
            this.m_index.Print(output);
            output.Print("]");
        }
    }
}
