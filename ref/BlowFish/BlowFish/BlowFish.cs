// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Blowfish encryption class.
/// </summary>
public sealed class BlowFish : IDisposable
{
    /// <summary>
    /// Initializes a new instance of the <see cref="BlowFish"/> class with the hex key provided.
    /// </summary>
    /// <param name="hexKey">Cipher key as a hex string.</param>
    public BlowFish(string hexKey)
        => throw null!;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlowFish"/> class with the byte key provided.
    /// </summary>
    /// <param name="cipherKey">Cipher key as a byte array.</param>
    public BlowFish(byte[] cipherKey)
        => throw null!;

    /// <summary>
    /// Gets or sets initialization vector for CBC mode.
    /// </summary>
    /// <value>
    /// Initialization vector for CBC mode.
    /// </value>
    public IEnumerable<byte> IV
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets or sets a value indicating whether non standard blowfish mode.
    /// </summary>
    /// <value>
    /// A value indicating whether non standard blowfish mode.
    /// </value>
    public bool NonStandard
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// XoR encrypts two 8 bit blocks.
    /// </summary>
    /// <param name="block">8 bit block 1.</param>
    /// <param name="iv">8 bit block 2.</param>
    public static void XorBlock(ref byte[] block, byte[] iv)
        => throw null!;

    /// <summary>
    /// XoR encrypts two 8 bit blocks.
    /// </summary>
    /// <param name="block">8 bit block 1.</param>
    /// <param name="iv">8 bit block 2.</param>
    public static void XorBlock(Stream block, byte[] iv)
        => throw null!;

    /// <summary>
    /// Encrypts a string in CBC mode.
    /// </summary>
    /// <param name="pt">Plaintext data to encrypt.</param>
    /// <returns>Ciphertext with IV appended to front.</returns>
    public string EncryptCBC(string pt)
        => throw null!;

    /// <summary>
    /// Encrypts a byte array in CBC mode.
    /// IV must be created and saved manually.
    /// </summary>
    /// <param name="pt">Plaintext data to encrypt.</param>
    /// <returns>Ciphertext.</returns>
    public byte[] EncryptCBC(byte[] pt)
        => throw null!;

    /// <summary>
    /// Decrypts a string in CBC mode.
    /// </summary>
    /// <param name="ct">Ciphertext with IV appended to front.</param>
    /// <returns>Plaintext.</returns>
    public string DecryptCBC(string ct)
        => throw null!;

    /// <summary>
    /// Decrypts a byte array in CBC mode.
    /// IV must be created and saved manually.
    /// </summary>
    /// <param name="ct">Ciphertext data to decrypt.</param>
    /// <returns>Plaintext.</returns>
    public byte[] DecryptCBC(byte[] ct)
        => throw null!;

    /// <summary>
    /// Encrypt a string in ECB mode.
    /// </summary>
    /// <param name="pt">Plaintext to encrypt as ascii string.</param>
    /// <returns>hex value of encrypted data.</returns>
    public string EncryptECB(string pt)
        => throw null!;

    /// <summary>
    /// Encrypts a byte array in ECB mode.
    /// </summary>
    /// <param name="pt">Plaintext data.</param>
    /// <returns>Ciphertext bytes.</returns>
    public byte[] EncryptECB(byte[] pt)
        => throw null!;

    /// <summary>
    /// Decrypts a string (ECB).
    /// </summary>
    /// <param name="ct">hHex string of the ciphertext.</param>
    /// <returns>Plaintext ascii string.</returns>
    public string DecryptECB(string ct)
        => throw null!;

    /// <summary>
    /// Decrypts a byte array.
    /// </summary>
    /// <param name="cipherText">Ciphertext byte array.</param>
    /// <param name="mode">Cipher mode.</param>
    /// <returns>Plaintext or <see langword="null"/> if mode is not <see cref="CipherMode.ECB"/>.</returns>
    public byte[] Decrypt(byte[] cipherText, CipherMode mode)
        => throw null!;

    /// <summary>
    /// Creates and sets a random initialization vector.
    /// </summary>
    /// <returns>The random IV.</returns>
    public byte[] SetRandomIV()
        => throw null!;

    /// <summary>
    /// Cleans up the resources used by <see cref="BlowFish"/>.
    /// </summary>
    public void Dispose()
        => throw null!;
}
