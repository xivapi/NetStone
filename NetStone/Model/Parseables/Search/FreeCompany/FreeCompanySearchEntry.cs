using System;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model.FreeCompany;
using NetStone.Model.Parseables.FreeCompany;
using NetStone.Search.FreeCompany;

namespace NetStone.Model.Parseables.Search.FreeCompany;

/// <summary>
/// Models on entry of the free company search results
/// </summary>
public class FreeCompanySearchEntry : LodestoneParseable
{
    private readonly LodestoneClient client;
    private readonly FreeCompanySearchEntryDefinition definition;

    ///
    public FreeCompanySearchEntry(LodestoneClient client, HtmlNode rootNode,
        FreeCompanySearchEntryDefinition definition) : base(rootNode)
    {
        this.client = client;
        this.definition = definition;
    }

    /// <summary>
    /// Free Company name
    /// </summary>
    public string Name => Parse(this.definition.Name);

    /// <summary>
    /// Free company Id
    /// </summary>
    public string Id => ParseHrefId(this.definition.Id);

    /// <summary>
    /// Home world of the FC
    /// </summary>
    public string Server => ParseRegex(this.definition.Server)["World"].Value;

    /// <summary>
    /// Data center of the FC
    /// </summary>
    public string Datacenter => ParseRegex(this.definition.Server)["DC"].Value;

    /// <summary>
    /// FC crest/icon
    /// </summary>
    public IconLayers CrestLayers => new(this.RootNode, this.definition.CrestLayers);

    /// <summary>
    /// Formation date
    /// </summary>
    public DateTime Formed => ParseTime(this.definition.Formed);

    /// <summary>
    /// Active status
    /// </summary>
    public ActiveTimes Active => Parse(this.definition.Active) switch
    {
        "Always" => ActiveTimes.Always,
        "Weekends Only" => ActiveTimes.WeekendsOnly,
        "Weekdays Only" => ActiveTimes.WeekdaysOnly,
        "Not specified" => ActiveTimes.All,
        _ => throw new ArgumentOutOfRangeException(),
    };

    /// <summary>
    /// Active member count
    /// </summary>
    public int ActiveMembers => int.Parse(Parse(this.definition.ActiveMembers));

    /// <summary>
    /// Recruitment status
    /// </summary>
    public bool RecruitmentOpen => Parse(this.definition.RecruitmentOpen) == "Open";

    /// <summary>
    /// Affiliated grand company
    /// </summary>
    public string GrandCompany => Parse(this.definition.GrandCompany);

    /// <summary>
    /// Estate status
    /// </summary>
    public Housing EstateBuild => Parse(this.definition.EstateBuilt) switch
    {
        "No Estate or Plot" => Housing.NoEstateOrPlot,
        "Estate Built" => Housing.EstateBuilt,
        "Plot Only" => Housing.PlotOnly,
        _ => throw new ArgumentOutOfRangeException(),
    };

    /// <summary>
    /// Retrieve Free Company profile 
    /// </summary>
    /// <returns>Full FC profile</returns>
    public async Task<LodestoneFreeCompany?> GetFreeCompany() => await this.client.GetFreeCompany(this.Id);

    ///<inheritdoc />
    public override string ToString() => this.Name;
}