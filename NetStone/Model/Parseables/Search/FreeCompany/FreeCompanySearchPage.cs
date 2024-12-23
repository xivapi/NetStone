using System.Collections.Generic;
using HtmlAgilityPack;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.FreeCompany;
using NetStone.Search.FreeCompany;

namespace NetStone.Model.Parseables.Search.FreeCompany;

/// <summary>
/// Models Free Company search results
/// </summary>
public class FreeCompanySearchPage : PaginatedSearchResult<FreeCompanySearchPage, 
    FreeCompanySearchEntry,FreeCompanySearchEntryDefinition, FreeCompanySearchQuery>
{
    private readonly LodestoneClient client;

    /// <summary>
    /// Constructs Free Company Search results
    /// </summary>
    /// <param name="client"></param>
    /// <param name="rootNode"></param>
    /// <param name="pageDefinition"></param>
    /// <param name="currentQuery"></param>
    public FreeCompanySearchPage(LodestoneClient client, HtmlNode rootNode, 
                                 PagedDefinition<FreeCompanySearchEntryDefinition> pageDefinition,
                                 FreeCompanySearchQuery currentQuery) 
        : base(rootNode, pageDefinition, client.SearchFreeCompany, currentQuery)
    {
        this.client = client;
    }

    /// <summary>
    /// Lists all search results
    /// </summary>
    public new IEnumerable<FreeCompanySearchEntry> Results => base.Results;

    ///<inheritdoc />
    protected override FreeCompanySearchEntry[] ParseResults()
    {
        var container = QueryContainer(this.PageDefinition);

        var parsedResults = new FreeCompanySearchEntry[container.Length];
        for (var i = 0; i < parsedResults.Length; i++)
        {
            parsedResults[i] = new FreeCompanySearchEntry(this.client, container[i], this.PageDefinition.Entry);
        }
        return parsedResults;
    }
}