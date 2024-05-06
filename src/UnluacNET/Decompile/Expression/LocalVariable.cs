// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class LocalVariable(Declaration decl) : Expression(PRECEDENCE_ATOMIC)
{
    public Declaration Declaration { get; private set; } = decl;

    public override int ConstantIndex => -1;

    public override bool IsBrief => true;

    public override bool IsDotChain => true;

    public override void Print(Output output)
        => output.Print(this.Declaration.Name);
}
