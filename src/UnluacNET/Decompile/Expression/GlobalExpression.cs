﻿// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class GlobalExpression : Expression
{
    private readonly string m_name;
    private readonly int m_index;

    public GlobalExpression(string name, int index)
        : base(PRECEDENCE_ATOMIC)
    {
        this.m_name = name;
        this.m_index = index;
    }

    public override int ConstantIndex => this.m_index;

    public override bool IsBrief => true;

    public override bool IsDotChain => true;

    public override void Print(Output output)
        => output.Print(this.m_name);
}
