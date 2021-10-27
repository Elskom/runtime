// Copyright (c) 2018-2021, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

public class LuaDecompileStream : Stream
{
    /// <summary>
    /// Initializes a new instance of the <see cref="LuaDecompileStream"/> class.
    /// </summary>
    /// <param name="input">
    /// The input lua data to decompile.
    /// Note: Must be a MemoryStream with the contents of the lua data.
    /// </param>
    public LuaDecompileStream(Stream input)
        : this(input, false)
        => throw null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="LuaDecompileStream"/> class.
    /// </summary>
    /// <param name="input">
    /// The input lua data to decompile.
    /// Note: Must be a MemoryStream with the contents of the lua data.
    /// </param>
    /// <param name="keepOpen">
    /// Controls if the stream keeps the input stream open when the stream is disposed.
    /// </param>
    public LuaDecompileStream(Stream input, bool keepOpen)
        => throw null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="LuaDecompileStream"/> class.
    /// </summary>
    public LuaDecompileStream()
        : this(new MemoryStream(), false)
        => throw null!;

    /// <inheritdoc/>
    public override bool CanRead
        => throw null!;

    /// <inheritdoc/>
    public override bool CanSeek
        => throw null!;

    /// <inheritdoc/>
    public override bool CanWrite
        => throw null!;

    /// <inheritdoc/>
    public override long Length
        => throw null!;

    /// <inheritdoc/>
    public override long Position
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Decompiles Lua bytecode based on the data Read from the input stream.
    /// </summary>
    /// <param name="buffer">A dummy buffer, set to null always.</param>
    /// <param name="offset">A dummy offset, set to 0 always.</param>
    /// <param name="count">A dummy count, set to 0 always.</param>
    /// <returns>The amount of data bytes in the decompiled lua.</returns>
    public override int Read(byte[] buffer, int offset, int count)
        => throw null!;

    /// <summary>
    /// Decompiles Lua bytecode based on the input buffer.
    /// </summary>
    /// <param name="buffer">The buffer to read the lua bytecode from.</param>
    /// <param name="offset">The lua bytecode should start at offset 0.</param>
    /// <param name="count">.</param>
    public override void Write(byte[] buffer, int offset, int count)
        => throw null!;

    public override long Seek(long offset, SeekOrigin origin)
        => throw null!;

    public override void SetLength(long value)
        => throw null!;

    public override void Flush()
        => throw null!;
}
