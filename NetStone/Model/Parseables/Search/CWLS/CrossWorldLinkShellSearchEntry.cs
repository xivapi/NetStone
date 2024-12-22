using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model.CWLS;
using NetStone.Model.Parseables.Character;

namespace NetStone.Model.Parseables.Search.CWLS;

public class CrossWorldLinkShellSearchEntry : LodestoneParseable
{
    private readonly LodestoneClient client;
    private readonly CrossWorldLinkShellSearchEntryDefinition definition;

    ///
    public CrossWorldLinkShellSearchEntry(LodestoneClient client, HtmlNode rootNode, CrossWorldLinkShellSearchEntryDefinition definition) :
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
    
    public int ActiveMembers =>  int.TryParse(Parse(this.definition.ActiveMembers), out var parsed) ? parsed : -1;

    /// <summary>
    /// Fetch character profile
    /// </summary>
    /// <returns>Task of retrieving character</returns>
    public async Task<LodestoneCharacter?> GetCharacter() =>
        this.Id is null ? null : await this.client.GetCharacter(this.Id);

    ///<inheritdoc />
    public override string ToString() => this.Name;
}