using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using NetStone.Definitions.Model;

namespace NetStone.Model.Parseables
{
    public class GearEntry : LodestoneParseable, IOptionalParseable<GearEntry>
    {
        private readonly GearEntryDefinition definition;

        public GearEntry(HtmlNode rootNode, GearEntryDefinition definition) : base(rootNode)
        {
            this.definition = definition;
        }

        public Uri ItemDatabaseLink => ParseHref(this.definition.DbLink);

        public string ItemName => ParseInnerText(this.definition.Name);

        public Uri GlamourDatabaseLink => ParseHref(this.definition.MirageDbLink);

        public string GlamourName => ParseInnerText(this.definition.MirageName);

        public string Stain => ParseInnerText(this.definition.Stain);

        public string[] Materia => new[]
        {
            ParseInnerText(this.definition.Materia1),
            ParseInnerText(this.definition.Materia2),
            ParseInnerText(this.definition.Materia3),
            ParseInnerText(this.definition.Materia4),
            ParseInnerText(this.definition.Materia5),
        };

        public string CreatorName => ParseInnerText(this.definition.CreatorName);

        public bool Exists => HasNode(this.definition.Name);

        public GearEntry GetOptional()
        {
            return !Exists ? null : this;
        }

        public override string ToString() => ItemName;
    }
}
