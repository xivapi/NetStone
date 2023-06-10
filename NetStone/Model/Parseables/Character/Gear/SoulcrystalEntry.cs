using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;
using NetStone.Search.FreeCompany;
using System;

namespace NetStone.Model.Parseables.Character.Gear;

/// <summary>
/// Represents data about a character's soul crystal
/// </summary>
public class SoulcrystalEntry : LodestoneParseable, IOptionalParseable<SoulcrystalEntry>
{
    private readonly SoulcrystalEntryDefinition definition;

    ///<inheritdoc />
    public SoulcrystalEntry(HtmlNode rootNode, SoulcrystalEntryDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    //public Uri ItemDatabaseLink => ParseHref(this.definition.Name);

    /// <summary>
    /// Name of the item
    /// </summary>
    public string ItemName => Parse(this.definition.Name);

    /// <inheritdoc />
    public bool Exists => HasNode(this.definition.Name);

    ///<inheritdoc />
    public override string ToString() => this.ItemName;
}