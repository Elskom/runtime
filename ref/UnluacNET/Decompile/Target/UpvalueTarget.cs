﻿// Copyright (c) 2018-2021, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

public class UpvalueTarget : Target
{
    private readonly string m_name;

    public UpvalueTarget(string name)
        => this.m_name = name;

    public override void Print(Output output)
        => output.Print(this.m_name);

    public override void PrintMethod(Output output)
        => throw new InvalidOperationException();
}
