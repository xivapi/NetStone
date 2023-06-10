using Newtonsoft.Json;

namespace NetStone.Definitions.Model.Character;

/// <summary>
/// Definitions for a slot of gear in character profile
/// </summary>
public class GearEntryDefinition
{
    /// <summary>
    /// Name of the item
    /// </summary>
    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; }

    /// <summary>
    /// Link to Eorzea Database for item
    /// </summary>
    [JsonProperty("DB_LINK")]
    public DefinitionsPack DbLink { get; set; }

    /// <summary>
    /// Name of glamour
    /// </summary>
    [JsonProperty("MIRAGE_NAME")]
    public DefinitionsPack MirageName { get; set; }

    /// <summary>
    /// Link to Eorzea Database for glamour item
    /// </summary>
    [JsonProperty("MIRAGE_DB_LINK")]
    public DefinitionsPack MirageDbLink { get; set; }

    /// <summary>
    /// Die of the item
    /// </summary>
    [JsonProperty("STAIN")]
    public DefinitionsPack Stain { get; set; }

    /// <summary>
    /// Materia Slot 1
    /// </summary>
    [JsonProperty("MATERIA_1")]
    public DefinitionsPack Materia1 { get; set; }

    /// <summary>
    /// Materia Slot 2
    /// </summary>
    [JsonProperty("MATERIA_2")]
    public DefinitionsPack Materia2 { get; set; }

    /// <summary>
    /// Materia Slot 3
    /// </summary>
    [JsonProperty("MATERIA_3")]
    public DefinitionsPack Materia3 { get; set; }

    /// <summary>
    /// Materia Slot 4
    /// </summary>
    [JsonProperty("MATERIA_4")]
    public DefinitionsPack Materia4 { get; set; }

    /// <summary>
    /// Materia Slot 5
    /// </summary>
    [JsonProperty("MATERIA_5")]
    public DefinitionsPack Materia5 { get; set; }

    /// <summary>
    /// Name of creator/crafter of this item (if applicable)
    /// </summary>
    [JsonProperty("CREATOR_NAME")]
    public DefinitionsPack CreatorName { get; set; }
}

/// <summary>
/// Definition for Soul Crystal slot
/// </summary>
public class SoulcrystalEntryDefinition
{
    /// <summary>
    /// Name of the item
    /// </summary>
    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; }
}

/// <summary>
/// Definition for all gear of the character
/// </summary>
public class CharacterGearDefinition : IDefinition
{
    /// <summary>
    /// Main hand weapon
    /// </summary>
    [JsonProperty("MAINHAND")]
    public GearEntryDefinition Mainhand { get; set; }

    /// <summary>
    /// Off hand weapon
    /// </summary>
    [JsonProperty("OFFHAND")]
    public GearEntryDefinition Offhand { get; set; }

    /// <summary>
    /// Head piece
    /// </summary>
    [JsonProperty("HEAD")]
    public GearEntryDefinition Head { get; set; }

    /// <summary>
    /// Chest piece
    /// </summary>
    [JsonProperty("BODY")]
    public GearEntryDefinition Body { get; set; }

    /// <summary>
    /// Hand piece
    /// </summary>
    [JsonProperty("HANDS")]
    public GearEntryDefinition Hands { get; set; }

    /// <summary>
    /// Waist
    /// </summary>
    [JsonProperty("WAIST")]
    public GearEntryDefinition Waist { get; set; }

    /// <summary>
    /// Legs
    /// </summary>
    [JsonProperty("LEGS")]
    public GearEntryDefinition Legs { get; set; }

    /// <summary>
    /// Feet
    /// </summary>
    [JsonProperty("FEET")]
    public GearEntryDefinition Feet { get; set; }

    /// <summary>
    /// Earrings
    /// </summary>
    [JsonProperty("EARRINGS")]
    public GearEntryDefinition Earrings { get; set; }

    /// <summary>
    /// Necklace
    /// </summary>
    [JsonProperty("NECKLACE")]
    public GearEntryDefinition Necklace { get; set; }

    /// <summary>
    /// Braccelets
    /// </summary>
    [JsonProperty("BRACELETS")]
    public GearEntryDefinition Bracelets { get; set; }

    /// <summary>
    /// Right ring
    /// </summary>
    [JsonProperty("RING1")]
    public GearEntryDefinition Ring1 { get; set; }

    /// <summary>
    /// Left ring
    /// </summary>
    [JsonProperty("RING2")]
    public GearEntryDefinition Ring2 { get; set; }

    /// <summary>
    /// Soul Crystal
    /// </summary>
    [JsonProperty("SOULCRYSTAL")]
    public SoulcrystalEntryDefinition Soulcrystal { get; set; }
}