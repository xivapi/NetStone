using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model;

namespace NetStone.Model.Parseables.Character.Achievement
{
    public class CharacterAchievementEntry : LodestoneParseable
    {
        private readonly LodestoneClient client;
        private readonly CharacterAchievementDefinition definition;

        public CharacterAchievementEntry(LodestoneClient client, HtmlNode rootNode, CharacterAchievementDefinition definition) : base(rootNode)
        {
            this.client = client;
            this.definition = definition;
        }

        public string Name => ParseInnerText(this.definition.ActivityDescription);

        public ulong? Id => ParseHrefIdULong(this.definition.Id);

        public Uri DatabaseLink => ParseHref(this.definition.Id);

        public DateTime TimeAchieved
        {
            get
            {
                var res = ParseInnerTextRegex(this.definition.Time);
                return DateTimeOffset.FromUnixTimeSeconds(long.Parse(res["Timestamp"].Value)).UtcDateTime;
            }
        }

        public override string ToString() => Name;
    }
}
