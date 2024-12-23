﻿using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model.CWLS;
using NetStone.Model.Parseables.CWLS;

namespace NetStone.Model.Parseables.Search.CWLS;

/// <summary>
/// Models one entry in the cwls search results list
/// </summary>
public class CrossWorldLinkShellSearchEntry : LodestoneParseable
{
    private readonly LodestoneClient client;
    private readonly CrossWorldLinkShellSearchEntryDefinition definition;

    ///
    public CrossWorldLinkShellSearchEntry(LodestoneClient client, HtmlNode rootNode, CrossWorldLinkShellSearchEntryDefinition definition) :
        base(rootNode)
    {
        this.client = client;
        this.definition = definition;
    }

    /// <summary>
    /// Character name
    /// </summary>
    public string Name => Parse(this.definition.Name);

    /// <summary>
    /// Lodestone Id
    /// </summary>
    public string? Id => ParseHrefId(this.definition.Id);

    /// <summary>
    /// Datacenter
    /// </summary>
    public string DataCenter => Parse(this.definition.Dc);
    
    
    /// <summary>
    /// Number of active members
    /// </summary>
    public int ActiveMembers =>  int.TryParse(Parse(this.definition.ActiveMembers), out var parsed) ? parsed : -1;

    /// <summary>
    /// Fetch cross world link shell
    /// </summary>
    /// <returns>Task of retrieving cwls</returns>
    public async Task<LodestoneCrossWorldLinkShell?> GetCrossWorldLinkShell() =>
        this.Id is null ? null : await this.client.GetCrossworldLinkshell(this.Id);

    ///<inheritdoc />
    public override string ToString() => this.Name;
}