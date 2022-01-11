// Copyright (c) 2018-2022, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Zlib Memory Compression and Decompression Helper Class.
/// </summary>
public static class MemoryZlib
{
    /// <summary>
    /// Compresses data using the default compression level.
    /// </summary>
    /// <param name="inData">The original input data.</param>
    /// <exception cref="NotPackableException">
    /// Thrown when the internal compression stream errors in any way.
    /// </exception>
    /// <returns>
    /// The compressed data.
    /// </returns>
    public static byte[] Compress(byte[] inData)
        => throw null!;

    /// <summary>
    /// Compresses a file using the default compression level.
    /// </summary>
    /// <param name="path">The file to compress.</param>
    /// <exception cref="NotPackableException">
    /// Thrown when the internal compression stream errors in any way.
    /// </exception>
    /// <returns>
    /// The compressed data.
    /// </returns>
    public static byte[] Compress(string path)
        => throw null!;

    /// <summary>
    /// Compresses data using an specific compression level.
    /// </summary>
    /// <param name="inData">The original input data.</param>
    /// <param name="level">The compression level to use.</param>
    /// <exception cref="NotPackableException">
    /// Thrown when the internal compression stream errors in any way.
    /// </exception>
    /// <returns>
    /// The compressed data.
    /// </returns>
    // discard returned adler32. The caller does not want it.
    public static byte[] Compress(byte[] inData, ZlibCompression level)
        => throw null!;

    /// <summary>
    /// Compresses a file using the default compression level.
    /// </summary>
    /// <param name="path">The file to compress.</param>
    /// <param name="level">The compression level to use.</param>
    /// <exception cref="NotPackableException">
    /// Thrown when the internal compression stream errors in any way.
    /// </exception>
    /// <returns>
    /// The compressed data.
    /// </returns>
    // discard returned adler32. The caller does not want it.
    public static byte[] Compress(string path, ZlibCompression level)
        => throw null!;

    /// <summary>
    /// Compresses data using the default compression level and outputs an adler32 hash with the data.
    /// </summary>
    /// <param name="inData">The original input data.</param>
    /// <exception cref="NotPackableException">
    /// Thrown when the internal compression stream errors in any way.
    /// </exception>
    /// <returns>
    /// A <see cref="ValueTuple"/> containing the compressed data, as well as the adler32 hash of that data.
    /// </returns>
    public static (byte[] OutData, uint Adler32) CompressHash(byte[] inData)
        => throw null!;

    /// <summary>
    /// Compresses a file using the default compression level and outputs an adler32 hash with the data.
    /// </summary>
    /// <param name="path">The file to compress.</param>
    /// <exception cref="NotPackableException">
    /// Thrown when the internal compression stream errors in any way.
    /// </exception>
    /// <returns>
    /// A <see cref="ValueTuple"/> containing the compressed data, as well as the adler32 hash of that data.
    /// </returns>
    public static (byte[] OutData, uint Adler32) CompressHash(string path)
        => throw null!;

    /// <summary>
    /// Compresses data using an specific compression level and outputs an adler32 hash with the data.
    /// </summary>
    /// <param name="inData">The original input data.</param>
    /// <param name="outStream">The compressed output data.</param>
    /// <param name="level">The compression level to use.</param>
    /// <exception cref="NotPackableException">
    /// Thrown when the internal compression stream errors in any way.
    /// </exception>
    /// <returns>
    /// The adler32 hash of the compressed data.
    /// </returns>
    public static uint CompressHash(byte[] inData, Stream outStream, ZlibCompression level)
        => throw null!;

    /// <summary>
    /// Compresses data using an specific compression level and outputs an adler32 hash with the data.
    /// </summary>
    /// <param name="inData">The original input data.</param>
    /// <param name="level">The compression level to use.</param>
    /// <exception cref="NotPackableException">
    /// Thrown when the internal compression stream errors in any way.
    /// </exception>
    /// <returns>
    /// A <see cref="ValueTuple"/> containing the compressed data, as well as the adler32 hash of that data.
    /// </returns>
    public static (byte[] OutData, uint Adler32) CompressHash(byte[] inData, ZlibCompression level)
        => throw null!;

    /// <summary>
    /// Compresses a file using an specific compression level and outputs an adler32 hash with the data.
    /// </summary>
    /// <param name="path">The file to compress.</param>
    /// <param name="level">The compression level to use.</param>
    /// <exception cref="NotPackableException">
    /// Thrown when the internal compression stream errors in any way.
    /// </exception>
    /// <returns>
    /// A <see cref="ValueTuple"/> containing the compressed data, as well as the adler32 hash of that data.
    /// </returns>
    public static (byte[] OutData, uint Adler32) CompressHash(string path, ZlibCompression level)
        => throw null!;

    /// <summary>
    /// Decompresses data.
    /// </summary>
    /// <param name="inData">The compressed input data.</param>
    /// <param name="outStream">The decompressed output data.</param>
    /// <exception cref="NotUnpackableException">
    /// Thrown when the internal decompression stream errors in any way.
    /// </exception>
    public static void Decompress(byte[] inData, Stream outStream)
        => throw null!;

    /// <summary>
    /// Decompresses data.
    /// </summary>
    /// <param name="inData">The compressed input data.</param>
    /// <exception cref="NotUnpackableException">
    /// Thrown when the internal decompression stream errors in any way.
    /// </exception>
    /// <returns>
    /// The decompressed data.
    /// </returns>
    public static byte[] Decompress(byte[] inData)
        => throw null!;

    /// <summary>
    /// Decompresses a file.
    /// </summary>
    /// <param name="path">The file to decompress.</param>
    /// <exception cref="NotPackableException">
    /// Thrown when the internal decompression stream errors in any way.
    /// </exception>
    /// <returns>
    /// The decompressed data.
    /// </returns>
    public static byte[] Decompress(string path)
        => throw null!;

    /// <summary>
    /// Check data for compression by zlib.
    /// </summary>
    /// <param name="stream">Input stream.</param>
    /// <returns>Returns <see langword="true" /> if data is compressed by zlib, else <see langword="false" />.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="stream"/> is <see langword="null" />.</exception>
    public static bool IsCompressedByZlib(Stream stream)
        => throw null!;

    /// <summary>
    /// Check data for compression by zlib.
    /// </summary>
    /// <param name="path">The file to check on if it is compressed by zlib.</param>
    /// <returns>Returns <see langword="true" /> if data is compressed by zlib, else <see langword="false" />.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="path"/> is <see langword="null" /> or <see cref="string.Empty"/>.</exception>
    public static bool IsCompressedByZlib(string path)
        => throw null!;

    /// <summary>
    /// Check data for compression by zlib.
    /// </summary>
    /// <param name="data">Input array.</param>
    /// <returns>Returns <see langword="true" /> if data is compressed by zlib, else <see langword="false" />.</returns>
    /// <exception cref="ArgumentNullException">When <paramref name="data"/> is <see langword="null" />.</exception>
    public static bool IsCompressedByZlib(byte[] data)
        => throw null!;

    // NEW: Zlib version check.

    /// <summary>
    /// Gets the version to zlib.managed.
    /// </summary>
    /// <returns>The version string to this version of zlib.managed.</returns>
    public static string ZlibVersion()
        => throw null!;

    // NEW: Adler32 hasher.

    /// <summary>
    /// Gets the Adler32 checksum of the input data at the specified index and length.
    /// </summary>
    /// <param name="data">The data to checksum.</param>
    /// <param name="index">The index of which to checksum.</param>
    /// <param name="length">The length of the data to checksum.</param>
    /// <returns>The Adler32 hash of the input data.</returns>
    public static long ZlibGetAdler32(byte[] data, int index, int length)
        => throw null!;
}
