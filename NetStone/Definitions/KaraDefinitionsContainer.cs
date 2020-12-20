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
            this.Character = await GetDefinition<CharacterDefinition>("profile/character.json");
            this.ClassJob = await GetDefinition<ClassJobDefinition>("profile/classjob.json");
            this.Gear = await GetDefinition<GearDefinition>("profile/gearset.json");
        }

        private async Task<T> GetDefinition<T>(string path)
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
