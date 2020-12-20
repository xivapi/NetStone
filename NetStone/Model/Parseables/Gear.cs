using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using JetBrains.Annotations;
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

        [CanBeNull]
        public GearEntry Weapon => new GearEntry(this.RootNode, this.definition.Weapon).GetOptional();

        [CanBeNull]
        public GearEntry Shield => new GearEntry(this.RootNode, this.definition.Shield).GetOptional();

        [CanBeNull]
        public GearEntry Head => new GearEntry(this.RootNode, this.definition.Head).GetOptional();

        [CanBeNull]
        public GearEntry Body => new GearEntry(this.RootNode, this.definition.Body).GetOptional();

        [CanBeNull]
        public GearEntry Hands => new GearEntry(this.RootNode, this.definition.Hands).GetOptional();

        [CanBeNull]
        public GearEntry Waist => new GearEntry(this.RootNode, this.definition.Waist).GetOptional();

        [CanBeNull]
        public GearEntry Legs => new GearEntry(this.RootNode, this.definition.Legs).GetOptional();

        [CanBeNull]
        public GearEntry Feet => new GearEntry(this.RootNode, this.definition.Feet).GetOptional();

        [CanBeNull]
        public GearEntry Earrings => new GearEntry(this.RootNode, this.definition.Earrings).GetOptional();

        [CanBeNull]
        public GearEntry Necklace => new GearEntry(this.RootNode, this.definition.Necklace).GetOptional();

        [CanBeNull]
        public GearEntry Bracelets => new GearEntry(this.RootNode, this.definition.Bracelets).GetOptional();

        [CanBeNull]
        public GearEntry Ring1 => new GearEntry(this.RootNode, this.definition.Ring1).GetOptional();

        [CanBeNull]
        public GearEntry Ring2 => new GearEntry(this.RootNode, this.definition.Ring2).GetOptional();

        [CanBeNull]
        public SoulcrystalEntry Soulcrystal => new SoulcrystalEntry(this.RootNode, this.definition.Soulcrystal).GetOptional();

    }
}
