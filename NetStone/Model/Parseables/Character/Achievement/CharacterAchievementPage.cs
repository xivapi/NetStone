using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions;
using NetStone.Definitions.Model;

namespace NetStone.Model.Parseables.Character.Achievement
{
    public class CharacterAchievementPage : LodestoneParseable, IPaginatedResult<CharacterAchievementPage>
    {
        private readonly LodestoneClient client;
        private readonly CharacterAchievementDefinition definition;
        
        private readonly ulong charId;

        public CharacterAchievementPage(LodestoneClient client, HtmlNode rootNode, CharacterAchievementDefinition definition, ulong charId) : base(rootNode)
        {
            this.client = client;
            this.definition = definition;
            this.charId = charId;
        }

        public int TotalAchievements
        {
            get
            {
                var res = ParseRegex(this.definition.TotalAchievements);
                return int.Parse(res["TotalAchievements"].Value);
            }
        }

        public int AchievementPoints => Int32.Parse(Parse(this.definition.AchievementPoints));

        public bool HasResults => !HasNode(this.definition.NoResultsFound);

        private CharacterAchievementEntry[] parsedResults;
        public IEnumerable<CharacterAchievementEntry> Achievements
        {
            get
            {
                if (!HasResults)
                    return new CharacterAchievementEntry[0];
                
                if (this.parsedResults == null)
                    ParseSearchResults();

                return this.parsedResults;
            }
        }

        private void ParseSearchResults()
        {
            var nodes = QueryChildNodes(this.definition.List);

            this.parsedResults = new CharacterAchievementEntry[nodes.Length];
            for (var i = 0; i < this.parsedResults.Length; i++)
            {
                this.parsedResults[i] = new CharacterAchievementEntry(this.client, nodes[i], this.definition);
            }
        }

        private int? currentPageVal;
        public int CurrentPage
        {
            get
            {
                if (!HasResults)
                    return 0;
                
                if (!this.currentPageVal.HasValue)
                    ParsePagesCount();

                return this.currentPageVal.Value;
            }
        }

        private int? numPagesVal;
        public int NumPages
        {
            get
            {
                if (!HasResults)
                    return 0;
                
                if (!this.numPagesVal.HasValue)
                    ParsePagesCount();

                return this.numPagesVal.Value;
            }
        }

        private void ParsePagesCount()
        {
            var results = ParseRegex(this.definition.PageInfo);

            this.currentPageVal = int.Parse(results["CurrentPage"].Value);
            this.numPagesVal = int.Parse(results["NumPages"].Value);
        }
        
        public async Task<CharacterAchievementPage> GetNextPage()
        {
            if (!HasResults)
                return null;
            
            if (CurrentPage == NumPages)
                return null;

            return await this.client.GetCharacterAchievement(this.charId, CurrentPage + 1);
        }
    }
}
