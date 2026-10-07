using System;
using System.IO;
using Lumina;
using Lumina.Data;
using Lumina.Excel;
using Lumina.Excel.Sheets;
using Cyalume = Lumina.GameData;

namespace NetStone.GameData.Lumina;

/// <summary>
/// Game data provider that reads data directly from Lumina.
/// This is slow and just exists as an alternative to the flatbuffer-based solution.
/// </summary>
public class LuminaGameDataProvider : IGameDataProvider
{
    private readonly Cyalume lumina;

    /// <summary>
    /// Create an instance of LuminaGameDataProvider 
    /// </summary>
    /// <param name="gamePath">Path to game installation</param>
    public LuminaGameDataProvider(DirectoryInfo gamePath)
    {
        this.lumina = new Cyalume(gamePath.FullName, new LuminaOptions{PanicOnSheetChecksumMismatch = false});
    }

    /// <summary>
    /// Gets infromation of an item by it's name
    /// </summary>
    /// <param name="name">Name of the item to search</param>
    /// <returns><see cref="NamedGameData"/> of the item with supplied name</returns>
    public NamedGameData? GetItem(string name)
    {
        var item = FindRow<Item>(name);

        if (!item.HasValue)
            return null;

        var langs = CollectLanguages<Item>(item.Value.RowId);

        return new NamedGameData
        {
            Info = new GameDataInfo
            {
                Key = item.Value.RowId,
                Name = name,
            },

            Name = new LanguageStrings
            {
                En = langs.En.Name.ToString(),
                De = langs.De.Name.ToString(),
                Fr = langs.Fr.Name.ToString(),
                Ja = langs.Ja.Name.ToString(),
            },
        };
    }

    private (T En, T De, T Fr, T Ja) CollectLanguages<T>(uint key) where T : struct, IExcelRow<T>
    {
        var en = this.lumina.Excel.GetSheet<T>(Language.English);
        var de = this.lumina.Excel.GetSheet<T>(Language.English);
        var fr = this.lumina.Excel.GetSheet<T>(Language.English);
        var ja = this.lumina.Excel.GetSheet<T>(Language.English);

        return (en!.GetRow(key)!, de!.GetRow(key)!, fr!.GetRow(key)!, ja!.GetRow(key)!);
    }

    private T? FindRow<T>(string name) where T : struct, IExcelRow<T>
    {
        var en = this.lumina.Excel.GetSheet<T>(Language.English);
        var de = this.lumina.Excel.GetSheet<T>(Language.English);
        var fr = this.lumina.Excel.GetSheet<T>(Language.English);
        var ja = this.lumina.Excel.GetSheet<T>(Language.English);

        var res = FindRowInSheet(en, name);
        if (res != null)
            return res;

        res = FindRowInSheet(de, name);
        if (res != null)
            return res;

        res = FindRowInSheet(fr, name);
        if (res != null)
            return res;

        res = FindRowInSheet(ja, name);
        return res;
    }

    private static T? FindRowInSheet<T>(ExcelSheet<T>? sheet, string name) where T : struct, IExcelRow<T>
    {
        if (sheet == null)
            return null;

        foreach (var excelRow in sheet)
        {
            if (excelRow is not Item item) continue;
            if (item.Name.ToString().Equals(name, StringComparison.InvariantCultureIgnoreCase))
                return excelRow;
        }

        return null;
    }
}