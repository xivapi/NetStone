using System;
using HtmlAgilityPack;
using NetStone.Definitions.Model;

namespace NetStone.Model.Parseables;

/// <summary>
/// Container class holding information about a social group's icon.
/// </summary>
public class IconLayers : LodestoneParseable
{
    private readonly IconLayersDefinition definition;

    public IconLayers(HtmlNode rootNode, IconLayersDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    /// <summary>
    /// Link to the top layer image of the icon.
    /// </summary>
    public Uri TopLayer => ParseImageSource(this.definition.Top);
        
    /// <summary>
    /// Link to the top layer image of the icon.
    /// </summary>
    public Uri MiddleLayer => ParseImageSource(this.definition.Middle);
        
    /// <summary>
    /// Link to the top layer image of the icon.
    /// </summary>
    public Uri BottomLayer => ParseImageSource(this.definition.Bottom);
}