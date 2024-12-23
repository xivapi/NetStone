using System.Collections.Generic;
using HtmlAgilityPack;
using NetStone.Definitions;
using NetStone.Definitions.Model.Linkshell;
using NetStone.Model.Parseables.Linkshell.Members;

namespace NetStone.Model.Parseables.Linkshell;

/// <summary>
/// Container class holding information about a linkshell and it's members.
/// </summary>
public class LodestoneLinkshell : PaginatedIdResult<LodestoneLinkshell,LinkshellMemberEntry,LinkshellMemberEntryDefinition>
{
    private readonly LinkshellDefinition lsDefinition;
    
    /// <summary>
    /// Container class for a parseable linkshell page.
    /// </summary>
    /// <param name="client">The <see cref="LodestoneClient"/> to be used to fetch further information.</param>
    /// <param name="rootNode">The root document node of the page.</param>
    /// <param name="container">The <see cref="DefinitionsContainer"/> holding definitions to be used to access data.</param>
    /// <param name="id">The ID of the cross world linkshell.</param>
    public LodestoneLinkshell(LodestoneClient client, HtmlNode rootNode, DefinitionsContainer container, string id) : base(rootNode,container.LinkshellMember, client.GetLinkshell,id)
    {
        this.lsDefinition = container.Linkshell;
    }

    /// <summary>
    /// Name
    /// </summary>
    public string Name => Parse(this.lsDefinition.Name);

    /// <summary>
    /// List of members
    /// </summary>
    public IEnumerable<LinkshellMemberEntry> Members => this.Results;
    
    ///<inheritdoc />
    protected override LinkshellMemberEntry[] ParseResults()
    {
        var nodes = QueryContainer(this.PageDefinition);

        var parsedResults = new LinkshellMemberEntry[nodes.Length];
        for (var i = 0; i < parsedResults.Length; i++)
        {
            parsedResults[i] = new LinkshellMemberEntry(nodes[i], this.PageDefinition.Entry);
        }
        return parsedResults;
    }
}