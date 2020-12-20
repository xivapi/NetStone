using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using NetStone.Definitions.Model;

namespace NetStone.Model
{
    public interface IOptionalParseable<out T> where T : LodestoneParseable
    {
        bool Exists { get; }

        public T GetOptional();
    }
}
