using System.Collections.Generic;
using HtmlAgilityPack;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.CWLS;
using NetStone.Search.Linkshell;

namespace NetStone.Model.Parseables.Search.CWLS;

/// <summary>
/// Models cross world link shell search results
/// </summary>
public class CrossworldLinkshellSearchPage 
    : PaginatedSearchResult<CrossworldLinkshellSearchPage, CrossworldLinkshellSearchEntry, 
        CrossworldLinkshellSearchEntryDefinition, CrossworldLinkshellSearchQuery>
{
    private readonly LodestoneClient client;
    /// <summary>
    /// Constructs character search results
    /// </summary>
    /// <param name="client"></param>
    /// <param name="rootNode"></param>
    /// <param name="pageDefinition"></param>
    /// <param name="currentQuery"></param>
    public CrossworldLinkshellSearchPage(LodestoneClient client, HtmlNode rootNode, 
                                         PagedDefinition<CrossworldLinkshellSearchEntryDefinition> pageDefinition,
                                         CrossworldLinkshellSearchQuery currentQuery) 
        : base(rootNode, pageDefinition, client.SearchCrossworldLinkshell, currentQuery)
    {
        this.client = client;
    }
    

    /// <summary>
    /// List all results
    /// </summary>
    public new IEnumerable<CrossworldLinkshellSearchEntry> Results => base.Results;

    ///<inheritdoc />
    protected override CrossworldLinkshellSearchEntry[] ParseResults()
    {
        var container = QueryContainer(this.PageDefinition);

         var parsedResults = new CrossworldLinkshellSearchEntry[container.Length];
        for (var i = 0; i < parsedResults.Length; i++)
        {
            parsedResults[i] = new CrossworldLinkshellSearchEntry(this.client, container[i], this.PageDefinition.Entry);
        }
        return parsedResults;
    }
}