// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class LFunction(BHeader header, int[] code, LLocal[] locals, LObject[] constants, LUpvalue[] upvalues, LFunction[] functions, int maximumStackSize, int numUpValues, int numParams, int vararg) : IBObject
{
    public BHeader Header { get; set; } = header;

    public int[] Code { get; set; } = code;

    public LLocal[] Locals { get; set; } = locals;

    public LObject[] Constants { get; set; } = constants;

    public LUpvalue[] UpValues { get; set; } = upvalues;

    public LFunction[] Functions { get; set; } = functions;

    public int MaxStackSize { get; set; } = maximumStackSize;

    public int NumUpValues { get; set; } = numUpValues;

    public int NumParams { get; set; } = numParams;

    public int VarArg { get; set; } = vararg;
}
