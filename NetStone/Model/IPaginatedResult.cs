using System.Threading.Tasks;

namespace NetStone.Model;

interface IPaginatedResult <T> where T : LodestoneParseable
{
    int CurrentPage { get; }
    int NumPages { get; }

    Task<T> GetNextPage();
}