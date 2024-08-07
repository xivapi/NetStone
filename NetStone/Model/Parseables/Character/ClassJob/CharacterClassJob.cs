﻿using System.Collections.Generic;
using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;

namespace NetStone.Model.Parseables.Character.ClassJob;

/// <summary>
/// Information about all classes for a character
/// </summary>
public class CharacterClassJob : LodestoneParseable
{
    private readonly CharacterClassJobDefinition definition;

    /// <summary>
    /// Creates ClassJobs data for the character represented by the Lodestone page
    /// </summary>
    /// <param name="rootNode">Root html node of Lodestone page</param>
    /// <param name="definition">Definition to parse ClassJobs</param>
    public CharacterClassJob(HtmlNode rootNode, CharacterClassJobDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    /// <summary>
    /// Information about the Eureka class.
    /// </summary>
    public ClassJobEureka? Eureka => new ClassJobEureka(this.RootNode, this.definition.Eureka).GetOptional();

    /// <summary>
    /// Information about the Bozja class.
    /// </summary>
    public ClassJobBozja? Bozja => new ClassJobBozja(this.RootNode, this.definition.Bozja).GetOptional();

    /// <summary>
    /// Information about the Paladin class.
    /// </summary>
    public ClassJobEntry Paladin => new(this.RootNode, this.definition.Paladin);

    /// <summary>
    /// Information about the Warrior class.
    /// </summary>
    public ClassJobEntry Warrior => new(this.RootNode, this.definition.Warrior);

    /// <summary>
    /// Information about the Dark Knight class.
    /// </summary>
    public ClassJobEntry DarkKnight => new(this.RootNode, this.definition.DarkKnight);

    /// <summary>
    /// Information about the Gunbreaker class.
    /// </summary>
    public ClassJobEntry Gunbreaker => new(this.RootNode, this.definition.Gunbreaker);

    /// <summary>
    /// Information about the Monk class.
    /// </summary>
    public ClassJobEntry Monk => new(this.RootNode, this.definition.Monk);

    /// <summary>
    /// Information about the Dragoon class.
    /// </summary>
    public ClassJobEntry Dragoon => new(this.RootNode, this.definition.Dragoon);

    /// <summary>
    /// Information about the Ninja class.
    /// </summary>
    public ClassJobEntry Ninja => new(this.RootNode, this.definition.Ninja);

    /// <summary>
    /// Information about the Samurai class.
    /// </summary>
    public ClassJobEntry Samurai => new(this.RootNode, this.definition.Samurai);

    /// <summary>
    /// Information about the Reaper class.
    /// </summary>
    public ClassJobEntry Reaper => new(this.RootNode, this.definition.Reaper);

    /// <summary>
    /// Information about the Viper class.
    /// </summary>
    public ClassJobEntry Viper => new(this.RootNode, this.definition.Viper);

    /// <summary>
    /// Information about the WhiteMage class.
    /// </summary>
    public ClassJobEntry WhiteMage => new(this.RootNode, this.definition.Whitemage);

    /// <summary>
    /// Information about the Scholar class.
    /// </summary>
    public ClassJobEntry Scholar => new(this.RootNode, this.definition.Scholar);

    /// <summary>
    /// Information about the Astrologian class.
    /// </summary>
    public ClassJobEntry Astrologian => new(this.RootNode, this.definition.Astrologian);

    /// <summary>
    /// Information about the Sage class.
    /// </summary>
    public ClassJobEntry Sage => new(this.RootNode, this.definition.Sage);

    /// <summary>
    /// Information about the Bard class.
    /// </summary>
    public ClassJobEntry Bard => new(this.RootNode, this.definition.Bard);

    /// <summary>
    /// Information about the Machinist class.
    /// </summary>
    public ClassJobEntry Machinist => new(this.RootNode, this.definition.Machinist);

    /// <summary>
    /// Information about the Dancer class.
    /// </summary>
    public ClassJobEntry Dancer => new(this.RootNode, this.definition.Dancer);

    /// <summary>
    /// Information about the BlackMage class.
    /// </summary>
    public ClassJobEntry BlackMage => new(this.RootNode, this.definition.Blackmage);

    /// <summary>
    /// Information about the Summoner class.
    /// </summary>
    public ClassJobEntry Summoner => new(this.RootNode, this.definition.Summoner);

    /// <summary>
    /// Information about the RedMage class.
    /// </summary>
    public ClassJobEntry RedMage => new(this.RootNode, this.definition.Redmage);
    
    /// <summary>
    /// Information about the Pictomancer class.
    /// </summary>
    public ClassJobEntry Pictomancer => new(this.RootNode, this.definition.Pictomancer);

    /// <summary>
    /// Information about the BlueMage class.
    /// </summary>
    public ClassJobEntry BlueMage => new(this.RootNode, this.definition.Bluemage);

    /// <summary>
    /// Information about the Carpenter class.
    /// </summary>
    public ClassJobEntry Carpenter => new(this.RootNode, this.definition.Carpenter);

    /// <summary>
    /// Information about the Blacksmith class.
    /// </summary>
    public ClassJobEntry Blacksmith => new(this.RootNode, this.definition.Blacksmith);

    /// <summary>
    /// Information about the Armorer class.
    /// </summary>
    public ClassJobEntry Armorer => new(this.RootNode, this.definition.Armorer);

    /// <summary>
    /// Information about the Goldsmith class.
    /// </summary>
    public ClassJobEntry Goldsmith => new(this.RootNode, this.definition.Goldsmith);

    /// <summary>
    /// Information about the Leatherworker class.
    /// </summary>
    public ClassJobEntry Leatherworker => new(this.RootNode, this.definition.Leatherworker);

    /// <summary>
    /// Information about the Weaver class.
    /// </summary>
    public ClassJobEntry Weaver => new(this.RootNode, this.definition.Weaver);

    /// <summary>
    /// Information about the Alchemist class.
    /// </summary>
    public ClassJobEntry Alchemist => new(this.RootNode, this.definition.Alchemist);

    /// <summary>
    /// Information about the Culinarian
    /// </summary>
    public ClassJobEntry Culinarian => new(this.RootNode, this.definition.Culinarian);

    /// <summary>
    /// Information about the Miner class.
    /// </summary>
    public ClassJobEntry Miner => new(this.RootNode, this.definition.Miner);

    /// <summary>
    /// Information about the Botanist class.
    /// </summary>
    public ClassJobEntry Botanist => new(this.RootNode, this.definition.Botanist);

    /// <summary>
    /// Information about the Fisher class.
    /// </summary>
    public ClassJobEntry Fisher => new(this.RootNode, this.definition.Fisher);

    /// <summary>
    /// This dictionary maps <see cref="StaticData.ClassJob"/> to the respective <see cref="ClassJobEntry"/>
    /// </summary>
    public IReadOnlyDictionary<StaticData.ClassJob, ClassJobEntry> ClassJobDict =>
        new Dictionary<StaticData.ClassJob, ClassJobEntry>
        {
            { StaticData.ClassJob.Gladiator, this.Paladin },
            { StaticData.ClassJob.Paladin, this.Paladin },

            { StaticData.ClassJob.Marauder, this.Warrior },
            { StaticData.ClassJob.Warrior, this.Warrior },

            { StaticData.ClassJob.DarkKnight, this.DarkKnight },

            { StaticData.ClassJob.Gunbreaker, this.Gunbreaker },

            { StaticData.ClassJob.Pugilist, this.Monk },
            { StaticData.ClassJob.Monk, this.Monk },

            { StaticData.ClassJob.Lancer, this.Dragoon },
            { StaticData.ClassJob.Dragoon, this.Dragoon },

            { StaticData.ClassJob.Rogue, this.Ninja },
            { StaticData.ClassJob.Ninja, this.Ninja },

            { StaticData.ClassJob.Samurai, this.Samurai },

            { StaticData.ClassJob.Reaper, this.Reaper },

            { StaticData.ClassJob.Viper, this.Viper },

            { StaticData.ClassJob.Conjurer, this.WhiteMage },
            { StaticData.ClassJob.WhiteMage, this.WhiteMage },

            { StaticData.ClassJob.Arcanist, this.Scholar },
            { StaticData.ClassJob.Scholar, this.Scholar },
            { StaticData.ClassJob.Summoner, this.Summoner },

            { StaticData.ClassJob.Astrologian, this.Astrologian },

            { StaticData.ClassJob.Sage, this.Sage },

            { StaticData.ClassJob.Archer, this.Bard },
            { StaticData.ClassJob.Bard, this.Bard },

            { StaticData.ClassJob.Machinist, this.Machinist },

            { StaticData.ClassJob.Dancer, this.Dancer },

            { StaticData.ClassJob.Thaumaturge, this.BlackMage },
            { StaticData.ClassJob.BlackMage, this.BlackMage },

            { StaticData.ClassJob.RedMage, this.RedMage },

            { StaticData.ClassJob.Pictomancer, this.Pictomancer },

            { StaticData.ClassJob.BlueMage, this.BlueMage },

            { StaticData.ClassJob.Blacksmith, this.Blacksmith },

            { StaticData.ClassJob.Armorer, this.Armorer },

            { StaticData.ClassJob.Goldsmith, this.Goldsmith },

            { StaticData.ClassJob.Leatherworker, this.Leatherworker },

            { StaticData.ClassJob.Weaver, this.Weaver },

            { StaticData.ClassJob.Alchemist, this.Alchemist },

            { StaticData.ClassJob.Miner, this.Miner },

            { StaticData.ClassJob.Botanist, this.Botanist },

            { StaticData.ClassJob.Fisher, this.Fisher },

            { StaticData.ClassJob.Carpenter, this.Carpenter },

            { StaticData.ClassJob.Culinarian, this.Culinarian },
        };
}