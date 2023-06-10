namespace NetStone.GameData;

/// <summary>
/// Game data with localized name
/// </summary>
public struct NamedGameData
{
    /// <summary>
    /// Base data
    /// </summary>
    public GameDataInfo Info { get; set; }

    /// <summary>
    /// Localized name
    /// </summary>
    public LanguageStrings Name { get; set; }
}