using System;
using System.IO;
using Lumina;
using Lumina.Data;
using Lumina.Excel;
using Lumina.Excel.GeneratedSheets;
using Cyalume = Lumina.GameData;

namespace NetStone.GameData.Lumina;

/// <summary>
/// Game data provider that reads data directly from Lumina.
/// This is slow and just exists as an alternative to the flatbuffer-based solution.
/// </summary>
public class LuminaGameDataProvider : IGameDataProvider
{
    private readonly Cyalume lumina;

    public LuminaGameDataProvider(DirectoryInfo gamePath)
    {
        lumina = new Cyalume(gamePath.FullName, new LuminaOptions{PanicOnSheetChecksumMismatch = false});
    }

    public NamedGameData? GetItem(string name)
    {
        var item = FindRow<Item>(name);

        if (item == null)
            return null;

        var langs = CollectLanguages<Item>(item.RowId);

        return new NamedGameData
        {
            Info = new GameDataInfo
            {
                Key = item.RowId,
                Name = name,
            },

            Name = new LanguageStrings
            {
                En = langs.En.Name,
                De = langs.De.Name,
                Fr = langs.Fr.Name,
                Ja = langs.Ja.Name,
            },
        };
    }

    private (T En, T De, T Fr, T Ja) CollectLanguages<T>(uint key) where T : ExcelRow
    {
        var en = this.lumina.Excel.GetSheet<T>(Language.English);
        var de = this.lumina.Excel.GetSheet<T>(Language.English);
        var fr = this.lumina.Excel.GetSheet<T>(Language.English);
        var ja = this.lumina.Excel.GetSheet<T>(Language.English);

        return (en!.GetRow(key)!, de!.GetRow(key)!, fr!.GetRow(key)!, ja!.GetRow(key)!);
    }

    private T? FindRow<T>(string name) where T: ExcelRow
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

    private static T? FindRowInSheet<T>(ExcelSheet<T>? sheet, string name) where T: ExcelRow
    {
        if (sheet == null)
            return null;

        foreach (var excelRow in sheet)
        {
            if (excelRow is Item item)
            {
                if (item.Name.ToString().Equals(name, StringComparison.InvariantCultureIgnoreCase))
                    return excelRow;
            }
        }

        return null;
    }
}