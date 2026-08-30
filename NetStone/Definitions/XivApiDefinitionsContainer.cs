using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.Character;
using NetStone.Definitions.Model.CWLS;
using NetStone.Definitions.Model.FreeCompany;
using NetStone.Definitions.Model.Linkshell;
using Newtonsoft.Json;

namespace NetStone.Definitions;

/// <summary>
/// Holds the definitions on how to find and parse values from Lodestone HTML
/// </summary>
public class XivApiDefinitionsContainer : DefinitionsContainer
{
    private const string DefinitionRepoBase = "https://raw.githubusercontent.com/Koenari/lodestone-css-selectors/main/";

    private readonly HttpClient client;

    /// <summary>
    /// Constructs this class without populating definitions
    /// </summary>
    public XivApiDefinitionsContainer()
    {
        this.client = new HttpClient
        {
            BaseAddress = new Uri(DefinitionRepoBase),
        };
    }

    /// <summary>
    /// Fetches current CSS selector definitions from xivapi/lodestone-css-selectors github repository.
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation</param>
    /// <exception cref="HttpRequestException"></exception>
    /// <exception cref="FormatException"></exception>
    /// <returns>Task for this operation</returns>
    public override async Task Reload(CancellationToken cancellationToken = default)
    {
        this.Meta = await GetDefinition<MetaDefinition>("meta.json", cancellationToken);

        this.Character = await GetDefinition<CharacterDefinition>("profile/character.json", cancellationToken);
        this.ClassJob = await GetDefinition<CharacterClassJobDefinition>("profile/classjob.json", cancellationToken);
        this.Gear = await GetDefinition<CharacterGearDefinition>("profile/gearset.json", cancellationToken);
        this.GearEntry = await GetDefinition<GearEntryDefinition>("profile/gearentry.json", cancellationToken);
        this.SoulCrystalEntry = await GetDefinition<SoulcrystalEntryDefinition>("profile/soulcrystal.json", cancellationToken);
        this.Attributes = await GetDefinition<CharacterAttributesDefinition>("profile/attributes.json", cancellationToken);
        this.Achievement = await GetDefinition<CharacterAchievementDefinition>("profile/achievements.json", cancellationToken);
        this.Mount = await GetDefinition<CharacterMountDefinition>("profile/mount.json", cancellationToken);
        this.Minion = await GetDefinition<CharacterMinionDefinition>("profile/minion.json", cancellationToken);

        this.FreeCompany = await GetDefinition<FreeCompanyDefinition>("freecompany/freecompany.json", cancellationToken);
        this.FreeCompanyFocus = await GetDefinition<FreeCompanyFocusDefinition>("freecompany/focus.json", cancellationToken);
        this.FreeCompanyReputation =
            await GetDefinition<FreeCompanyReputationDefinition>("freecompany/reputation.json", cancellationToken);

        this.FreeCompanyMembers = await GetDefinition<PagedDefinition<FreeCompanyMembersEntryDefinition>>("freecompany/members.json", cancellationToken);

        this.CharacterSearch = await GetDefinition<PagedDefinition<CharacterSearchEntryDefinition>>("search/character.json", cancellationToken);
        this.FreeCompanySearch = await GetDefinition<PagedDefinition<FreeCompanySearchEntryDefinition>>("search/freecompany.json", cancellationToken);
        
        this.CrossworldLinkshell = await GetDefinition<CrossworldLinkshellDefinition>("cwls/cwls.json", cancellationToken);
        this.CrossworldLinkshellMember = await GetDefinition<PagedDefinition<CrossworldLinkshellMemberEntryDefinition>>("cwls/members.json", cancellationToken);
        this.CrossworldLinkshellSearch = await GetDefinition<PagedDefinition<CrossworldLinkshellSearchEntryDefinition>>("search/cwls.json", cancellationToken);
        
        this.Linkshell = await GetDefinition<LinkshellDefinition>("linkshell/ls.json", cancellationToken);
        this.LinkshellMember = await GetDefinition<PagedDefinition<LinkshellMemberEntryDefinition>>("linkshell/members.json", cancellationToken);
        this.LinkshellSearch = await GetDefinition<PagedDefinition<LinkshellSearchEntryDefinition>>("search/linkshell.json", cancellationToken);
    }

    

    private async Task<T> GetDefinition<T>(string path, CancellationToken cancellationToken) where T : IDefinition
    {
        var json = await this.client.GetStringAsync(path);
        var result = JsonConvert.DeserializeObject<T>(json);
        return result == null ? throw new FormatException($"Could not parse definitions in {path}.") : result;
    }

    /// <inheritdoc />
    public override void Dispose()
    {
        this.client.Dispose();
    }
}