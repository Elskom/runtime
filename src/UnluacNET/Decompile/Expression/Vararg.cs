// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class Vararg(bool multiple) : Expression(PRECEDENCE_ATOMIC)
{
    private readonly bool m_multiple = multiple;

    public override int ConstantIndex => -1;

    public override bool IsMultiple => this.m_multiple;

    public override void Print(Output output)
        => output.Print(this.m_multiple ? "..." : "(...)");

    public override void PrintMultiple(Output output)
        => output.Print(this.m_multiple ? "..." : "(...)");
}
