// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal abstract class Branch(int line, int begin, int end)
{
    public int Line { get; private set; } = line;

    public int Begin { get; set; } = begin;

    public int End { get; set; } = end;

    public bool IsSet { get; set; }

    public bool IsCompareSet { get; set; }

    public bool IsTest { get; set; }

    public int SetTarget { get; set; } = -1;

    public abstract Branch Invert();

    public abstract int GetRegister();

    public abstract Expression AsExpression(Registers registers);

    public abstract void UseExpression(Expression expression);
}
