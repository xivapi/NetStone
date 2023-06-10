using System;
using HtmlAgilityPack;
using NetStone.Definitions.Model.FreeCompany;

namespace NetStone.Model.Parseables.FreeCompany.Members;

/// <summary>
/// Models one entry for the Free Company member list
/// </summary>
public class FreeCompanyMembersEntry : LodestoneParseable
{
    private readonly FreeCompanyMembersEntryDefinition definition;

    ///
    public FreeCompanyMembersEntry(HtmlNode rootNode, FreeCompanyMembersEntryDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    /// <summary>
    /// Name of character
    /// </summary>
    public string Name => Parse(this.definition.Name);

    /// <summary>
    /// Id of character
    /// </summary>
    public string Id => Parse(this.definition.Id);

    /// <summary>
    /// Rank with character's Grand Company
    /// </summary>
    public string Rank => Parse(this.definition.Rank);

    /// <summary>
    /// Icon representing <see cref="Rank"/>
    /// </summary>
    public Uri? RankIcon => ParseImageSource(this.definition.RankIcon);

    /// <summary>
    /// Home world
    /// </summary>
    public string Server => ParseRegex(this.definition.Server)["World"].Value;

    /// <summary>
    /// Data center
    /// </summary>
    public string Datacenter => ParseRegex(this.definition.Server)["DC"].Value;

    /// <summary>
    /// Character's avatar
    /// </summary>
    public Uri? Avatar => ParseImageSource(this.definition.Avatar);
}