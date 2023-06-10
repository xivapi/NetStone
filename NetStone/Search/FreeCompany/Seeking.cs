using System;

namespace NetStone.Search.FreeCompany;

/// <summary>
/// Seeking player filters for FC searches.
/// </summary>
[Flags]
public enum Seeking
{
    /// <summary>
    /// No status specified
    /// </summary>
    NotSpecified = 0,

    /// <summary>
    /// Seeking tanks
    /// </summary>
    Tank = 1 << 0,

    /// <summary>
    /// Seeking healers
    /// </summary>
    Healer = 1 << 1,

    /// <summary>
    /// Seeking DPS
    /// </summary>
    Dps = 1 << 2,

    /// <summary>
    /// Seeking crafters
    /// </summary>
    Crafter = 1 << 3,

    /// <summary>
    /// Seeking gatherers
    /// </summary>
    Gatherer = 1 << 4,
}