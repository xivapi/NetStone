namespace NetStone.Search.Character;

/// <summary>
/// Result sorting schemes for character searches.
/// </summary>
public enum SortKind
{
    /// <summary>
    /// Sort by name A to Z
    /// </summary>
    NameAtoZ = 1,

    /// <summary>
    /// Sort by name Z to A
    /// </summary>
    NameZtoA = 2,

    /// <summary>
    /// Sort by Homeworld A to Z
    /// </summary>
    WorldAtoZ = 3,

    /// <summary>
    /// Sort by Homeworld Z to A
    /// </summary>
    WorldZtoA = 4,

    /// <summary>
    /// Sort by level descending
    /// </summary>
    LevelDesc = 5,

    /// <summary>
    /// Sort by level ascending
    /// </summary>
    LevelAsc = 6,
}