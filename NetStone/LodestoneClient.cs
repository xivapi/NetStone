using System;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions;
using NetStone.Model.Parseables;
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

        /// <summary>
        /// Get a character by its Lodestone ID.
        /// </summary>
        /// <param name="id">The ID of the character.</param>
        /// <returns><see cref="Character"/> class containing information about the character.</returns>
        public async Task<Character> GetCharacter(ulong id) => new Character(this, await GetRootNode($"/lodestone/character/{id}"), this.Definitions, id);

        /// <summary>
        /// Get a characters' class/job information by its Lodestone ID.
        /// You can also get this from the character directly by calling <see cref="Character.GetClassJobInfo()"/>.
        /// </summary>
        /// <param name="id">The ID of the character.</param>
        /// <returns><see cref="CharacterClassJob"/> class containing information about the characters' classes and jobs.</returns>
        public async Task<CharacterClassJob> GetCharacterClassJob(ulong id) => new CharacterClassJob(await GetRootNode($"/lodestone/character/{id}/class_job/"), this.Definitions.ClassJob);

        /// <summary>
        /// Get a characters' unlocked achievement information by its Lodestone ID.
        /// You can also get this from the character directly by calling <see cref="Character.GetClassJobInfo()"/>.
        /// </summary>
        /// <param name="id">The ID of the character.</param>
        /// <param name="page">The number of the page that should be fetched.</param>
        /// <returns><see cref="CharacterAchievementPage"/> class containing information about the characters' achievements.</returns>
        public async Task<CharacterAchievementPage> GetCharacterAchievement(ulong id, int page = 1) => new CharacterAchievementPage(this, await GetRootNode($"/lodestone/character/{id}/achievement/?page={page}"), this.Definitions.Achievement, id);
        
        public async Task<CharacterSearchPage> SearchCharacter(CharacterSearchQuery query, int page = 1) =>
            new CharacterSearchPage(this, await GetRootNode($"/lodestone/character/{query.BuildQueryString()}&page={page}"), this.Definitions.CharacterSearch, query);
        
        private async Task<HtmlNode> GetRootNode(string url, UserAgent agent = UserAgent.Desktop)
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
            
            var doc = new HtmlDocument();
            doc.LoadHtml(await this.client.GetStringAsync(url));

            return doc.DocumentNode;
        }

        public void Dispose()
        {
            this.client?.Dispose();
            Definitions?.Dispose();
        }
    }
}
