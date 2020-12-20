using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using NetStone.Definitions.Model;

namespace NetStone.Model.Parseables
{
    public class Gear : LodestoneParseable
    {
        private readonly GearDefinition definition;

        public Gear(HtmlNode rootNode, GearDefinition definition) : base(rootNode)
        {
            this.definition = definition;
        }

        public GearEntry Weapon => new GearEntry(this.RootNode, this.definition.Weapon).GetOptional();

        public GearEntry Shield => new GearEntry(this.RootNode, this.definition.Shield).GetOptional();

        public GearEntry Head => new GearEntry(this.RootNode, this.definition.Head).GetOptional();

        public GearEntry Body => new GearEntry(this.RootNode, this.definition.Body).GetOptional();

        public GearEntry Hands => new GearEntry(this.RootNode, this.definition.Hands).GetOptional();

        public GearEntry Waist => new GearEntry(this.RootNode, this.definition.Waist).GetOptional();

        public GearEntry Legs => new GearEntry(this.RootNode, this.definition.Legs).GetOptional();

        public GearEntry Feet => new GearEntry(this.RootNode, this.definition.Feet).GetOptional();

        public GearEntry Earrings => new GearEntry(this.RootNode, this.definition.Earrings).GetOptional();

        public GearEntry Necklace => new GearEntry(this.RootNode, this.definition.Necklace).GetOptional();

        public GearEntry Bracelets => new GearEntry(this.RootNode, this.definition.Bracelets).GetOptional();

        public GearEntry Ring1 => new GearEntry(this.RootNode, this.definition.Ring1).GetOptional();

        public GearEntry Ring2 => new GearEntry(this.RootNode, this.definition.Ring2).GetOptional();

        public SoulcrystalEntry Soulcrystal => new SoulcrystalEntry(this.RootNode, this.definition.Soulcrystal).GetOptional();

    }
}
