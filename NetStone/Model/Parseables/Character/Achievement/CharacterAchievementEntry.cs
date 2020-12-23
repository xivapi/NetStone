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

        public string Name => Parse(this.definition.ActivityDescription);

        public ulong? Id => ParseHrefIdULong(this.definition.Id);

        public Uri DatabaseLink => ParseHref(this.definition.Id);

        public DateTime TimeAchieved => ParseTime(this.definition.Time);

        public override string ToString() => Name;
    }
}
