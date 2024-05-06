// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class Upvalues(LUpvalue[] upvalues)
{
    private readonly LUpvalue[] m_upvalues = upvalues;

    public string GetName(int idx)
        => idx < this.m_upvalues.Length && this.m_upvalues[idx].Name != null
        ? this.m_upvalues[idx].Name
        : $"_UPVALUE{idx}_";

    public UpvalueExpression GetExpression(int index)
        => new(this.GetName(index));
}
