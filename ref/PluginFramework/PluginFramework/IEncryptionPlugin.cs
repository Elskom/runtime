// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Interface for Els_kom kom entry Encryption and Decryption plugins (Version 1.5.0.0 or newer).
///
/// Interface plugins can be made in C++ Common Language Runtime (/clr) to mix
/// unmanaged and managed code to avoid anyone from easily decompiling the code to
/// C# and getting private things like encryption keys to an particular kom file.
/// </summary>
public interface IEncryptionPlugin
{
    /// <summary>
    /// Gets the name of the Encryption plugin.
    /// </summary>
    /// <value>
    /// The name of the Encryption plugin.
    /// </value>
    string PluginName { get; }

    /// <summary>
    /// Gets the encryption key to use for decrypting a KOM file entry.
    /// If KOM file algorithm is not supported throw <see cref="NotPackableException"/>.
    /// </summary>
    /// <exception cref="NotPackableException">
    /// When the KOM file algorithm is not suppoted by the curently installed
    /// encryption plugin.
    /// </exception>
    /// <param name="algorithm">The algorithm the entry is.</param>
    /// <param name="encrypt"><see langword="true"/> if the key is used for encrypting,
    /// <see langword="false"/> for decryption.</param>
    /// <returns>The encrpytion key, in bytes.</returns>
    byte[] GetEncryptionKey(uint algorithm, bool encrypt);
}
