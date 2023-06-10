using System;
using HtmlAgilityPack;
using NetStone.Definitions.Model.FreeCompany;

namespace NetStone.Model.Parseables.FreeCompany;

/// <summary>
/// Data about one type of Free Company focus
/// </summary>
public class FreeCompanyFocusEntry : LodestoneParseable
{
    private readonly FreeCompanyFocusEntryDefinition definition;

    /// <summary>
    /// Construct instance to parse focus
    /// </summary>
    /// <param name="rootNode">Node that contains relevant data</param>
    /// <param name="definition">Parse definition</param>
    public FreeCompanyFocusEntry(HtmlNode rootNode, FreeCompanyFocusEntryDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    /// <summary>
    /// Name of the focus type
    /// </summary>
    public string Name => Parse(this.definition.NAME);

    /// <summary>
    /// Uri to icon
    /// </summary>
    public Uri Icon => ParseImageSource(this.definition.ICON);

    /// <summary>
    /// Indicates this focus is selected
    /// </summary>
    public bool IsEnabled => Parse(this.definition.STATUS) == null;
}