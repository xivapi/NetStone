using System;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions;
using NetStone.Definitions.Model.FreeCompany;
using NetStone.Model.Parseables.FreeCompany.Members;

namespace NetStone.Model.Parseables.FreeCompany;

public class LodestoneFreeCompany : LodestoneParseable
{
    private readonly LodestoneClient client;

    private readonly FreeCompanyDefinition fcDefinition;
    private readonly FreeCompanyFocusDefinition focusDefinition;
    private readonly FreeCompanyReputationDefinition reputationDefinition;

    public LodestoneFreeCompany(LodestoneClient client, HtmlNode rootNode, DefinitionsContainer definitions, string id) : base(rootNode)
    {
        this.client = client;
        this.Id = id;

        this.fcDefinition = definitions.FreeCompany;
        this.focusDefinition = definitions.FreeCompanyFocus;
        this.reputationDefinition = definitions.FreeCompanyReputation;
    }

    public string Name => Parse(this.fcDefinition.Name);

    public string Id { get; }

    public string Slogan => Parse(this.fcDefinition.Slogan);

    public string Tag => Parse(this.fcDefinition.Tag);

    public IconLayers CrestLayers => new IconLayers(this.RootNode, this.fcDefinition.CrestLayers);

    public DateTime Formed => ParseTime(this.fcDefinition.Formed);

    public string GrandCompany => Parse(this.fcDefinition.GrandCompany);

    public int Rank => int.Parse(Parse(this.fcDefinition.Rank));

    public int RankingMonthly => int.Parse(Parse(this.fcDefinition.Ranking.Monthly));
        
    public int RankingWeekly => int.Parse(Parse(this.fcDefinition.Ranking.Weekly));

    public string Recruitment => Parse(this.fcDefinition.Recruitment);

    public int ActiveMemberCount => int.Parse(Parse(this.fcDefinition.ActiveMemberCount));

    public string ActiveState => Parse(this.fcDefinition.Activestate);

    public FreeCompanyEstate Estate => new FreeCompanyEstate(this.RootNode, this.fcDefinition.EstateDefinition).GetOptional();

    public FreeCompanyFocus Focus => new FreeCompanyFocus(this.RootNode, this.focusDefinition).GetOptional();

    public FreeCompanyReputation Reputation => new FreeCompanyReputation(this.RootNode, this.reputationDefinition);

    public string World => Parse(this.fcDefinition.Server);

    public async Task<FreeCompanyMembers?> GetMembers() => await this.client.GetFreeCompanyMembers(this.Id);
}