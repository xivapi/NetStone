using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.FreeCompany;
using NetStone.Search.FreeCompany;

namespace NetStone.Model.Parseables.Search.FreeCompany;

public class FreeCompanySearchPage : LodestoneParseable, IPaginatedResult<FreeCompanySearchPage>
{
    private readonly LodestoneClient client;
    private readonly FreeCompanySearchQuery currentQuery;

    private readonly PagedDefinition pageDefinition;
    private readonly FreeCompanySearchEntryDefinition entryDefinition;

    public FreeCompanySearchPage(LodestoneClient client, HtmlNode rootNode, PagedDefinition pageDefinition, FreeCompanySearchQuery currentQuery) : base(rootNode)
    {
        this.client = client;
        this.currentQuery = currentQuery;

        this.pageDefinition = pageDefinition;
        this.entryDefinition = pageDefinition.Entry.ToObject<FreeCompanySearchEntryDefinition>();
    }

    public bool HasResults => !HasNode(this.pageDefinition.NoResultsFound);

    private FreeCompanySearchEntry[] parsedResults;
    public IEnumerable<FreeCompanySearchEntry> Results
    {
        get
        {
            if (!HasResults)
                return Array.Empty<FreeCompanySearchEntry>();

            if (this.parsedResults == null)
                ParseSearchResults();

            return this.parsedResults;
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
    public int CurrentPage
    {
        get
        {
            if (!HasResults)
                return 0;

            if (!this.currentPageVal.HasValue)
                ParsePagesCount();

            return this.currentPageVal.Value;
        }
    }

    private int? numPagesVal;
    public int NumPages
    {
        get
        {
            if (!HasResults)
                return 0;

            if (!this.numPagesVal.HasValue)
                ParsePagesCount();

            return this.numPagesVal.Value;
        }
    }

    private void ParsePagesCount()
    {
        var results = ParseRegex(this.pageDefinition.PageInfo);

        this.currentPageVal = int.Parse(results["CurrentPage"].Value);
        this.numPagesVal = int.Parse(results["NumPages"].Value);
    }

    public async Task<FreeCompanySearchPage?> GetNextPage()
    {
        if (!HasResults)
            return null;

        if (CurrentPage == NumPages)
            return null;

        return await this.client.SearchFreeCompany(this.currentQuery, CurrentPage + 1);
    }
}