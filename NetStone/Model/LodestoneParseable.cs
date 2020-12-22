using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Web;
using HtmlAgilityPack;
using NetStone.Definitions;
using NetStone.Definitions.Model;

namespace NetStone.Model
{
    public abstract class LodestoneParseable
    {
        protected readonly HtmlNode RootNode;

        protected LodestoneParseable(HtmlNode rootNode)
        {
            this.RootNode = rootNode;
        }

        protected HtmlNode QueryNode(string selector) => this.RootNode.QuerySelector(selector);

        protected bool HasNode(DefinitionsPack pack) => QueryNode(pack.Selector) != null;

        /// <summary>
        /// Parse the InnerHTML via selector.
        /// </summary>
        /// <param name="selector">Selector to the node.</param>
        /// <returns>InnerHTML of the node.</returns>
        protected string ParseInnerText(DefinitionsPack pack)
        {
            var node = QueryNode(pack.Selector);
            var text = node?.InnerText;

            return !string.IsNullOrEmpty(text) ? HttpUtility.HtmlDecode(text) : null;
        }

        protected GroupCollection ParseInnerTextRegex(DefinitionsPack pack)
        {
            var text = ParseInnerText(pack);

            if (string.IsNullOrEmpty(text))
                return null;
            
            var regex = new Regex(pack.Regex);
            var match = regex.Match(text);

            return match.Groups;
        }
        
        protected string ParseTooltip(DefinitionsPack pack)
        {
            var text = ParseAttribute(pack, "data-tooltip");

            return !string.IsNullOrEmpty(text) ? HttpUtility.HtmlDecode(text) : null;
        }

        protected string ParseAttribute(DefinitionsPack pack, string attribute)
        {
            var node = QueryNode(pack.Selector);

            if (node == null)
                return null;

            if (node.Attributes.All(x => x.Name != attribute))
                return null;

            return node.Attributes[attribute].Value;
        }

        protected Uri ParseHref(DefinitionsPack pack)
        {
            var href = ParseAttribute(pack, "href");

            if (string.IsNullOrEmpty(href))
                return null;

            if (!href.StartsWith("http://", StringComparison.InvariantCulture) &&
                !href.StartsWith("https://", StringComparison.InvariantCulture))
                href = Constants.LodestoneBase + href;

            return new Uri(href);
        }

        protected string ParseHrefId(DefinitionsPack pack)
        {
            var url = ParseHref(pack);

            if (url == null)
                return null;

            var link = url.AbsoluteUri;

            // Trim last /
            link = link.Substring(0, link.Length - 1);

            // Get only the ID
            link = link.Substring(link.LastIndexOf("/", StringComparison.InvariantCulture) + 1);

            return link;
        }

        protected ulong? ParseHrefIdULong(DefinitionsPack pack)
        {
            var link = ParseHrefId(pack);

            if (link == null)
                return null;

            return ulong.Parse(link);
        }

        protected Uri ParseImageSource(DefinitionsPack pack)
        {
            var src = ParseAttribute(pack, "src");

            return string.IsNullOrEmpty(src) ? null : new Uri(src);
        }
    }
}
