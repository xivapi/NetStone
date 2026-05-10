using System.Diagnostics.CodeAnalysis;

namespace NetStone.GameData;

/// <summary>
/// Container for localized strings
/// </summary>
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public struct LanguageStrings
{
    /// <summary>
    /// English
    /// </summary>
    public string En { get; set; }

    /// <summary>
    /// German
    /// </summary>
    public string De { get; set; }

    /// <summary>
    /// Japanese
    /// </summary>
    public string Ja { get; set; }

    /// <summary>
    /// French
    /// </summary>
    public string Fr { get; set; }
}