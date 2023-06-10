namespace NetStone.Search.FreeCompany;

/// <summary>
/// Active time filters for FC searches.
/// </summary>
public enum ActiveTimes
{
    /// <summary>
    /// All options specified
    /// </summary>
    All,

    /// <summary>
    /// FC is active on week days
    /// </summary>
    WeekdaysOnly,

    /// <summary>
    /// FC is active on weekends
    /// </summary>
    WeekendsOnly,

    /// <summary>
    /// FC is always active
    /// </summary>
    Always,
}