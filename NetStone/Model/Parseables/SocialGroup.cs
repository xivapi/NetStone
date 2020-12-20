using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using NetStone.Definitions.Model;

namespace NetStone.Model.Parseables
{
    public class SocialGroup : LodestoneParseable, IOptionalParseable<SocialGroup>
    {
        private readonly ISocialGroupDefinition definition;

        public SocialGroup(HtmlNode rootNode, ISocialGroupDefinition socialGroupDefinition) : base(rootNode)
        {
            this.definition = socialGroupDefinition;
        }

        public bool Exists => Id != null;

        public string Name => ParseInnerText(this.definition.Name);

        public string Id => ParseHrefId(this.definition.Name);

        public Uri Link => ParseHref(this.definition.Name);

        public IconLayers IconLayers => new IconLayers(this.RootNode, this.definition);

        public SocialGroup GetOptional()
        {
            return Exists ? this : null;
        }

        public override string ToString() => Name;
    }
}
