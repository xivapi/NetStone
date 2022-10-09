using System;
using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;
using NetStone.GameData;

namespace NetStone.Model.Parseables.Character.Gear;

/// <summary>
/// Container class holding information about a gear slot.
/// </summary>
public class GearEntry : LodestoneParseable, IOptionalParseable<GearEntry>
{
    private readonly LodestoneClient client;
    private readonly GearEntryDefinition definition;

    private NamedGameData? cachedGameData;

    public GearEntry(LodestoneClient client, HtmlNode rootNode, GearEntryDefinition definition) : base(rootNode)
    {
        this.client = client;
        this.definition = definition;
    }

    /// <summary>
    /// Link to this piece's Eorzea DB page.
    /// </summary>
    public Uri ItemDatabaseLink => ParseHref(this.definition.DbLink);

    /// <summary>
    /// Name of this item.
    /// </summary>
    public string ItemName => Parse(this.definition.Name);

    /// <summary>
    /// Link to the glamoured item's Eorzea DB page.
    /// </summary>
    public Uri GlamourDatabaseLink => ParseHref(this.definition.MirageDbLink);

    /// <summary>
    /// Name of the glamoured item.
    /// </summary>
    public string GlamourName => Parse(this.definition.MirageName);

    /// <summary>
    /// Name of the dye applied to this item.
    /// </summary>
    //TODO: parse
    public string Stain => Parse(this.definition.Stain);

    /// <summary>
    /// Materia applied to this item.
    /// </summary>
    public string[] Materia => new[]
    {
        ParseDirectInnerText(this.definition.Materia1),
        ParseDirectInnerText(this.definition.Materia2),
        ParseDirectInnerText(this.definition.Materia3),
        ParseDirectInnerText(this.definition.Materia4),
        ParseDirectInnerText(this.definition.Materia5)
    };

    /// <summary>
    /// Name of this item's crafter.
    /// </summary>
    public string CreatorName => Parse(this.definition.CreatorName);

    /// <summary>
    /// Indicating whether the item slot has an item equipped or not.
    /// </summary>
    public bool Exists => HasNode(this.definition.Name);

    public NamedGameData? GetGameData()
    {
        cachedGameData ??= !Exists ? null : client.Data?.GetItem(ItemName);
        return cachedGameData;
    }

    /// <summary>
    /// String representation of the gear slot.
    /// </summary>
    /// <returns>The name of the item.</returns>
    public override string ToString() => ItemName;
}