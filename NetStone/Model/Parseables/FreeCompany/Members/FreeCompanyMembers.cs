using System.Collections.Generic;
using HtmlAgilityPack;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.FreeCompany;

namespace NetStone.Model.Parseables.FreeCompany.Members;

/// <summary>
/// Information about a Free Company's members
/// </summary>
public class FreeCompanyMembers : PaginatedIdResult<FreeCompanyMembers, FreeCompanyMembersEntry, FreeCompanyMembersEntryDefinition>
{
    /// <summary>
    /// Constructs member list
    /// </summary>
    /// <param name="client"></param>
    /// <param name="rootNode"></param>
    /// <param name="definition"></param>
    /// <param name="id"></param>
    public FreeCompanyMembers(LodestoneClient client, HtmlNode rootNode, PagedDefinition<FreeCompanyMembersEntryDefinition> definition, string id) :
        base(rootNode, definition, client.GetFreeCompanyMembers, id)
    {
    }

    /// <summary>
    /// Lists all members
    /// </summary>
    public IEnumerable<FreeCompanyMembersEntry> Members => this.Results;

    ///<inheritdoc />
    protected override FreeCompanyMembersEntry[] ParseResults()
    {
        var nodes = QueryContainer(this.PageDefinition);

        var parsedResults = new FreeCompanyMembersEntry[nodes.Length];
        for (var i = 0; i < parsedResults.Length; i++)
        {
            parsedResults[i] = new FreeCompanyMembersEntry(nodes[i], this.PageDefinition.Entry);
        }
        return parsedResults;
    }
}