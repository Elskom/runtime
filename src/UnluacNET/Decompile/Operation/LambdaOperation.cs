// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class LambdaOperation(int line, Func<Registers, Block, Statement> func) : Operation(line)
{
    private readonly Func<Registers, Block, Statement> m_func = func;

    public override Statement Process(Registers r, Block block)
        => this.m_func.Invoke(r, block);
}
