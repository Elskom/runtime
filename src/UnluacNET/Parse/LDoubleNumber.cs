// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class LDoubleNumber(double number) : LNumber
{
    public double Number { get; } = number;

    public override double Value => this.Number;

    public override bool Equals(object obj)
        => obj is LDoubleNumber lnumber ? this.Number == lnumber.Number : base.Equals(obj);

    public override int GetHashCode()
        => throw new NotImplementedException();

    public override string ToString()
        => this.Number == Math.Round(this.Number)
        ? ((long)this.Number).ToString(CultureInfo.InvariantCulture)
        : this.Number.ToString(CultureInfo.InvariantCulture);
}
