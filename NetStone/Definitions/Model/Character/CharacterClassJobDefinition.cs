using Newtonsoft.Json;

namespace NetStone.Definitions.Model.Character;

/// <summary>
/// Definitions for Bozja jobs
/// </summary>
public class ClassJobBozjaDefinition
{
    /// <summary>
    /// Level
    /// </summary>
    [JsonProperty("LEVEL")]
    public DefinitionsPack LEVEL { get; set; }

    /// <summary>
    /// Mettle
    /// </summary>
    [JsonProperty("METTLE")]
    public DefinitionsPack METTLE { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("NAME")]
    public DefinitionsPack NAME { get; set; }
}

/// <summary>
/// Definitions for Eureka jobs
/// </summary>
public class ClassJobEurekaDefinition
{
    /// <summary>
    /// Experience
    /// </summary>
    [JsonProperty("EXP")]
    public DefinitionsPack Exp { get; set; }

    /// <summary>
    /// Level
    /// </summary>
    [JsonProperty("LEVEL")]
    public DefinitionsPack Level { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; }
}

/// <summary>
/// Definitions for Battle jobs, Crafter and Gatherer
/// </summary>
public class ClassJobEntryDefinition
{
    /// <summary>
    /// Level
    /// </summary>
    [JsonProperty("LEVEL")]
    public DefinitionsPack Level { get; set; }

    /// <summary>
    /// Indicates of the job is Unlocked
    /// </summary>
    [JsonProperty("UNLOCKSTATE")]
    public DefinitionsPack UnlockState { get; set; }

    /// <summary>
    /// Experience
    /// </summary>
    [JsonProperty("EXP")]
    public DefinitionsPack Exp { get; set; }
}

/// <summary>
/// Definition container for all classes and jobs of a character
/// </summary>
public class CharacterClassJobDefinition : IDefinition
{
    /// <summary>
    /// Bozja job
    /// </summary>
    [JsonProperty("BOZJA")]
    public ClassJobBozjaDefinition Bozja { get; set; }

    /// <summary>
    /// Eureka
    /// </summary>
    [JsonProperty("EUREKA")]
    public ClassJobEurekaDefinition Eureka { get; set; }

    /// <summary>
    /// Paladin (includes Gladiator)
    /// </summary>
    [JsonProperty("PALADIN")]
    public ClassJobEntryDefinition Paladin { get; set; }

    /// <summary>
    /// Warrior (includes Marauder)
    /// </summary>
    [JsonProperty("WARRIOR")]
    public ClassJobEntryDefinition Warrior { get; set; }

    /// <summary>
    /// Dark Knight
    /// </summary>
    [JsonProperty("DARKKNIGHT")]
    public ClassJobEntryDefinition DarkKnight { get; set; }

    /// <summary>
    /// Gunbreaker
    /// </summary>
    [JsonProperty("GUNBREAKER")]
    public ClassJobEntryDefinition Gunbreaker { get; set; }

    /// <summary>
    /// Monk (includes Pugilist)
    /// </summary>
    [JsonProperty("MONK")]
    public ClassJobEntryDefinition Monk { get; set; }

    /// <summary>
    /// Dragoon (include Lancer)
    /// </summary>
    [JsonProperty("DRAGOON")]
    public ClassJobEntryDefinition Dragoon { get; set; }

    /// <summary>
    /// Ninja (includes Rogue)
    /// </summary>
    [JsonProperty("NINJA")]
    public ClassJobEntryDefinition Ninja { get; set; }

    /// <summary>
    /// Samurai
    /// </summary>
    [JsonProperty("SAMURAI")]
    public ClassJobEntryDefinition Samurai { get; set; }

    /// <summary>
    /// Reaper
    /// </summary>
    [JsonProperty("REAPER")]
    public ClassJobEntryDefinition Reaper { get; set; }

    /// <summary>
    /// White Mage (includes Conjurer)
    /// </summary>
    [JsonProperty("WHITEMAGE")]
    public ClassJobEntryDefinition Whitemage { get; set; }

    /// <summary>
    /// Scholar
    /// </summary>
    [JsonProperty("SCHOLAR")]
    public ClassJobEntryDefinition Scholar { get; set; }

    /// <summary>
    /// Astrologian
    /// </summary>
    [JsonProperty("ASTROLOGIAN")]
    public ClassJobEntryDefinition Astrologian { get; set; }

    /// <summary>
    /// Sage
    /// </summary>
    [JsonProperty("SAGE")]
    public ClassJobEntryDefinition Sage { get; set; }

    /// <summary>
    /// Bard
    /// </summary>
    [JsonProperty("BARD")]
    public ClassJobEntryDefinition Bard { get; set; }

    /// <summary>
    /// Machinist
    /// </summary>
    [JsonProperty("MACHINIST")]
    public ClassJobEntryDefinition Machinist { get; set; }

    /// <summary>
    /// Dancer
    /// </summary>
    [JsonProperty("DANCER")]
    public ClassJobEntryDefinition Dancer { get; set; }

    /// <summary>
    /// Black Mage
    /// </summary>
    [JsonProperty("BLACKMAGE")]
    public ClassJobEntryDefinition Blackmage { get; set; }

    /// <summary>
    /// Summoner
    /// </summary>
    [JsonProperty("SUMMONER")]
    public ClassJobEntryDefinition Summoner { get; set; }

    /// <summary>
    /// Red Mage
    /// </summary>
    [JsonProperty("REDMAGE")]
    public ClassJobEntryDefinition Redmage { get; set; }

    /// <summary>
    /// Blue Mage
    /// </summary>
    [JsonProperty("BLUEMAGE")]
    public ClassJobEntryDefinition Bluemage { get; set; }

    /// <summary>
    /// Carpenter
    /// </summary>
    [JsonProperty("CARPENTER")]
    public ClassJobEntryDefinition Carpenter { get; set; }

    /// <summary>
    /// Blacksmith
    /// </summary>
    [JsonProperty("BLACKSMITH")]
    public ClassJobEntryDefinition Blacksmith { get; set; }

    /// <summary>
    /// Armorer
    /// </summary>
    [JsonProperty("ARMORER")]
    public ClassJobEntryDefinition Armorer { get; set; }

    /// <summary>
    /// Goldsmith
    /// </summary>
    [JsonProperty("GOLDSMITH")]
    public ClassJobEntryDefinition Goldsmith { get; set; }

    /// <summary>
    /// Leatherworker
    /// </summary>
    [JsonProperty("LEATHERWORKER")]
    public ClassJobEntryDefinition Leatherworker { get; set; }

    /// <summary>
    /// Weaver
    /// </summary>
    [JsonProperty("WEAVER")]
    public ClassJobEntryDefinition Weaver { get; set; }

    /// <summary>
    /// Alchemist
    /// </summary>
    [JsonProperty("ALCHEMIST")]
    public ClassJobEntryDefinition Alchemist { get; set; }

    /// <summary>
    /// Culinarian
    /// </summary>
    [JsonProperty("CULINARIAN")]
    public ClassJobEntryDefinition Culinarian { get; set; }

    /// <summary>
    /// Miner
    /// </summary>
    [JsonProperty("MINER")]
    public ClassJobEntryDefinition Miner { get; set; }

    /// <summary>
    ///Botanist
    /// </summary>
    [JsonProperty("BOTANIST")]
    public ClassJobEntryDefinition Botanist { get; set; }

    /// <summary>
    /// Fisher
    /// </summary>
    [JsonProperty("FISHER")]
    public ClassJobEntryDefinition Fisher { get; set; }
}