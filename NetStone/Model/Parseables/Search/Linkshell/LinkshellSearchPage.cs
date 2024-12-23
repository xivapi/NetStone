using System.Collections.Generic;
using HtmlAgilityPack;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.Linkshell;
using NetStone.Search.Linkshell;

namespace NetStone.Model.Parseables.Search.Linkshell;

/// <summary>
/// Models link shell search results
/// </summary>
public class LinkshellSearchPage : PaginatedSearchResult<LinkshellSearchPage, LinkshellSearchEntry,
    LinkshellSearchEntryDefinition, LinkshellSearchQuery>
{
    private readonly LodestoneClient client;

    /// <summary>
    /// Constructs character search results
    /// </summary>
    /// <param name="client"></param>
    /// <param name="rootNode"></param>
    /// <param name="pageDefinition"></param>
    /// <param name="currentQuery"></param>
    public LinkshellSearchPage(LodestoneClient client, HtmlNode rootNode, 
                               PagedDefinition<LinkshellSearchEntryDefinition> pageDefinition,
                               LinkshellSearchQuery currentQuery) 
        : base(rootNode, pageDefinition, client.SearchLinkshell, currentQuery)
    {
        this.client = client;
    }

    /// <summary>
    /// List all results
    /// </summary>
    public new IEnumerable<LinkshellSearchEntry> Results => base.Results;

    ///<inheritdoc />
    protected override LinkshellSearchEntry[] ParseResults()
    {
        var container = QueryContainer(this.PageDefinition);

        var parsedResults = new LinkshellSearchEntry[container.Length];
        for (var i = 0; i < parsedResults.Length; i++)
        {
            parsedResults[i] = new LinkshellSearchEntry(this.client, container[i], this.PageDefinition.Entry);
        }
        return parsedResults;
    }
}