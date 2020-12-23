using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NetStone.Definitions.Model
{
    public class IconLayersDefinition : IDefinition
    {
        [JsonProperty("BOTTOM")] public DefinitionsPack Bottom { get; set; }

        [JsonProperty("MIDDLE")] public DefinitionsPack Middle { get; set; }

        [JsonProperty("TOP")] public DefinitionsPack Top { get; set; }
    }
}
