using System;

namespace NetStone.Search.FreeCompany;

/// <summary>
/// Focus filters for FC searches.
/// </summary>
[Flags]
public enum Focus
{
    NotSpecified = 0,
    RolePlaying = 1 << 0,
    Leveling = 1 << 1,
    Casual = 1 << 2,
    Hardcore = 1 << 3,
    Dungeons = 1 << 4,
    Guildhests = 1 << 5,
    Trials = 1 << 6,
    Raids = 1 << 7,
    PvP = 1 << 8,
}