namespace NetStone.Search.FreeCompany;

/// <summary>
/// Active member filters for FC searches.
/// </summary>
public enum ActiveMembers
{
    /// <summary>
    /// Include all FCs
    /// </summary>
    All,

    /// <summary>
    /// Filter for FCs with less than 10 members
    /// </summary>
    OneToTen,

    /// <summary>
    /// Filter for FCs with 11-30 members
    /// </summary>
    ElevenToThirty,

    /// <summary>
    /// Filter for FCs with 31-50 members
    /// </summary>
    ThirtyOneToFifty,

    /// <summary>
    /// Filter for FCs with more then 50 members
    /// </summary>
    OverFiftyOne,
}