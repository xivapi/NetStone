using System;

namespace NetStone.Search.FreeCompany;

/// <summary>
/// Focus filters for FC searches.
/// </summary>
[Flags]
public enum Focus
{
    /// <summary>
    /// No focus specified
    /// </summary>
    NotSpecified = 0,

    /// <summary>
    /// Focus on Role Play
    /// </summary>
    RolePlaying = 1 << 0,

    /// <summary>
    /// Focus on leveling
    /// </summary>
    Leveling = 1 << 1,

    /// <summary>
    /// Focus on casual content
    /// </summary>
    Casual = 1 << 2,

    /// <summary>
    /// Focus on hardcore content
    /// </summary>
    Hardcore = 1 << 3,

    /// <summary>
    /// Focus on Dungeon content
    /// </summary>
    Dungeons = 1 << 4,

    /// <summary>
    /// Focus on guild heists
    /// </summary>
    Guildhests = 1 << 5,

    /// <summary>
    /// Focus on trials
    /// </summary>
    Trials = 1 << 6,

    /// <summary>
    /// Focus on raiding
    /// </summary>
    Raids = 1 << 7,

    /// <summary>
    /// Focus on PvP
    /// </summary>
    PvP = 1 << 8,
}