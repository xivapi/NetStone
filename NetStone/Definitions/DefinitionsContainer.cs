using System;
using System.Diagnostics.CodeAnalysis;
using System.Runtime.CompilerServices;
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

    /// <summary>
    /// Meta definitions
    /// Contains version, user-agents and Uris
    /// </summary>
    public MetaDefinition Meta { get; protected set; }

    /// <summary>
    /// General definitions for characters
    /// </summary>
    public CharacterDefinition Character { get; protected set; }

    /// <summary>
    /// Class information for characters
    /// </summary>
    public CharacterClassJobDefinition ClassJob { get; protected set; }

    /// <summary>
    /// Gear definitions for character
    /// </summary>
    public CharacterGearDefinition Gear { get; protected set; }

    /// <summary>
    /// Definitions for a character's attribute
    /// </summary>
    public CharacterAttributesDefinition Attributes { get; set; }

    /// <summary>
    /// Definitions for a character's achievements
    /// </summary>
    public PagedDefinition Achievement { get; set; }

    /// <summary>
    /// Definitions for a character's mounts
    /// </summary>
    public CharacterCollectableDefinition Mount { get; set; }

    /// <summary>
    /// Definitions for a character's minions
    /// </summary>
    public CharacterCollectableDefinition Minion { get; set; }

    /// <summary>
    /// Definitions for Free Company
    /// </summary>
    public FreeCompanyDefinition FreeCompany { get; set; }

    /// <summary>
    /// Definitions for Free Company focus
    /// </summary>
    public FreeCompanyFocusDefinition FreeCompanyFocus { get; set; }

    /// <summary>
    /// Definitions for Free Company reputation
    /// </summary>
    public FreeCompanyReputationDefinition FreeCompanyReputation { get; set; }

    /// <summary>
    /// Definitions for Free Company member list
    /// </summary>
    public PagedDefinition FreeCompanyMembers { get; set; }

    /// <summary>
    /// Definitions for character search
    /// </summary>
    public PagedDefinition CharacterSearch { get; protected set; }

    /// <summary>
    /// Definitions for Free company search
    /// </summary>
    public PagedDefinition FreeCompanySearch { get; protected set; }

    #endregion

    /// <summary>
    /// Loads the definitions from repo
    /// </summary>
    /// <returns>Reload task</returns>
    public abstract Task Reload();

    /// <inheritdoc />
    public abstract void Dispose();
}