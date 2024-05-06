// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class CompareBlock(LFunction function, int begin, int end, int target, Branch branch) : Block(function, begin, end)
{
    public int Target { get; } = target;

    public Branch Branch { get; } = branch;

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
        => output.Print("-- unhandled compare assign");

    public override Operation Process(Decompiler d)
        => new LambdaOperation(this.End - 1, (r, block) =>
        {
            return new RegisterSet(this.End - 1, this.Target, this.Branch.AsExpression(r)).Process(r, block);
        });
}
