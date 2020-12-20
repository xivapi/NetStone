using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using NetStone.Definitions.Model;

namespace NetStone.Model.Parseables
{
    public class SoulcrystalEntry : LodestoneParseable, IOptionalParseable<SoulcrystalEntry>
    {
        private readonly SoulcrystalEntryDefinition definition;

        public SoulcrystalEntry(HtmlNode rootNode, SoulcrystalEntryDefinition definition) : base(rootNode)
        {
            this.definition = definition;
        }

        //public Uri ItemDatabaseLink => ParseHref(this.definition.Name);

        public string ItemName => ParseInnerText(this.definition.Name);

        public bool Exists => HasNode(this.definition.Name);

        public SoulcrystalEntry GetOptional()
        {
            return !Exists ? null : this;
        }

        public override string ToString() => ItemName;
    }
}
