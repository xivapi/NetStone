using System;
using System.Collections.Generic;
using System.Text;

namespace NetStone.Search.FreeCompany
{
    public enum SortKind
    {
        NameAtoZ = 1,
        NameZtoA = 2,
        MembershipHighToLow = 3,
        MembershipLowToHigh = 4,
        DateFoundedMostRecent = 5,
        DateFoundedOldest = 6
    }
}
