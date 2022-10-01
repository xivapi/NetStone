using System;
using Newtonsoft.Json;

namespace NetStone.Definitions;

public class DefinitionsPack
{
    [JsonProperty("selector")] public string Selector { get; set; }
        
    [JsonProperty("regex")] public string PerlBasedRegex { get; set; }

    public string Regex => PerlBasedRegex?.Replace("(?P<", "(?<", StringComparison.InvariantCulture);

    [JsonProperty("or")] public string Description { get; set; }
        
    [JsonProperty("attribute")] public string Attribute { get; set; }
}