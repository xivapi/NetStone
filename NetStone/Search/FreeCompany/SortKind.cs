namespace NetStone.Search.FreeCompany;

/// <summary>
/// Result sorting schemes for FC searches.
/// </summary>
public enum SortKind
{
    NameAtoZ = 1,
    NameZtoA = 2,
    MembershipHighToLow = 3,
    MembershipLowToHigh = 4,
    DateFoundedMostRecent = 5,
    DateFoundedOldest = 6,
}