// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class FunctionCallStatement(FunctionCall call) : Statement
{
    private readonly FunctionCall m_call = call;

    public override bool BeginsWithParen => this.m_call.BeginsWithParen;

    public override void Print(Output output)
        => this.m_call.Print(output);
}
