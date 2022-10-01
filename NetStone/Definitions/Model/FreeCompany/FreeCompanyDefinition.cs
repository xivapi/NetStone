using Newtonsoft.Json;

namespace NetStone.Definitions.Model.FreeCompany;

public class EstateDefinition : IDefinition   {
    [JsonProperty("NO_ESTATE")]
    public DefinitionsPack NoEstate { get; set; } 

    [JsonProperty("GREETING")]
    public DefinitionsPack Greeting { get; set; } 

    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; } 

    [JsonProperty("PLOT")]
    public DefinitionsPack Plot { get; set; } 
}
    
public class Ranking    {
    [JsonProperty("WEEKLY")]
    public DefinitionsPack Weekly { get; set; } 

    [JsonProperty("MONTHLY")]
    public DefinitionsPack Monthly { get; set; } 
}
    
public class FreeCompanyDefinition : IDefinition
{
    [JsonProperty("ACTIVE_STATE")]
    public DefinitionsPack Activestate { get; set; } 

    [JsonProperty("ACTIVE_MEMBER_COUNT")]
    public DefinitionsPack ActiveMemberCount { get; set; } 

    [JsonProperty("CREST_LAYERS")]
    public IconLayersDefinition CrestLayers { get; set; } 

    [JsonProperty("ESTATE")]
    public EstateDefinition EstateDefinition { get; set; } 

    [JsonProperty("FORMED")]
    public DefinitionsPack Formed { get; set; } 

    [JsonProperty("GRAND_COMPANY")]
    public DefinitionsPack GrandCompany { get; set; } 

    [JsonProperty("ID")]
    public DefinitionsPack Id { get; set; } 

    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; } 

    [JsonProperty("RANK")]
    public DefinitionsPack Rank { get; set; } 

    [JsonProperty("RANKING")]
    public Ranking Ranking { get; set; } 

    [JsonProperty("RECRUITMENT")]
    public DefinitionsPack Recruitment { get; set; } 

    [JsonProperty("SERVER")]
    public DefinitionsPack Server { get; set; } 

    [JsonProperty("SLOGAN")]
    public DefinitionsPack Slogan { get; set; } 

    [JsonProperty("TAG")]
    public DefinitionsPack Tag { get; set; } 
}