// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

internal static class RuntimeExtensions
{
    public static List<T> CreateInstancesFromInterface<T>(this AssemblyLoadContext context, string dllFile, string pdbFile)
    {
        List<T> instances = [];
        try
        {
            var (asmBytes, pdbBytes) = OpenAssemblyFiles(dllFile, pdbFile);
            using MemoryStream ms1 = new(asmBytes!);
            MemoryStream? ms2 = Debugger.IsAttached && pdbBytes is not null ? new(pdbBytes) : null;
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
        List<T> instances = [];
        if (assembly is not null)
        {
            try
            {
                var types = assembly.GetTypes();
                if (typeof(T).FullName is null)
                {
                    var args = new MessageEventArgs("Type name cannot be null.", "Error!", ErrorLevel.Error);
                    GenericPluginLoader.InvokeLoaderMessage(ref args);
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
                    _ = exMsg.AppendLine(
                        CultureInfo.InvariantCulture,
                        $"{ex.GetType()}: {exceptions?.Message}");
                    _ = exMsg.AppendLine(exceptions?.StackTrace);
                }

                var args = new MessageEventArgs(exMsg.ToString(), "Error!", ErrorLevel.Error);
                GenericPluginLoader.InvokeLoaderMessage(ref args);
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
        if (instances.Count == 0 && context.IsCollectible)
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
