using System.Collections.Generic;
using HtmlAgilityPack;
using NetStone.Definitions;
using NetStone.Definitions.Model.CWLS;
using NetStone.Model.Parseables.CWLS.Members;

namespace NetStone.Model.Parseables.CWLS;

/// <summary>
/// Container class holding information about a cross world linkshell and it's members.
/// </summary>
public class LodestoneCrossworldLinkshell : PaginatedIdResult<LodestoneCrossworldLinkshell,CrossworldLinkshellMemberEntry, CrossworldLinkshellMemberEntryDefinition>
{

    private readonly CrossworldLinkshellDefinition definition;
    
    /// <summary>
    /// Container class for a parseable corss world linkshell page.
    /// </summary>
    /// <param name="client">The <see cref="LodestoneClient"/> to be used to fetch further information.</param>
    /// <param name="rootNode">The root document node of the page.</param>
    /// <param name="container">The <see cref="DefinitionsContainer"/> holding definitions to be used to access data.</param>
    /// <param name="id">The ID of the cross world linkshell.</param>
    public LodestoneCrossworldLinkshell(LodestoneClient client, HtmlNode rootNode, DefinitionsContainer container, string id) 
        : base(rootNode,container.CrossworldLinkshellMember,client.GetCrossworldLinkshell,id)
    {
        this.definition = container.CrossworldLinkshell;
    }

    /// <summary>
    /// Name
    /// </summary>
    public string Name => ParseDirectInnerText(this.definition.Name).Trim();
    
    /// <summary>
    /// Datacenter
    /// </summary>
    public string DataCenter => Parse(this.definition.DataCenter);

    /// <summary>
    /// Members
    /// </summary>
    public IEnumerable<CrossworldLinkshellMemberEntry> Members => this.Results;
    
    ///<inheritdoc />
    protected override CrossworldLinkshellMemberEntry[] ParseResults()
    {
        var nodes = QueryContainer(this.PageDefinition);

        var parsedResults = new CrossworldLinkshellMemberEntry[nodes.Length];
        for (var i = 0; i < parsedResults.Length; i++)
        {
            parsedResults[i] = new CrossworldLinkshellMemberEntry(nodes[i], this.PageDefinition.Entry);
        }
        return parsedResults;
    }
}