namespace NetStone.Search.FreeCompany;

/// <summary>
/// Recruitment filters for FC searches.
/// </summary>
public enum Recruitment
{
    /// <summary>
    /// Dot not filter by recruitment status
    /// </summary>
    All = 99,

    /// <summary>
    /// Filter for groups actively recruiting
    /// </summary>
    Open = 1,

    /// <summary>
    /// Filter for groups not actively recruiting
    /// </summary>
    Closed = 0
}