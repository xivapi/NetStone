using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using NetStone.Definitions.Model;

namespace NetStone.Model.Parseables
{
    public class IconLayers : LodestoneParseable
    {
        private readonly ISocialGroupDefinition definition;

        public IconLayers(HtmlNode rootNode, ISocialGroupDefinition definition) : base(rootNode)
        {
            this.definition = definition;
        }

        public Uri TopLayer => ParseImageSource(this.definition.IconLayers.Top);
        public Uri MiddleLayer => ParseImageSource(this.definition.IconLayers.Middle);
        public Uri BottomLayer => ParseImageSource(this.definition.IconLayers.Bottom);
    }
}
