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

        /// <summary>
        /// Information about the Paladin class.
        /// </summary>
        public ClassJobEntry Paladin => new ClassJobEntry(this.RootNode, this.definition.Paladin).GetOptional();
        
        /// <summary>
        /// Information about the Warrior class.
        /// </summary>
        public ClassJobEntry Warrior => new ClassJobEntry(this.RootNode, this.definition.Warrior).GetOptional();
        
        /// <summary>
        /// Information about the Dark Knight class.
        /// </summary>
        public ClassJobEntry DarkKnight => new ClassJobEntry(this.RootNode, this.definition.DarkKnight).GetOptional();
        
        /// <summary>
        /// Information about the Gunbreaker class.
        /// </summary>
        public ClassJobEntry Gunbreaker => new ClassJobEntry(this.RootNode, this.definition.Gunbreaker).GetOptional();
        
        /// <summary>
        /// Information about the Monk class.
        /// </summary>
        public ClassJobEntry Monk => new ClassJobEntry(this.RootNode, this.definition.Monk).GetOptional();
        
        /// <summary>
        /// Information about the Dragoon class.
        /// </summary>
        public ClassJobEntry Dragoon => new ClassJobEntry(this.RootNode, this.definition.Dragoon).GetOptional();
        
        /// <summary>
        /// Information about the Ninja class.
        /// </summary>
        public ClassJobEntry Ninja => new ClassJobEntry(this.RootNode, this.definition.Ninja).GetOptional();
        
        /// <summary>
        /// Information about the Samurai class.
        /// </summary>
        public ClassJobEntry Samurai => new ClassJobEntry(this.RootNode, this.definition.Samurai).GetOptional();
        
        /// <summary>
        /// Information about the Whitemage class.
        /// </summary>
        public ClassJobEntry Whitemage => new ClassJobEntry(this.RootNode, this.definition.Whitemage).GetOptional();
        
        /// <summary>
        /// Information about the Scholar class.
        /// </summary>
        public ClassJobEntry Scholar => new ClassJobEntry(this.RootNode, this.definition.Scholar).GetOptional();
        
        /// <summary>
        /// Information about the Astrologian class.
        /// </summary>
        public ClassJobEntry Astrologian => new ClassJobEntry(this.RootNode, this.definition.Astrologian).GetOptional();
        
        /// <summary>
        /// Information about the Bard class.
        /// </summary>
        public ClassJobEntry Bard => new ClassJobEntry(this.RootNode, this.definition.Bard).GetOptional();
        
        /// <summary>
        /// Information about the Machinist class.
        /// </summary>
        public ClassJobEntry Machinist => new ClassJobEntry(this.RootNode, this.definition.Machinist).GetOptional();
        
        /// <summary>
        /// Information about the Dancer class.
        /// </summary>
        public ClassJobEntry Dancer => new ClassJobEntry(this.RootNode, this.definition.Dancer).GetOptional();
        
        /// <summary>
        /// Information about the Blackmage class.
        /// </summary>
        public ClassJobEntry Blackmage => new ClassJobEntry(this.RootNode, this.definition.Blackmage).GetOptional();
        
        /// <summary>
        /// Information about the Summoner class.
        /// </summary>
        public ClassJobEntry Summoner => new ClassJobEntry(this.RootNode, this.definition.Summoner).GetOptional();
        
        /// <summary>
        /// Information about the Redmage class.
        /// </summary>
        public ClassJobEntry Redmage => new ClassJobEntry(this.RootNode, this.definition.Redmage).GetOptional();
        
        /// <summary>
        /// Information about the Bluemage class.
        /// </summary>
        public ClassJobEntry Bluemage => new ClassJobEntry(this.RootNode, this.definition.Bluemage).GetOptional();
        
        /// <summary>
        /// Information about the Carpenter class.
        /// </summary>
        public ClassJobEntry Carpenter => new ClassJobEntry(this.RootNode, this.definition.Carpenter).GetOptional();
        
        /// <summary>
        /// Information about the Blacksmith class.
        /// </summary>
        public ClassJobEntry Blacksmith => new ClassJobEntry(this.RootNode, this.definition.Blacksmith).GetOptional();
        
        /// <summary>
        /// Information about the Armorer class.
        /// </summary>
        public ClassJobEntry Armorer => new ClassJobEntry(this.RootNode, this.definition.Armorer).GetOptional();

        /// <summary>
        /// Information about the Goldsmith class.
        /// </summary>
        public ClassJobEntry Goldsmith => new ClassJobEntry(this.RootNode, this.definition.Goldsmith).GetOptional();

        /// <summary>
        /// Information about the Leatherworker class.
        /// </summary>
        public ClassJobEntry Leatherworker => new ClassJobEntry(this.RootNode, this.definition.Leatherworker).GetOptional();
        
        /// <summary>
        /// Information about the Weaver class.
        /// </summary>
        public ClassJobEntry Weaver => new ClassJobEntry(this.RootNode, this.definition.Weaver).GetOptional();

        /// <summary>
        /// Information about the Alchemist class.
        /// </summary>
        public ClassJobEntry Alchemist => new ClassJobEntry(this.RootNode, this.definition.Alchemist).GetOptional();

        /// <summary>
        /// Information about the Miner class.
        /// </summary>
        public ClassJobEntry Miner => new ClassJobEntry(this.RootNode, this.definition.Miner).GetOptional();

        /// <summary>
        /// Information about the Botanist class.
        /// </summary>
        public ClassJobEntry Botanist => new ClassJobEntry(this.RootNode, this.definition.Botanist).GetOptional();
        
        /// <summary>
        /// Information about the Fisher class.
        /// </summary>
        public ClassJobEntry Fisher => new ClassJobEntry(this.RootNode, this.definition.Fisher).GetOptional();
    }
}
