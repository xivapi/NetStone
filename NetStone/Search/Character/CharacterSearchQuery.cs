using System;
using System.Text;
using NetStone.StaticData;

namespace NetStone.Search.Character;

/// <summary>
/// Models a search for characters
/// </summary>
public class CharacterSearchQuery : ISearchQuery
{
    /// <summary>
    /// Name to search
    /// </summary>
    public string CharacterName { get; set; } = "";

    /// <summary>
    /// Homeworld for search
    /// </summary>
    public string World { get; set; } = "";

    /// <summary>
    /// Datacenter to search
    /// </summary>
    public string DataCenter { get; set; } = "";

    /// <summary>
    /// Role to search for
    /// </summary>
    public Role Role { get; set; }

    /// <summary>
    /// Job to search for
    /// </summary>
    public ClassJob ClassJob { get; set; }

    /// <summary>
    /// Race to search for
    /// </summary>
    public Race Race { get; set; }

    /// <summary>
    /// Tribe/Clan to search for
    /// </summary>
    public Tribe Tribe { get; set; }

    /// <summary>
    /// Grand Company affiliation to search for
    /// </summary>
    public GrandCompany GrandCompany { get; set; } = GrandCompany.None;

    /// <summary>
    /// Languages to include
    /// </summary>
    public Language Language { get; set; } =
        Language.Japanese | Language.English | Language.German | Language.French;

    /// <summary>
    /// Sort order
    /// </summary>
    public SortKind SortKind { get; set; } = SortKind.NameAtoZ;

    /// <summary>
    /// Construct search string to append to uri.
    /// Throws <see cref="ArgumentException"/> if incompatible query parameters are used
    /// </summary>
    /// <returns>Query string</returns>
    /// <exception cref="ArgumentException"></exception>
    public string BuildQueryString()
    {
        if (string.IsNullOrEmpty(this.CharacterName))
            throw new ArgumentException("CharacterName must not be empty or null.", nameof(this.CharacterName));

        if (!string.IsNullOrEmpty(this.World) && !string.IsNullOrEmpty(this.DataCenter))
            throw new ArgumentException(
                "You cannot specify World and DataCenter at the same time in one search query.");

        if (this.Role != Role.None && this.ClassJob != ClassJob.None)
            throw new ArgumentException(
                "You cannot specify Role and ClassJob at the same time in one search query.");

        if (this.Race != Race.None && this.Tribe != Tribe.None)
            throw new ArgumentException(
                "You cannot specify Race and Tribe at the same time in one search query.");

        var query = new StringBuilder();

        query.Append($"?q={this.CharacterName}");


        if (!string.IsNullOrEmpty(this.World))
            query.Append($"&worldname={this.World}");

        if (!string.IsNullOrEmpty(this.DataCenter))
            query.Append($"&worldname=_dc_{this.DataCenter}");


        if (this.Role != Role.None)
            query.Append($"&classjob=_job_{this.Role.ToString().ToUpperInvariant()}");

        if (this.ClassJob != ClassJob.None)
            query.Append($"&classjob={(int)this.ClassJob}");


        if (this.Tribe != Tribe.None)
            query.Append($"&race_tribe=tribe_{(int)this.Tribe}");

        if (this.Race != Race.None)
            query.Append($"&race_tribe=race_{(int)this.Race}");


        if (this.GrandCompany.HasFlag(GrandCompany.NoAffiliation))
            query.Append("&gcid=0");

        if (this.GrandCompany.HasFlag(GrandCompany.Maelstrom))
            query.Append("&gcid=1");

        if (this.GrandCompany.HasFlag(GrandCompany.OrderOfTheTwinAdder))
            query.Append("&gcid=2");

        if (this.GrandCompany.HasFlag(GrandCompany.ImmortalFlames))
            query.Append("&gcid=3");


        if (this.Language.HasFlag(Language.Japanese))
            query.Append("&blog_lang=ja");

        if (this.Language.HasFlag(Language.English))
            query.Append("&blog_lang=en");

        if (this.Language.HasFlag(Language.German))
            query.Append("&blog_lang=de");

        if (this.Language.HasFlag(Language.French))
            query.Append("&blog_lang=fr");


        query.Append($"&order={(int)this.SortKind}");

        return query.ToString();
    }
}