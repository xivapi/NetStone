using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.Character;
using NetStone.Definitions.Model.FreeCompany;
using NetStone.Model.Parseables.Character;

namespace NetStone.Model.Parseables.Search.FreeCompany
{
    public class FreeCompanySearchEntry : LodestoneParseable
    {
        private readonly LodestoneClient client;
        private readonly FreeCompanySearchEntryDefinition definition;

        public FreeCompanySearchEntry(LodestoneClient client, HtmlNode rootNode, FreeCompanySearchEntryDefinition definition) : base(rootNode)
        {
            this.client = client;
            this.definition = definition;
        }

        public string Name => Parse(this.definition.Name);

        public string Id => ParseHrefId(this.definition.Id);

        public async Task<LodestoneCharacter> GetCharacter() => await this.client.GetCharacter(this.Id);

        public override string ToString() => Name;
    }
}