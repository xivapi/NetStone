using System;
using System.Collections.Generic;
using System.Diagnostics;
using HtmlAgilityPack;
using NetStone.Definitions.Model.FreeCompany;
using NetStone.StaticData;

namespace NetStone.Model.Parseables.FreeCompany;

/// <summary>
/// Information on free companies
/// </summary>
public class FreeCompanyReputation : LodestoneParseable
{
    private readonly FreeCompanyReputationDefinition definition;

    /// <summary>
    /// Creates Free Company reputation information
    /// </summary>
    /// <param name="rootNode"></param>
    /// <param name="definition"></param>
    public FreeCompanyReputation(HtmlNode rootNode, FreeCompanyReputationDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    /// <summary>
    /// Maelstrom
    /// </summary>
    public FreeCompanyReputationEntry Maelstrom => new(this.RootNode, this.definition.Maelstrom);

    /// <summary>
    /// Order of the Twin Adder
    /// </summary>
    public FreeCompanyReputationEntry Adders => new(this.RootNode, this.definition.Adders);

    /// <summary>
    /// Immortal Flames
    /// </summary>
    public FreeCompanyReputationEntry Flames => new(this.RootNode, this.definition.Flames);

    /// <summary>
    /// Returns the relevant <see cref="FreeCompanyReputationEntry"/>.
    /// </summary>
    /// <param name="gc">Grand Company</param>
    /// <returns>Grand company reputation</returns>
    public FreeCompanyReputationEntry GrandCompanyRep(GrandCompany gc) => gc switch
    {
        GrandCompany.Maelstrom => this.Maelstrom,
        GrandCompany.OrderOfTheTwinAdder => this.Adders,
        GrandCompany.ImmortalFlames => this.Flames,
        _ => throw new ArgumentException("Unknown Grand Company"),
    };

    /// <summary>
    /// Maps <see cref="GrandCompany"/> to <see cref="FreeCompanyReputationEntry"/>.
    /// You should only access this once and store a reference.
    /// </summary>
    public Dictionary<GrandCompany, FreeCompanyReputationEntry> GrandCompanyDict =>
        new()
        {
            { GrandCompany.Maelstrom, this.Maelstrom },
            { GrandCompany.OrderOfTheTwinAdder, this.Adders },
            { GrandCompany.ImmortalFlames, this.Flames },
        };
}