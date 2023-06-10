namespace NetStone.Search.FreeCompany;

/// <summary>
/// Result sorting schemes for FC searches.
/// </summary>
public enum SortKind
{
    /// <summary>
    /// Sort by name from A to Z
    /// </summary>
    NameAtoZ = 1,

    /// <summary>
    /// Sort by name from Z to A
    /// </summary>
    NameZtoA = 2,

    /// <summary>
    /// Sort by member count (high to low)
    /// </summary>
    MembershipHighToLow = 3,

    /// <summary>
    /// Sort by member count (low to high)
    /// </summary>
    MembershipLowToHigh = 4,

    /// <summary>
    /// Sort by foundation date (newest first)
    /// </summary>
    DateFoundedMostRecent = 5,

    /// <summary>
    /// Sort by foundation date (oldest first)
    /// </summary>
    DateFoundedOldest = 6,
}