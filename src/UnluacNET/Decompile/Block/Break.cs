// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class Break(LFunction function, int line, int target) : Block(function, line, line)
{
    public int Target { get; private set; } = target;

    public override bool Breakable => false;

    public override bool IsContainer => false;

    // Actually, it is unprotected, but not really a block
    public override bool IsUnprotected => false;

    public override void AddStatement(Statement statement)
        => throw new InvalidOperationException();

    public override int GetLoopback()
        => throw new InvalidOperationException();

    public override void Print(Output output)
        => output.Print("do return end");

    public override void PrintTail(Output output)
        => output.Print("break");
}
