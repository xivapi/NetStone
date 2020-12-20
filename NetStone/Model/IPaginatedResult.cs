using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace NetStone.Model
{
    interface IPaginatedResult <T> where T : LodestoneParseable
    {
        int CurrentPage { get; set; }
        int NumPages { get; set; }

        Task<T> GetNextPage();
    }
}
