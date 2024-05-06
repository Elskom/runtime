// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal class TestNode : Branch
{
    public TestNode(int test, bool inverted, int line, int begin, int end)
        : base(line, begin, end)
    {
        this.Test = test;
        this.Inverted = inverted;
        this.IsTest = true;
    }

    public int Test { get; }

    public bool Inverted { get; }

    public override Expression AsExpression(Registers registers)
        => this.Inverted ? new NotBranch(this.Invert()).AsExpression(registers) : registers.GetExpression(this.Test, this.Line);

    public override int GetRegister()
        => this.Test;

    public override Branch Invert()
        => new TestNode(this.Test, !this.Inverted, this.Line, this.End, this.Begin);

    public override void UseExpression(Expression expression)
    {
        // Do nothing
    }

    public override string ToString()
        => $"TestNode[test={this.Test};inverted={this.Inverted};line={this.Line};begin={this.Begin};end={this.End}]";
}
