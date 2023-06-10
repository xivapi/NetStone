using Newtonsoft.Json;

namespace NetStone.Definitions.Model.FreeCompany;

/// <summary>
/// Definition container for one Free Company search result entry
/// </summary>
public class FreeCompanySearchEntryDefinition : PagedEntryDefinition
{
    /// <summary>
    /// Crest layers
    /// </summary>
    [JsonProperty("CREST_LAYERS")]
    public IconLayersDefinition CrestLayers { get; set; }

    /// <summary>
    /// FC Id
    /// </summary>
    [JsonProperty("ID")]
    public DefinitionsPack Id { get; set; }

    /// <summary>
    /// Grand Company
    /// </summary>
    [JsonProperty("GRAND_COMPANY")]
    public DefinitionsPack GrandCompany { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; }

    /// <summary>
    /// World
    /// </summary>
    [JsonProperty("SERVER")]
    public DefinitionsPack Server { get; set; }

    /// <summary>
    /// FC active status
    /// </summary>
    [JsonProperty("ACTIVE")]
    public DefinitionsPack Active { get; set; }

    /// <summary>
    /// Active member count
    /// </summary>
    [JsonProperty("ACTIVE_MEMBERS")]
    public DefinitionsPack ActiveMembers { get; set; }

    /// <summary>
    /// Recruitment status
    /// </summary>
    [JsonProperty("RECRUITMENT_OPEN")]
    public DefinitionsPack RecruitmentOpen { get; set; }

    /// <summary>
    /// Estate state
    /// </summary>
    [JsonProperty("ESTATE_BUILT")]
    public DefinitionsPack EstateBuilt { get; set; }

    /// <summary>
    /// Formation date
    /// </summary>
    [JsonProperty("FORMED")]
    public DefinitionsPack Formed { get; set; }

    /// <summary>
    /// Root node
    /// </summary>
    [JsonProperty("ROOT")]
    public new DefinitionsPack Root { get; set; }
}