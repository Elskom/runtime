// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

internal static class RuntimeExtensions
{
    public static List<T> CreateInstancesFromInterface<T>(this AssemblyLoadContext context, string dllFile, string pdbFile)
    {
        List<T> instances = new();
        try
        {
            var asmFiles = OpenAssemblyFiles(dllFile, pdbFile);
            using MemoryStream ms1 = new(asmFiles.AsmBytes!);
            MemoryStream? ms2 = Debugger.IsAttached && asmFiles.PdbBytes is not null ? new(asmFiles.PdbBytes) : null;
            instances.AddRange(context.CreateInstancesFromInterface<T>(ms1, ms2));
            ms2?.Dispose();
        }
        catch (BadImageFormatException)
        {
            // ignore the error (this would cause the end of
            // the function to return an empty list).
        }
        catch (FileLoadException)
        {
            instances.AddRange(CreateInstancesFromInterface<T>(context.LoadFromAssemblyPath(dllFile)));
        }

        return instances;
    }

    public static List<T> CreateInstancesFromInterface<T>(this AssemblyLoadContext context, Stream assembly, Stream? assemblySymbols)
        => CreateInstancesFromInterface<T>(context.LoadFromStream(assembly, assemblySymbols));

    public static List<T> CreateInstancesFromInterface<T>(Assembly? assembly)
    {
        List<T> instances = new();
        if (assembly is not null)
        {
            try
            {
                var types = assembly.GetTypes();
                if (typeof(T).FullName is null)
                {
                    GenericPluginLoader.InvokeLoaderMessage(new("Type name cannot be null.", "Error!", ErrorLevel.Error));
                }

                instances.AddRange(types.Where(type =>
                        !type.IsInterface && !type.IsAbstract &&
                        type.GetInterface(typeof(T).FullName!) is not null)
                    .Select(Activator.CreateInstance).OfType<T>().ToList());
            }
            catch (ReflectionTypeLoadException ex)
            {
                StringBuilder exMsg = new();
                foreach (var exceptions in ex.LoaderExceptions)
                {
                    exMsg.Append(
                        $"{ex.GetType()}: {exceptions?.Message}{Environment.NewLine}{exceptions?.StackTrace}{Environment.NewLine}");
                }

                GenericPluginLoader.InvokeLoaderMessage(new(exMsg.ToString(), "Error!", ErrorLevel.Error));
            }
            catch (MissingMethodException)
            {
                // ignore the error (this would cause the end of
                // the function to return an empty list).
            }
        }

        return instances;
    }

    public static void UnloadIfNoInstances<T>(this AssemblyLoadContext context, List<T> instances)
    {
        if (!instances.Any() && context.IsCollectible)
        {
            context.Unload();
        }
    }

    private static (byte[]? AsmBytes, byte[]? PdbBytes) OpenAssemblyFiles(string dllFile, string pdbFile)
    {
        if (File.Exists(dllFile))
        {
            var asmBytes = File.ReadAllBytes(dllFile);

            // We need to handle the case where the pdb does not exist and where the
            // symbols might actually be embedded inside the dll instead or simply does
            // not exist yet.
            var pdbBytes = Debugger.IsAttached && File.Exists(pdbFile)
                ? File.ReadAllBytes(pdbFile) : null;
            return (asmBytes, pdbBytes);
        }

        return (null, null);
    }
}
