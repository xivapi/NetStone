using System;

namespace NetStone.StaticData;

/// <summary>
/// The Grand Company IDs.
/// </summary>
[Flags]
public enum GrandCompany
{
    /// <summary>
    /// Unspecified
    /// </summary>
    None = 0,

    /// <summary>
    /// No affiliation with any grand company
    /// </summary>
    NoAffiliation = 1 << 0,

    /// <summary>
    /// Affiliated with Maelstrom
    /// </summary>
    Maelstrom = 1 << 1,

    /// <summary>
    /// Affiliated with The Twin Adder
    /// </summary>
    OrderOfTheTwinAdder = 1 << 2,

    /// <summary>
    /// Affiliated with the Immortal Flames
    /// </summary>
    ImmortalFlames = 1 << 3,
}