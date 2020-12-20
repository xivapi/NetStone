using Newtonsoft.Json;

namespace NetStone.Definitions.Model
{
    public class GearEntryDefinition
    {
        [JsonProperty("NAME")] public string Name { get; set; }

        [JsonProperty("DB_LINK")] public string DbLink { get; set; }

        [JsonProperty("MIRAGE_NAME")] public string MirageName { get; set; }

        [JsonProperty("MIRAGE_DB_LINK")] public string MirageDbLink { get; set; }

        [JsonProperty("STAIN")] public string Stain { get; set; }

        [JsonProperty("MATERIA_1")] public string Materia1 { get; set; }

        [JsonProperty("MATERIA_2")] public string Materia2 { get; set; }

        [JsonProperty("MATERIA_3")] public string Materia3 { get; set; }

        [JsonProperty("MATERIA_4")] public string Materia4 { get; set; }

        [JsonProperty("MATERIA_5")] public string Materia5 { get; set; }

        [JsonProperty("CREATOR_NAME")] public string CreatorName { get; set; }
    }

    public class SoulcrystalEntryDefinition
    {
        [JsonProperty("NAME")] public string Name { get; set; }
    }

    public class GearDefinition
    {
        [JsonProperty("WEAPON")] public GearEntryDefinition Weapon { get; set; }

        [JsonProperty("SHIELD")] public GearEntryDefinition Shield { get; set; }

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
}