using System.Collections.Generic;
using HtmlAgilityPack;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.Character;
using NetStone.Search.Character;

namespace NetStone.Model.Parseables.Search.Character;

/// <summary>
/// Models character search results
/// </summary>
public class CharacterSearchPage : PaginatedSearchResult<CharacterSearchPage, CharacterSearchEntry,
    CharacterSearchEntryDefinition, CharacterSearchQuery>
{
    private readonly LodestoneClient client;

    /// <summary>
    /// Constructs character search results
    /// </summary>
    /// <param name="client"></param>
    /// <param name="rootNode"></param>
    /// <param name="pageDefinition"></param>
    /// <param name="currentQuery"></param>
    public CharacterSearchPage(LodestoneClient client, HtmlNode rootNode, 
                               PagedDefinition<CharacterSearchEntryDefinition> pageDefinition,
                               CharacterSearchQuery currentQuery) 
        : base(rootNode, pageDefinition, client.SearchCharacter, currentQuery)
    {
        this.client = client;
    }

    /// <summary>
    /// List all results
    /// </summary>
    public new IEnumerable<CharacterSearchEntry> Results => base.Results;

    ///<inheritdoc />
    protected override CharacterSearchEntry[] ParseResults() 
    {
        var container = QueryContainer(this.PageDefinition);

        var parsedResults = new CharacterSearchEntry[container.Length];
        for (var i = 0; i < parsedResults.Length; i++)
        {
            parsedResults[i] = new CharacterSearchEntry(this.client, container[i], this.PageDefinition.Entry);
        }

        return parsedResults;
    }
}