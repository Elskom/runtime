// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Load assemblies from a zip file.
/// </summary>
[Serializable]
public sealed class ZipAssembly : Assembly
{
    private static readonly CompositeFormat ZipAssemblyDoesNotExist = CompositeFormat.Parse(Resources.ZipAssembly_does_not_exist);
    private static readonly CompositeFormat ZipAssemblyMustEndWithDll = CompositeFormat.Parse(Resources.ZipAssembly_must_end_with_dll);

    // always set to Zip file full path + \\ + file path in zip.
    private string locationValue;

    private ZipAssembly(SerializationInfo serializationInfo, StreamingContext streamingContext)
        => throw new NotImplementedException();

    // hopefully this has the path to the assembly on System.Reflection.Assembly.Location output with the value from this override.

    /// <summary>
    /// Gets the location of the assembly in the zip file.
    /// </summary>
    public override string Location
        => this.locationValue;

    /// <summary>
    /// Loads the assembly with it’s debugging symbols
    /// from the specified zip file.
    /// </summary>
    /// <param name="zipFileName">The zip file for which to look for the assembly in.</param>
    /// <param name="assemblyName">The assembly file name to load.</param>
    /// <param name="context">The context to load the assemblies into.</param>
    /// <returns>A new <see cref="ZipAssembly"/> that represents the loaded assembly.</returns>
    /// <exception cref="ArgumentNullException">
    /// When the passed in <see cref="AssemblyLoadContext"/> or the passed in <paramref name="zipFileName"/> is <see langword="null"/>.
    /// </exception>
    /// <exception cref="ArgumentException">
    /// When <paramref name="zipFileName"/> Empty, or does not exist.
    /// Or <paramref name="assemblyName"/> is null, Empty or does not end with the '.dll' extension.
    /// </exception>
    /// <exception cref="ZipAssemblyLoadException">
    /// When the assembly name specified was not found in the input zip file.
    /// </exception>
    /// <exception cref="Exception">
    /// Any other exception not documented here indirectly thrown by this
    /// If any other exceptions other than the ones above is thrown from a call to this, it exposes a bug.
    /// </exception>
    public static ZipAssembly? LoadFromZip(string zipFileName, string assemblyName, AssemblyLoadContext context)
    {
        ArgumentNullException.ThrowIfNull(context);
        ArgumentException.ThrowIfNullOrEmpty(zipFileName);
        ArgumentException.ThrowIfNullOrEmpty(assemblyName);
        if (!File.Exists(zipFileName))
        {
            throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, ZipAssemblyDoesNotExist!, nameof(zipFileName)), nameof(zipFileName));
        }

        if (!assemblyName.EndsWith(".dll", StringComparison.Ordinal))
        {
            // setting pdbFileName fails or makes unpredicted/unwanted things if this is not checked
            throw new ArgumentException(string.Format(CultureInfo.CurrentCulture, ZipAssemblyMustEndWithDll!, nameof(assemblyName)), nameof(assemblyName));
        }

        // check if the assembly is in the zip file.
        // If it is, get it’s bytes then load it.
        // If not throw an exception. Also throw
        // an exception if the pdb file is requested but not found.
        bool found;
        string zipAssemblyName;
        var pdbAssemblyName = string.Empty;
        byte[]? asmbytes;
        byte[]? pdbbytes = null;
        using (var zipFile = ZipFile.OpenRead(zipFileName))
        {
            GetBytesFromZipFile(assemblyName, zipFile, out asmbytes, out found, out zipAssemblyName);
            if (Debugger.IsAttached)
            {
                var pdbFileName = assemblyName.Replace("dll", "pdb", StringComparison.OrdinalIgnoreCase);
                GetBytesFromZipFile(pdbFileName, zipFile, out pdbbytes, out _, out pdbAssemblyName);
            }
        }

        if (!found)
        {
            throw new ZipAssemblyLoadException(Resources.ZipAssembly_Assembly_specified_not_found!);
        }

        // always load pdb when debugging (automatically loaded when embedded however).
        // PDB should be automatically downloaded to zip file always
        // and really *should* always be present unless embedded inside of the dll file.
        try
        {
            using MemoryStream ms1 = new(asmbytes!);
            MemoryStream? ms2 = pdbbytes is not null ? new(pdbbytes) : null;
            var zipassembly = Debugger.IsAttached && pdbbytes is not null ?
                (ZipAssembly)context.LoadFromStream(ms1, ms2) :
                (ZipAssembly)context.LoadFromStream(ms1);
            ms2?.Dispose();
            zipassembly.locationValue = $"{zipFileName}{Path.DirectorySeparatorChar}{zipAssemblyName}";
            return zipassembly;
        }
        catch (BadImageFormatException)
        {
            // ignore the error and load the other files.
            return null;
        }
        catch (FileLoadException)
        {
            var tmpDir = Path.GetTempPath();
            using (var dllfs = File.Create($"{tmpDir}{zipAssemblyName}"))
            {
                dllfs.Write(asmbytes!, 0, asmbytes!.Length);
            }

            if (Debugger.IsAttached && pdbbytes is not null)
            {
                using var pdbfs = File.Create($"{tmpDir}{pdbAssemblyName}");
                pdbfs.Write(pdbbytes, 0, pdbbytes.Length);
            }

            var zipassembly = (ZipAssembly)context.LoadFromAssemblyPath($"{tmpDir}{zipAssemblyName}");
            zipassembly.locationValue = $"{tmpDir}{zipAssemblyName}";
            return zipassembly;
        }
    }

    private static void GetBytesFromZipFile(string entryName, ZipArchive zipFile, out byte[]? bytes, out bool found, out string assemblyName)
    {
        var assemblyEntry = zipFile.Entries.FirstOrDefault(e => e.FullName.Equals(entryName, StringComparison.OrdinalIgnoreCase));
        assemblyName = string.Empty;
        found = false;
        bytes = null;
        if (assemblyEntry is not null)
        {
            assemblyName = assemblyEntry.FullName;
            found = true;
            using var strm = assemblyEntry.Open();
            using MemoryStream ms = new();
            strm.CopyTo(ms);
            bytes = ms.ToArray();
        }
    }
}
