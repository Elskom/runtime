// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class CallOperation : Operation
{
    private readonly FunctionCall m_call;

    public CallOperation(int line, FunctionCall call)
        : base(line)
        => this.m_call = call;

    public override Statement Process(Registers r, Block block)
        => new FunctionCallStatement(this.m_call);
}
