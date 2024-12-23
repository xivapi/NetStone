using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions;
using NetStone.Definitions.Model.Linkshell;
using NetStone.Model.Parseables.Linkshell.Members;

namespace NetStone.Model.Parseables.Linkshell;

/// <summary>
/// Container class holding information about a linkshell and it's members.
/// </summary>
public class LodestoneLinkshell : LodestoneParseable, IPaginatedResult<LodestoneLinkshell>
{
    private readonly LodestoneClient client;

    private readonly string lsId;

    private readonly LinkshellDefinition lsDefinition;
    private readonly LinkshellMemberDefinition pageDefinition;
    
    /// <summary>
    /// Container class for a parseable linkshell page.
    /// </summary>
    /// <param name="client">The <see cref="LodestoneClient"/> to be used to fetch further information.</param>
    /// <param name="rootNode">The root document node of the page.</param>
    /// <param name="container">The <see cref="DefinitionsContainer"/> holding definitions to be used to access data.</param>
    /// <param name="id">The ID of the cross world linkshell.</param>
    public LodestoneLinkshell(LodestoneClient client, HtmlNode rootNode, DefinitionsContainer container, string id) : base(rootNode)
    {
        this.client = client;
        this.lsId = id;
        this.lsDefinition = container.Linkshell;
        this.pageDefinition = container.LinkshellMember;
    }

    /// <summary>
    /// Name
    /// </summary>
    public string Name => Parse(this.lsDefinition.Name);
    
    
    private LinkshellMemberEntry[]? parsedResults;
    
    /// <summary>
    /// List of members
    /// </summary>
    public IEnumerable<LinkshellMemberEntry> Members
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

        this.parsedResults = new LinkshellMemberEntry[nodes.Length];
        for (var i = 0; i < this.parsedResults.Length; i++)
        {
            this.parsedResults[i] = new LinkshellMemberEntry(nodes[i], this.pageDefinition.Entry);
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
    public async Task<LodestoneLinkshell?> GetNextPage()
    {
        if (this.CurrentPage == this.NumPages)
            return null;

        return await this.client.GetLinkshell(this.lsId, this.CurrentPage + 1);
    }
}