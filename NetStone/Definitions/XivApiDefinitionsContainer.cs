using System;
using System.Net.Http;
using System.Threading.Tasks;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.Character;
using NetStone.Definitions.Model.FreeCompany;
using Newtonsoft.Json;

namespace NetStone.Definitions;

public class XivApiDefinitionsContainer : DefinitionsContainer
{
    private const string DefinitionRepoBase = "https://raw.githubusercontent.com/xivapi/lodestone-css-selectors/main/";

    private readonly HttpClient client;

    public XivApiDefinitionsContainer()
    {
        this.client = new HttpClient
        {
            BaseAddress = new Uri(DefinitionRepoBase),
        };
    }

    public override async Task Reload()
    {
        this.Meta = await GetDefinition<MetaDefinition>("meta.json");

        this.Character = await GetDefinition<CharacterDefinition>("profile/character.json");
        this.ClassJob = await GetDefinition<CharacterClassJobDefinition>("profile/classjob.json");
        this.Gear = await GetDefinition<CharacterGearDefinition>("profile/gearset.json");
        this.Attributes = await GetDefinition<CharacterAttributesDefinition>("profile/attributes.json");
        this.Achievement = await GetDefinition<PagedDefinition>("profile/achievements.json");
        this.Mount = await GetDefinition<CharacterMountDefinition>("profile/mount.json");
        this.Minion = await GetDefinition<CharacterMinionDefinition>("profile/minion.json");

        this.FreeCompany = await GetDefinition<FreeCompanyDefinition>("freecompany/freecompany.json");
        this.FreeCompanyFocus = await GetDefinition<FreeCompanyFocusDefinition>("freecompany/focus.json");
        this.FreeCompanyReputation = await GetDefinition<FreeCompanyReputationDefinition>("freecompany/reputation.json");

        this.FreeCompanyMembers = await GetDefinition<PagedDefinition>("freecompany/members.json");

        this.CharacterSearch = await GetDefinition<PagedDefinition>("search/character.json");
        this.FreeCompanySearch = await GetDefinition<PagedDefinition>("search/freecompany.json");
    }

    private async Task<T> GetDefinition<T>(string path) where T : IDefinition
    {
        var json = await this.client.GetStringAsync(path);
        return JsonConvert.DeserializeObject<T>(json);
    }

    public override void Dispose()
    {
        this.client.Dispose();
    }
}