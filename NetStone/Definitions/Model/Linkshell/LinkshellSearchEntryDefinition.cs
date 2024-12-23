using Newtonsoft.Json;

namespace NetStone.Definitions.Model.Linkshell;

/// <summary>
/// Definition container for one Link-Shell search result entry
/// </summary>
public class LinkshellSearchEntryDefinition : PagedEntryDefinition
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
    [JsonProperty("SERVER")] public DefinitionsPack Server { get; set; }
    
    /// <summary>
    /// Rank Icon
    /// </summary>
    [JsonProperty("ACTIVE_MEMBERS")] public DefinitionsPack ActiveMembers { get; set; }
}