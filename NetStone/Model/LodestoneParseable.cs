using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using HtmlAgilityPack;
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

        private HtmlNode QueryNode(string selector) => this.RootNode.QuerySelector(selector);

        protected bool HasNode(string selector) => QueryNode(selector) != null;

        /// <summary>
        /// Parse the InnerHTML via selector.
        /// </summary>
        /// <param name="selector">Selector to the node.</param>
        /// <returns>InnerHTML of the node.</returns>
        protected string ParseInnerText(string selector)
        {
            var text = QueryNode(selector)?.InnerText;

            return !string.IsNullOrEmpty(text) ? HttpUtility.HtmlDecode(text) : null;
        }

        protected string ParseTooltip(string selector)
        {
            var text = ParseAttribute(selector, "data-tooltip");

            return !string.IsNullOrEmpty(text) ? HttpUtility.HtmlDecode(text) : null;
        }

        protected string ParseAttribute(string selector, string attribute)
        {
            var node = QueryNode(selector);

            if (node == null)
                return null;

            if (node.Attributes.All(x => x.Name != attribute))
                return null;

            return node.Attributes[attribute].Value;
        }

        protected Uri ParseHref(string selector)
        {
            var href = ParseAttribute(selector, "href");

            if (string.IsNullOrEmpty(href))
                return null;

            if (!href.StartsWith("http://", StringComparison.InvariantCulture) &&
                !href.StartsWith("https://", StringComparison.InvariantCulture))
                href = Constants.LodestoneBase + href;

            return new Uri(href);
        }

        protected string ParseHrefId(string selector)
        {
            var url = ParseHref(selector);

            if (url == null)
                return null;

            var link = url.AbsoluteUri;

            // Trim last /
            link = link.Substring(0, link.Length - 1);

            // Get only the ID
            link = link.Substring(link.LastIndexOf("/", StringComparison.InvariantCulture) + 1);

            return link;
        }

        protected ulong? ParseHrefIdULong(string selector)
        {
            var link = ParseHrefId(selector);

            if (link == null)
                return null;

            return ulong.Parse(link);
        }

        protected Uri ParseImageSource(string selector)
        {
            var src = ParseAttribute(selector, "src");

            return string.IsNullOrEmpty(src) ? null : new Uri(src);
        }
    }
}
