using Newtonsoft.Json;

namespace NetStone.Definitions.Model.CWLS;
/// <summary>
/// Definition container for one Cross World Link Shell search result entry
/// </summary>
public class CrossworldLinkshellSearchEntryDefinition : PagedEntryDefinition
{
    /// <summary>
    /// ID
    /// </summary>
    [JsonProperty("ID")] public DefinitionsPack Id { get; set; }
    
    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }
    
    /// <summary>
    /// Rank
    /// </summary>
    [JsonProperty("DC")] public DefinitionsPack Dc { get; set; }
    
    /// <summary>
    /// Rank Icon
    /// </summary>
    [JsonProperty("ACTIVE_MEMBERS")] public DefinitionsPack ActiveMembers { get; set; }
}