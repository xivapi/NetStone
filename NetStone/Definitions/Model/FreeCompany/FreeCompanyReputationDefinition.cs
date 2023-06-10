using Newtonsoft.Json;

namespace NetStone.Definitions.Model.FreeCompany;

/// <summary>
/// Definition for reputation of FC with GC
/// </summary>
public class FreeCompanyReputationEntryDefinition : IDefinition
{
    /// <summary>
    /// Name of the Grand Company
    /// </summary>
    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; }

    /// <summary>
    /// Progress to next rank
    /// </summary>
    [JsonProperty("PROGRESS")]
    public DefinitionsPack Progress { get; set; }

    /// <summary>
    /// Current Rank
    /// </summary>
    [JsonProperty("RANK")]
    public DefinitionsPack Rank { get; set; }
}

/// <summary>
/// Definition container for all reputations of a FC
/// </summary>
public class FreeCompanyReputationDefinition : IDefinition
{
    /// <summary>
    /// Maelstrom
    /// </summary>
    [JsonProperty("MAELSTROM")]
    public FreeCompanyReputationEntryDefinition Maelstrom { get; set; }

    /// <summary>
    /// Order of the Twin Adder
    /// </summary>
    [JsonProperty("ADDERS")]
    public FreeCompanyReputationEntryDefinition Adders { get; set; }

    /// <summary>
    /// Immortal Flames
    /// </summary>
    [JsonProperty("FLAMES")]
    public FreeCompanyReputationEntryDefinition Flames { get; set; }
}