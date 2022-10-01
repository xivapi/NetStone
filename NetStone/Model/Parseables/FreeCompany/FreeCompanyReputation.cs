using System.Collections.Generic;
using HtmlAgilityPack;
using NetStone.Definitions.Model.FreeCompany;
using NetStone.StaticData;

namespace NetStone.Model.Parseables.FreeCompany;

public class FreeCompanyReputation : LodestoneParseable
{
    private readonly FreeCompanyReputationDefinition definition;

    public FreeCompanyReputation(HtmlNode rootNode, FreeCompanyReputationDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    public FreeCompanyReputationEntry Maelstrom =>
        new FreeCompanyReputationEntry(this.RootNode, this.definition.Maelstrom);
        
    public FreeCompanyReputationEntry Adders =>
        new FreeCompanyReputationEntry(this.RootNode, this.definition.Adders);
        
    public FreeCompanyReputationEntry Flames =>
        new FreeCompanyReputationEntry(this.RootNode, this.definition.Flames);

    public Dictionary<GrandCompany, FreeCompanyReputationEntry> GrandCompanyDict =>
        new Dictionary<GrandCompany, FreeCompanyReputationEntry>
        {
            {GrandCompany.Maelstrom, Maelstrom},
            {GrandCompany.OrderOfTheTwinAdder, Adders},
            {GrandCompany.ImmortalFlames, Flames},
        };
}