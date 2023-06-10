namespace NetStone.Search;

/// <summary>
/// Models a search query for search requests
/// </summary>
public interface ISearchQuery
{
    /// <summary>
    /// Constructs the query to send modeling this search query
    /// </summary>
    /// <returns>Search parameters to append to the request uri</returns>
    public string BuildQueryString();
}