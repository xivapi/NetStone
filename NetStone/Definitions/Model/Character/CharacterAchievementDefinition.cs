using Newtonsoft.Json;

namespace NetStone.Definitions.Model.Character;

public class CharacterAchievementEntryDefinition : PagedEntryDefinition
{
    [JsonProperty("ROOT")] public DefinitionsPack Root { get; set; }

    [JsonProperty("ID")] public DefinitionsPack Id { get; set; }

    [JsonProperty("TIME")] public DefinitionsPack Time { get; set; }

    [JsonProperty("PAGE_INFO")] public DefinitionsPack PageInfo { get; set; }

    [JsonProperty("TOTAL_ACHIEVEMENTS")] public DefinitionsPack TotalAchievements { get; set; }

    [JsonProperty("ACHIEVEMENT_POINTS")] public DefinitionsPack AchievementPoints { get; set; }

    [JsonProperty("ACTIVITY_DESCRIPTION")] public DefinitionsPack ActivityDescription { get; set; }
}