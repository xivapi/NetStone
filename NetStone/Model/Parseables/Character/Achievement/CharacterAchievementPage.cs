using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.Character;

namespace NetStone.Model.Parseables.Character.Achievement;

public class CharacterAchievementPage : LodestoneParseable, IPaginatedResult<CharacterAchievementPage>
{
    private readonly LodestoneClient client;

    private readonly PagedDefinition pageDefinition;
    private readonly CharacterAchievementEntryDefinition entryDefinition;

    private readonly string charId;

    public CharacterAchievementPage(LodestoneClient client, HtmlNode rootNode, PagedDefinition definition,
        string charId) : base(rootNode)
    {
        this.client = client;
        this.charId = charId;

        this.pageDefinition = definition;
        this.entryDefinition = definition.Entry.ToObject<CharacterAchievementEntryDefinition>();
    }

    public int TotalAchievements
    {
        get
        {
            var res = ParseRegex(this.entryDefinition.TotalAchievements);
            return int.Parse(res["TotalAchievements"].Value);
        }
    }

    public int AchievementPoints => int.Parse(Parse(this.entryDefinition.AchievementPoints));

    public bool HasResults => !HasNode(this.pageDefinition.NoResultsFound);

    private CharacterAchievementEntry[] parsedResults;

    public IEnumerable<CharacterAchievementEntry> Achievements
    {
        get
        {
            if (!this.HasResults)
                return new CharacterAchievementEntry[0];

            if (this.parsedResults == null)
                ParseSearchResults();

            return this.parsedResults;
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

    public async Task<CharacterAchievementPage?> GetNextPage()
    {
        if (!this.HasResults)
            return null;

        if (this.CurrentPage == this.NumPages)
            return null;

        return await this.client.GetCharacterAchievement(this.charId, this.CurrentPage + 1);
    }
}