using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model.Linkshell;
using NetStone.Model.Parseables.Linkshell;

namespace NetStone.Model.Parseables.Search.Linkshell;

/// <summary>
/// Models one entry in the linkshell search results list
/// </summary>
public class LinkshellSearchEntry : LodestoneParseable
{
    private readonly LodestoneClient client;
    private readonly LinkshellSearchEntryDefinition definition;

    ///
    public LinkshellSearchEntry(LodestoneClient client, HtmlNode rootNode, LinkshellSearchEntryDefinition definition) :
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
    /// Homeworld / Server
    /// </summary>
    public string HomeWorld => Parse(this.definition.Server);
    
    /// <summary>
    /// Number of active members
    /// </summary>
    public int ActiveMembers =>  int.TryParse(Parse(this.definition.ActiveMembers), out var parsed) ? parsed : -1;

    /// <summary>
    /// Fetch character profile
    /// </summary>
    /// <returns>Task of retrieving character</returns>
    public async Task<LodestoneLinkshell?> GetLinkshell() =>
        this.Id is null ? null : await this.client.GetLinkshell(this.Id);

    ///<inheritdoc />
    public override string ToString() => this.Name;
}