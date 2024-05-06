// Copyright (c) 2018-2024, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Obtain the git repository information for the assembly.
/// </summary>
[SuppressMessage("Performance", "CA1822:Mark members as static", Justification = "Ref assembly which must match ABI of runtime.")]
public class GitInformation
{
    /// <summary>
    /// Gets the git commit head description based upon the string constructed by
    /// git name-rev.
    /// </summary>
    public string Headdesc
        => throw null!;

    /// <summary>
    /// Gets the git commit hash as formatted by git rev-parse.
    /// </summary>
    /// <value>
    /// The git commit hash as formatted by git rev-parse.
    /// </value>
    public string Commit
        => throw null!;

    /// <summary>
    /// Gets the git branch name as formatted by git name-rev.
    /// </summary>
    /// <value>
    /// The git branch name as formatted by git name-rev.
    /// </value>
    public string Branchname
        => throw null!;

    /// <summary>
    /// Gets a value indicating whether the branch is dirty or
    /// clean based upon the string constructed by git describe.
    /// </summary>
    /// <value>
    /// A value indicating whether the branch is dirty or
    /// clean based upon the string constructed by git describe.
    /// </value>
    public bool IsDirty
        => throw null!;

    /// <summary>
    /// Gets a value indicating whether the branch is the master
    /// branch or not based upon the string constructed by
    /// git name-rev. This also returns true if the branch is main as well.
    /// </summary>
    /// <value>
    /// A value indicating whether the branch is the master
    /// branch or not based upon the string constructed by
    /// git name-rev. This also returns true if the branch is main as well.
    /// </value>
    [Obsolete("Use GitInformation.IsMain instead. This will be removed in a future release. This is because most people using git are abandoning the use of master as the default branch name for the name of main. To prevent breakage I suggest you rename your default branch from master to main today.")]
    [ExcludeFromCodeCoverage]
    public bool IsMaster
        => throw null!;

    /// <summary>
    /// Gets a value indicating whether the branch is the main
    /// branch or not based upon the string constructed by
    /// git name-rev.
    /// </summary>
    /// <value>
    /// A value indicating whether the branch is the main
    /// branch or not based upon the string constructed by
    /// git name-rev.
    /// </value>
    public bool IsMain
        => throw null!;

    /// <summary>
    /// Gets a value indicating whether refs point to a stable tag release.
    /// </summary>
    /// <value>
    /// A value indicating whether refs point to a stable tag release.
    /// </value>
    public bool IsTag
        => throw null!;

    /// <summary>
    /// Applies the <see cref="Attribute"/>s that the specified <see cref="Assembly"/> contains.
    /// </summary>
    /// <param name="assembly">
    /// The <see cref="Assembly"/> to apply the attributes to.
    /// </param>
    public static void ApplyAssemblyAttributes(Assembly assembly)
        => throw null!;

    /// <summary>
    /// Gets the instance of the <see cref="GitInformation"/> class for
    /// the specified <see cref="Type"/> or <see langword="null"/>.
    /// </summary>
    /// <param name="assemblyType">
    /// The <see cref="Type"/> to the <see cref="Assembly"/> to look for a instance of the <see cref="GitInformation"/> class.
    /// </param>
    /// <returns>
    /// The <see cref="GitInformation"/> class instance to the specified <see cref="Type"/>
    /// or <see langword="null"/>.
    /// </returns>
    public static GitInformation? GetAssemblyInstance(Type assemblyType)
        => throw null!;

    /// <summary>
    /// Gets the instance of the <see cref="GitInformation"/> class for
    /// the specified <see cref="Assembly"/> or <see langword="null"/>.
    /// </summary>
    /// <param name="assembly">
    /// The <see cref="Assembly"/> to look for a instance of the <see cref="GitInformation"/> class.
    /// </param>
    /// <returns>
    /// The <see cref="GitInformation"/> class instance to the specified <see cref="Assembly"/>
    /// or <see langword="null"/>.
    /// </returns>
    public static GitInformation? GetAssemblyInstance(Assembly assembly)
        => throw null!;
}
