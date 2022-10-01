using Newtonsoft.Json;

namespace NetStone.Definitions.Model.FreeCompany;

public class FreeCompanyReputationEntryDefinition : IDefinition
{
    [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }
        
    [JsonProperty("PROGRESS")] public DefinitionsPack Progress { get; set; }
        
    [JsonProperty("RANK")] public DefinitionsPack Rank { get; set; }
}

public class FreeCompanyReputationDefinition : IDefinition
{
    [JsonProperty("MAELSTROM")] public FreeCompanyReputationEntryDefinition Maelstrom { get; set; }
        
    [JsonProperty("ADDERS")] public FreeCompanyReputationEntryDefinition Adders { get; set; }
        
    [JsonProperty("FLAMES")] public FreeCompanyReputationEntryDefinition Flames { get; set; }
}