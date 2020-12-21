using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions;
using NetStone.Definitions.Model;
using NetStone.Search;

namespace NetStone.Model.Parseables.Search
{
    public class CharacterSearchPage : LodestoneParseable, IPaginatedResult<CharacterSearchPage>
    {
        private readonly LodestoneClient client;
        private readonly CharacterSearchDefinition definition;
        private readonly CharacterSearchQuery currentQuery;

        public CharacterSearchPage(LodestoneClient client, HtmlNode rootNode, CharacterSearchDefinition definition, CharacterSearchQuery currentQuery) : base(rootNode)
        {
            this.client = client;
            this.definition = definition;
            this.currentQuery = currentQuery;
        }

        private CharacterSearchEntry[] parsedResults;
        public CharacterSearchEntry[] Results
        {
            get
            {
                if (this.parsedResults == null)
                    ParseSearchResults();

                return this.parsedResults;
            }
        }

        private void ParseSearchResults()
        {
            var container = QueryNode(this.definition.EntriesContainer.Selector).QuerySelectorAll(this.definition.SingleEntry.Root.Selector);

            this.parsedResults = new CharacterSearchEntry[container.Count];
            for (var i = 0; i < this.parsedResults.Length; i++)
            {
                this.parsedResults[i] = new CharacterSearchEntry(this.client, container[i], this.definition.SingleEntry);
            }
        }

        private int? currentPageVal;
        public int CurrentPage
        {
            get
            {
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
                if (!this.numPagesVal.HasValue)
                    ParsePagesCount();

                return this.numPagesVal.Value;
            }
        }

        private void ParsePagesCount()
        {
            var results = ParseInnerTextRegex(this.definition.PageInfo);

            this.currentPageVal = int.Parse(results["CurrentPage"].Value);
            this.numPagesVal = int.Parse(results["NumPages"].Value);
        }
        
        public async Task<CharacterSearchPage> GetNextPage()
        {
            if (CurrentPage == NumPages)
                return null;

            return await this.client.SearchCharacter(this.currentQuery, CurrentPage + 1);
        }
    }
}
