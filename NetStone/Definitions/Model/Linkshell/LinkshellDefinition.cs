using Newtonsoft.Json;

namespace NetStone.Definitions.Model.Linkshell;

/// <summary>
/// Definitions for link shell
/// </summary>
public class LinkshellDefinition : IDefinition
{
    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; }
}