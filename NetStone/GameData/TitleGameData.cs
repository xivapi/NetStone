namespace NetStone.GameData;

/// <summary>
/// Game data for titles
/// </summary>
public struct TitleGameData
{
    /// <summary>
    /// Localized title
    /// </summary>
    public NamedGameData Names { get; set; }

    /// <summary>
    /// Indicates if before name
    /// </summary>
    public bool Prefix { get; set; }
}