// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class GenericOperation(int line, Statement statement) : Operation(line)
{
    private readonly Statement m_statement = statement;

    public override Statement Process(Registers r, Block block)
        => this.m_statement;
}
