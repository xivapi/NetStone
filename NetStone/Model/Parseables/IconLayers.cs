using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using NetStone.Definitions.Model;

namespace NetStone.Model.Parseables
{
    /// <summary>
    /// Container class holding information about a social group's icon.
    /// </summary>
    public class IconLayers : LodestoneParseable
    {
        private readonly ISocialGroupDefinition definition;

        public IconLayers(HtmlNode rootNode, ISocialGroupDefinition definition) : base(rootNode)
        {
            this.definition = definition;
        }

        /// <summary>
        /// Link to the top layer image of the icon.
        /// </summary>
        public Uri TopLayer => ParseImageSource(this.definition.IconLayers.Top);
        
        /// <summary>
        /// Link to the top layer image of the icon.
        /// </summary>
        public Uri MiddleLayer => ParseImageSource(this.definition.IconLayers.Middle);
        
        /// <summary>
        /// Link to the top layer image of the icon.
        /// </summary>
        public Uri BottomLayer => ParseImageSource(this.definition.IconLayers.Bottom);
    }
}
