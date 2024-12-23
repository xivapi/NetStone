using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.CWLS;
using NetStone.Search.Linkshell;

namespace NetStone.Model.Parseables.Search.CWLS;

/// <summary>
/// Models cross world link shell search results
/// </summary>
public class CrossworldLinkshellSearchPage : LodestoneParseable, IPaginatedResult<CrossworldLinkshellSearchPage>
{
    private readonly LodestoneClient client;
    private readonly CrossworldLinkshellSearchQuery currentQuery;

    private readonly PagedDefinition<CrossworldLinkshellSearchEntryDefinition> pageDefinition;

    /// <summary>
    /// Constructs character search results
    /// </summary>
    /// <param name="client"></param>
    /// <param name="rootNode"></param>
    /// <param name="pageDefinition"></param>
    /// <param name="currentQuery"></param>
    public CrossworldLinkshellSearchPage(LodestoneClient client, HtmlNode rootNode, PagedDefinition<CrossworldLinkshellSearchEntryDefinition> pageDefinition,
                                         CrossworldLinkshellSearchQuery currentQuery) : base(rootNode)
    {
        this.client = client;
        this.currentQuery = currentQuery;
        this.pageDefinition = pageDefinition;
    }

    /// <summary>
    /// Indicates if any results are present
    /// </summary>
    public bool HasResults => !HasNode(this.pageDefinition.NoResultsFound);

    private CrossworldLinkshellSearchEntry[]? parsedResults;

    /// <summary>
    /// List all results
    /// </summary>
    public IEnumerable<CrossworldLinkshellSearchEntry> Results
    {
        get
        {
            if (!this.HasResults)
                return Array.Empty<CrossworldLinkshellSearchEntry>();

            if (this.parsedResults == null)
                ParseSearchResults();

            return this.parsedResults!;
        }
    }

    private void ParseSearchResults()
    {
        var container = QueryContainer(this.pageDefinition);

        this.parsedResults = new CrossworldLinkshellSearchEntry[container.Length];
        for (var i = 0; i < this.parsedResults.Length; i++)
        {
            this.parsedResults[i] = new CrossworldLinkshellSearchEntry(this.client, container[i], this.pageDefinition.Entry);
        }
    }

    private int? currentPageVal;

    ///<inheritdoc />
    public int CurrentPage
    {
        get
        {
            if (!this.HasResults)
                return 0;

            if (!this.currentPageVal.HasValue)
                ParsePagesCount();

            return this.currentPageVal!.Value;
        }
    }

    private int? numPagesVal;

    ///<inheritdoc />
    public int NumPages
    {
        get
        {
            if (!this.HasResults)
                return 0;

            if (!this.numPagesVal.HasValue)
                ParsePagesCount();

            return this.numPagesVal!.Value;
        }
    }

    private void ParsePagesCount()
    {
        var results = ParseRegex(this.pageDefinition.PageInfo);

        this.currentPageVal = int.Parse(results["CurrentPage"].Value);
        this.numPagesVal = int.Parse(results["NumPages"].Value);
    }

    ///<inheritdoc />
    public async Task<CrossworldLinkshellSearchPage?> GetNextPage()
    {
        if (!this.HasResults)
            return null;

        if (this.CurrentPage == this.NumPages)
            return null;

        return await this.client.SearchCrossworldLinkshell(this.currentQuery, this.CurrentPage + 1);
    }
}