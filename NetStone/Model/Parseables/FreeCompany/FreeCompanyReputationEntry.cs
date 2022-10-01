using HtmlAgilityPack;
using NetStone.Definitions.Model.FreeCompany;

namespace NetStone.Model.Parseables.FreeCompany;

public class FreeCompanyReputationEntry : LodestoneParseable
{
    private readonly FreeCompanyReputationEntryDefinition definition;

    public FreeCompanyReputationEntry(HtmlNode rootNode, FreeCompanyReputationEntryDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    public string Name => Parse(this.definition.Name);

    public int Progress => int.Parse(Parse(this.definition.Progress));

    public string Rank => Parse(this.definition.Rank);
}