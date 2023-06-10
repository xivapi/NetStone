using Newtonsoft.Json;

namespace NetStone.Definitions.Model.Character;

/// <summary>
/// Definition pack for character search results
/// </summary>
public class CharacterSearchEntryDefinition : PagedEntryDefinition
{
    /// <summary>
    /// Avatar of character
    /// </summary>
    [JsonProperty("AVATAR")]
    public DefinitionsPack Avatar { get; set; }

    /// <summary>
    /// Lodestone Id
    /// </summary>
    [JsonProperty("ID")]
    public DefinitionsPack Id { get; set; }

    /// <summary>
    /// Language
    /// </summary>
    [JsonProperty("LANG")]
    public DefinitionsPack Lang { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; }

    /// <summary>
    /// Grand Company rank
    /// </summary>
    [JsonProperty("RANK")]
    public DefinitionsPack Rank { get; set; }

    /// <summary>
    /// Grand Company rank icon
    /// </summary>
    [JsonProperty("RANK_ICON")]
    public DefinitionsPack RankIcon { get; set; }

    /// <summary>
    /// Homeworld
    /// </summary>
    [JsonProperty("SERVER")]
    public DefinitionsPack Server { get; set; }

    /// <summary>
    /// Root node
    /// </summary>
    [JsonProperty("ROOT")]
    public DefinitionsPack Root { get; set; }
}