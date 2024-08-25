// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs.UnluacNET;

/// <summary>
/// A stream that can decompile Lua files.
/// </summary>
[GenerateDispose(true)]
public partial class LuaDecompileStream : Stream
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
    {
    }

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
    [SuppressMessage("Style", "IDE0290:Use primary constructor", Justification = "Cannot be used for this class. This is a Roslyn Bug LOL.")]
    public LuaDecompileStream(Stream input, bool keepOpen)
    {
        this.BaseStream = input;
        this.KeepOpen = keepOpen;
    }

    /// <summary>
    /// Initializes a new instance of the <see cref="LuaDecompileStream"/> class.
    /// </summary>
    public LuaDecompileStream()
        : this(new MemoryStream())
        => this.InputNoData = true;

    /// <inheritdoc/>
    public override bool CanRead
        => !this.InputNoData;

    /// <inheritdoc/>
    public override bool CanSeek
        => false;

    /// <inheritdoc/>
    public override bool CanWrite
        => this.InputNoData;

    /// <inheritdoc/>
    public override long Length
        => this.BaseStream.Length;

    /// <inheritdoc/>
    public override long Position
    {
        get => throw new NotSupportedException();
        set => throw new NotSupportedException();
    }

    [DisposeField(true)]
    private Stream BaseStream { get; set; }

    private bool InputNoData { get; }

    /// <summary>
    /// Decompiles Lua bytecode based on the data Read from the input stream.
    /// </summary>
    /// <param name="buffer">A dummy buffer, set to null always.</param>
    /// <param name="offset">A dummy offset, set to 0 always.</param>
    /// <param name="count">A dummy count, set to 0 always.</param>
    /// <returns>The amount of data bytes in the decompiled lua.</returns>
    public override int Read(byte[] buffer, int offset, int count)
        => !this.CanRead switch
        {
            true => throw new InvalidOperationException(
                "Read can only be used to decompile an lua file only if the backing stream contains the data to the lua file to decompile."),
            _ => this.DecompileLuaWithStreamBuffer(),
        };

    /// <summary>
    /// Decompiles Lua bytecode based on the input buffer.
    /// </summary>
    /// <param name="buffer">The buffer to read the lua bytecode from.</param>
    /// <param name="offset">The lua bytecode should start at offset 0.</param>
    /// <param name="count">.</param>
    public override void Write(byte[] buffer, int offset, int count)
    {
        if (!this.CanWrite)
        {
            throw new InvalidOperationException("Write can only be used to decompile an lua file only if the backing stream contains no data.");
        }

        this.BaseStream.Write(buffer, offset, count);
        _ = this.DecompileLuaWithStreamBuffer();
    }

    /// <inheritdoc/>
    public override long Seek(long offset, SeekOrigin origin)
        => throw new NotSupportedException();

    /// <inheritdoc/>
    public override void SetLength(long value)
        => throw new NotSupportedException();

    /// <inheritdoc/>
    public override void Flush()
        => throw new NotSupportedException();

    private int DecompileLuaWithStreamBuffer()
    {
        if (this.BaseStream is not MemoryStream baseMemStream)
        {
            return 0;
        }

        LFunction lMain;
        using (var ms = new MemoryStream(baseMemStream.ToArray()))
        {
            var header = new BHeader(ms);
            lMain = header.Function.Parse(ms, header);
        }

        var d = new Decompiler(lMain);
        d.Decompile();
        baseMemStream.Clear(baseMemStream.GetBuffer().Length);
        using var writer = new StreamWriter(baseMemStream, Encoding.UTF8);
        d.Print(new Output(writer));
        writer.Flush();
        return baseMemStream.GetBuffer().Length;
    }
}
