using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.Character;

namespace NetStone.Model.Parseables.Character.Achievement;

/// <summary>
/// Holds information about a characters unlocked achievements
/// </summary>
public class CharacterAchievementPage : LodestoneParseable, IPaginatedResult<CharacterAchievementPage>
{
    private readonly LodestoneClient client;

    private readonly PagedDefinition pageDefinition;
    private readonly CharacterAchievementEntryDefinition entryDefinition;

    private readonly string charId;

    /// <summary>
    /// Creates a new instance retrieving information about a characters unlocked achievements
    /// </summary>
    /// <param name="client">Lodestone client instance</param>
    /// <param name="rootNode">Root node of the achievement page</param>
    /// <param name="definition">Parse definition pack</param>
    /// <param name="charId">Id of the character</param>
    public CharacterAchievementPage(LodestoneClient client, HtmlNode rootNode, PagedDefinition definition,
        string charId) : base(rootNode)
    {
        this.client = client;
        this.charId = charId;

        this.pageDefinition = definition;
        this.entryDefinition = definition.Entry.ToObject<CharacterAchievementEntryDefinition>();
    }

    /// <summary>
    /// Total number of achievements
    /// </summary>
    public int TotalAchievements
    {
        get
        {
            var res = ParseRegex(this.entryDefinition.TotalAchievements);
            return int.Parse(res["TotalAchievements"].Value);
        }
    }

    /// <summary>
    /// Number of achievement points for this character
    /// </summary>
    public int AchievementPoints => int.Parse(Parse(this.entryDefinition.AchievementPoints));

    /// <summary>
    /// Indicates if this hold any results
    /// </summary>
    public bool HasResults => !HasNode(this.pageDefinition.NoResultsFound);

    private CharacterAchievementEntry[]? parsedResults;

    /// <summary>
    /// Unlocked achievements for character
    /// </summary>
    public IEnumerable<CharacterAchievementEntry> Achievements
    {
        get
        {
            if (!this.HasResults)
                return Array.Empty<CharacterAchievementEntry>();

            if (this.parsedResults == null)
                ParseSearchResults();

            return this.parsedResults!;
        }
    }

    private void ParseSearchResults()
    {
        var nodes = QueryContainer(this.pageDefinition);

        this.parsedResults = new CharacterAchievementEntry[nodes.Length];
        for (var i = 0; i < this.parsedResults.Length; i++)
        {
            this.parsedResults[i] = new CharacterAchievementEntry(nodes[i], this.entryDefinition);
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

    /// <inheritdoc/>
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

    /// <inheritdoc />
    public async Task<CharacterAchievementPage?> GetNextPage()
    {
        if (!this.HasResults)
            return null;

        if (this.CurrentPage == this.NumPages)
            return null;

        return await this.client.GetCharacterAchievement(this.charId, this.CurrentPage + 1);
    }
}