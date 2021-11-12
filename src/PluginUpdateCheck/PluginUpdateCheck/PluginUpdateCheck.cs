// Copyright (c) 2018-2021, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// A generic plugin update checker.
/// </summary>
[GenerateDispose(false)]
public sealed partial class PluginUpdateCheck
{
    private readonly ServiceProvider serviceProvider;

    internal PluginUpdateCheck(ServiceProvider serviceprovider)
    {
        this.serviceProvider = serviceprovider;
        this.PluginUpdateDatas = new List<PluginUpdateData>();
    }

    /// <summary>
    /// Event that fires when a new message should show up.
    /// </summary>
    public static event EventHandler<MessageEventArgs> MessageEvent;

    /// <summary>
    /// Gets the plugin urls used in all instances.
    /// </summary>
    [SetNullOnDispose]
    public List<string> PluginUrls { get; private set; }

    /// <summary>
    /// Gets a value indicating whether there are any pending updates and displays a message if there is.
    /// </summary>
    public bool ShowMessage
    {
        get
        {
            if (this.isDisposed)
            {
                throw new ObjectDisposedException(nameof(PluginUpdateCheck));
            }

            var result = false;
            if (!this.PluginUpdateDatas.Any())
            {
                return false;
            }

            foreach (var pluginUpdateData in this.PluginUpdateDatas.Where(
                         pluginUpdateData =>
                             !string.Equals(
                                 pluginUpdateData.InstalledVersion,
                                 pluginUpdateData.CurrentVersion,
                                 StringComparison.Ordinal)
                             && !string.IsNullOrEmpty(pluginUpdateData.InstalledVersion)))
            {
                MessageEvent?.Invoke(
                    null,
                    new(
                        string.Format(
                            CultureInfo.InvariantCulture,
                            Resources.PluginUpdateCheck_ShowMessage_Update_for_plugin_is_availible!,
                            pluginUpdateData.CurrentVersion,
                            pluginUpdateData.PluginName),
                        Resources.PluginUpdateCheck_ShowMessage_New_plugin_update!,
                        ErrorLevel.Info));
                result = true;
            }

            return result;
        }
    }

    /// <summary>
    /// Gets a list of <see cref="PluginUpdateData"/> instances representing the plugins that needs updating or are to be installed.
    /// </summary>
    [SetNullOnDispose]
    public List<PluginUpdateData> PluginUpdateDatas { get; private set; }

    /// <summary>
    /// Checks for plugin updates from the provided plugin source urls.
    /// </summary>
    /// <param name="pluginURLs">The repository urls to the plugins.</param>
    /// <param name="pluginTypes">A list of types to the plugins to check for updates to.</param>
    /// <exception cref="ArgumentNullException">Thrown if <paramref name="pluginURLs"/> or <paramref name="pluginTypes"/> are <see langword="null"/>.</exception>
    /// <returns>A value indicating if the operation was successful or not.</returns>
    // catches the plugin urls and uses that cache to detect added urls, and only appends those to the list.
    public bool CheckForUpdates(string[] pluginURLs, List<Type> pluginTypes)
    {
        _ = pluginURLs ?? throw new ArgumentNullException(nameof(pluginURLs));
        _ = pluginTypes ?? throw new ArgumentNullException(nameof(pluginTypes));

        // fixup the github urls (if needed).
        var pluginURLs1 = new string[pluginURLs.Length];
        for (var i = 0; i < pluginURLs.Length; i++)
        {
            var arg0 = pluginURLs[i].Replace(
                "https://github.com/",
                "https://raw.githubusercontent.com/",
                StringComparison.Ordinal);
            var arg1 = pluginURLs[i].EndsWith("/", StringComparison.Ordinal)
                ? "main/plugins.xml"
                : "/main/plugins.xml";
            pluginURLs1[i] = $"{arg0}{arg1}";
        }

        this.PluginUrls ??= new();
        foreach (var pluginURL in pluginURLs1)
        {
            if (!this.PluginUrls.Contains(pluginURL))
            {
                try
                {
                    var doc = XDocument.Parse(this.serviceProvider.GetRequiredService<HttpClient>()?.GetStringAsync(pluginURL).GetAwaiter().GetResult()!);
                    var elements = doc.Root!.Elements("Plugin");
                    foreach (var element in elements)
                    {
                        var currentVersion = element.Attribute("Version")!.Value;
                        var pluginName = element.Attribute("Name")!.Value;
                        var found = false;
                        foreach (var pluginType in pluginTypes.Where(
                            pluginType => pluginName.Equals(pluginType.Namespace, StringComparison.Ordinal)))
                        {
                            found = true;
                            var installedVersion = pluginType.Assembly.GetName().Version!.ToString();
                            PluginUpdateData pluginUpdateData = new()
                            {
                                CurrentVersion = currentVersion,
                                InstalledVersion = installedVersion,
                                PluginName = pluginName,
                                DownloadUrl = new($"{element.Attribute("DownloadUrl")!.Value}/{currentVersion}/"),
                                DownloadFiles = element.Descendants("DownloadFile").Select(y => y.Attribute("Name")?.Value).ToList(),
                            };
                            this.PluginUpdateDatas.Add(pluginUpdateData);
                        }

                        if (!found)
                        {
                            PluginUpdateData pluginUpdateData = new()
                            {
                                CurrentVersion = currentVersion,
                                InstalledVersion = string.Empty,
                                PluginName = pluginName,
                                DownloadUrl = new($"{element.Attribute("DownloadUrl")!.Value}/{currentVersion}/"),
                                DownloadFiles = element.Descendants("DownloadFile").Select(y => y.Attribute("Name")?.Value).ToList(),
                            };
                            this.PluginUpdateDatas.Add(pluginUpdateData);
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageEvent?.Invoke(null, new(string.Format(CultureInfo.InvariantCulture, Resources.PluginUpdateCheck_CheckForUpdates_Failed_to_download_the_plugins_sources_list_Reason!, Environment.NewLine, ex.Message), Resources.PluginUpdateCheck_CheckForUpdates_Error!, ErrorLevel.Error));
                    return false;
                }

                // append the string to the cache.
                this.PluginUrls.Add(pluginURL);
            }
        }

        return true;
    }

    /// <summary>
    /// Installs the files to the plugin pointed to by the passed in plugin update data.
    /// </summary>
    /// <param name="pluginUpdateData">The plugin update data for the plugin to install.</param>
    /// <param name="saveToZip">A bool indicating if the file should be installed to a zip file instead of a folder.</param>
    /// <returns>A bool indicating if anything changed.</returns>
    public bool Install(PluginUpdateData pluginUpdateData, bool saveToZip)
    {
        if (this.isDisposed)
        {
            throw new ObjectDisposedException(nameof(PluginUpdateCheck));
        }

        foreach (var downloadFile in pluginUpdateData.DownloadFiles)
        {
            try
            {
                var path = $"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}plugins{Path.DirectorySeparatorChar}{downloadFile}";
                using (var fs = File.Create(path))
                using (var response = this.serviceProvider.GetRequiredService<HttpClient>()?.GetStreamAsync($"{pluginUpdateData.DownloadUrl}{downloadFile}").GetAwaiter().GetResult())
                {
                    response?.CopyTo(fs);
                }

                if (saveToZip)
                {
                    var zippath = $"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}plugins.zip";
                    using var zipFile = ZipFile.Open(zippath, ZipArchiveMode.Update);
                    foreach (var entry in zipFile.Entries.Where(
                        entry => entry.FullName.Equals(downloadFile, StringComparison.Ordinal)))
                    {
                        entry.Delete();
                    }

                    _ = zipFile.CreateEntryFromFile(path, downloadFile!);
                    File.Delete(path);
                }

                return true;
            }
            catch (HttpRequestException ex)
            {
                MessageEvent?.Invoke(null, new(string.Format(CultureInfo.InvariantCulture, Resources.PluginUpdateCheck_Install_Failed_to_install_the_selected_plugin_Reason!, Environment.NewLine, ex.Message), Resources.PluginUpdateCheck_CheckForUpdates_Error!, ErrorLevel.Error));
            }
        }

        return false;
    }

    /// <summary>
    /// Uninstalls the files to the plugin pointed to by the passed in plugin update data.
    /// </summary>
    /// <param name="pluginUpdateData">The plugin update data for the plugin to uninstall.</param>
    /// <param name="saveToZip">A bool indicating if the file should be uninstalled from a zip file instead of a folder. If the zip file after the operation becomes empty it is also deleted automatically.</param>
    /// <returns>A bool indicating if anything changed.</returns>
    public bool Uninstall(PluginUpdateData pluginUpdateData, bool saveToZip)
    {
        if (this.isDisposed)
        {
            throw new ObjectDisposedException(nameof(PluginUpdateCheck));
        }

        try
        {
            foreach (var downloadFile in pluginUpdateData.DownloadFiles)
            {
                var path = $"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}plugins{Path.DirectorySeparatorChar}{downloadFile}";
                if (File.Exists(path))
                {
                    File.Delete(path);
                }

                if (saveToZip)
                {
                    var zippath = $"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}plugins.zip";
                    using var zipFile = ZipFile.Open(zippath, ZipArchiveMode.Update);
                    foreach (var entry in zipFile.Entries.Where(
                        entry => entry.FullName.Equals(downloadFile, StringComparison.Ordinal)))
                    {
                        entry.Delete();
                    }

                    var entries = zipFile.Entries.Count;
                    if (entries == 0)
                    {
                        File.Delete(zippath);
                    }
                }
            }

            return true;
        }
        catch (Exception ex)
        {
            MessageEvent?.Invoke(null, new(string.Format(CultureInfo.InvariantCulture, Resources.PluginUpdateCheck_Uninstall_Failed_to_uninstall_the_selected_plugin_Reason!, Environment.NewLine, ex.Message), Resources.PluginUpdateCheck_CheckForUpdates_Error!, ErrorLevel.Error));
        }

        return false;
    }

    [CallOnDispose]
    private void ClearDownloadFiles()
    {
        foreach (var pluginUpdateData in this.PluginUpdateDatas)
        {
            pluginUpdateData.DownloadFiles.Clear();
        }

        this.PluginUpdateDatas.Clear();
        this.PluginUrls.Clear();
    }
}
