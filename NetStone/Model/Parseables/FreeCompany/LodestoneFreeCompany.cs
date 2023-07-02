using System;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions;
using NetStone.Definitions.Model.FreeCompany;
using NetStone.Model.Parseables.FreeCompany.Members;
using NetStone.Search.FreeCompany;

namespace NetStone.Model.Parseables.FreeCompany;

/// <summary>
/// Provides information of a Free Company
/// </summary>
public class LodestoneFreeCompany : LodestoneParseable
{
    private readonly LodestoneClient client;

    private readonly FreeCompanyDefinition fcDefinition;
    private readonly FreeCompanyFocusDefinition focusDefinition;
    private readonly FreeCompanyReputationDefinition reputationDefinition;

    /// <summary>
    /// Constructs Free Company information parser
    /// </summary>
    /// <param name="client">Current client</param>
    /// <param name="rootNode">Root node of FC page</param>
    /// <param name="definitions">Parser definitions</param>
    /// <param name="id">Id of FC</param>
    public LodestoneFreeCompany(LodestoneClient client, HtmlNode rootNode, DefinitionsContainer definitions, string id)
        : base(rootNode)
    {
        this.client = client;
        this.Id = id;

        this.fcDefinition = definitions.FreeCompany;
        this.focusDefinition = definitions.FreeCompanyFocus;
        this.reputationDefinition = definitions.FreeCompanyReputation;
    }

    /// <summary>
    /// Name of this FC
    /// </summary>
    public string Name => Parse(this.fcDefinition.Name);

    /// <summary>
    /// Id of this FC
    /// </summary>
    public string Id { get; }

    /// <summary>
    /// Slogan
    /// </summary>
    public string Slogan => Parse(this.fcDefinition.Slogan);

    /// <summary>
    /// Tag
    /// </summary>
    public string Tag => Parse(this.fcDefinition.Tag);

    /// <summary>
    /// FC Icon/Crest
    /// </summary>
    public IconLayers CrestLayers => new(this.RootNode, this.fcDefinition.CrestLayers);

    /// <summary>
    /// Formation date
    /// </summary>
    public DateTime Formed => ParseTime(this.fcDefinition.Formed);

    /// <summary>
    /// Current GC
    /// </summary>
    public string GrandCompany => Parse(this.fcDefinition.GrandCompany).TrimEnd();

    /// <summary>
    /// Current Rank
    /// </summary>
    public int Rank => int.Parse(Parse(this.fcDefinition.Rank));

    /// <summary>
    /// Monthly ranking
    /// </summary>
    public int RankingMonthly => int.Parse(Parse(this.fcDefinition.Ranking.Monthly));

    /// <summary>
    /// Weekly ranking
    /// </summary>
    public int RankingWeekly => int.Parse(Parse(this.fcDefinition.Ranking.Weekly));

    /// <summary>
    /// Recruitment status
    /// </summary>
    public string Recruitment => Parse(this.fcDefinition.Recruitment);

    /// <summary>
    /// Number of active members
    /// </summary>
    public int ActiveMemberCount => int.Parse(Parse(this.fcDefinition.ActiveMemberCount));

    /// <summary>
    /// Activity status
    /// </summary>
    //todo: selector does not work
    public string ActiveState => Parse(this.fcDefinition.Activestate).Trim();


    /// <summary>
    /// Information about the estate
    /// </summary>
    public FreeCompanyEstate? Estate =>
        new FreeCompanyEstate(this.RootNode, this.fcDefinition.EstateDefinition).GetOptional();

    /// <summary>
    /// Information about focused gameplay
    /// </summary>
    public FreeCompanyFocus? Focus => new FreeCompanyFocus(this.RootNode, this.focusDefinition).GetOptional();

    /// <summary>
    /// Reputation with the Grand Companies
    /// </summary>
    public FreeCompanyReputation Reputation => new(this.RootNode, this.reputationDefinition);

    /// <summary>
    /// Home World 
    /// </summary>
    public string World => Parse(this.fcDefinition.Server);

    /// <summary>
    /// Fetches all members of this FC
    /// </summary>
    /// <returns>Members</returns>
    public async Task<FreeCompanyMembers?> GetMembers() => await this.client.GetFreeCompanyMembers(this.Id);
}