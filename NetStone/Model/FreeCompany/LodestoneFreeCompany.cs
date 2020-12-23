using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using NetStone.Definitions;
using NetStone.Definitions.Model.FreeCompany;
using NetStone.Model.Parseables;

namespace NetStone.Model.FreeCompany
{
    class LodestoneFreeCompany : LodestoneParseable
    {
        private readonly LodestoneClient client;
        private readonly FreeCompanyDefinition fcDefinition;
        
        public LodestoneFreeCompany(LodestoneClient client, HtmlNode rootNode, DefinitionsContainer definitions) : base(rootNode)
        {
            this.client = client;
            
            this.fcDefinition = definitions.FreeCompany;
        }

        public string Name => Parse(this.fcDefinition.Name);
        
        public ulong Id => ParseHrefIdULong(this.fcDefinition.Id).GetValueOrDefault(0);

        public string Slogan => Parse(this.fcDefinition.Slogan);

        public string Tag => Parse(this.fcDefinition.Tag);

        public IconLayers CrestLayers => new IconLayers(this.RootNode, this.fcDefinition.CrestLayers);

        public DateTime Formed => ParseTime(this.fcDefinition.Formed);

        public string GrandCompany => Parse(this.fcDefinition.GrandCompany);

        public string Rank => Parse(this.fcDefinition.Rank);

        public string RankMonthly => Parse(this.fcDefinition.Ranking.Monthly);
        
        public string RankWeekly => Parse(this.fcDefinition.Ranking.Weekly);
    }
}
