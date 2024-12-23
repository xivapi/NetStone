using System.Collections.Generic;
using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;

namespace NetStone.Model.Parseables.Character.Achievement;

/// <summary>
/// Holds information about a characters unlocked achievements
/// </summary>
public class CharacterAchievementPage : PaginatedIdResult<CharacterAchievementPage, CharacterAchievementEntry, CharacterAchievementEntryDefinition>
{
    private readonly CharacterAchievementDefinition definition;

    /// <summary>
    /// Creates a new instance retrieving information about a characters unlocked achievements
    /// </summary>
    /// <param name="client">Lodestone client instance</param>
    /// <param name="rootNode">Root node of the achievement page</param>
    /// <param name="definition">Parse definition pack</param>
    /// <param name="charId">ID of the character</param>
    public CharacterAchievementPage(LodestoneClient client, HtmlNode rootNode, 
                                    CharacterAchievementDefinition definition,string charId) 
        : base(rootNode, definition, client.GetCharacterAchievement, charId)
    {
        this.definition = definition;
    }

    /// <summary>
    /// Total number of achievements
    /// </summary>
    public int TotalAchievements
    {
        get
        {
            var res = ParseRegex(this.definition.TotalAchievements);
            return int.Parse(res["TotalAchievements"].Value);
        }
    }

    /// <summary>
    /// Number of achievement points for this character
    /// </summary>
    public int AchievementPoints => int.Parse(Parse(this.definition.AchievementPoints));

    /// <summary>
    /// Unlocked achievements for character
    /// </summary>
    public IEnumerable<CharacterAchievementEntry> Achievements => this.Results;

    ///<inheritdoc />
    protected override CharacterAchievementEntry[] ParseResults()
    {
        var nodes = QueryContainer(this.definition);

        var parsedResults = new CharacterAchievementEntry[nodes.Length];
        for (var i = 0; i < parsedResults.Length; i++)
        {
            parsedResults[i] = new CharacterAchievementEntry(nodes[i], this.definition.Entry);
        }
        return parsedResults;
    }
}