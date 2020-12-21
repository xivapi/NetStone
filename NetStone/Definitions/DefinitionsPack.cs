using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NetStone.Definitions
{
    public class DefinitionsPack
    {
        [JsonProperty("selector")] public string Selector { get; set; }
        [JsonProperty("regex")] public string Regex { get; set; }
        [JsonProperty("or")] public string Description { get; set; }
    }
}
