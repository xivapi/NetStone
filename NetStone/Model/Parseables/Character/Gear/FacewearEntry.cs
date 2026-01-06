using System;
using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;

namespace NetStone.Model.Parseables.Character.Gear;

/// <summary>
/// Represents data about a character's facewear
/// </summary>
public class FacewearEntry : LodestoneParseable, IOptionalParseable<FacewearEntry>
{
    private readonly FacewearEntryDefinition definition;

    ///<inheritdoc />
    public FacewearEntry(HtmlNode rootNode, FacewearEntryDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    /// <summary>
    /// Name of the facewear
    /// </summary>
    public string ItemName => Parse(this.definition.Name);
    
    /// <summary>
    /// Name of the item this facewear is unlocked by
    /// </summary>
    public string? UnlockedBy => ParseTooltip(this.definition.UnlockedBy);

    /// <summary>
    /// Link to this facewear's Eorzea DB page.
    /// </summary>
    public Uri? DbLink => ParseHref(this.definition.DbLink);
    
    ///<inheritdoc />
    public bool Exists => HasNode(this.definition.Name);
    
    ///<inheritdoc />
    public override string ToString() => this.ItemName;
}