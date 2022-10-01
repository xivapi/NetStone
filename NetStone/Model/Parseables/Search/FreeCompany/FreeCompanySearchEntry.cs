using System;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model.FreeCompany;
using NetStone.Model.Parseables.FreeCompany;
using NetStone.Search.FreeCompany;

namespace NetStone.Model.Parseables.Search.FreeCompany;

public class FreeCompanySearchEntry : LodestoneParseable
{
    private readonly LodestoneClient client;
    private readonly FreeCompanySearchEntryDefinition definition;

    public FreeCompanySearchEntry(LodestoneClient client, HtmlNode rootNode, FreeCompanySearchEntryDefinition definition) : base(rootNode)
    {
        this.client = client;
        this.definition = definition;
    }

    public string Name => Parse(this.definition.Name);

    public string Id => ParseHrefId(this.definition.Id);

    public string Server => ParseRegex(this.definition.Server)["World"].Value;

    public string Datacenter => ParseRegex(this.definition.Server)["DC"].Value;

    public IconLayers CrestLayers => new IconLayers(this.RootNode, this.definition.CrestLayers);

    public DateTime Formed => ParseTime(this.definition.Formed);

    public ActiveTimes Active => Parse(this.definition.Active) switch
    {
        "Always" => ActiveTimes.Always,
        "Weekends Only" => ActiveTimes.WeekendsOnly,
        "Weekdays Only" => ActiveTimes.WeekdaysOnly,
        "Not specified" => ActiveTimes.All,
        _ => throw new ArgumentOutOfRangeException(),
    };

    public int ActiveMembers => int.Parse(Parse(this.definition.ActiveMembers));

    public bool RecruitmentOpen => Parse(this.definition.RecruitmentOpen) == "Open";

    public string GrandCompany => Parse(this.definition.GrandCompany);

    public Housing EstateBuild => Parse(this.definition.EstateBuilt) switch
    {
        "No Estate or Plot" => Housing.NoEstateOrPlot,
        "Estate Built" => Housing.EstateBuilt,
        "Plot Only" => Housing.PlotOnly,
        _ => throw new ArgumentOutOfRangeException(),
    };

    public async Task<LodestoneFreeCompany?> GetFreeCompany() => await this.client.GetFreeCompany(this.Id);

    public override string ToString() => Name;
}