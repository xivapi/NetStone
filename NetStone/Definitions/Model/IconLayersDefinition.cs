using Newtonsoft.Json;

namespace NetStone.Definitions.Model;

/// <summary>
/// Definition for an icon with multiple layers
/// </summary>
public class IconLayersDefinition : IDefinition
{
    /// <summary>
    /// Bottom layer
    /// </summary>
    [JsonProperty("BOTTOM")]
    public DefinitionsPack Bottom { get; set; }

    /// <summary>
    /// Middle layer
    /// </summary>
    [JsonProperty("MIDDLE")]
    public DefinitionsPack Middle { get; set; }

    /// <summary>
    /// Top layer
    /// </summary>
    [JsonProperty("TOP")]
    public DefinitionsPack Top { get; set; }
}