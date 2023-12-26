// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Class that allows managing kom Files.
/// </summary>
public static class KOMManager
{
    /// <summary>
    /// The event to which allows getting the message to do stuff with.
    /// </summary>
    public static event EventHandler<MessageEventArgs>? MessageEvent
    {
        add => throw null!;
        remove => throw null!;
    }

    /// <summary>
    /// Gets a value indicating whether the current state on packing KOM files.
    /// </summary>
    /// <returns>The current state on packing KOM files.</returns>
    public static bool PackingState
        => throw null!;

    /// <summary>
    /// Gets a value indicating whether the current state on unpacking KOM files.
    /// </summary>
    /// <returns>The current state on unpacking KOM files.</returns>
    public static bool UnpackingState
        => throw null!;

    /// <summary>
    /// Gets The list of <see cref="IKomPlugin"/> plugins.
    /// </summary>
    /// <value>
    /// The list of <see cref="IKomPlugin"/> plugins.
    /// </value>
    public static IList<IKomPlugin> Komplugins
        => throw null!;

    /// <summary>
    /// Gets The list of <see cref="IEncryptionPlugin"/> plugins.
    /// </summary>
    /// <value>
    /// The list of <see cref="IEncryptionPlugin"/> plugins.
    /// </value>
    public static IList<IEncryptionPlugin> Encryptionplugins
        => throw null!;

    /// <summary>
    /// Gets the list of <see cref="ICallbackPlugin"/> plugins.
    /// </summary>
    /// <value>
    /// The list of <see cref="ICallbackPlugin"/> plugins.
    /// </value>
    public static IList<ICallbackPlugin> Callbackplugins
        => throw null!;

    /// <summary>
    /// Copies Modified KOM files to the Elsword Directory that was Set in the Settings Dialog in Els_kom. Requires: File Name, Original Directory the File is in, And Destination Directory.
    /// </summary>
    /// <param name="fileName">The name of the file to copy.</param>
    /// <param name="origFileDir">The original kom file location.</param>
    /// <param name="destFileDir">The target to copy the kom file too.</param>
    public static void CopyKomFiles(string fileName, string origFileDir, string destFileDir)
        => throw null!;

    /// <summary>
    /// Moves the Original KOM Files back to their original locations, overwriting the modified ones.
    /// </summary>
    /// <param name="fileName">The name of the file to move.</param>
    /// <param name="origFileDir">The original kom file location.</param>
    /// <param name="destFileDir">The target to move the kom file too.</param>
    /// <exception cref="ArgumentNullException">When <paramref name="origFileDir"/> or <paramref name="destFileDir"/> are <see langword="null"/> or empty.</exception>
    public static void MoveOriginalKomFilesBack(string fileName, string origFileDir, string destFileDir)
        => throw null!;

    /// <summary>
    /// Unpacks KOM files by invoking the extractor.
    /// </summary>
    public static void UnpackKoms()
        => throw null!;

    /// <summary>
    /// Packs KOM files by invoking the packer.
    /// </summary>
    public static void PackKoms()
        => throw null!;

    /// <summary>
    /// Converts the KOM crc.xml file to the provided version,
    /// if it is not already that version.
    /// </summary>
    /// <param name="toVersion">The version to convert the CRC.xml file to.</param>
    /// <param name="crcpath">The path to the crc.xml file.</param>
    public static void ConvertCRC(int toVersion, string crcpath)
        => throw null!;

    /// <summary>
    /// Updates the crc.xml file if the folder has new files
    /// not in the crc.xml, or removes files listed in crc.xml that are
    /// no longer in the folder.
    /// </summary>
    /// <param name="crcversion">The version of the crc.xml file.</param>
    /// <param name="crcpath">The path to the crc.xml file.</param>
    /// <param name="checkpath">The directry that contains the crc.xml file.</param>
    public static void UpdateCRC(int crcversion, string crcpath, string checkpath)
        => throw null!;

    /// <summary>
    /// Deploys the Test Mods callback functions provided by plugins.
    /// This is a blocking call that has to run in a separate thread from Els_kom's main thread.
    /// NEVER UNDER ANY CIRCUMSTANCES RUN THIS IN THE MAIN THREAD, YOU WILL DEADLOCK ELS_KOM!!!.
    /// </summary>
    /// <param name="directRun">if the game was executed directly.</param>
    public static void DeployCallBack(bool directRun)
        => throw null!;

    /// <summary>
    /// Gets the base file name of the KOM File.
    /// </summary>
    /// <param name="fileName">The input kom file.</param>
    /// <returns>The base file name of the KOM File.</returns>
    public static string GetFileBaseName(string fileName)
        => throw null!;
}
