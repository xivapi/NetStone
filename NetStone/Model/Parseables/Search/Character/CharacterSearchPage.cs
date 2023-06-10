using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.Character;
using NetStone.Search.Character;

namespace NetStone.Model.Parseables.Search.Character;

/// <summary>
/// Models character search results
/// </summary>
public class CharacterSearchPage : LodestoneParseable, IPaginatedResult<CharacterSearchPage>
{
    private readonly LodestoneClient client;
    private readonly CharacterSearchQuery currentQuery;

    private readonly PagedDefinition pageDefinition;
    private readonly CharacterSearchEntryDefinition entryDefinition;

    /// <summary>
    /// Constructs character search results
    /// </summary>
    /// <param name="client"></param>
    /// <param name="rootNode"></param>
    /// <param name="pageDefinition"></param>
    /// <param name="currentQuery"></param>
    public CharacterSearchPage(LodestoneClient client, HtmlNode rootNode, PagedDefinition pageDefinition,
        CharacterSearchQuery currentQuery) : base(rootNode)
    {
        this.client = client;
        this.currentQuery = currentQuery;

        this.pageDefinition = pageDefinition;
        this.entryDefinition = pageDefinition.Entry.ToObject<CharacterSearchEntryDefinition>();
    }

    /// <summary>
    /// Indicates if any results are present
    /// </summary>
    public bool HasResults => !HasNode(this.pageDefinition.NoResultsFound);

    private CharacterSearchEntry[] parsedResults;

    /// <summary>
    /// List all results
    /// </summary>
    public IEnumerable<CharacterSearchEntry> Results
    {
        get
        {
            if (!this.HasResults)
                return new CharacterSearchEntry[0];

            if (this.parsedResults == null)
                ParseSearchResults();

            return this.parsedResults;
        }
    }

    private void ParseSearchResults()
    {
        var container = QueryContainer(this.pageDefinition);

        this.parsedResults = new CharacterSearchEntry[container.Length];
        for (var i = 0; i < this.parsedResults.Length; i++)
        {
            this.parsedResults[i] = new CharacterSearchEntry(this.client, container[i], this.entryDefinition);
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

            return this.currentPageVal.Value;
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

            return this.numPagesVal.Value;
        }
    }

    private void ParsePagesCount()
    {
        var results = ParseRegex(this.pageDefinition.PageInfo);

        this.currentPageVal = int.Parse(results["CurrentPage"].Value);
        this.numPagesVal = int.Parse(results["NumPages"].Value);
    }

    ///<inheritdoc />
    public async Task<CharacterSearchPage?> GetNextPage()
    {
        if (!this.HasResults)
            return null;

        if (this.CurrentPage == this.NumPages)
            return null;

        return await this.client.SearchCharacter(this.currentQuery, this.CurrentPage + 1);
    }
}