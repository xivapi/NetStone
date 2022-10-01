using System;

namespace NetStone.Search.FreeCompany;

/// <summary>
/// Seeking player filters for FC searches.
/// </summary>
[Flags]
public enum Seeking
{
    NotSpecified = 0,
    Tank = 1 << 0,
    Healer = 1 << 1,
    Dps = 1 << 2,
    Crafter = 1 << 3,
    Gatherer = 1 << 4,
}