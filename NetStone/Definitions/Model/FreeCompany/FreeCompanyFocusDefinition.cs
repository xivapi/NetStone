using Newtonsoft.Json;

namespace NetStone.Definitions.Model.FreeCompany;

/// <summary>
/// Definition for one type of FC foc
/// us
/// </summary>
public class FreeCompanyFocusEntryDefinition : IDefinition
{
    /// <summary>
    /// Name of type
    /// </summary>
    [JsonProperty("NAME")]
    public DefinitionsPack NAME { get; set; }

    /// <summary>
    /// Icon for type
    /// </summary>
    [JsonProperty("ICON")]
    public DefinitionsPack ICON { get; set; }

    /// <summary>
    /// Status (if company focuses on this)
    /// </summary>
    [JsonProperty("STATUS")]
    public DefinitionsPack STATUS { get; set; }
}

/// <summary>
/// Definition container for all FC focus types
/// </summary>
public class FreeCompanyFocusDefinition : IDefinition
{
    /// <summary>
    /// No focus specified
    /// </summary>
    [JsonProperty("NOT_SPECIFIED")]
    public DefinitionsPack NOTSPECIFIED { get; set; }

    /// <summary>
    /// Role play
    /// </summary>
    [JsonProperty("RP")]
    public FreeCompanyFocusEntryDefinition RolePlay { get; set; }

    /// <summary>
    /// Leveling
    /// </summary>
    [JsonProperty("LEVELING")]
    public FreeCompanyFocusEntryDefinition Leveling { get; set; }

    /// <summary>
    /// Casual
    /// </summary>
    [JsonProperty("CASUAL")]
    public FreeCompanyFocusEntryDefinition Casual { get; set; }

    /// <summary>
    /// Hardcore
    /// </summary>
    [JsonProperty("HARDCORE")]
    public FreeCompanyFocusEntryDefinition Hardcore { get; set; }

    /// <summary>
    /// Dungeons
    /// </summary>
    [JsonProperty("DUNGEONS")]
    public FreeCompanyFocusEntryDefinition Dungeons { get; set; }

    /// <summary>
    /// Guild hests
    /// </summary>
    [JsonProperty("GUILDHESTS")]
    public FreeCompanyFocusEntryDefinition Guildhests { get; set; }

    /// <summary>
    /// Trials
    /// </summary>
    [JsonProperty("TRIALS")]
    public FreeCompanyFocusEntryDefinition Trials { get; set; }

    /// <summary>
    /// Raids
    /// </summary>
    [JsonProperty("RAIDS")]
    public FreeCompanyFocusEntryDefinition Raids { get; set; }

    /// <summary>
    /// PvP
    /// </summary>
    [JsonProperty("PVP")]
    public FreeCompanyFocusEntryDefinition PvP { get; set; }
}