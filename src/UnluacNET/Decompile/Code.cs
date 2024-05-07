// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class Code(LFunction function)
{
    /*
    ** Size and position of opcode arguments
    */
    private const int SIZE_C = 9;
    private const int SIZE_B = 9;
    private const int SIZE_Bx = SIZE_C + SIZE_B;
    private const int SIZE_A = 8;
    private const int SIZE_OP = 6;
    private const int POS_OP = 0;
    private const int POS_A = POS_OP + SIZE_OP;
    private const int POS_C = POS_A + SIZE_A;
    private const int POS_B = POS_C + SIZE_C;
    private const int POS_Bx = POS_C;

    /*
    ** Limits for opcode arguments
    ** (signed) int used to manipulate most arguments
    */
    private const int MAXARG_Bx = (1 << SIZE_Bx) - 1;
    private const int MAXARG_sBx = MAXARG_Bx >> 1;

    /*
     ** Macros to operate RK indices
     */
    private static readonly int MASK_OPCODE = MASK1(SIZE_OP, 0);
    private static readonly int MASK_A = MASK1(SIZE_A, 0);
    private static readonly int MASK_B = MASK1(SIZE_B, 0);
    private static readonly int MASK_C = MASK1(SIZE_C, 0);
    private static readonly int MASK_Bx = MASK1(SIZE_Bx, 0);

    private readonly OpcodeMap map = function.Header.Version.GetOpcodeMap();
    private readonly int[] code = function.Code;

    public static int GetOpCode(int codePoint)
        => (codePoint >> POS_OP) & MASK_OPCODE;

    public static int GetArgA(int codePoint)
        => (codePoint >> POS_A) & MASK_A;

    public static int GetArgB(int codePoint)
        => (codePoint >> POS_B) & MASK_B;

    public static int GetArgC(int codePoint)
        => (codePoint >> POS_C) & MASK_C;

    public static int GetArgBx(int codePoint)
        => (codePoint >> POS_Bx) & MASK_Bx;

    public static int GetArgsBX(int codePoint)
        => GetArgBx(codePoint) - MAXARG_sBx;

    public Op Op(int line)
        => this.map.GetOp(GetOpCode(this.CodePoint(line)));

    public int A(int line)
        => GetArgA(this.CodePoint(line));

    public int C(int line)
        => GetArgC(this.CodePoint(line));

    public int B(int line)
        => GetArgB(this.CodePoint(line));

    public int Bx(int line)
        => GetArgBx(this.CodePoint(line));

    public int SBx(int line)
        => GetArgsBX(this.CodePoint(line));

    public OpMode OpMode(int line)
        => this.map.GetOpMode((int)this.Op(line));

    public OpArgMask BMode(int line)
        => this.map.GetBMode((int)this.Op(line));

    public OpArgMask CMode(int line)
        => this.map.GetCMode((int)this.Op(line));

    public bool TestA(int line)
        => this.map.TestAMode((int)this.Op(line));

    public bool TestT(int line)
        => this.map.TestTMode((int)this.Op(line));

    public int CodePoint(int line)
        => this.code[line - 1];

    private static int MASK1(int n, int p)
        => ~(~0 << n) << p;
}
