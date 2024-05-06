// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class LFloatNumber(float number) : LNumber
{
    public float Number { get; } = number;

    public override double Value => this.Number;

    public override bool Equals(object obj)
        => obj is LFloatNumber lnumber ? this.Number == lnumber.Number : base.Equals(obj);

    public override int GetHashCode()
        => throw new NotImplementedException();

    public override string ToString()
        => this.Number == (float)Math.Round(this.Number)
        ? ((int)this.Number).ToString(CultureInfo.InvariantCulture)
        : this.Number.ToString(CultureInfo.InvariantCulture);
}
