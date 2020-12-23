using System;
using System.Net.Http;
using System.Threading.Tasks;
using NetStone.Definitions.Model;
using Newtonsoft.Json;

namespace NetStone.Definitions
{
    public class KaraDefinitionsContainer : DefinitionsContainer
    {
        private const string DefinitionRepoBase = "https://raw.githubusercontent.com/karashiiro/lodestone-css-selectors/main/";

        private readonly HttpClient client;

        public KaraDefinitionsContainer()
        {
            this.client = new HttpClient
            {
                BaseAddress = new Uri(DefinitionRepoBase)
            };
        }

        public override async Task Reload()
        {
            this.Meta = await GetDefinition<MetaDefinition>("meta.json");
            
            this.Character = await GetDefinition<CharacterDefinition>("profile/character.json");
            this.ClassJob = await GetDefinition<CharacterClassJobDefinition>("profile/classjob.json");
            this.Gear = await GetDefinition<CharacterGearDefinition>("profile/gearset.json");
            this.Attributes = await GetDefinition<CharacterAttributesDefinition>("profile/attributes.json");
            this.Achievement = await GetDefinition<CharacterAchievementDefinition>("profile/achievements.json");
            this.Mount = await GetDefinition<CharacterCollectableDefinition>("profile/mount.json");
            this.Minion = await GetDefinition<CharacterCollectableDefinition>("profile/minion.json");
            
            this.CharacterSearch = await GetDefinition<CharacterSearchDefinition>("search/character.json"); 
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
}
