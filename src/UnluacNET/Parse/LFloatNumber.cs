﻿// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class LFloatNumber : LNumber
{
    public LFloatNumber(float number)
        => this.Number = number;

    public float Number { get; }

    public override double Value => this.Number;

    public override bool Equals(object obj)
        => obj is LFloatNumber number ? this.Number == number.Number : base.Equals(obj);

    public override int GetHashCode()
        => throw new NotImplementedException();

    public override string ToString()
        => this.Number == (float)Math.Round(this.Number)
        ? ((int)this.Number).ToString(CultureInfo.InvariantCulture)
        : this.Number.ToString(CultureInfo.InvariantCulture);
}
