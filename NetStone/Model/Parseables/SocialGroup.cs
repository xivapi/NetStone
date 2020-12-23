using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using JetBrains.Annotations;
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

        /// <summary>
        /// Indicating whether this social group exists or not.
        /// </summary>
        public bool Exists => Id != null;

        /// <summary>
        /// Name of this social group.
        /// </summary>
        public string Name => ParseInnerText(this.definition.Name);

        /// <summary>
        /// ID of this social group.
        /// </summary>
        public string Id => ParseHrefId(this.definition.Name);

        /// <summary>
        /// Link to this social group's page.
        /// </summary>
        public Uri Link => ParseHref(this.definition.Name);

        /// <summary>
        /// <see cref="IconLayers"/> of this social group's icon.
        /// </summary>
        public IconLayers IconLayers => new IconLayers(this.RootNode, this.definition);

        /// <summary>
        /// String representation of the gear slot.
        /// </summary>
        /// <returns>The name of the item.</returns>
        public override string ToString() => Name;
    }
}
