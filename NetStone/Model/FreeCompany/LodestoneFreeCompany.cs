using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using NetStone.Definitions;
using NetStone.Definitions.Model.FreeCompany;
using NetStone.Model.Parseables;

namespace NetStone.Model.FreeCompany
{
    public class LodestoneFreeCompany : LodestoneParseable
    {
        private readonly LodestoneClient client;

        private readonly FreeCompanyDefinition fcDefinition;
        
        private readonly string id;
        
        public LodestoneFreeCompany(LodestoneClient client, HtmlNode rootNode, DefinitionsContainer definitions, string id) : base(rootNode)
        {
            this.client = client;
            this.id = id;

            this.fcDefinition = definitions.FreeCompany;
        }

        public string Name => Parse(this.fcDefinition.Name);
        
        public ulong Id => ParseHrefIdULong(this.fcDefinition.Id).GetValueOrDefault(0);

        public string Slogan => Parse(this.fcDefinition.Slogan);

        public string Tag => Parse(this.fcDefinition.Tag);

        public IconLayers CrestLayers => new IconLayers(this.RootNode, this.fcDefinition.CrestLayers);

        public DateTime Formed => ParseTime(this.fcDefinition.Formed);

        public string GrandCompany => Parse(this.fcDefinition.GrandCompany);

        public int Rank => int.Parse(Parse(this.fcDefinition.Rank));

        public int RankingMonthly => int.Parse(Parse(this.fcDefinition.Ranking.Monthly));
        
        public int RankingWeekly => int.Parse(Parse(this.fcDefinition.Ranking.Weekly));

        public string Recruitment => Parse(this.fcDefinition.Recruitment);

        public int ActiveMemberCount => int.Parse(Parse(this.fcDefinition.ActiveMemberCount));

        public string ActiveState => Parse(this.fcDefinition.Activestate);

        public FreeCompanyEstate Estate => new FreeCompanyEstate(this.RootNode, this.fcDefinition.EstateDefinition).GetOptional();
    }
}
