using System;
using System.Text;
using NetStone.StaticData;

namespace NetStone.Search.Character;

public class CharacterSearchQuery : ISearchQuery
{
    public string CharacterName { get; set; }
        
    public string World { get; set; }
    public string DataCenter { get; set; }
        
    public Role Role { get; set; }
    public ClassJob ClassJob { get; set; }
        
    public Race Race { get; set; }
    public Tribe Tribe { get; set; }

    public GrandCompany GrandCompany { get; set; } = GrandCompany.None;

    public Language Language { get; set; } =
        Language.Japanese | Language.English | Language.German | Language.French;

    public SortKind SortKind { get; set; } = SortKind.NameAtoZ;

    public string BuildQueryString()
    {
        if (string.IsNullOrEmpty(CharacterName))
            throw new ArgumentException("CharacterName must not be empty or null.", nameof(CharacterName));
            
        if (!string.IsNullOrEmpty(World) && !string.IsNullOrEmpty(DataCenter))
            throw new ArgumentException(
                "You cannot specify World and DataCenter at the same time in one search query.");
            
        if (Role != Role.None && ClassJob != ClassJob.None)
            throw new ArgumentException(
                "You cannot specify Role and ClassJob at the same time in one search query.");
            
        if (Race != Race.None && Tribe != Tribe.None)
            throw new ArgumentException(
                "You cannot specify Race and Tribe at the same time in one search query.");

        var query = new StringBuilder();

        query.Append($"?q={CharacterName}");

            
        if (!string.IsNullOrEmpty(World))
            query.Append($"&worldname={World}");

        if (!string.IsNullOrEmpty(DataCenter))
            query.Append($"&worldname=_dc_{DataCenter}");
            

        if (Role != Role.None)
            query.Append($"&classjob=_job_{Role.ToString().ToUpperInvariant()}");
            
        if (ClassJob != ClassJob.None)
            query.Append($"&classjob={(int) ClassJob}");
            
            
        if (Tribe != Tribe.None)
            query.Append($"&race_tribe=tribe_{(int) Tribe}");
            
        if (Race != Race.None)
            query.Append($"&race_tribe=race_{(int) Race}");


        if (GrandCompany.HasFlag(GrandCompany.NoAffiliation))
            query.Append("&gcid=0");
            
        if (GrandCompany.HasFlag(GrandCompany.Maelstrom))
            query.Append("&gcid=1");
            
        if (GrandCompany.HasFlag(GrandCompany.OrderOfTheTwinAdder))
            query.Append("&gcid=2");
            
        if (GrandCompany.HasFlag(GrandCompany.ImmortalFlames))
            query.Append("&gcid=3");
            
            
        if (Language.HasFlag(Language.Japanese))
            query.Append("&blog_lang=ja");
            
        if (Language.HasFlag(Language.English))
            query.Append("&blog_lang=en");
            
        if (Language.HasFlag(Language.German))
            query.Append("&blog_lang=de");
            
        if (Language.HasFlag(Language.French))
            query.Append("&blog_lang=fr");


        query.Append($"&order={(int) SortKind}");

        return query.ToString();
    }
}