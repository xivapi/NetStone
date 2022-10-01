using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions;
using NetStone.GameData;
using NetStone.Model;
using NetStone.Model.Parseables.Character;
using NetStone.Model.Parseables.Character.Achievement;
using NetStone.Model.Parseables.Character.ClassJob;
using NetStone.Model.Parseables.Character.Collectable;
using NetStone.Model.Parseables.FreeCompany;
using NetStone.Model.Parseables.FreeCompany.Members;
using NetStone.Model.Parseables.Search.Character;
using NetStone.Model.Parseables.Search.FreeCompany;
using NetStone.Search.Character;
using NetStone.Search.FreeCompany;

namespace NetStone;

/// <summary>
/// The main Lodestone client class offering parsed information and search.
/// </summary>
public class LodestoneClient : IDisposable
{
    // TODO: Switch to URLs in meta.json

    /// <summary>
    /// Container holding information about the current Lodestone layout, needed to parse responses.
    /// </summary>
    public DefinitionsContainer Definitions { get; }

    /// <summary>
    /// The service providing game data to the Lodestone parser.
    /// </summary>
    public IGameDataProvider? Data { get; set; }

    private readonly HttpClient client;

    /// <summary>
    /// Initialize a new Lodestone client with default options.
    /// </summary>
    private LodestoneClient(DefinitionsContainer definitions, IGameDataProvider? gameData = null,
        string lodestoneBaseAddress = Constants.LodestoneBase)
    {
        this.client = new HttpClient
        {
            BaseAddress = new Uri(lodestoneBaseAddress),
        };

        Definitions = definitions;
        Data = gameData;
    }

    public static async Task<LodestoneClient> GetClientAsync(IGameDataProvider? gameData = null,
        string lodestoneBaseAddress = Constants.LodestoneBase)
    {
        var defs = new XivApiDefinitionsContainer();
        await defs.Reload();

        return new LodestoneClient(defs, gameData, lodestoneBaseAddress);
    }

    #region Character

    /// <summary>
    /// Get a character by its Lodestone ID.
    /// </summary>
    /// <param name="id">The ID of the character.</param>
    /// <returns><see cref="LodestoneCharacter"/> class containing information about the character.</returns>
    public async Task<LodestoneCharacter?> GetCharacter(string id) => await GetParsed($"/lodestone/character/{id}/",
        node => new LodestoneCharacter(this, node, this.Definitions, id));

    /// <summary>
    /// Get a characters' class/job information by its Lodestone ID.
    /// You can also get this from the character directly by calling <see cref="LodestoneCharacter.GetClassJobInfo()"/>.
    /// </summary>
    /// <param name="id">The ID of the character.</param>
    /// <returns><see cref="CharacterClassJob"/> class containing information about the characters' classes and jobs.</returns>
    public async Task<CharacterClassJob?> GetCharacterClassJob(string id) => await GetParsed(
        $"/lodestone/character/{id}/class_job/", node => new CharacterClassJob(node, this.Definitions.ClassJob));

    /// <summary>
    /// Get a characters' unlocked achievement information by its Lodestone ID.
    /// You can also get this from the character directly by calling <see cref="LodestoneCharacter.GetAchievement()"/>.
    /// </summary>
    /// <param name="id">The ID of the character.</param>
    /// <param name="page">The number of the page that should be fetched.</param>
    /// <returns><see cref="CharacterAchievementPage"/> class containing information about the characters' achievements.</returns>
    public async Task<CharacterAchievementPage?> GetCharacterAchievement(string id, int page = 1) =>
        await GetParsed(
            $"/lodestone/character/{id}/achievement/?page={page}",
            node => new CharacterAchievementPage(this, node, this.Definitions.Achievement, id));

    /// <summary>
    /// Get a characters' unlocked mount information by its Lodestone ID.
    /// You can also get this from the character directly by calling <see cref="LodestoneCharacter.GetMounts()"/>.
    /// </summary>
    /// <param name="id">The ID of the character.</param>
    /// <returns><see cref="CharacterCollectable"/> class containing information about the characters' mounts.</returns>
    public async Task<CharacterCollectable?> GetCharacterMount(string id) => await GetParsed(
        $"/lodestone/character/{id}/mount/",
        node => new CharacterCollectable(node, this.Definitions.Mount),
        UserAgent.Mobile);

    /// <summary>
    /// Get a characters' unlocked minion information by its Lodestone ID.
    /// You can also get this from the character directly by calling <see cref="LodestoneCharacter.GetMinions()"/>.
    /// </summary>
    /// <param name="id">The ID of the character.</param>
    /// <returns><see cref="CharacterCollectable"/> class containing information about the characters' minions.</returns>
    public async Task<CharacterCollectable?> GetCharacterMinion(string id) => await GetParsed(
        $"/lodestone/character/{id}/minion/",
        node => new CharacterCollectable(node, this.Definitions.Minion),
        UserAgent.Mobile);

    /// <summary>
    /// Search lodestone for a character with the specified query.
    /// </summary>
    /// <param name="query"><see cref="CharacterSearchQuery"/> object detailing search parameters</param>
    /// <param name="page">The page of search results to fetch.</param>
    /// <returns><see cref="CharacterSearchPage"/> containing search results.</returns>
    public async Task<CharacterSearchPage?> SearchCharacter(CharacterSearchQuery query, int page = 1) =>
        await GetParsed($"/lodestone/character/{query.BuildQueryString()}&page={page}",
            node => new CharacterSearchPage(this, node, this.Definitions.CharacterSearch, query));

    #endregion

    #region FreeCompany

    /// <summary>
    /// Get a character by its Lodestone ID.
    /// </summary>
    /// <param name="id">The ID of the character.</param>
    /// <returns><see cref="LodestoneFreeCompany"/> class containing information about the character.</returns>
    public async Task<LodestoneFreeCompany?> GetFreeCompany(string id) => await GetParsed(
        $"/lodestone/freecompany/{id}/", node => new LodestoneFreeCompany(this, node, this.Definitions, id));

    /// <summary>
    /// Get the members of a Free Company
    /// </summary>
    /// <param name="id">The ID of the free company.</param>
    /// <param name="page">The page of members to fetch.</param>
    /// <returns><see cref="FreeCompanyMembers"/> class containing information about FC members.</returns>
    public async Task<FreeCompanyMembers?> GetFreeCompanyMembers(string id, int page = 1) => await GetParsed(
        $"/lodestone/freecompany/{id}/member/?page={page}",
        node => new FreeCompanyMembers(this, node, this.Definitions.FreeCompanyMembers, id));

    /// <summary>
    /// Search lodestone for a free company with the specified query.
    /// </summary>
    /// <param name="query"><see cref="FreeCompanySearchPage"/> object detailing search parameters.</param>
    /// <param name="page">The page of search results to fetch.</param>
    /// <returns><see cref="FreeCompanySearchPage"/> containing search results.</returns>
    public async Task<FreeCompanySearchPage?> SearchFreeCompany(FreeCompanySearchQuery query, int page = 1) =>
        await GetParsed($"/lodestone/freecompany/{query.BuildQueryString()}&page={page}",
            node => new FreeCompanySearchPage(this, node, this.Definitions.FreeCompanySearch, query));

    #endregion

    /// <summary>
    /// Get the instantiated LodestoneParseable if the request succeeded, or null in case of StatusCode.NotFound.
    /// </summary>
    /// <typeparam name="T">The LodestoneParseable descendant to instantiate.</typeparam>
    /// <param name="url">The URL to fetch.</param>
    /// <param name="createParseable">Func creating the LodestoneParseable.</param>
    /// <param name="agent">The user agent to use for the request.</param>
    /// <returns>The instantiated LodestoneParseable in case of success.</returns>
    private async Task<T?> GetParsed<T>(string url, Func<HtmlNode, T?> createParseable,
        UserAgent agent = UserAgent.Desktop) where T : LodestoneParseable
    {
        var request = new HttpRequestMessage(HttpMethod.Get, url);

        switch (agent)
        {
            case UserAgent.Desktop:
                request.Headers.UserAgent.ParseAdd(this.Definitions.Meta.UserAgentDesktop);
                break;
            case UserAgent.Mobile:
                request.Headers.UserAgent.ParseAdd(this.Definitions.Meta.UserAgentMobile);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(agent), agent, null);
        }

        var response = await this.client.SendAsync(request);

        if (response.StatusCode == HttpStatusCode.NotFound)
            return null;

        var doc = new HtmlDocument();
        doc.LoadHtml(await response.Content.ReadAsStringAsync());

        return createParseable.Invoke(doc.DocumentNode);
    }

    /// <inheritdoc />
    public void Dispose()
    {
        this.client.Dispose();
        Definitions.Dispose();
    }
}