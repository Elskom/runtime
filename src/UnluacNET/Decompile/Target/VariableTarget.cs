﻿// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class VariableTarget(Declaration decl) : Target
{
    public Declaration Declaration { get; private set; } = decl;

    public override bool IsLocal => true;

    public override bool IsDeclaration(Declaration decl)
        => this.Declaration == decl;

    public override bool Equals(object obj)
        => obj is VariableTarget target && this.Declaration == target.Declaration;

    public override int GetIndex()
        => this.Declaration.Register;

    public override void Print(Output output)
        => output.Print(this.Declaration.Name);

    public override void PrintMethod(Output output)
        => throw new InvalidOperationException();

    public override int GetHashCode()
        => throw new NotImplementedException();
}
