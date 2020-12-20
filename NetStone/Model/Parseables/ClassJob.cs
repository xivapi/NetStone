using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;
using HtmlAgilityPack;
using NetStone.Definitions.Model;

namespace NetStone.Model.Parseables
{
    public class ClassJob : LodestoneParseable
    {
        private readonly ClassJobDefinition definition;

        public ClassJob(HtmlNode rootNode, ClassJobDefinition definition) : base(rootNode)
        {
            this.definition = definition;
        }

        public ClassJobEntry Paladin => new ClassJobEntry(this.RootNode, this.definition.Paladin).GetOptional();
        public ClassJobEntry Warrior => new ClassJobEntry(this.RootNode, this.definition.Warrior).GetOptional();
        public ClassJobEntry DarkKnight => new ClassJobEntry(this.RootNode, this.definition.DarkKnight).GetOptional();
        public ClassJobEntry Gunbreaker => new ClassJobEntry(this.RootNode, this.definition.Gunbreaker).GetOptional();
        public ClassJobEntry Monk => new ClassJobEntry(this.RootNode, this.definition.Monk).GetOptional();
        public ClassJobEntry Dragoon => new ClassJobEntry(this.RootNode, this.definition.Dragoon).GetOptional();
        public ClassJobEntry Ninja => new ClassJobEntry(this.RootNode, this.definition.Ninja).GetOptional();
        public ClassJobEntry Samurai => new ClassJobEntry(this.RootNode, this.definition.Samurai).GetOptional();
        public ClassJobEntry Whitemage => new ClassJobEntry(this.RootNode, this.definition.Whitemage).GetOptional();
        public ClassJobEntry Scholar => new ClassJobEntry(this.RootNode, this.definition.Scholar).GetOptional();
        public ClassJobEntry Astrologian => new ClassJobEntry(this.RootNode, this.definition.Astrologian).GetOptional();
        public ClassJobEntry Bard => new ClassJobEntry(this.RootNode, this.definition.Bard).GetOptional();
        public ClassJobEntry Machinist => new ClassJobEntry(this.RootNode, this.definition.Machinist).GetOptional();
        public ClassJobEntry Dancer => new ClassJobEntry(this.RootNode, this.definition.Dancer).GetOptional();

        public ClassJobEntry Blackmage => new ClassJobEntry(this.RootNode, this.definition.Blackmage).GetOptional();

        public ClassJobEntry Summoner => new ClassJobEntry(this.RootNode, this.definition.Summoner).GetOptional();

        public ClassJobEntry Redmage => new ClassJobEntry(this.RootNode, this.definition.Redmage).GetOptional();

        public ClassJobEntry Bluemage => new ClassJobEntry(this.RootNode, this.definition.Bluemage).GetOptional();

        public ClassJobEntry Carpenter => new ClassJobEntry(this.RootNode, this.definition.Carpenter).GetOptional();
        public ClassJobEntry Blacksmith => new ClassJobEntry(this.RootNode, this.definition.Blacksmith).GetOptional();

        public ClassJobEntry Armorer => new ClassJobEntry(this.RootNode, this.definition.Armorer).GetOptional();

        public ClassJobEntry Goldsmith => new ClassJobEntry(this.RootNode, this.definition.Goldsmith).GetOptional();

        public ClassJobEntry Leatherworker => new ClassJobEntry(this.RootNode, this.definition.Leatherworker).GetOptional();
        public ClassJobEntry Weaver => new ClassJobEntry(this.RootNode, this.definition.Weaver).GetOptional();

        public ClassJobEntry Alchemist => new ClassJobEntry(this.RootNode, this.definition.Alchemist).GetOptional();

        public ClassJobEntry Miner => new ClassJobEntry(this.RootNode, this.definition.Miner).GetOptional();

        public ClassJobEntry Botanist => new ClassJobEntry(this.RootNode, this.definition.Botanist).GetOptional();
        
        public ClassJobEntry Fisher => new ClassJobEntry(this.RootNode, this.definition.Fisher).GetOptional();
    }
}
