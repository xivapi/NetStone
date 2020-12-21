using System;
using System.Collections.Generic;
using System.Text;

namespace NetStone.StaticData
{
    [Flags]
    public enum GrandCompany
    {
        None = 0,
        NoAffiliation = 1 << 0,
        Maelstrom = 1 << 1,
        OrderOfTheTwinAdder = 1 << 2,
        ImmortalFlames = 1 << 3,
    }
}
