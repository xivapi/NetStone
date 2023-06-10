using Newtonsoft.Json;

namespace NetStone.Definitions.Model.FreeCompany;

/// <summary>
/// Definitions for FC estate
/// </summary>
public class EstateDefinition : IDefinition
{
    /// <summary>
    /// Definition for empty estate
    /// </summary>
    [JsonProperty("NO_ESTATE")]
    public DefinitionsPack NoEstate { get; set; }

    /// <summary>
    /// Greeting
    /// </summary>
    [JsonProperty("GREETING")]
    public DefinitionsPack Greeting { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; }

    /// <summary>
    /// Plot
    /// </summary>
    [JsonProperty("PLOT")]
    public DefinitionsPack Plot { get; set; }
}

/// <summary>
/// Ranking definitions
/// </summary>
public class Ranking
{
    /// <summary>
    /// Weekly ranking
    /// </summary>
    [JsonProperty("WEEKLY")]
    public DefinitionsPack Weekly { get; set; }

    /// <summary>
    /// Monthly ranking
    /// </summary>
    [JsonProperty("MONTHLY")]
    public DefinitionsPack Monthly { get; set; }
}

/// <summary>
/// Definitions for free company profile
/// </summary>
public class FreeCompanyDefinition : IDefinition
{
    /// <summary>
    /// Is Active
    /// </summary>
    [JsonProperty("ACTIVE_STATE")]
    public DefinitionsPack Activestate { get; set; }

    /// <summary>
    /// Active member count
    /// </summary>
    [JsonProperty("ACTIVE_MEMBER_COUNT")]
    public DefinitionsPack ActiveMemberCount { get; set; }

    /// <summary>
    /// Layers of the crest
    /// </summary>
    [JsonProperty("CREST_LAYERS")]
    public IconLayersDefinition CrestLayers { get; set; }

    /// <summary>
    /// Information about estate
    /// </summary>
    [JsonProperty("ESTATE")]
    public EstateDefinition EstateDefinition { get; set; }

    /// <summary>
    /// Foundation date
    /// </summary>
    [JsonProperty("FORMED")]
    public DefinitionsPack Formed { get; set; }

    /// <summary>
    /// Grand company
    /// </summary>
    [JsonProperty("GRAND_COMPANY")]
    public DefinitionsPack GrandCompany { get; set; }

    /// <summary>
    /// Id
    /// </summary>
    [JsonProperty("ID")]
    public DefinitionsPack Id { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; }

    /// <summary>
    /// Rank
    /// </summary>
    [JsonProperty("RANK")]
    public DefinitionsPack Rank { get; set; }

    /// <summary>
    /// Rankings
    /// </summary>
    [JsonProperty("RANKING")]
    public Ranking Ranking { get; set; }

    /// <summary>
    /// Recruitment info
    /// </summary>
    [JsonProperty("RECRUITMENT")]
    public DefinitionsPack Recruitment { get; set; }

    /// <summary>
    /// World
    /// </summary>
    [JsonProperty("SERVER")]
    public DefinitionsPack Server { get; set; }

    /// <summary>
    /// Slogan
    /// </summary>
    [JsonProperty("SLOGAN")]
    public DefinitionsPack Slogan { get; set; }

    /// <summary>
    /// Tags
    /// </summary>
    [JsonProperty("TAG")]
    public DefinitionsPack Tag { get; set; }
}