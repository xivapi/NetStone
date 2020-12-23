using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using NetStone.Definitions.Model;

namespace NetStone.Model.Parseables
{
    public class CharacterCollectableEntry : LodestoneParseable
    {
        private readonly CharacterCollectableDefinition definition;

        public CharacterCollectableEntry(HtmlNode rootNode, CharacterCollectableDefinition definition) : base(rootNode)
        {
            this.definition = definition;
        }

        public string Name => ParseInnerText(this.definition.Name);

        public override string ToString() => Name;
    }
}
