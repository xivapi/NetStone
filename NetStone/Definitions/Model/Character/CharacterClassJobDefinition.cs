using Newtonsoft.Json;

namespace NetStone.Definitions.Model.Character;

public class ClassJobBozjaDefinition
{
    [JsonProperty("LEVEL")] public DefinitionsPack LEVEL { get; set; }

    [JsonProperty("METTLE")] public DefinitionsPack METTLE { get; set; }

    [JsonProperty("NAME")] public DefinitionsPack NAME { get; set; }
}

public class ClassJobEurekaDefinition
{
    [JsonProperty("EXP")] public DefinitionsPack Exp { get; set; }

    [JsonProperty("LEVEL")] public DefinitionsPack Level { get; set; }

    [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }
}

public class ClassJobEntryDefinition
{
    [JsonProperty("LEVEL")] public DefinitionsPack Level { get; set; }

    [JsonProperty("UNLOCKSTATE")] public DefinitionsPack UnlockState { get; set; }

    [JsonProperty("EXP")] public DefinitionsPack Exp { get; set; }
}

public class CharacterClassJobDefinition : IDefinition
{
    [JsonProperty("BOZJA")] public ClassJobBozjaDefinition Bozja { get; set; }

    [JsonProperty("EUREKA")] public ClassJobEurekaDefinition Eureka { get; set; }

    [JsonProperty("PALADIN")] public ClassJobEntryDefinition Paladin { get; set; }

    [JsonProperty("WARRIOR")] public ClassJobEntryDefinition Warrior { get; set; }

    [JsonProperty("DARKKNIGHT")] public ClassJobEntryDefinition DarkKnight { get; set; }

    [JsonProperty("GUNBREAKER")] public ClassJobEntryDefinition Gunbreaker { get; set; }

    [JsonProperty("MONK")] public ClassJobEntryDefinition Monk { get; set; }

    [JsonProperty("DRAGOON")] public ClassJobEntryDefinition Dragoon { get; set; }

    [JsonProperty("NINJA")] public ClassJobEntryDefinition Ninja { get; set; }

    [JsonProperty("SAMURAI")] public ClassJobEntryDefinition Samurai { get; set; }

    [JsonProperty("REAPER")] public ClassJobEntryDefinition Reaper { get; set; }

    [JsonProperty("WHITEMAGE")] public ClassJobEntryDefinition Whitemage { get; set; }

    [JsonProperty("SCHOLAR")] public ClassJobEntryDefinition Scholar { get; set; }

    [JsonProperty("ASTROLOGIAN")] public ClassJobEntryDefinition Astrologian { get; set; }

    [JsonProperty("SAGE")] public ClassJobEntryDefinition Sage { get; set; }

    [JsonProperty("BARD")] public ClassJobEntryDefinition Bard { get; set; }

    [JsonProperty("MACHINIST")] public ClassJobEntryDefinition Machinist { get; set; }

    [JsonProperty("DANCER")] public ClassJobEntryDefinition Dancer { get; set; }

    [JsonProperty("BLACKMAGE")] public ClassJobEntryDefinition Blackmage { get; set; }

    [JsonProperty("SUMMONER")] public ClassJobEntryDefinition Summoner { get; set; }

    [JsonProperty("REDMAGE")] public ClassJobEntryDefinition Redmage { get; set; }

    [JsonProperty("BLUEMAGE")] public ClassJobEntryDefinition Bluemage { get; set; }

    [JsonProperty("CARPENTER")] public ClassJobEntryDefinition Carpenter { get; set; }

    [JsonProperty("BLACKSMITH")] public ClassJobEntryDefinition Blacksmith { get; set; }

    [JsonProperty("ARMORER")] public ClassJobEntryDefinition Armorer { get; set; }

    [JsonProperty("GOLDSMITH")] public ClassJobEntryDefinition Goldsmith { get; set; }

    [JsonProperty("LEATHERWORKER")] public ClassJobEntryDefinition Leatherworker { get; set; }

    [JsonProperty("WEAVER")] public ClassJobEntryDefinition Weaver { get; set; }

    [JsonProperty("ALCHEMIST")] public ClassJobEntryDefinition Alchemist { get; set; }

    [JsonProperty("CULINARIAN")] public ClassJobEntryDefinition Culinarian { get; set; }

    [JsonProperty("MINER")] public ClassJobEntryDefinition Miner { get; set; }

    [JsonProperty("BOTANIST")] public ClassJobEntryDefinition Botanist { get; set; }

    [JsonProperty("FISHER")] public ClassJobEntryDefinition Fisher { get; set; }
}