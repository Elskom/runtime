// Copyright (c) 2018-2023, Els_kom org.
// https://github.com/Elskom/
// All rights reserved.
// license: MIT, see LICENSE for more details.

namespace Elskom.Generic.Libs;

/// <summary>
/// Json Setting file data.
/// </summary>
public class JsonSettings
{
    /// <summary>
    /// Gets or sets the icon to use.
    /// </summary>
    [JsonPropertyName(nameof(WindowIcon))]
    public int WindowIcon
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets or sets the Elsword install directory.
    /// </summary>
    [JsonPropertyName(nameof(ElsDir))]
    public string ElsDir
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets or sets whether to show the icon in tray, in taskbar, or both when Elsword is not running.
    /// </summary>
    [JsonPropertyName(nameof(IconWhileElsNotRunning))]
    public int IconWhileElsNotRunning
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets or sets whether to show the icon in tray, in taskbar, or both when Elsword is running.
    /// </summary>
    [JsonPropertyName(nameof(IconWhileElsRunning))]
    public int IconWhileElsRunning
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets or sets whether to save installed plugins to a zip file or not.
    /// </summary>
    [JsonPropertyName(nameof(SaveToZip))]
    public int SaveToZip
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets or sets whether to show test messages or not.
    /// </summary>
    [JsonPropertyName(nameof(ShowTestMessages))]
    public int ShowTestMessages
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets or sets whether to use notifications or not.
    /// </summary>
    [JsonPropertyName(nameof(UseNotifications))]
    public int UseNotifications
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Gets or sets the sources to use to install plugins from.
    /// </summary>
    [JsonPropertyName(nameof(Sources))]
    public string[] Sources
    {
        get => throw null!;
        set => throw null!;
    }

    /// <summary>
    /// Deserializes the input json data to the target type for the settings file.
    /// </summary>
    /// <param name="json">The json data to Deserialize.</param>
    /// <returns>The target type instance for the settings file.</returns>
    public static JsonSettings? Deserialize(string json)
        => throw null!;

    /// <summary>
    /// Deserializes the input json data to the target type for the settings file.
    /// </summary>
    /// <param name="json">The json data to Deserialize.</param>
    /// <param name="options">The options to deserialize with.</param>
    /// <returns>The target type instance for the settings file.</returns>
    public static JsonSettings? Deserialize(string json, JsonSerializerOptions? options)
        => throw null!;

    /// <summary>
    /// Serializes the input type instance to a json string.
    /// </summary>
    /// <param name="value">The object for which holds the data to the input type instance.</param>
    /// <returns>The json string to the input type instance's data.</returns>
    public static string Serialize(JsonSettings value)
        => throw null!;

    /// <summary>
    /// Serializes the input type instance to a json string.
    /// </summary>
    /// <param name="value">The object for which holds the data to the input type instance.</param>
    /// <param name="options">The options to serialize with.</param>
    /// <returns>The json string to the input type instance's data.</returns>
    public static string Serialize(JsonSettings value, JsonSerializerOptions? options)
        => throw null!;

    /// <summary>
    /// Returns a new instance of this type either with preset contents
    /// from the settings file or with default settings to create a settings file.
    /// </summary>
    /// <returns>A new instance of this type.</returns>
    public static JsonSettings? OpenFile()
        => throw null!;

    /// <summary>
    /// Returns a new instance of this type so this one can be discarded.
    /// </summary>
    /// <returns>A new instance of this type.</returns>
    public JsonSettings? ReopenFile()
        => throw null!;

    /// <summary>
    /// Saves the data in this instance to file.
    /// </summary>
    public void Save()
        => throw null!;
}
