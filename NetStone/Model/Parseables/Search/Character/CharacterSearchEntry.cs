using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;
using NetStone.Model.Parseables.Character;

namespace NetStone.Model.Parseables.Search.Character;

/// <summary>
/// Models one entry in the character search results list
/// </summary>
public class CharacterSearchEntry : LodestoneParseable
{
    private readonly LodestoneClient client;
    private readonly CharacterSearchEntryDefinition definition;

    ///
    public CharacterSearchEntry(LodestoneClient client, HtmlNode rootNode, CharacterSearchEntryDefinition definition) :
        base(rootNode)
    {
        this.client = client;
        this.definition = definition;
    }

    /// <summary>
    /// Character name
    /// </summary>
    public string Name => Parse(this.definition.Name);

    /// <summary>
    /// Lodestone Id
    /// </summary>
    public string? Id => ParseHrefId(this.definition.Id);

    /// <summary>
    /// Fetch character profile
    /// </summary>
    /// <returns>Task of retrieving character</returns>
    public async Task<LodestoneCharacter?> GetCharacter() =>
        this.Id is null ? null : await this.client.GetCharacter(this.Id);

    ///<inheritdoc />
    public override string ToString() => this.Name;
}