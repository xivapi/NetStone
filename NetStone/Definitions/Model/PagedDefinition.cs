using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace NetStone.Definitions.Model;

public class PagedDefinition : IDefinition
{
    [JsonProperty("ROOT")] public DefinitionsPack Root { get; set; }

    // TODO: this is a bit cheap, maybe think of something better
    [JsonProperty("ENTRY")] public JObject Entry { get; set; }

    [JsonProperty("PAGE_INFO")] public DefinitionsPack PageInfo { get; set; }

    [JsonProperty("LIST_NEXT_BUTTON")] public DefinitionsPack ListNextButton { get; set; }

    [JsonProperty("NO_RESULTS_FOUND")] public DefinitionsPack NoResultsFound { get; set; }
}

public class PagedEntryDefinition
{
    public DefinitionsPack Root { get; set; }
}