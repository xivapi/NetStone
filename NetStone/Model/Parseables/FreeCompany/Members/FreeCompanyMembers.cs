using System.Collections.Generic;
using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.FreeCompany;

namespace NetStone.Model.Parseables.FreeCompany.Members;

/// <summary>
/// Information about a Free Company's members
/// </summary>
public class FreeCompanyMembers : LodestoneParseable, IPaginatedResult<FreeCompanyMembers>
{
    private readonly LodestoneClient client;
    private readonly string id;

    private readonly PagedDefinition pageDefinition;
    private readonly FreeCompanyMembersEntryDefinition entryDefinition;

    /// <summary>
    /// Constructs member list
    /// </summary>
    /// <param name="client"></param>
    /// <param name="rootNode"></param>
    /// <param name="definition"></param>
    /// <param name="id"></param>
    public FreeCompanyMembers(LodestoneClient client, HtmlNode rootNode, PagedDefinition definition, string id) :
        base(rootNode)
    {
        this.client = client;
        this.id = id;

        this.pageDefinition = definition;
        this.entryDefinition = definition.Entry.ToObject<FreeCompanyMembersEntryDefinition>();
    }

    /// <summary>
    /// IF there is data
    /// </summary>
    public bool HasResults => true;

    private FreeCompanyMembersEntry[] parsedResults;

    /// <summary>
    /// Lists all members
    /// </summary>
    public IEnumerable<FreeCompanyMembersEntry> Members
    {
        get
        {
            if (!this.HasResults)
                return new FreeCompanyMembersEntry[0];

            if (this.parsedResults == null)
                ParseSearchResults();

            return this.parsedResults;
        }
    }

    private void ParseSearchResults()
    {
        var nodes = QueryContainer(this.pageDefinition);

        this.parsedResults = new FreeCompanyMembersEntry[nodes.Length];
        for (var i = 0; i < this.parsedResults.Length; i++)
        {
            this.parsedResults[i] = new FreeCompanyMembersEntry(this.client, nodes[i], this.entryDefinition);
        }
    }

    private int? currentPageVal;

    ///<inheritdoc />
    public int CurrentPage
    {
        get
        {
            if (!this.HasResults)
                return 0;

            if (!this.currentPageVal.HasValue)
                ParsePagesCount();

            return this.currentPageVal.Value;
        }
    }

    private int? numPagesVal;

    ///<inheritdoc />
    public int NumPages
    {
        get
        {
            if (!this.HasResults)
                return 0;

            if (!this.numPagesVal.HasValue)
                ParsePagesCount();

            return this.numPagesVal.Value;
        }
    }

    private void ParsePagesCount()
    {
        var results = ParseRegex(this.pageDefinition.PageInfo);

        this.currentPageVal = int.Parse(results["CurrentPage"].Value);
        this.numPagesVal = int.Parse(results["NumPages"].Value);
    }

    ///<inheritdoc />
    public async Task<FreeCompanyMembers?> GetNextPage()
    {
        if (this.CurrentPage == this.NumPages)
            return null;

        return await this.client.GetFreeCompanyMembers(this.id, this.CurrentPage + 1);
    }
}