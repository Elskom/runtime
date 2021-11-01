﻿// Copyright (c) 2018-2021, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

public class LIntNumber : LNumber
{
    public LIntNumber(int number)
        => this.Number = number;

    public int Number { get; private set; }

    public override double Value => this.Number;

    public override bool Equals(object obj)
        => obj is LIntNumber number ? this.Number == number.Number : base.Equals(obj);

    public override int GetHashCode()
        => throw new NotImplementedException();

    public override string ToString()
        => this.Number.ToString();
}
