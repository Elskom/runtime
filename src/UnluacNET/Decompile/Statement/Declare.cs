﻿// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class Declare(List<Declaration> decls) : Statement
{
    private readonly List<Declaration> m_decls = decls;

    public override void Print(Output output)
    {
        output.Print("local ");
        output.Print(this.m_decls[0].Name);
        for (var i = 1; i < this.m_decls.Count; i++)
        {
            output.Print(", ");
            output.Print(this.m_decls[i].Name);
        }
    }
}
