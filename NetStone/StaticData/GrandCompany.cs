using System;

namespace NetStone.StaticData;

/// <summary>
/// The Grand Company IDs.
/// </summary>
[Flags]
public enum GrandCompany
{
    None = 0,
    NoAffiliation = 1 << 0,
    Maelstrom = 1 << 1,
    OrderOfTheTwinAdder = 1 << 2,
    ImmortalFlames = 1 << 3,
}