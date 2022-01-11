// Copyright (c) 2018-2022, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Class that provides support for zlib compression/decompression for an input stream.
/// This is an sealed class.
/// </summary>
public sealed class ZlibStream : Stream
{
    /// <summary>
    /// Initializes a new instance of the <see cref="ZlibStream"/> class for compression.
    /// </summary>
    /// <param name="input">The input stream to decompress with.</param>
    public ZlibStream(Stream input)
        : this(input, false)
        => throw null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="ZlibStream"/> class for compression.
    /// </summary>
    /// <param name="input">The input stream to decompress with.</param>
    /// <param name="keepOpen">Whether to keep the input stream open or not.</param>
    public ZlibStream(Stream input, bool keepOpen)
        => throw null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="ZlibStream"/> class for compression.
    /// </summary>
    /// <param name="output">The output stream to compress to.</param>
    /// <param name="level">The compression level for the data to compress.</param>
    public ZlibStream(Stream output, ZlibCompression level)
        : this(output, level, false)
        => throw null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="ZlibStream"/> class for compression.
    /// </summary>
    /// <param name="output">The output stream to compress to.</param>
    /// <param name="level">The compression level for the data to compress.</param>
    /// <param name="keepOpen">Whether to keep the output stream open or not.</param>
    public ZlibStream(Stream output, ZlibCompression level, bool keepOpen)
        => throw null!;

    /// <summary>
    /// Gets a value indicating whether the stream is finished.
    /// </summary>
    public bool IsFinished
        => throw null!;

    /// <summary>
    /// Gets or sets a value indicating whether there is more input.
    /// </summary>
    public bool MoreInput
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets the total number of bytes input so far.
    /// </summary>
    public long TotalIn
        => throw null!;

    /// <summary>
    /// Gets the total number of bytes output so far.
    /// </summary>
    public long TotalOut
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

    /// <inheritdoc/>
    public override int ReadByte()
        => throw null!;

    /// <inheritdoc/>
    public override int Read(byte[] buffer, int offset, int count)
        => throw null!;

    /// <inheritdoc/>
    public override void WriteByte(byte value)
        => throw null!;

    /// <summary>
    /// Writes a byte to the current position in the stream and advances the position
    /// within the stream by one byte.
    /// </summary>
    /// <param name="value">
    /// The byte to write to the stream.
    /// </param>
    /// <exception cref="IOException">
    /// An I/O error occurs.
    /// </exception>
    /// <exception cref="NotSupportedException">
    /// The stream does not support writing, or the stream is already closed.
    /// </exception>
    /// <exception cref="ObjectDisposedException">
    /// Methods were called after the stream was closed.
    /// </exception>
    public void WriteByte(int value)
        => throw null!;

    /// <inheritdoc/>
    public override void Write(byte[] buffer, int offset, int count)
        => throw null!;

    /// <inheritdoc/>
    public override void Flush()
        => throw null!;

    /// <summary>
    /// Finishes the stream.
    /// </summary>
    public void Finish()
        => throw null!;

    /// <summary>
    /// Ends the compression or decompression on the stream.
    /// </summary>
    public void EndStream()
        => throw null!;

    /// <summary>
    /// Gets the Adler32 hash of the stream's data.
    /// </summary>
    /// <returns>The Adler32 hash of the stream's data.</returns>
    public long GetAdler32()
        => throw null!;

    /// <inheritdoc/>
    public override long Seek(long offset, SeekOrigin origin)
        => throw null!;

    /// <inheritdoc/>
    public override void SetLength(long value)
        => throw null!;
}
