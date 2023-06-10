namespace NetStone.GameData;

/// <summary>
/// Game data with different names depending on gender
/// </summary>
public struct GenderedGameData
{
    /// <summary>
    /// Basic game data
    /// </summary>
    public GameDataInfo Info { get; set; }

    /// <summary>
    /// Masculine name
    /// </summary>
    public LanguageStrings NameMasc { get; set; }

    /// <summary>
    /// Feminine name
    /// </summary>
    public LanguageStrings NameFem { get; set; }
}