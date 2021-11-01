﻿// Copyright (c) 2018-2021, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

public class VariableTarget : Target
{
    public VariableTarget(Declaration decl)
        => this.Declaration = decl;

    public Declaration Declaration { get; private set; }

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
