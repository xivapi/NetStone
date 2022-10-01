using System;
using System.Threading.Tasks;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.Character;
using NetStone.Definitions.Model.FreeCompany;

namespace NetStone.Definitions;

/// <summary>
/// Class providing definitions(Selectors, paths) for parsing lodestone content.
/// </summary>
public abstract class DefinitionsContainer : IDisposable
{
    #region Definitions

    // Meta
    public MetaDefinition Meta { get; protected set; }

    // Entities
    public CharacterDefinition Character { get; protected set; }
    public CharacterClassJobDefinition ClassJob { get; protected set; }
    public CharacterGearDefinition Gear { get; protected set; }
    public CharacterAttributesDefinition Attributes { get; set; }
    public PagedDefinition Achievement { get; set; }
    public CharacterCollectableDefinition Mount { get; set; }
    public CharacterCollectableDefinition Minion { get; set; }

    public FreeCompanyDefinition FreeCompany { get; set; }
    public FreeCompanyFocusDefinition FreeCompanyFocus { get; set; }
    public FreeCompanyReputationDefinition FreeCompanyReputation { get; set; }

    public PagedDefinition FreeCompanyMembers { get; set; }

    // Search
    public PagedDefinition CharacterSearch { get; protected set; }

    public PagedDefinition FreeCompanySearch { get; protected set; }

    #endregion

    public abstract Task Reload();
    public abstract void Dispose();
}