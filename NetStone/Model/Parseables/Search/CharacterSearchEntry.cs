using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model;

namespace NetStone.Model.Parseables.Search
{
    public class CharacterSearchEntry : LodestoneParseable
    {
        private readonly LodestoneClient client;
        private readonly CharacterSearchEntryDefinition definition;

        public CharacterSearchEntry(LodestoneClient client, HtmlNode rootNode, CharacterSearchEntryDefinition definition) : base(rootNode)
        {
            this.client = client;
            this.definition = definition;
        }

        public string Name => ParseInnerText(this.definition.Name);

        public ulong? Id => ParseHrefIdULong(this.definition.Id);

        public async Task<Character> GetCharacter() => await this.client.GetCharacter(this.Id.Value);
        
        public override string ToString() => Name;
    }
}
