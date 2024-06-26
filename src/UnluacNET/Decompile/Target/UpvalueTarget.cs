﻿// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class UpvalueTarget(string name) : Target
{
    private readonly string m_name = name;

    public override void Print(Output output)
        => output.Print(this.m_name);

    public override void PrintMethod(Output output)
        => throw new InvalidOperationException();
}
