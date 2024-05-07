// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Blowfish encryption class.
/// </summary>
[GenerateDispose(false)]
public sealed partial class BlowFish
{
    [DisposeField(false)]
    private BlowFishInternal bfInternal;

    /// <summary>
    /// Initializes a new instance of the <see cref="BlowFish"/> class with the hex key provided.
    /// </summary>
    /// <param name="hexKey">Cipher key as a hex string.</param>
    public BlowFish(string hexKey)
        => this.bfInternal = new(hexKey);

    /// <summary>
    /// Initializes a new instance of the <see cref="BlowFish"/> class with the byte key provided.
    /// </summary>
    /// <param name="cipherKey">Cipher key as a byte array.</param>
    public BlowFish(byte[] cipherKey)
        => this.bfInternal = new(cipherKey);

    /// <summary>
    /// Gets or sets initialization vector for CBC mode.
    /// </summary>
    /// <value>
    /// Initialization vector for CBC mode.
    /// </value>
    public IEnumerable<byte> IV
    {
        get => this.bfInternal.IV;
        set => this.bfInternal.IV = value;
    }

    /// <summary>
    /// Gets or sets a value indicating whether non standard blowfish mode.
    /// </summary>
    /// <value>
    /// A value indicating whether non standard blowfish mode.
    /// </value>
    public bool NonStandard
    {
        get => this.bfInternal.NonStandard;
        set => this.bfInternal.NonStandard = value;
    }

    /// <summary>
    /// XoR encrypts two 8 bit blocks.
    /// </summary>
    /// <param name="block">8 bit block 1.</param>
    /// <param name="iv">8 bit block 2.</param>
    public static void XorBlock(ref byte[] block, byte[] iv)
    {
        ArgumentNullException.ThrowIfNull(block);
        ArgumentNullException.ThrowIfNull(iv);
        ArgumentOutOfRangeException.ThrowIfEqual(block.Length, 0);
        ArgumentOutOfRangeException.ThrowIfEqual(iv.Length, 0);
        for (var i = 0; i < block.Length; i++)
        {
            block[i] ^= iv[i % iv.Length];
        }
    }

    /// <summary>
    /// XoR encrypts two 8 bit blocks.
    /// </summary>
    /// <param name="block">8 bit block 1.</param>
    /// <param name="iv">8 bit block 2.</param>
    public static void XorBlock(Stream block, byte[] iv)
    {
        ArgumentNullException.ThrowIfNull(block);
        if (block is MemoryStream ms)
        {
            var block1 = ms.GetBuffer();
            XorBlock(ref block1, iv);
        }
    }

    /// <summary>
    /// Encrypts a string.
    /// </summary>
    /// <param name="ct">Ciphertext with IV appended to front if <see cref="CipherMode.CBC"/> mode, or hex string if <see cref="CipherMode.ECB"/> mode.</param>
    /// <param name="mode">Cipher mode.</param>
    /// <returns>Ciphertext with or without the IV appended to front or <see langword="null"/> if mode is not <see cref="CipherMode.ECB"/> or <see cref="CipherMode.CBC"/>.</returns>
    [SuppressMessage("Security", "CA5358:Review cipher mode usage with cryptography experts", Justification = "Part of ABI.")]
    [Obsolete("Using CipherMode.ECB in this method is deprecated.")]
    public string? Encrypt(string ct, CipherMode mode)
        => mode switch
        {
            CipherMode.ECB => this.bfInternal.EncryptECB(ct),
            CipherMode.CBC => this.bfInternal.EncryptCBC(ct),
            _ => null,
        };

    /// <summary>
    /// Encrypts a byte array.
    /// </summary>
    /// <param name="cipherText">Ciphertext byte array.</param>
    /// <param name="mode">Cipher mode.</param>
    /// <returns>Plaintext or <see langword="null"/> if mode is not <see cref="CipherMode.ECB"/> or <see cref="CipherMode.CBC"/>.</returns>
    [SuppressMessage("Security", "CA5358:Review cipher mode usage with cryptography experts", Justification = "Part of ABI.")]
    [Obsolete("Using CipherMode.ECB in this method is deprecated.")]
    public byte[]? Encrypt(byte[] cipherText, CipherMode mode)
        => mode switch
        {
            CipherMode.ECB => this.bfInternal.EncryptECB(cipherText),
            CipherMode.CBC => this.bfInternal.EncryptCBC(cipherText),
            _ => null,
        };

    /// <summary>
    /// Decrypts a string.
    /// </summary>
    /// <param name="ct">Ciphertext with IV appended to front if <see cref="CipherMode.CBC"/> mode, or hex string if <see cref="CipherMode.ECB"/> mode.</param>
    /// <param name="mode">Cipher mode.</param>
    /// <returns>Plaintext or <see langword="null"/> if mode is not <see cref="CipherMode.ECB"/> or <see cref="CipherMode.CBC"/>.</returns>
    [SuppressMessage("Security", "CA5358:Review cipher mode usage with cryptography experts", Justification = "Part of ABI.")]
    [Obsolete("Using CipherMode.ECB in this method is deprecated.")]
    public string? Decrypt(string ct, CipherMode mode)
        => mode switch
        {
            CipherMode.ECB => this.bfInternal.DecryptECB(ct),
            CipherMode.CBC => this.bfInternal.DecryptCBC(ct),
            _ => null,
        };

    /// <summary>
    /// Decrypts a byte array.
    /// </summary>
    /// <param name="cipherText">Ciphertext byte array.</param>
    /// <param name="mode">Cipher mode.</param>
    /// <returns>Plaintext or <see langword="null"/> if mode is not <see cref="CipherMode.ECB"/> or <see cref="CipherMode.CBC"/>.</returns>
    [SuppressMessage("Security", "CA5358:Review cipher mode usage with cryptography experts", Justification = "Part of ABI.")]
    [Obsolete("Using CipherMode.ECB in this method is deprecated.")]
    public byte[]? Decrypt(byte[] cipherText, CipherMode mode)
        => mode switch
        {
            CipherMode.ECB => this.bfInternal.DecryptECB(cipherText),
            CipherMode.CBC => this.bfInternal.DecryptCBC(cipherText),
            _ => null,
        };

    /// <summary>
    /// Creates and sets a random initialization vector.
    /// </summary>
    /// <returns>The random IV.</returns>
    public byte[] SetRandomIV()
        => this.bfInternal.SetRandomIV();
}
