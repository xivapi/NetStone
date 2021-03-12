using System;
using System.Collections.Generic;
using System.Text;

namespace NetStone.Search
{
    public interface ISearchQuery
    {
        public string BuildQueryString();
    }
}
