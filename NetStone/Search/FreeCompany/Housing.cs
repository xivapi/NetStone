namespace NetStone.Search.FreeCompany;

/// <summary>
/// Housing filters for FC searches.
/// </summary>
public enum Housing
{
    /// <summary>
    /// Do not filter by housing
    /// </summary>
    All = 99,

    /// <summary>
    /// Filter for FCs with an estate built
    /// </summary>
    EstateBuilt = 2,

    /// <summary>
    /// Filter for FCs with a plot but no estate built
    /// </summary>
    PlotOnly = 1,

    /// <summary>
    /// Filter for Fcs with neither an estate nor a plot
    /// </summary>
    NoEstateOrPlot = 0,
}