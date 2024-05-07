// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class BooleanIndicator(LFunction function, int line) : Block(function, line, line)
{
    public override bool Breakable => false;

    public override bool IsContainer => false;

    public override bool IsUnprotected => false;

    public override void AddStatement(Statement statement)
    {
        // Do nothing
    }

    public override int GetLoopback()
        => throw new InvalidOperationException();

    public override void Print(Output output)
        => output.Print("-- unhandled boolean indicator");
}
