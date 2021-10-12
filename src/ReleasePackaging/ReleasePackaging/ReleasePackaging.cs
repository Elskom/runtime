// Copyright (c) 2018-2021, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Handles application's release packaging command line.
/// </summary>
public static class ReleasePackaging
{
    private static ReadOnlySpan<string> ExcludeFile
        => new[]
    {
        ".CodeAnalysisLog.xml",
    };

    private static ReadOnlySpan<string> Extensions
        => new[]
    {
        "*.exe", "*.dll", "*.xml", "*.txt", "*.pdb",
    };

    /// <summary>
    /// Packages an application's Release build to a zip file.
    /// </summary>
    /// <param name="args">The command line arguments passed into the calling process.</param>
    public static void PackageRelease(string[] args)
    {
        if (args is null)
        {
            throw new ArgumentNullException(nameof(args));
        }

        // Replace spaces with periods.
        var outfilename = args[1].Replace(" ", ".", StringComparison.OrdinalIgnoreCase);
        args[1] = (
            args[1].StartsWith(".\\", StringComparison.OrdinalIgnoreCase),
            args[1].StartsWith("./", StringComparison.OrdinalIgnoreCase)) switch
        {
            (true, false) => outfilename.Replace(".\\", $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase),
            (false, true) =>outfilename.Replace("./", $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase),
            _ => $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}{outfilename.Replace(".", string.Empty, StringComparison.OrdinalIgnoreCase)}",
        };
        if (args[0].Equals("-p", StringComparison.Ordinal))
        {
            Console.WriteLine(Resources.ReleasePackaging_Write_output!, outfilename);
            if (File.Exists(args[1]))
            {
                File.Delete(args[1]);
            }

            using var zipFile = ZipFile.Open(args[1], ZipArchiveMode.Update);
            DirectoryInfo di1 = new(Directory.GetCurrentDirectory());
            foreach (var fi1 in GetAllFilesWithExtensions(di1, Extensions, ExcludeFile).Select(fi => fi.Name))
            {
                _ = zipFile.CreateEntryFromFile(fi1, fi1);
            }

            foreach (var di2 in di1.GetDirectories())
            {
                foreach (var fi2 in GetAllFilesWithExtensions(di2, Extensions[1..], ExcludeFile).Select(fi => fi.Name))
                {
                    _ = zipFile.CreateEntryFromFile($"{di2.Name}{Path.DirectorySeparatorChar}{fi2}", $"{di2.Name}{Path.DirectorySeparatorChar}{fi2}");
                }
            }
        }
    }

    private static List<FileInfo> GetAllFilesWithExtensions(DirectoryInfo dinfo, ReadOnlySpan<string> extensions, ReadOnlySpan<string> excludeFile)
    {
        List<FileInfo> fileInfos = new();
        foreach (var extension in extensions)
        {
            var files = dinfo.GetFiles(extension).ToList();
            foreach (var file in files)
            {
                // filter out excluded files.
                var excluded = file.Name.EndsWith(excludeFile[0], StringComparison.OrdinalIgnoreCase);
                if (!excluded)
                {
                    fileInfos.Add(file);
                }
            }
        }

        return fileInfos;
    }
}
