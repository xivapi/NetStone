using HtmlAgilityPack;
using NetStone.Definitions.Model.CWLS;

namespace NetStone.Model.Parseables.CWLS.Members;

/// <summary>
/// Container class holding information about a cross-world linkshelll member.
/// </summary>
public class CrossWorldLinkShellMemberEntry : LodestoneParseable
{
    private readonly CrossWorldLinkShellMemberEntryDefinition definition;
    /// <summary>
    /// Create instance of member entry for a given node
    /// </summary>
    /// <param name="rootNode">Root html node of this entry</param>
    /// <param name="definition">Css and regex definition</param>
    public CrossWorldLinkShellMemberEntry(HtmlNode rootNode, CrossWorldLinkShellMemberEntryDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    /// <summary>
    /// Avatar
    /// </summary>
    public string Avatar => Parse(this.definition.Avatar);

    /// <summary>
    /// ID
    /// </summary>
    public string? Id => ParseHrefId(this.definition.Id);

    /// <summary>
    /// Name
    /// </summary>
    public string Name => Parse(this.definition.Name);

    /// <summary>
    /// Rank
    /// </summary>
    public string Rank => Parse(this.definition.Rank);

    /// <summary>
    /// Rank Icon
    /// </summary>
    public string RankIcon => Parse(this.definition.RankIcon);

    /// <summary>
    /// Linkshell rank
    /// </summary>
    public string LinkshellRank => Parse(this.definition.LinkshellRank);

    /// <summary>
    /// Linkshell rank Icon
    /// </summary>
    public string LinkshellRankIcon => Parse(this.definition.LinkshellRankIcon);

    /// <summary>
    /// Server
    /// </summary>
    public string Server => Parse(this.definition.Server);
}