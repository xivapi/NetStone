using System.Collections.Generic;
using HtmlAgilityPack;
using JetBrains.Annotations;
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
    /// Information about the Paladin class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Paladin => new ClassJobEntry(this.RootNode, this.definition.Paladin).GetOptional();

    /// <summary>
    /// Information about the Warrior class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Warrior => new ClassJobEntry(this.RootNode, this.definition.Warrior).GetOptional();

    /// <summary>
    /// Information about the Dark Knight class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry DarkKnight => new ClassJobEntry(this.RootNode, this.definition.DarkKnight).GetOptional();

    /// <summary>
    /// Information about the Gunbreaker class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Gunbreaker => new ClassJobEntry(this.RootNode, this.definition.Gunbreaker).GetOptional();

    /// <summary>
    /// Information about the Monk class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Monk => new ClassJobEntry(this.RootNode, this.definition.Monk).GetOptional();

    /// <summary>
    /// Information about the Dragoon class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Dragoon => new ClassJobEntry(this.RootNode, this.definition.Dragoon).GetOptional();

    /// <summary>
    /// Information about the Ninja class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Ninja => new ClassJobEntry(this.RootNode, this.definition.Ninja).GetOptional();

    /// <summary>
    /// Information about the Samurai class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Samurai => new ClassJobEntry(this.RootNode, this.definition.Samurai).GetOptional();

    /// <summary>
    /// Information about the Reaper class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Reaper => new ClassJobEntry(this.RootNode, this.definition.Reaper).GetOptional();

    /// <summary>
    /// Information about the WhiteMage class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry WhiteMage => new ClassJobEntry(this.RootNode, this.definition.Whitemage).GetOptional();

    /// <summary>
    /// Information about the Scholar class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Scholar => new ClassJobEntry(this.RootNode, this.definition.Scholar).GetOptional();

    /// <summary>
    /// Information about the Astrologian class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Astrologian => new ClassJobEntry(this.RootNode, this.definition.Astrologian).GetOptional();

    /// <summary>
    /// Information about the Sage class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Sage => new ClassJobEntry(this.RootNode, this.definition.Sage).GetOptional();

    /// <summary>
    /// Information about the Bard class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Bard => new ClassJobEntry(this.RootNode, this.definition.Bard).GetOptional();

    /// <summary>
    /// Information about the Machinist class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Machinist => new ClassJobEntry(this.RootNode, this.definition.Machinist).GetOptional();

    /// <summary>
    /// Information about the Dancer class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Dancer => new ClassJobEntry(this.RootNode, this.definition.Dancer).GetOptional();

    /// <summary>
    /// Information about the BlackMage class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry BlackMage => new ClassJobEntry(this.RootNode, this.definition.Blackmage).GetOptional();

    /// <summary>
    /// Information about the Summoner class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Summoner => new ClassJobEntry(this.RootNode, this.definition.Summoner).GetOptional();

    /// <summary>
    /// Information about the RedMage class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry RedMage => new ClassJobEntry(this.RootNode, this.definition.Redmage).GetOptional();

    /// <summary>
    /// Information about the BlueMage class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry BlueMage => new ClassJobEntry(this.RootNode, this.definition.Bluemage).GetOptional();

    /// <summary>
    /// Information about the Carpenter class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Carpenter => new ClassJobEntry(this.RootNode, this.definition.Carpenter).GetOptional();

    /// <summary>
    /// Information about the Blacksmith class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Blacksmith => new ClassJobEntry(this.RootNode, this.definition.Blacksmith).GetOptional();

    /// <summary>
    /// Information about the Armorer class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Armorer => new ClassJobEntry(this.RootNode, this.definition.Armorer).GetOptional();

    /// <summary>
    /// Information about the Goldsmith class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Goldsmith => new ClassJobEntry(this.RootNode, this.definition.Goldsmith).GetOptional();

    /// <summary>
    /// Information about the Leatherworker class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Leatherworker => new ClassJobEntry(this.RootNode, this.definition.Leatherworker).GetOptional();

    /// <summary>
    /// Information about the Weaver class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Weaver => new ClassJobEntry(this.RootNode, this.definition.Weaver).GetOptional();

    /// <summary>
    /// Information about the Alchemist class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Alchemist => new ClassJobEntry(this.RootNode, this.definition.Alchemist).GetOptional();

    /// <summary>
    /// Information about the Culinarian
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Culinarian => new ClassJobEntry(this.RootNode, this.definition.Culinarian).GetOptional();

    /// <summary>
    /// Information about the Miner class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Miner => new ClassJobEntry(this.RootNode, this.definition.Miner).GetOptional();

    /// <summary>
    /// Information about the Botanist class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Botanist => new ClassJobEntry(this.RootNode, this.definition.Botanist).GetOptional();

    /// <summary>
    /// Information about the Fisher class.
    /// </summary>
    [CanBeNull]
    public ClassJobEntry Fisher => new ClassJobEntry(this.RootNode, this.definition.Fisher).GetOptional();

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