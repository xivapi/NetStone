using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;

namespace NetStone.Model.Parseables.Character.Gear;

public class SoulcrystalEntry : LodestoneParseable, IOptionalParseable<SoulcrystalEntry>
{
    private readonly SoulcrystalEntryDefinition definition;

    public SoulcrystalEntry(HtmlNode rootNode, SoulcrystalEntryDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    //public Uri ItemDatabaseLink => ParseHref(this.definition.Name);

    public string ItemName => Parse(this.definition.Name);

    public bool Exists => HasNode(this.definition.Name);

    public override string ToString() => ItemName;
}