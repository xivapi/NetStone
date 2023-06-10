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
    /// <summary>
    /// Character representing the high quality symbol
    /// </summary>
    public const char HqChar = '\uE03C';

    private readonly LodestoneClient client;
    private readonly GearEntryDefinition definition;

    private NamedGameData? cachedGameData;

    /// <summary>
    /// Construct a new gear entry
    /// </summary>
    /// <param name="client">Lodestone client</param>
    /// <param name="rootNode">Entry node</param>
    /// <param name="definition">Parser definition</param>
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
    /// Indicates if this item is high quality
    /// </summary>
    public bool IsHq => this.ItemName.EndsWith(HqChar);

    /// <summary>
    /// Returns the name of this item without high quality icon
    /// </summary>
    public string StrippedItemName => this.IsHq ? this.ItemName.Remove(this.ItemName.Length - 1) : this.ItemName;

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
        ParseDirectInnerText(this.definition.Materia5),
    };

    /// <summary>
    /// Name of this item's crafter.
    /// </summary>
    public string CreatorName => Parse(this.definition.CreatorName);

    /// <summary>
    /// Indicating whether the item slot has an item equipped or not.
    /// </summary>
    public bool Exists => HasNode(this.definition.Name);

    /// <summary>
    /// Get game data representing this item
    /// </summary>
    /// <returns>Item data</returns>
    public NamedGameData? GetGameData()
    {
        this.cachedGameData ??= !this.Exists ? null : this.client.Data?.GetItem(this.ItemName);
        return this.cachedGameData;
    }

    /// <summary>
    /// String representation of the gear slot.
    /// </summary>
    /// <returns>The name of the item.</returns>
    public override string ToString() => this.ItemName;
}