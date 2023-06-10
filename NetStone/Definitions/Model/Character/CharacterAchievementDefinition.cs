using Newtonsoft.Json;

namespace NetStone.Definitions.Model.Character;

/// <summary>
/// Models the definition of one achievement entry for a character
/// </summary>
public class CharacterAchievementEntryDefinition : PagedEntryDefinition
{
    /// <summary>
    /// Root node of entry
    /// </summary>
    [JsonProperty("ROOT")]
    public new DefinitionsPack Root { get; set; }

    /// <summary>
    /// Achievement name
    /// </summary>
    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; }

    /// <summary>
    /// Id of this achievement
    /// </summary>
    [JsonProperty("ID")]
    public DefinitionsPack Id { get; set; }

    /// <summary>
    /// Time when this achievement was earned
    /// </summary>
    [JsonProperty("TIME")]
    public DefinitionsPack Time { get; set; }

    /// <summary>
    /// Info about pages
    /// </summary>
    [JsonProperty("PAGE_INFO")]
    public DefinitionsPack PageInfo { get; set; }

    /// <summary>
    /// Total number of achievements earned by this character
    /// </summary>
    [JsonProperty("TOTAL_ACHIEVEMENTS")]
    public DefinitionsPack TotalAchievements { get; set; }

    /// <summary>
    /// Total achievement points earned by this character
    /// </summary>
    [JsonProperty("ACHIEVEMENT_POINTS")]
    public DefinitionsPack AchievementPoints { get; set; }

    /// <summary>
    /// Full text displayed for this achievement
    /// </summary>
    [JsonProperty("ACTIVITY_DESCRIPTION")]
    public DefinitionsPack ActivityDescription { get; set; }
}