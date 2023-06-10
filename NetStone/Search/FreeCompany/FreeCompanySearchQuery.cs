using System;
using System.Text;
using NetStone.StaticData;

namespace NetStone.Search.FreeCompany;

/// <summary>
/// Models a search query for Free companies
/// </summary>
public class FreeCompanySearchQuery : ISearchQuery
{
    /// <summary>
    /// Name to search for
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// World name the FC should belong to
    /// </summary>
    public string World { get; set; }

    /// <summary>
    /// Data center the FC should belong to
    /// </summary>
    public string DataCenter { get; set; }

    /// <summary>
    /// IF the FC is recruiting via Community Finder
    /// </summary>
    public bool IsCommunityFinderRecruiting { get; set; }

    /// <summary>
    /// Filter by active times
    /// </summary>
    public ActiveTimes ActiveTimes { get; set; } = ActiveTimes.All;

    /// <summary>
    /// Filter by number of active players
    /// </summary>
    public ActiveMembers ActiveMembers { get; set; } = ActiveMembers.All;

    /// <summary>
    /// Filter by recruitment status
    /// </summary>
    public Recruitment Recruitment { get; set; } = Recruitment.All;

    /// <summary>
    /// Filter by housing status
    /// </summary>
    public Housing Housing { get; set; } = Housing.All;

    /// <summary>
    /// Filter by content focus of the FC
    /// </summary>
    public Focus Focus { get; set; }

    /// <summary>
    /// Filter by type of players the FC is seeking
    /// </summary>
    public Seeking Seeking { get; set; }

    /// <summary>
    /// Filter for Grand Company membership
    /// </summary>
    public GrandCompany GrandCompany { get; set; } = GrandCompany.None;

    /// <summary>
    /// How to sort results
    /// </summary>
    public SortKind SortKind { get; set; } = SortKind.NameAtoZ;

    /// <inheritdoc />
    /// <exception cref="ArgumentException" />
    public string BuildQueryString()
    {
        if (!string.IsNullOrEmpty(this.World) && !string.IsNullOrEmpty(this.DataCenter))
            throw new ArgumentException(
                "You cannot specify World and DataCenter at the same time in one search query.");

        var query = new StringBuilder();

        if (!string.IsNullOrEmpty(this.Name))
            query.Append($"?q={this.Name}");


        if (this.IsCommunityFinderRecruiting)
            query.Append("&cf_public=1");


        if (!string.IsNullOrEmpty(this.World))
            query.Append($"&worldname={this.World}");

        if (!string.IsNullOrEmpty(this.DataCenter))
            query.Append($"&worldname=_dc_{this.DataCenter}");


        if (this.ActiveTimes != ActiveTimes.All)
            query.Append($"&activetime={(int)this.ActiveTimes}");


        if (this.Recruitment != Recruitment.All)
            query.Append($"&join={(int)this.Recruitment}");


        if (this.Housing != Housing.All)
            query.Append($"&house={(int)this.Housing}");


        if (this.ActiveMembers == ActiveMembers.OneToTen)
            query.Append("&character_count=1-10");

        if (this.ActiveMembers == ActiveMembers.ElevenToThirty)
            query.Append("&character_count=11-30");

        if (this.ActiveMembers == ActiveMembers.ThirtyOneToFifty)
            query.Append("&character_count=31-50");

        if (this.ActiveMembers == ActiveMembers.OverFiftyOne)
            query.Append("&character_count=50-");


        if (this.Focus.HasFlag(Focus.RolePlaying))
            query.Append("&activities=0");

        if (this.Focus.HasFlag(Focus.Leveling))
            query.Append("&activities=1");

        if (this.Focus.HasFlag(Focus.Casual))
            query.Append("&activities=2");

        if (this.Focus.HasFlag(Focus.Hardcore))
            query.Append("&activities=3");

        if (this.Focus.HasFlag(Focus.Dungeons))
            query.Append("&activities=6");

        if (this.Focus.HasFlag(Focus.Guildhests))
            query.Append("&activities=4");

        if (this.Focus.HasFlag(Focus.Trials))
            query.Append("&activities=5");

        if (this.Focus.HasFlag(Focus.Raids))
            query.Append("&activities=7");

        if (this.Focus.HasFlag(Focus.PvP))
            query.Append("&activities=8");


        if (this.Seeking.HasFlag(Seeking.Tank))
            query.Append("&roles=16");

        if (this.Seeking.HasFlag(Seeking.Healer))
            query.Append("&roles=17");

        if (this.Seeking.HasFlag(Seeking.Dps))
            query.Append("&roles=18");

        if (this.Seeking.HasFlag(Seeking.Crafter))
            query.Append("&roles=19");

        if (this.Seeking.HasFlag(Seeking.Gatherer))
            query.Append("&roles=20");


        if (this.GrandCompany.HasFlag(GrandCompany.Maelstrom))
            query.Append("&gcid=1");

        if (this.GrandCompany.HasFlag(GrandCompany.OrderOfTheTwinAdder))
            query.Append("&gcid=2");

        if (this.GrandCompany.HasFlag(GrandCompany.ImmortalFlames))
            query.Append("&gcid=3");


        query.Append($"&order={(int)this.SortKind}");

        return query.ToString();
    }
}