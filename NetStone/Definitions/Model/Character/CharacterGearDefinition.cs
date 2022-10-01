using Newtonsoft.Json;

namespace NetStone.Definitions.Model.Character;

public class GearEntryDefinition
{
    [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }

    [JsonProperty("DB_LINK")] public DefinitionsPack DbLink { get; set; }

    [JsonProperty("MIRAGE_NAME")] public DefinitionsPack MirageName { get; set; }

    [JsonProperty("MIRAGE_DB_LINK")] public DefinitionsPack MirageDbLink { get; set; }

    [JsonProperty("STAIN")] public DefinitionsPack Stain { get; set; }

    [JsonProperty("MATERIA_1")] public DefinitionsPack Materia1 { get; set; }

    [JsonProperty("MATERIA_2")] public DefinitionsPack Materia2 { get; set; }

    [JsonProperty("MATERIA_3")] public DefinitionsPack Materia3 { get; set; }

    [JsonProperty("MATERIA_4")] public DefinitionsPack Materia4 { get; set; }

    [JsonProperty("MATERIA_5")] public DefinitionsPack Materia5 { get; set; }

    [JsonProperty("CREATOR_NAME")] public DefinitionsPack CreatorName { get; set; }
}

public class SoulcrystalEntryDefinition
{
    [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }
}

public class CharacterGearDefinition : IDefinition
{
    [JsonProperty("MAINHAND")] public GearEntryDefinition Mainhand { get; set; }

    [JsonProperty("OFFHAND")] public GearEntryDefinition Offhand { get; set; }

    [JsonProperty("HEAD")] public GearEntryDefinition Head { get; set; }

    [JsonProperty("BODY")] public GearEntryDefinition Body { get; set; }

    [JsonProperty("HANDS")] public GearEntryDefinition Hands { get; set; }

    [JsonProperty("WAIST")] public GearEntryDefinition Waist { get; set; }

    [JsonProperty("LEGS")] public GearEntryDefinition Legs { get; set; }

    [JsonProperty("FEET")] public GearEntryDefinition Feet { get; set; }

    [JsonProperty("EARRINGS")] public GearEntryDefinition Earrings { get; set; }

    [JsonProperty("NECKLACE")] public GearEntryDefinition Necklace { get; set; }

    [JsonProperty("BRACELETS")] public GearEntryDefinition Bracelets { get; set; }

    [JsonProperty("RING1")] public GearEntryDefinition Ring1 { get; set; }

    [JsonProperty("RING2")] public GearEntryDefinition Ring2 { get; set; }

    [JsonProperty("SOULCRYSTAL")] public SoulcrystalEntryDefinition Soulcrystal { get; set; }
}