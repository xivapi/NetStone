using System;
using HtmlAgilityPack;
using NetStone.Definitions.Model.FreeCompany;

namespace NetStone.Model.Parseables.FreeCompany.Members;

public class FreeCompanyMembersEntry : LodestoneParseable
{
    private readonly FreeCompanyMembersEntryDefinition definition;

    public FreeCompanyMembersEntry(LodestoneClient client, HtmlNode rootNode, FreeCompanyMembersEntryDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    public string Name => Parse(this.definition.Name);

    public string Id => Parse(this.definition.Id);

    public string Rank => Parse(this.definition.Rank);

    public Uri RankIcon => ParseImageSource(this.definition.RankIcon);

    public string Server => ParseRegex(this.definition.Server)["World"].Value;
        
    public string Datacenter => ParseRegex(this.definition.Server)["DC"].Value;

    public Uri Avatar => ParseImageSource(this.definition.Avatar);
}