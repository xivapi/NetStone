using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;
using NetStone.Model.Parseables.Character;

namespace NetStone.Model.Parseables.Search.Character;

public class CharacterSearchEntry : LodestoneParseable
{
    private readonly LodestoneClient client;
    private readonly CharacterSearchEntryDefinition definition;

    public CharacterSearchEntry(LodestoneClient client, HtmlNode rootNode, CharacterSearchEntryDefinition definition) : base(rootNode)
    {
        this.client = client;
        this.definition = definition;
    }

    public string Name => Parse(this.definition.Name);

    public string Id => ParseHrefId(this.definition.Id);

    public async Task<LodestoneCharacter?> GetCharacter() => await this.client.GetCharacter(this.Id);

    public override string ToString() => Name;
}