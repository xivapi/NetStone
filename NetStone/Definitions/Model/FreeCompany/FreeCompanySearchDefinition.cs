using Newtonsoft.Json;

namespace NetStone.Definitions.Model.FreeCompany;

public class FreeCompanySearchEntryDefinition : PagedEntryDefinition
{
    [JsonProperty("CREST_LAYERS")]
    public IconLayersDefinition CrestLayers { get; set; }

    [JsonProperty("ID")] public DefinitionsPack Id { get; set; }

    [JsonProperty("GRAND_COMPANY")] public DefinitionsPack GrandCompany { get; set; }

    [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }

    [JsonProperty("SERVER")] public DefinitionsPack Server { get; set; }

    [JsonProperty("ACTIVE")] public DefinitionsPack Active { get; set; }

    [JsonProperty("ACTIVE_MEMBERS")] public DefinitionsPack ActiveMembers { get; set; }

    [JsonProperty("RECRUITMENT_OPEN")] public DefinitionsPack RecruitmentOpen { get; set; }

    [JsonProperty("ESTATE_BUILT")] public DefinitionsPack EstateBuilt { get; set; }

    [JsonProperty("FORMED")] public DefinitionsPack Formed { get; set; }

    [JsonProperty("ROOT")] public new DefinitionsPack Root { get; set; }
}