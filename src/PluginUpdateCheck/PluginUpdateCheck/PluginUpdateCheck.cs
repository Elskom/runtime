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
    private readonly IServiceProvider serviceProvider;

    internal PluginUpdateCheck(IServiceProvider serviceprovider)
        => this.serviceProvider = serviceprovider;

    /// <summary>
    /// Event that fires when a new message should show up.
    /// </summary>
    public static event EventHandler<MessageEventArgs> MessageEvent;

    /// <summary>
    /// Gets the plugin urls used in all instances.
    /// </summary>
    public static List<string> PluginUrls { get; private set; }

    /// <summary>
    /// Gets a value indicating whether there are any pending updates and displays a message if there is.
    /// </summary>
    public bool ShowMessage
    {
        get
        {
            if (!string.Equals(this.InstalledVersion, this.CurrentVersion, StringComparison.Ordinal) && !string.IsNullOrEmpty(this.InstalledVersion))
            {
                MessageEvent?.Invoke(null, new(string.Format(CultureInfo.InvariantCulture, Resources.PluginUpdateCheck_ShowMessage_Update_for_plugin_is_availible!, this.CurrentVersion, this.PluginName), Resources.PluginUpdateCheck_ShowMessage_New_plugin_update, ErrorLevel.Info));
                return true;
            }

            return false;
        }
    }

    /// <summary>
    /// Gets the plugin name this instance is pointing to.
    /// </summary>
    [SetNullOnDispose]
    public string PluginName { get; private set; }

    /// <summary>
    /// Gets the current version of the plugin that is pointed to by this instance.
    /// </summary>
    [SetNullOnDispose]
    public string CurrentVersion { get; private set; }

    /// <summary>
    /// Gets the installed version of the plugin that is pointed to by this instance.
    /// </summary>
    [SetNullOnDispose]
    public string InstalledVersion { get; private set; }

    /// <summary>
    /// Gets the url to download the files to the plugin from.
    /// </summary>
    [SetNullOnDispose]
    public Uri DownloadUrl { get; private set; }

    /// <summary>
    /// Gets the files to the plugin to download.
    /// </summary>
    [SetNullOnDispose]
    public List<string> DownloadFiles { get; private set; }

    /// <summary>
    /// Checks for plugin updates from the provided plugin source urls.
    /// </summary>
    /// <param name="pluginURLs">The repository urls to the plugins.</param>
    /// <param name="pluginTypes">A list of types to the plugins to check for updates to.</param>
    /// <param name="serviceprovider">The <see cref="IServiceProvider"/> to use.</param>
    /// <returns>A list of <see cref="PluginUpdateCheck"/> instances representing the plugins that needs updating or are to be installed.</returns>
    // catches the plugin urls and uses that cache to detect added urls, and only appends those to the list.
    public static List<PluginUpdateCheck> CheckForUpdates(string[] pluginURLs, List<Type> pluginTypes, IServiceProvider serviceprovider)
    {
        _ = pluginURLs ?? throw new ArgumentNullException(nameof(pluginURLs));
        _ = pluginTypes ?? throw new ArgumentNullException(nameof(pluginTypes));
        List<PluginUpdateCheck> pluginUpdateChecks = new();

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

        PluginUrls ??= new();
        foreach (var pluginURL in pluginURLs1)
        {
            if (!PluginUrls.Contains(pluginURL))
            {
                try
                {
                    var doc = XDocument.Parse(((HttpClient)serviceprovider.GetService(typeof(HttpClient)))?.GetStringAsync(pluginURL).GetAwaiter().GetResult());
                    var elements = doc.Root.Elements("Plugin");
                    foreach (var element in elements)
                    {
                        var currentVersion = element.Attribute("Version").Value;
                        var pluginName = element.Attribute("Name").Value;
                        var found = false;
                        foreach (var pluginType in pluginTypes.Where(
                            pluginType => pluginName.Equals(pluginType.Namespace, StringComparison.Ordinal)))
                        {
                            found = true;
                            var installedVersion = pluginType.Assembly.GetName().Version.ToString();
                            PluginUpdateCheck pluginUpdateCheck = new(serviceprovider)
                            {
                                CurrentVersion = currentVersion,
                                InstalledVersion = installedVersion,
                                PluginName = pluginName,
                                DownloadUrl = new($"{element.Attribute("DownloadUrl").Value}/{currentVersion}/"),
                                DownloadFiles = element.Descendants("DownloadFile").Select(y => y.Attribute("Name")?.Value).ToList(),
                            };
                            pluginUpdateChecks.Add(pluginUpdateCheck);
                        }

                        if (!found)
                        {
                            PluginUpdateCheck pluginUpdateCheck = new(serviceprovider)
                            {
                                CurrentVersion = currentVersion,
                                InstalledVersion = string.Empty,
                                PluginName = pluginName,
                                DownloadUrl = new($"{element.Attribute("DownloadUrl").Value}/{currentVersion}/"),
                                DownloadFiles = element.Descendants("DownloadFile").Select(y => y.Attribute("Name")?.Value).ToList(),
                            };
                            pluginUpdateChecks.Add(pluginUpdateCheck);
                        }
                    }
                }
                catch (HttpRequestException ex)
                {
                    MessageEvent?.Invoke(null, new(string.Format(CultureInfo.InvariantCulture, Resources.PluginUpdateCheck_CheckForUpdates_Failed_to_download_the_plugins_sources_list_Reason, Environment.NewLine, ex.Message), Resources.PluginUpdateCheck_CheckForUpdates_Error, ErrorLevel.Error));
                }
            }

            // append the string to the cache.
            PluginUrls.Add(pluginURL);
        }

        return pluginUpdateChecks;
    }

    /// <summary>
    /// Installs the files to the plugin pointed to by this instance.
    /// </summary>
    /// <param name="saveToZip">A bool indicating if the file should be installed to a zip file instead of a folder.</param>
    /// <returns>A bool indicating if anything changed.</returns>
    public bool Install(bool saveToZip)
    {
        if (this.isDisposed)
        {
            throw new ObjectDisposedException(nameof(PluginUpdateCheck));
        }

        foreach (var downloadFile in this.DownloadFiles)
        {
            try
            {
                var path = $"{Environment.CurrentDirectory}{Path.DirectorySeparatorChar}plugins{Path.DirectorySeparatorChar}{downloadFile}";
                using (var fs = File.Create(path))
                using (var response = ((HttpClient)this.serviceProvider.GetService(typeof(HttpClient)))?.GetStreamAsync($"{this.DownloadUrl}{downloadFile}").GetAwaiter().GetResult())
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
                MessageEvent?.Invoke(null, new(string.Format(CultureInfo.InvariantCulture, Resources.PluginUpdateCheck_Install_Failed_to_install_the_selected_plugin_Reason!, Environment.NewLine, ex.Message), Resources.PluginUpdateCheck_CheckForUpdates_Error, ErrorLevel.Error));
            }
        }

        return false;
    }

    /// <summary>
    /// Uninstalls the files to the plugin pointed to by this instance.
    /// </summary>
    /// <param name="saveToZip">A bool indicating if the file should be uninstalled from a zip file instead of a folder. If the zip file after the operation becomes empty it is also deleted automatically.</param>
    /// <returns>A bool indicating if anything changed.</returns>
    public bool Uninstall(bool saveToZip)
    {
        if (this.isDisposed)
        {
            throw new ObjectDisposedException(nameof(PluginUpdateCheck));
        }

        try
        {
            foreach (var downloadFile in this.DownloadFiles)
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
            MessageEvent?.Invoke(null, new(string.Format(CultureInfo.InvariantCulture, Resources.PluginUpdateCheck_Uninstall_Failed_to_uninstall_the_selected_plugin_Reason!, Environment.NewLine, ex.Message), Resources.PluginUpdateCheck_CheckForUpdates_Error, ErrorLevel.Error));
        }

        return false;
    }

    [CallOnDispose]
    private void ClearDownloadFiles()
        => this.DownloadFiles.Clear();
}
