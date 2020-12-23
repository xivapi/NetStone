using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NetStone.Definitions.Model
{
    public class CharacterCollectableDefinition : IDefinition
    {
        [JsonProperty("LIST")] public DefinitionsPack List { get; set; }

        [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }
    }
}
