using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NetStone.Definitions.Model
{
    public class CharacterAchievementDefinition : IDefinition
    {
        [JsonProperty("LIST")] public DefinitionsPack List { get; set; }

        [JsonProperty("LIST_NEXT_BUTTON")] public DefinitionsPack ListNextButton { get; set; }

        [JsonProperty("ENTRY")] public DefinitionsPack Entry { get; set; }

        [JsonProperty("ID")] public DefinitionsPack Id { get; set; }

        [JsonProperty("TIME")] public DefinitionsPack Time { get; set; }
        
        [JsonProperty("ACTIVITY_DESCRIPTION")] public DefinitionsPack ActivityDescription { get; set; }

        [JsonProperty("NO_RESULTS_FOUND")] public DefinitionsPack NoResultsFound { get; set; }
        
        [JsonProperty("TOTAL_ACHIEVEMENTS")] public DefinitionsPack TotalAchievements { get; set; }
        
        [JsonProperty("ACHIEVEMENT_POINTS")] public DefinitionsPack AchievementPoints { get; set; }
        
        [JsonProperty("PAGE_INFO")] public DefinitionsPack PageInfo { get; set; }
    }
}
