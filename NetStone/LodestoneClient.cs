using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions;
using NetStone.Model.FreeCompany;
using NetStone.Model.Parseables;
using NetStone.Model.Parseables.Character;
using NetStone.Model.Parseables.Character.Achievement;
using NetStone.Model.Parseables.Character.ClassJob;
using NetStone.Model.Parseables.Character.Collectable;
using NetStone.Model.Parseables.Search;
using NetStone.Search;

namespace NetStone
{
    /// <summary>
    /// The main Lodestone client class offering parsed information and search.
    /// </summary>
    public class LodestoneClient : IDisposable
    {
        //TODO: Switch to URLs in meta.json
        
        /// <summary>
        /// Container holding information about the current Lodestone layout, needed to parse responses.
        /// </summary>
        public DefinitionsContainer Definitions { get; }

        private readonly HttpClient client;

        /// <summary>
        /// Initialize a new Lodestone client with default options.
        /// </summary>
        public LodestoneClient()
        {
            this.client = new HttpClient
            {
                BaseAddress = new Uri(Constants.LodestoneBase)
            };

            Definitions = new KaraDefinitionsContainer();
            Definitions.Reload().GetAwaiter().GetResult();
        }

        #region Character

        /// <summary>
        /// Get a character by its Lodestone ID.
        /// </summary>
        /// <param name="id">The ID of the character.</param>
        /// <returns><see cref="LodestoneCharacter"/> class containing information about the character.</returns>
        public async Task<LodestoneCharacter> GetCharacter(string id) => new LodestoneCharacter(this, await GetRootNode($"/lodestone/character/{id}/"), this.Definitions, id);

        /// <summary>
        /// Get a characters' class/job information by its Lodestone ID.
        /// You can also get this from the character directly by calling <see cref="LodestoneCharacter.GetClassJobInfo()"/>.
        /// </summary>
        /// <param name="id">The ID of the character.</param>
        /// <returns><see cref="CharacterClassJob"/> class containing information about the characters' classes and jobs.</returns>
        public async Task<CharacterClassJob> GetCharacterClassJob(string id) => new CharacterClassJob(await GetRootNode($"/lodestone/character/{id}/class_job/"), this.Definitions.ClassJob);

        /// <summary>
        /// Get a characters' unlocked achievement information by its Lodestone ID.
        /// You can also get this from the character directly by calling <see cref="LodestoneCharacter.GetAchievement()"/>.
        /// </summary>
        /// <param name="id">The ID of the character.</param>
        /// <param name="page">The number of the page that should be fetched.</param>
        /// <returns><see cref="CharacterAchievementPage"/> class containing information about the characters' achievements.</returns>
        public async Task<CharacterAchievementPage> GetCharacterAchievement(string id, int page = 1) => new CharacterAchievementPage(this, await GetRootNode($"/lodestone/character/{id}/achievement/?page={page}"), this.Definitions.Achievement, id);
        
        /// <summary>
        /// Get a characters' unlocked mount information by its Lodestone ID.
        /// You can also get this from the character directly by calling <see cref="LodestoneCharacter.GetMounts()"/>.
        /// </summary>
        /// <param name="id">The ID of the character.</param>
        /// <returns><see cref="CharacterCollectable"/> class containing information about the characters' mounts.</returns>
        public async Task<CharacterCollectable> GetCharacterMount(string id) => new CharacterCollectable(await GetRootNode($"/lodestone/character/{id}/mount/", UserAgent.Mobile), this.Definitions.Mount);
        
        /// <summary>
        /// Get a characters' unlocked minion information by its Lodestone ID.
        /// You can also get this from the character directly by calling <see cref="LodestoneCharacter.GetMinions()"/>.
        /// </summary>
        /// <param name="id">The ID of the character.</param>
        /// <returns><see cref="CharacterCollectable"/> class containing information about the characters' minions.</returns>
        public async Task<CharacterCollectable> GetCharacterMinion(string id) => new CharacterCollectable(await GetRootNode($"/lodestone/character/{id}/minion/", UserAgent.Mobile), this.Definitions.Minion);
        
        /// <summary>
        /// Search lodestone for a character with the specified query.
        /// </summary>
        /// <param name="query"><see cref="CharacterSearchQuery"/> object detailing search parameters</param>
        /// <param name="page">The page of search results to fetch.</param>
        /// <returns><see cref="CharacterSearchPage"/> containing search results.</returns>
        public async Task<CharacterSearchPage> SearchCharacter(CharacterSearchQuery query, int page = 1) =>
            new CharacterSearchPage(this, await GetRootNode($"/lodestone/character/{query.BuildQueryString()}&page={page}"), this.Definitions.CharacterSearch, query);
        
        #endregion

        #region FreeCompany

        /// <summary>
        /// Get a character by its Lodestone ID.
        /// </summary>
        /// <param name="id">The ID of the character.</param>
        /// <returns><see cref="LodestoneFreeCompany"/> class containing information about the character.</returns>
        public async Task<LodestoneFreeCompany> GetFreeCompany(string id) => new LodestoneFreeCompany(this, await GetRootNode($"/lodestone/freecompany/{id}/"), this.Definitions, id);

        #endregion
        
        private async Task<HtmlNode> GetRootNode(string url, UserAgent agent = UserAgent.Desktop)
        {
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            
            switch (agent)
            {
                case UserAgent.Desktop:
                    request.Headers.UserAgent.ParseAdd(this.Definitions.Meta.UserAgentDesktop);
                    break;
                case UserAgent.Mobile:
                    request.Headers.UserAgent.ParseAdd("Mozilla/5.0 (iPhone; CPU OS 10_15_5 like Mac OS X) AppleWebKit/605.1.15 (KHTML, like Gecko) Version/12.1.1 Mobile/14E304 Safari/605.1.15");
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(agent), agent, null);
            }

            var response = await this.client.SendAsync(request);

            if (response.StatusCode == HttpStatusCode.NotFound)
                return null;

            var doc = new HtmlDocument();
            doc.LoadHtml(await response.Content.ReadAsStringAsync());

            return doc.DocumentNode;
        }

        public void Dispose()
        {
            this.client?.Dispose();
            Definitions?.Dispose();
        }
    }
}
