using Newtonsoft.Json;

namespace NetStone.Definitions.Model.FreeCompany;

public class FreeCompanyFocusEntryDefinition : IDefinition
{
    [JsonProperty("NAME")]
    public DefinitionsPack NAME { get; set; } 

    [JsonProperty("ICON")]
    public DefinitionsPack ICON { get; set; } 

    [JsonProperty("STATUS")]
    public DefinitionsPack STATUS { get; set; } 
}

public class FreeCompanyFocusDefinition : IDefinition
{
    [JsonProperty("NOT_SPECIFIED")]
    public DefinitionsPack NOTSPECIFIED { get; set; } 

    [JsonProperty("RP")]
    public FreeCompanyFocusEntryDefinition RolePlay { get; set; } 

    [JsonProperty("LEVELING")]
    public FreeCompanyFocusEntryDefinition Leveling { get; set; } 

    [JsonProperty("CASUAL")]
    public FreeCompanyFocusEntryDefinition Casual { get; set; } 

    [JsonProperty("HARDCORE")]
    public FreeCompanyFocusEntryDefinition Hardcore { get; set; } 

    [JsonProperty("DUNGEONS")]
    public FreeCompanyFocusEntryDefinition Dungeons { get; set; } 

    [JsonProperty("GUILDHESTS")]
    public FreeCompanyFocusEntryDefinition Guildhests { get; set; } 

    [JsonProperty("TRIALS")]
    public FreeCompanyFocusEntryDefinition Trials { get; set; } 

    [JsonProperty("RAIDS")]
    public FreeCompanyFocusEntryDefinition Raids { get; set; } 

    [JsonProperty("PVP")]
    public FreeCompanyFocusEntryDefinition PvP { get; set; } 
}