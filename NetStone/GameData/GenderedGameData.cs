namespace NetStone.GameData;

public struct GenderedGameData
{
    public GameDataInfo Info { get; set; }

    public LanguageStrings NameMasc { get; set; }
    public LanguageStrings NameFem { get; set; }
}