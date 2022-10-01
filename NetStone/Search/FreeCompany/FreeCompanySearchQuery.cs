using System;
using System.Text;
using NetStone.StaticData;

namespace NetStone.Search.FreeCompany;

public class FreeCompanySearchQuery : ISearchQuery
{
    public string Name { get; set; }
        
    public string World { get; set; }
    public string DataCenter { get; set; }
        
    public bool IsCommunityFinderRecruiting { get; set; }

    public ActiveTimes ActiveTimes { get; set; } = ActiveTimes.All;
    public ActiveMembers ActiveMembers { get; set; } = ActiveMembers.All;

    public Recruitment Recruitment { get; set; } = Recruitment.All;
    public Housing Housing { get; set; } = Housing.All;

    public Focus Focus { get; set; }
    public Seeking Seeking { get; set; }

    public GrandCompany GrandCompany { get; set; } = GrandCompany.None;

    public SortKind SortKind { get; set; } = SortKind.NameAtoZ;

    public string BuildQueryString()
    {
        if (!string.IsNullOrEmpty(World) && !string.IsNullOrEmpty(DataCenter))
            throw new ArgumentException(
                "You cannot specify World and DataCenter at the same time in one search query.");
            
        var query = new StringBuilder();

        if (!string.IsNullOrEmpty(Name))
            query.Append($"?q={Name}");

            
        if (IsCommunityFinderRecruiting)
            query.Append("&cf_public=1");

            
        if (!string.IsNullOrEmpty(World))
            query.Append($"&worldname={World}");

        if (!string.IsNullOrEmpty(DataCenter))
            query.Append($"&worldname=_dc_{DataCenter}");
            

        if (ActiveTimes != ActiveTimes.All)
            query.Append($"&activetime={(int) ActiveTimes}");
            
            
        if (Recruitment != Recruitment.All)
            query.Append($"&join={(int) Recruitment}");
            
            
        if (Housing != Housing.All)
            query.Append($"&house={(int) Housing}");
            
            
        if (ActiveMembers == ActiveMembers.OneToTen)
            query.Append("&character_count=1-10");
            
        if (ActiveMembers == ActiveMembers.ElevenToThirty)
            query.Append("&character_count=11-30");
            
        if (ActiveMembers == ActiveMembers.ThirtyOneToFifty)
            query.Append("&character_count=31-50");
            
        if (ActiveMembers == ActiveMembers.OverFiftyOne)
            query.Append("&character_count=50-");

            
        if (Focus.HasFlag(Focus.RolePlaying))
            query.Append("&activities=0");
            
        if (Focus.HasFlag(Focus.Leveling))
            query.Append("&activities=1");
            
        if (Focus.HasFlag(Focus.Casual))
            query.Append("&activities=2");
            
        if (Focus.HasFlag(Focus.Hardcore))
            query.Append("&activities=3");
            
        if (Focus.HasFlag(Focus.Dungeons))
            query.Append("&activities=6");
            
        if (Focus.HasFlag(Focus.Guildhests))
            query.Append("&activities=4");
            
        if (Focus.HasFlag(Focus.Trials))
            query.Append("&activities=5");
            
        if (Focus.HasFlag(Focus.Raids))
            query.Append("&activities=7");
            
        if (Focus.HasFlag(Focus.PvP))
            query.Append("&activities=8");
            

        if (Seeking.HasFlag(Seeking.Tank))
            query.Append("&roles=16");
            
        if (Seeking.HasFlag(Seeking.Healer))
            query.Append("&roles=17");
            
        if (Seeking.HasFlag(Seeking.Dps))
            query.Append("&roles=18");
            
        if (Seeking.HasFlag(Seeking.Crafter))
            query.Append("&roles=19");
            
        if (Seeking.HasFlag(Seeking.Gatherer))
            query.Append("&roles=20");
            
            
        if (GrandCompany.HasFlag(GrandCompany.Maelstrom))
            query.Append("&gcid=1");
            
        if (GrandCompany.HasFlag(GrandCompany.OrderOfTheTwinAdder))
            query.Append("&gcid=2");
            
        if (GrandCompany.HasFlag(GrandCompany.ImmortalFlames))
            query.Append("&gcid=3");


        query.Append($"&order={(int) SortKind}");

        return query.ToString();
    }
}