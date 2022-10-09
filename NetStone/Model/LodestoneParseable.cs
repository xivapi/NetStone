using HtmlAgilityPack;
using HtmlAgilityPack.CssSelectors.NetCore;
using NetStone.Definitions;
using NetStone.Definitions.Model;
using System;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace NetStone.Model;

/// <summary>
/// Main superclass for parsed lodestone nodes.
/// </summary>
public abstract class LodestoneParseable
{
    /// <summary>
    /// The HTML document's root node.
    /// </summary>
    protected readonly HtmlNode RootNode;

    protected LodestoneParseable(){ }
    protected LodestoneParseable(HtmlNode rootNode)
    {
        this.RootNode = rootNode;
    }

    /// <summary>
    /// Query a <see cref="HtmlNode"/> via pack selector.
    /// </summary>
    /// <param name="pack">Definition of the node.</param>
    /// <returns>The needed node.</returns>
    protected HtmlNode QueryNode(DefinitionsPack pack) => this.RootNode.QuerySelector(pack.Selector);

    /// <summary>
    /// Query all ChildNodes of a <see cref="HtmlNode"/> via pack selector.
    /// Removes unneeded "#text" nodes.
    /// </summary>
    /// <param name="pack">Definition of the node.</param>
    /// <returns>All ChildNodes.</returns>
    protected HtmlNode[] QueryChildNodes(DefinitionsPack pack) => this.RootNode
        .QuerySelectorAll(pack.Selector)
        .Where(x => x.Name != "#text")
        .ToArray();

    protected HtmlNode[] QueryContainer(PagedDefinition pagedDefinition)
    {
        var entryDef = pagedDefinition.Entry.ToObject<PagedEntryDefinition>();

        if (entryDef == null)
            throw new ArgumentException("Could not get entry definition");

        return QueryNode(pagedDefinition.Root)
            ?.QuerySelectorAll(entryDef.Root.Selector).ToArray();
    }

    protected bool HasNode(DefinitionsPack pack) => QueryNode(pack) != null;

    /// <summary>
    /// Parse the InnerText via selector.
    /// </summary>
    /// <param name="pack">Definition of the node.</param>
    /// <returns>InnerText of the node.</returns>
    protected string Parse(DefinitionsPack pack)
    {
        if (!string.IsNullOrEmpty(pack.Regex))
        {
            var res = ParseRegex(pack);

            if (res == null)
                return null;

            if (res.Count != 0)
                return res[1].Value;
        }

        return ParseInnerText(pack);
    }

    protected string ParseInnerText(DefinitionsPack pack, bool noAttribute = false)
    {
        var node = QueryNode(pack);

        // Handle default attribute parsing
        var text = !string.IsNullOrEmpty(pack.Attribute) && !noAttribute ? ParseAttribute(pack) : node?.InnerText;

        return !string.IsNullOrEmpty(text) ? HttpUtility.HtmlDecode(text) : null;
    }

    /// <summary>
    /// Parse the InnerText via selector, then parse out regex groups.
    /// </summary>
    /// <param name="pack">Definition of the node.</param>
    /// <returns>Matched Regex groups.</returns>
    protected GroupCollection ParseRegex(DefinitionsPack pack)
    {
        var text = ParseInnerText(pack);

        if (string.IsNullOrEmpty(text))
            return null;

        var regex = new Regex(pack.Regex);
        var match = regex.Match(text);

        return match.Groups;
    }

    /// <summary>
    /// Parses the DirectInnerText via selector.
    /// </summary>
    /// <param name="pack">Definition of the node.</param>
    /// <param name="noAttribute">Determines if Attributes are parsed or not.</param>
    /// <returns></returns>
    protected string ParseDirectInnerText(DefinitionsPack pack, bool noAttribute = false)
    {
        var node = QueryNode(pack);

        var text = !string.IsNullOrEmpty(pack.Attribute) && !noAttribute ? ParseAttribute(pack) : node?.GetDirectInnerText();

        return !string.IsNullOrEmpty(text) ? HttpUtility.HtmlDecode(text) : null;
    }

    /// <summary>
    /// Parse tooltip attribute.
    /// </summary>
    /// <param name="pack">Definition of the node.</param>
    /// <returns>Parsed tooltip.</returns>
    // TODO: Switch to attribute in pack
    protected string ParseTooltip(DefinitionsPack pack)
    {
        var text = ParseAttribute(pack, "data-tooltip");

        return !string.IsNullOrEmpty(text) ? HttpUtility.HtmlDecode(text) : null;
    }

    /// <summary>
    /// Parse attribute from pack.
    /// </summary>
    /// <param name="pack">Definition of the node.</param>
    /// <returns>Parsed attribute.</returns>
    protected string ParseAttribute(DefinitionsPack pack)
    {
        return ParseAttribute(pack, pack.Attribute);
    }

    /// <summary>
    /// Parse specified attribute via selector from pack.
    /// </summary>
    /// <param name="pack">Definition of the node.</param>
    /// <param name="attribute">Attribute to parse.</param>
    /// <returns>Parsed attribute.</returns>
    protected string ParseAttribute(DefinitionsPack pack, string attribute)
    {
        var node = QueryNode(pack);

        if (node == null)
            return null;

        if (node.Attributes.All(x => x.Name != attribute))
            return null;

        return node.Attributes[attribute].Value;
    }

    /// <summary>
    /// Parse href attribute on a node.
    /// </summary>
    /// <param name="pack">Definition of the node.</param>
    /// <returns>Parsed href.</returns>
    // TODO: Switch to attribute in pack
    protected Uri ParseHref(DefinitionsPack pack)
    {
        var href = ParseAttribute(pack, "href");

        if (string.IsNullOrEmpty(href))
            return null;

        // Normalize href to have the lodestone URL in front
        if (!href.StartsWith("http://", StringComparison.InvariantCulture) &&
            !href.StartsWith("https://", StringComparison.InvariantCulture))
            href = Constants.LodestoneBase + href;

        return new Uri(href);
    }

    /// <summary>
    /// Parse out ID into string or null if node was not found.
    /// </summary>
    /// <param name="pack">Definition of the node.</param>
    /// <returns>Parsed ID.</returns>
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

    /// <summary>
    /// Parse out ID into ulong or null if node was not found.
    /// </summary>
    /// <param name="pack">Definition of the node.</param>
    /// <returns>Parsed ID.</returns>
    protected ulong? ParseHrefIdULong(DefinitionsPack pack)
    {
        var link = ParseHrefId(pack);

        if (link == null)
            return null;

        return ulong.Parse(link);
    }

    /// <summary>
    /// Parse image source attribute.
    /// </summary>
    /// <param name="pack">Definition of the node.</param>
    /// <returns>Parsed image source.</returns>
    // TODO: Switch to attribute in pack
    protected Uri ParseImageSource(DefinitionsPack pack)
    {
        var src = ParseAttribute(pack, "src");

        return string.IsNullOrEmpty(src) ? null : new Uri(src);
    }

    protected DateTime ParseTime(DefinitionsPack pack)
    {
        var res = Parse(pack);
        return DateTimeOffset.FromUnixTimeSeconds(long.Parse(res)).UtcDateTime;
    }
}