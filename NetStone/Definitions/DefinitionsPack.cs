using System;
using Newtonsoft.Json;

namespace NetStone.Definitions;

/// <summary>
/// Models the definition on how to extract information from the Lodestone HTML document
/// </summary>
public class DefinitionsPack
{
    /// <summary>
    /// Hold a CSS selector to get the relevant html node from the DOM
    /// </summary>
    [JsonProperty("selector")]
    public string Selector { get; set; }

    /// <summary>
    /// A perl regex to extract the relevant information from the inner text of the relevant node
    /// </summary>
    [JsonProperty("regex")]
    public string? PerlBasedRegex { get; set; }

    /// <summary>
    /// C# usable regex based on <see cref="PerlBasedRegex"/>
    /// </summary>
    public string? Regex => this.PerlBasedRegex?.Replace("(?P<", "(?<", StringComparison.InvariantCulture);

    //Never used
    //[JsonProperty("or")] public string Description { get; set; }

    /// <summary>
    /// HTML attribute that holds information. Only set if data is not in the inner text
    /// </summary>
    [JsonProperty("attribute")]
    public string? Attribute { get; set; }
}