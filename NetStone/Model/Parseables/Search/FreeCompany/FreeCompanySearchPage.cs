using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.FreeCompany;
using NetStone.Search.FreeCompany;

namespace NetStone.Model.Parseables.Search.FreeCompany;

/// <summary>
/// Models Free Company search results
/// </summary>
public class FreeCompanySearchPage : LodestoneParseable, IPaginatedResult<FreeCompanySearchPage>
{
    private readonly LodestoneClient client;
    private readonly FreeCompanySearchQuery currentQuery;

    private readonly PagedDefinition pageDefinition;
    private readonly FreeCompanySearchEntryDefinition entryDefinition;

    /// <summary>
    /// Constructs Free Company Search results
    /// </summary>
    /// <param name="client"></param>
    /// <param name="rootNode"></param>
    /// <param name="pageDefinition"></param>
    /// <param name="currentQuery"></param>
    public FreeCompanySearchPage(LodestoneClient client, HtmlNode rootNode, PagedDefinition pageDefinition,
        FreeCompanySearchQuery currentQuery) : base(rootNode)
    {
        this.client = client;
        this.currentQuery = currentQuery;

        this.pageDefinition = pageDefinition;
        this.entryDefinition = pageDefinition.Entry.ToObject<FreeCompanySearchEntryDefinition>();
    }

    /// <summary>
    /// Indicates if any results are present
    /// </summary>
    public bool HasResults => !HasNode(this.pageDefinition.NoResultsFound);

    private FreeCompanySearchEntry[]? parsedResults;

    /// <summary>
    /// Lists all search results
    /// </summary>
    public IEnumerable<FreeCompanySearchEntry> Results
    {
        get
        {
            if (!this.HasResults)
                return Array.Empty<FreeCompanySearchEntry>();

            if (this.parsedResults == null)
                ParseSearchResults();

            return this.parsedResults!;
        }
    }

    private void ParseSearchResults()
    {
        var container = QueryContainer(this.pageDefinition);

        this.parsedResults = new FreeCompanySearchEntry[container.Length];
        for (var i = 0; i < this.parsedResults.Length; i++)
        {
            this.parsedResults[i] = new FreeCompanySearchEntry(this.client, container[i], this.entryDefinition);
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
    public async Task<FreeCompanySearchPage?> GetNextPage()
    {
        if (!this.HasResults)
            return null;

        if (this.CurrentPage == this.NumPages)
            return null;

        return await this.client.SearchFreeCompany(this.currentQuery, this.CurrentPage + 1);
    }
}