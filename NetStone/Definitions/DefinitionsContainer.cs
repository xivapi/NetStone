using System;
using System.Threading;
using System.Threading.Tasks;
using NetStone.Definitions.Model;
using NetStone.Definitions.Model.Character;
using NetStone.Definitions.Model.CWLS;
using NetStone.Definitions.Model.FreeCompany;
using NetStone.Definitions.Model.Linkshell;

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
    /// Definition for character gear entry (single slot)
    /// </summary>
    public GearEntryDefinition GearEntry { get; protected set; }
    
    /// <summary>
    /// Definition for character soul crystal entry
    /// </summary>
    public SoulcrystalEntryDefinition SoulCrystalEntry { get; protected set; }

    /// <summary>
    /// Definitions for a character's attribute
    /// </summary>
    public CharacterAttributesDefinition Attributes { get; protected set; }

    /// <summary>
    /// Definitions for a character's achievements
    /// </summary>
    public CharacterAchievementDefinition Achievement { get; protected set; }

    /// <summary>
    /// Definitions for a character's mounts
    /// </summary>
    public CharacterCollectableDefinition Mount { get; protected set; }

    /// <summary>
    /// Definitions for a character's minions
    /// </summary>
    public CharacterCollectableDefinition Minion { get; protected set; }

    /// <summary>
    /// Definitions for Free Company
    /// </summary>
    public FreeCompanyDefinition FreeCompany { get; protected set; }

    /// <summary>
    /// Definitions for Free Company focus
    /// </summary>
    public FreeCompanyFocusDefinition FreeCompanyFocus { get; protected set; }

    /// <summary>
    /// Definitions for Free Company reputation
    /// </summary>
    public FreeCompanyReputationDefinition FreeCompanyReputation { get; protected set; }

    /// <summary>
    /// Definitions for Free Company member list
    /// </summary>
    public PagedDefinition<FreeCompanyMembersEntryDefinition> FreeCompanyMembers { get; protected set; }

    /// <summary>
    /// Definitions for character search
    /// </summary>
    public PagedDefinition<CharacterSearchEntryDefinition> CharacterSearch { get; protected set; }

    /// <summary>
    /// Definitions for Free company search
    /// </summary>
    public PagedDefinition<FreeCompanySearchEntryDefinition> FreeCompanySearch { get; protected set; }
    
    /// <summary>
    /// Definitions for cross world link shells
    /// </summary>
    public CrossworldLinkshellDefinition CrossworldLinkshell { get; protected set; }
    
    /// <summary>
    /// Definitions for cross world link shell members
    /// </summary>
    public PagedDefinition<CrossworldLinkshellMemberEntryDefinition> CrossworldLinkshellMember { get; protected set; }
    
    /// <summary>
    /// Definitions for cross world link shell searches
    /// </summary>
    public PagedDefinition<CrossworldLinkshellSearchEntryDefinition> CrossworldLinkshellSearch { get; protected set; }
    
    /// <summary>
    /// Definitions for link shells
    /// </summary>
    public LinkshellDefinition Linkshell { get; protected set; }
    
    /// <summary>
    /// Definitions for link shell members
    /// </summary>
    public PagedDefinition<LinkshellMemberEntryDefinition> LinkshellMember { get; protected set; }
    
    /// <summary>
    /// Definitions for link-shell searches
    /// </summary>
    public PagedDefinition<LinkshellSearchEntryDefinition> LinkshellSearch { get; protected set; }

    #endregion

    /// <summary>
    /// Loads the definitions from repo
    /// </summary>
    /// <param name="cancellationToken">The cancellation token to cancel operation</param>
    /// <returns>Reload task</returns>
    public abstract Task Reload(CancellationToken cancellationToken = default);

    /// <inheritdoc />
    public abstract void Dispose();
}