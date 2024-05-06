// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class LLongNumber(long number) : LNumber
{
    public long Number { get; private set; } = number;

    public override double Value => this.Number;

    public override bool Equals(object obj)
        => obj is LLongNumber lnumber ? this.Number == lnumber.Number : base.Equals(obj);

    public override int GetHashCode()
        => throw new NotImplementedException();

    public override string ToString()
        => this.Number.ToString(CultureInfo.InvariantCulture);
}
