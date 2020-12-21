using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NetStone.Definitions.Model
{
    public class CharacterSearchEntryDefinition
    {
        [JsonProperty("AVATAR")] public DefinitionsPack Avatar { get; set; }

        [JsonProperty("ID")] public DefinitionsPack Id { get; set; }

        [JsonProperty("LANG")] public DefinitionsPack Lang { get; set; }

        [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }

        [JsonProperty("RANK")] public DefinitionsPack Rank { get; set; }

        [JsonProperty("RANK_ICON")] public DefinitionsPack RankIcon { get; set; }

        [JsonProperty("SERVER")] public DefinitionsPack Server { get; set; }

        [JsonProperty("ROOT")] public DefinitionsPack Root { get; set; }
    }

    public class CharacterSearchDefinition
    {
        [JsonProperty("ENTRIES_CONTAINER")] public DefinitionsPack EntriesContainer { get; set; }
        
        [JsonProperty("ENTRY")] public CharacterSearchEntryDefinition SingleEntry { get; set; }

        [JsonProperty("LIST_NEXT_BUTTON")] public DefinitionsPack ListNextButton { get; set; }

        [JsonProperty("PAGE_INFO")] public DefinitionsPack PageInfo { get; set; }
    }
}
