using System;
using HtmlAgilityPack;
using NetStone.Definitions.Model.FreeCompany;

namespace NetStone.Model.Parseables.FreeCompany;

public class FreeCompanyFocusEntry : LodestoneParseable
{
    private readonly FreeCompanyFocusEntryDefinition definition;

    public FreeCompanyFocusEntry(HtmlNode rootNode, FreeCompanyFocusEntryDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    public string Name => Parse(this.definition.NAME);

    public Uri Icon => ParseImageSource(this.definition.ICON);

    public bool IsEnabled => Parse(this.definition.STATUS) == null;
}