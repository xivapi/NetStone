using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.Character;
using NetStone.Search.Character;

namespace NetStone.Model.Parseables.Search.Character;

public class CharacterSearchPage : LodestoneParseable, IPaginatedResult<CharacterSearchPage>
{
    private readonly LodestoneClient client;
    private readonly CharacterSearchQuery currentQuery;
        
    private readonly PagedDefinition pageDefinition;
    private readonly CharacterSearchEntryDefinition entryDefinition;

    public CharacterSearchPage(LodestoneClient client, HtmlNode rootNode, PagedDefinition pageDefinition, CharacterSearchQuery currentQuery) : base(rootNode)
    {
        this.client = client;
        this.currentQuery = currentQuery;
            
        this.pageDefinition = pageDefinition;
        this.entryDefinition = pageDefinition.Entry.ToObject<CharacterSearchEntryDefinition>();
    }

    public bool HasResults => !HasNode(this.pageDefinition.NoResultsFound);

    private CharacterSearchEntry[] parsedResults;
    public IEnumerable<CharacterSearchEntry> Results
    {
        get
        {
            if (!HasResults)
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
        
    public async Task<CharacterSearchPage?> GetNextPage()
    {
        if (!HasResults)
            return null;
            
        if (CurrentPage == NumPages)
            return null;

        return await this.client.SearchCharacter(this.currentQuery, CurrentPage + 1);
    }
}