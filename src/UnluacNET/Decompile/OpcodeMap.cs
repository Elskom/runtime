// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

internal sealed class OpcodeMap(int version)
{
    private readonly int[] luaP_opmodes =
    [
        /*       T  A    B                 C                 mode             opcode       */
        Opmode(0, 1, OpArgMask.OpArgR, OpArgMask.OpArgN, OpMode.iABC), /* OP_MOVE */
        Opmode(0, 1, OpArgMask.OpArgK, OpArgMask.OpArgN, OpMode.iABx), /* OP_LOADK */
        Opmode(0, 1, OpArgMask.OpArgU, OpArgMask.OpArgU, OpMode.iABC), /* OP_LOADBOOL */
        Opmode(0, 1, OpArgMask.OpArgR, OpArgMask.OpArgN, OpMode.iABC), /* OP_LOADNIL */
        Opmode(0, 1, OpArgMask.OpArgU, OpArgMask.OpArgN, OpMode.iABC), /* OP_GETUPVAL */
        Opmode(0, 1, OpArgMask.OpArgK, OpArgMask.OpArgN, OpMode.iABx), /* OP_GETGLOBAL */
        Opmode(0, 1, OpArgMask.OpArgR, OpArgMask.OpArgK, OpMode.iABC), /* OP_GETTABLE */
        Opmode(0, 0, OpArgMask.OpArgK, OpArgMask.OpArgN, OpMode.iABx), /* OP_SETGLOBAL */
        Opmode(0, 0, OpArgMask.OpArgU, OpArgMask.OpArgN, OpMode.iABC), /* OP_SETUPVAL */
        Opmode(0, 0, OpArgMask.OpArgK, OpArgMask.OpArgK, OpMode.iABC), /* OP_SETTABLE */
        Opmode(0, 1, OpArgMask.OpArgU, OpArgMask.OpArgU, OpMode.iABC), /* OP_NEWTABLE */
        Opmode(0, 1, OpArgMask.OpArgR, OpArgMask.OpArgK, OpMode.iABC), /* OP_SELF */
        Opmode(0, 1, OpArgMask.OpArgK, OpArgMask.OpArgK, OpMode.iABC), /* OP_ADD */
        Opmode(0, 1, OpArgMask.OpArgK, OpArgMask.OpArgK, OpMode.iABC), /* OP_SUB */
        Opmode(0, 1, OpArgMask.OpArgK, OpArgMask.OpArgK, OpMode.iABC), /* OP_MUL */
        Opmode(0, 1, OpArgMask.OpArgK, OpArgMask.OpArgK, OpMode.iABC), /* OP_DIV */
        Opmode(0, 1, OpArgMask.OpArgK, OpArgMask.OpArgK, OpMode.iABC), /* OP_MOD */
        Opmode(0, 1, OpArgMask.OpArgK, OpArgMask.OpArgK, OpMode.iABC), /* OP_POW */
        Opmode(0, 1, OpArgMask.OpArgR, OpArgMask.OpArgN, OpMode.iABC), /* OP_UNM */
        Opmode(0, 1, OpArgMask.OpArgR, OpArgMask.OpArgN, OpMode.iABC), /* OP_NOT */
        Opmode(0, 1, OpArgMask.OpArgR, OpArgMask.OpArgN, OpMode.iABC), /* OP_LEN */
        Opmode(0, 1, OpArgMask.OpArgR, OpArgMask.OpArgR, OpMode.iABC), /* OP_CONCAT */
        Opmode(0, 0, OpArgMask.OpArgR, OpArgMask.OpArgN, OpMode.iAsBx), /* OP_JMP */
        Opmode(1, 0, OpArgMask.OpArgK, OpArgMask.OpArgK, OpMode.iABC), /* OP_EQ */
        Opmode(1, 0, OpArgMask.OpArgK, OpArgMask.OpArgK, OpMode.iABC), /* OP_LT */
        Opmode(1, 0, OpArgMask.OpArgK, OpArgMask.OpArgK, OpMode.iABC), /* OP_LE */
        Opmode(1, 1, OpArgMask.OpArgR, OpArgMask.OpArgU, OpMode.iABC), /* OP_TEST */
        Opmode(1, 1, OpArgMask.OpArgR, OpArgMask.OpArgU, OpMode.iABC), /* OP_TESTSET */
        Opmode(0, 1, OpArgMask.OpArgU, OpArgMask.OpArgU, OpMode.iABC), /* OP_CALL */
        Opmode(0, 1, OpArgMask.OpArgU, OpArgMask.OpArgU, OpMode.iABC), /* OP_TAILCALL */
        Opmode(0, 0, OpArgMask.OpArgU, OpArgMask.OpArgN, OpMode.iABC), /* OP_RETURN */
        Opmode(0, 1, OpArgMask.OpArgR, OpArgMask.OpArgN, OpMode.iAsBx), /* OP_FORLOOP */
        Opmode(0, 1, OpArgMask.OpArgR, OpArgMask.OpArgN, OpMode.iAsBx), /* OP_FORPREP */
        Opmode(1, 0, OpArgMask.OpArgN, OpArgMask.OpArgU, OpMode.iABC), /* OP_TFORLOOP */
        Opmode(0, 0, OpArgMask.OpArgU, OpArgMask.OpArgU, OpMode.iABC), /* OP_SETLIST */
        Opmode(0, 0, OpArgMask.OpArgN, OpArgMask.OpArgN, OpMode.iABC), /* OP_CLOSE */
        Opmode(0, 1, OpArgMask.OpArgU, OpArgMask.OpArgN, OpMode.iABx), /* OP_CLOSURE */
        Opmode(0, 1, OpArgMask.OpArgU, OpArgMask.OpArgN, OpMode.iABC), /* OP_VARARG */
    ];

    private readonly Op[] m_map = version is 0x51
        ?
        [
            Op.MOVE, Op.LOADK, Op.LOADBOOL, Op.LOADNIL, Op.GETUPVAL, Op.GETGLOBAL, Op.GETTABLE, Op.SETGLOBAL, Op.SETUPVAL,
            Op.SETTABLE, Op.NEWTABLE, Op.SELF, Op.ADD, Op.SUB, Op.MUL, Op.DIV, Op.MOD, Op.POW, Op.UNM, Op.NOT, Op.LEN, Op.CONCAT,
            Op.JMP, Op.EQ, Op.LT, Op.LE, Op.TEST, Op.TESTSET, Op.CALL, Op.TAILCALL, Op.RETURN, Op.FORLOOP, Op.FORPREP, Op.TFORLOOP,
            Op.SETLIST, Op.CLOSE, Op.CLOSURE, Op.VARARG,
        ]
        :
        [
            Op.MOVE, Op.LOADK, Op.LOADKX, Op.LOADBOOL, Op.LOADNIL, Op.GETUPVAL, Op.GETTABUP, Op.GETTABLE, Op.SETTABUP, Op.SETUPVAL,
            Op.SETTABLE, Op.NEWTABLE, Op.SELF, Op.ADD, Op.SUB, Op.MUL, Op.DIV, Op.MOD, Op.POW, Op.UNM, Op.NOT, Op.LEN, Op.CONCAT,
            Op.JMP, Op.EQ, Op.LT, Op.LE, Op.TEST, Op.TESTSET, Op.CALL, Op.TAILCALL, Op.RETURN, Op.FORLOOP, Op.FORPREP, Op.TFORCALL,
            Op.TFORLOOP, Op.SETLIST, Op.CLOSURE, Op.VARARG, Op.EXTRAARG,
        ];

    public Op this[int opcode] => this.GetOp(opcode);

    public Op GetOp(int opcode)
        => opcode >= 0 && opcode < this.m_map.Length
        ? this.m_map[opcode]
        : throw new ArgumentOutOfRangeException(nameof(opcode), opcode, "The specified opcode exceeds the boundaries of valid opcodes.");

    public OpMode GetOpMode(int m)
        => (OpMode)(this.luaP_opmodes[m] & 3);

    public OpArgMask GetBMode(int m)
        => (OpArgMask)((this.luaP_opmodes[m] >> 4) & 3);

    public OpArgMask GetCMode(int m)
        => (OpArgMask)((this.luaP_opmodes[m] >> 2) & 3);

    public bool TestAMode(int m)
        => (this.luaP_opmodes[m] & (1 << 6)) == 1;

    public bool TestTMode(int m)
        => (this.luaP_opmodes[m] & (1 << 7)) == 1;

    /*
    ** masks for instruction properties. The format is:
    ** bits 0-1: op mode
    ** bits 2-3: C arg mode
    ** bits 4-5: B arg mode
    ** bit 6: instruction set register A
    ** bit 7: operator is a test
    */
    private static int Opmode(byte t, byte a, OpArgMask b, OpArgMask c, OpMode m)
        => (t << 7) | (a << 6) | ((byte)b << 4) | ((byte)c << 2) | (byte)m;
}
