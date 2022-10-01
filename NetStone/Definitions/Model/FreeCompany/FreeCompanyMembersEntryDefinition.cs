using Newtonsoft.Json;

namespace NetStone.Definitions.Model.FreeCompany;

public class FreeCompanyMembersEntryDefinition : PagedEntryDefinition
{
    [JsonProperty("ROOT")] public DefinitionsPack Root { get; set; }
        
    [JsonProperty("AVATAR")] public DefinitionsPack Avatar { get; set; }
        
    [JsonProperty("ID")] public DefinitionsPack Id { get; set; }
        
    [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }
        
    [JsonProperty("RANK")] public DefinitionsPack Rank { get; set; }
        
    [JsonProperty("RANK_ICON")] public DefinitionsPack RankIcon { get; set; }
        
    [JsonProperty("SERVER")] public DefinitionsPack Server { get; set; }
}