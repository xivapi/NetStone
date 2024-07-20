using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions;
using NetStone.Definitions.Model.CWLS;
using NetStone.Model.Parseables.CWLS.Members;

namespace NetStone.Model.Parseables.CWLS;

/// <summary>
/// Container class holding information about a cross world linkshell and it's members.
/// </summary>
public class LodestoneCrossWorldLinkShell : LodestoneParseable, IPaginatedResult<LodestoneCrossWorldLinkShell>
{
    private readonly LodestoneClient client;

    private readonly string cwlsId;

    private readonly CrossWorldLinkShellDefinition cwlsDefinition;
    private readonly CrossWorldLinkShellMemberDefinition pageDefinition;
    
    /// <summary>
    /// Container class for a parseable corss world linkshell page.
    /// </summary>
    /// <param name="client">The <see cref="LodestoneClient"/> to be used to fetch further information.</param>
    /// <param name="rootNode">The root document node of the page.</param>
    /// <param name="container">The <see cref="DefinitionsContainer"/> holding definitions to be used to access data.</param>
    /// <param name="id">The ID of the cross world linkshell.</param>
    public LodestoneCrossWorldLinkShell(LodestoneClient client, HtmlNode rootNode, DefinitionsContainer container, string id) : base(rootNode)
    {
        this.client = client;
        this.cwlsId = id;
        this.cwlsDefinition = container.CrossWorldLinkShell;
        this.pageDefinition = container.CrossWorldLinkShellMember;
    }

    /// <summary>
    /// Name
    /// </summary>
    public string Name => Parse(this.cwlsDefinition.Name);

    /// <summary>
    /// Datacenter
    /// </summary>
    public string DataCenter => Parse(this.cwlsDefinition.DataCenter);
    
    
    private CrossWorldLinkShellMemberEntry[]? parsedResults;
    
    /// <summary>
    /// Unlocked achievements for character
    /// </summary>
    public IEnumerable<CrossWorldLinkShellMemberEntry> Members
    {
        get
        {
            if (this.parsedResults == null)
                ParseSearchResults();

            return this.parsedResults!;
        }
    }

    private void ParseSearchResults()
    {
        var nodes = QueryContainer(this.pageDefinition);

        this.parsedResults = new CrossWorldLinkShellMemberEntry[nodes.Length];
        for (var i = 0; i < this.parsedResults.Length; i++)
        {
            this.parsedResults[i] = new CrossWorldLinkShellMemberEntry(nodes[i], this.pageDefinition.Entry);
        }
    }

    private int? currentPageVal;

    ///<inheritdoc />
    public int CurrentPage
    {
        get
        {
            if (!this.currentPageVal.HasValue)
                ParsePagesCount();

            return this.currentPageVal!.Value;
        }
    }

    private int? numPagesVal;

    /// <inheritdoc/>
    public int NumPages
    {
        get
        {
            if (!this.numPagesVal.HasValue)
                ParsePagesCount();

            return this.numPagesVal!.Value;
        }
    }
    private void ParsePagesCount()
    {
        var results = ParseRegex(this.pageDefinition.PageInfo);

        this.currentPageVal = int.Parse(results["CurrentPage"].Value);
        this.numPagesVal = int.Parse(results["NumPages"].Value);
    }
    
    /// <inheritdoc />
    public async Task<LodestoneCrossWorldLinkShell?> GetNextPage()
    {
        if (this.CurrentPage == this.NumPages)
            return null;

        return await this.client.GetCrossworldLinkshell(this.cwlsId, this.CurrentPage + 1);
    }
}