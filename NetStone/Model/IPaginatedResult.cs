using System.Threading.Tasks;

namespace NetStone.Model;

/// <summary>
/// Models data that is presented over multiple pages
/// </summary>
/// <typeparam name="T">Type of data presented</typeparam>
public interface IPaginatedResult<T> where T : LodestoneParseable
{
    /// <summary>
    /// Currently handled page
    /// </summary>
    int CurrentPage { get; }

    /// <summary>
    /// Total number of pages
    /// </summary>
    int NumPages { get; }

    /// <summary>
    /// Gets the next page of results
    /// </summary>
    /// <returns>Task of retrieving next page</returns>
    Task<T> GetNextPage();
}