// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Handles application's release packaging command line.
/// </summary>
public static class ReleasePackaging
{
    private static List<string> Extensions
        =>
    [
        "*.exe", "*.dll", "*.xml", "*.txt", "*.pdb",
    ];

    /// <summary>
    /// Packages an application's Release build to a zip file.
    /// </summary>
    /// <param name="args">The command line arguments passed into the calling process.</param>
    /// <exception cref="ArgumentOutOfRangeException">When the length of args is greater than or less than 2.</exception>
    public static void PackageRelease(ReadOnlySpan<string> args)
    {
        ArgumentOutOfRangeException.ThrowIfNotEqual(args.Length, 2);

        // Replace spaces with periods.
        var outfilename = args[1].Replace(" ", ".", StringComparison.OrdinalIgnoreCase);
        outfilename = (
            args[1].StartsWith(".\\", StringComparison.OrdinalIgnoreCase),
            args[1].StartsWith("./", StringComparison.OrdinalIgnoreCase)) switch
        {
            (true, false) => outfilename.Replace(".\\", $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase),
            (false, true) => outfilename.Replace("./", $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}", StringComparison.OrdinalIgnoreCase),
            _ => $"{Directory.GetCurrentDirectory()}{Path.DirectorySeparatorChar}{outfilename.Replace(".", string.Empty, StringComparison.OrdinalIgnoreCase)}",
        };
        if (args[0] is "-p")
        {
            Console.WriteLine(Resources.ReleasePackaging_Write_output!, outfilename);
            if (File.Exists(outfilename))
            {
                File.Delete(outfilename);
            }

            using var zipFile = ZipFile.Open(outfilename, ZipArchiveMode.Update);
            DirectoryInfo di1 = new(Directory.GetCurrentDirectory());
            foreach (var fi1 in GetAllFilesWithExtensions(di1, Extensions).Select(fi => fi.Name))
            {
                _ = zipFile.CreateEntryFromFile(fi1, fi1);
            }

            foreach (var di2 in di1.GetDirectories())
            {
                foreach (var fi2 in GetAllFilesWithExtensions(di2, Extensions.GetRange(1, Extensions.Count)).Select(fi => fi.Name))
                {
                    _ = zipFile.CreateEntryFromFile($"{di2.Name}{Path.DirectorySeparatorChar}{fi2}", $"{di2.Name}{Path.DirectorySeparatorChar}{fi2}");
                }
            }
        }
    }

    private static List<FileInfo> GetAllFilesWithExtensions(DirectoryInfo dinfo, List<string> extensions)
    {
        List<FileInfo> fileInfos = [];
        foreach (var extension in extensions)
        {
            var files = dinfo.GetFiles(extension).ToList();
            foreach (var file in files)
            {
                // filter out excluded files.
                var excluded = file.Name.EndsWith(".CodeAnalysisLog.xml", StringComparison.OrdinalIgnoreCase);
                if (!excluded)
                {
                    fileInfos.Add(file);
                }
            }
        }

        return fileInfos;
    }
}
