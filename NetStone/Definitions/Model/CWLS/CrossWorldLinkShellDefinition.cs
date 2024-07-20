using Newtonsoft.Json;

namespace NetStone.Definitions.Model.CWLS;

/// <summary>
/// Definitions for cross world link shell
/// </summary>
public class CrossWorldLinkShellDefinition : IDefinition
{
    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; }
    
    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("DC")]
    public DefinitionsPack DataCenter { get; set; }
}