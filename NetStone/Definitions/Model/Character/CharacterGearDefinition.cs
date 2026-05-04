using Newtonsoft.Json;

namespace NetStone.Definitions.Model.Character;

/// <summary>
/// Definitions for a slot of gear in character profile
/// </summary>
public class GearEntryDefinition : IDefinition
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
    
    /// <summary>
    /// Item level of the item
    /// </summary>
    [JsonProperty("ITEM_LEVEL")]
    public DefinitionsPack ItemLevel { get; set; }
}

/// <summary>
/// Definition for Soul Crystal slot
/// </summary>
public class SoulcrystalEntryDefinition : IDefinition
{
    /// <summary>
    /// Name of the item
    /// </summary>
    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; }
    
    /// <summary>
    /// List of classes that can use this item
    /// </summary>
    [JsonProperty("CLASS_LIST")]
    public DefinitionsPack ClassList { get; set; }
    
    /// <summary>
    /// Item level
    /// </summary>
    [JsonProperty("ITEM_LEVEL")]
    public DefinitionsPack ItemLevel { get; set; }
}
/// <summary>
/// Definition for gear data link
/// </summary>
public class GearDataLinkDefinition
{
    /// <summary>
    /// Data link definition
    /// </summary>
    [JsonProperty("DATA_Link")]
    public DefinitionsPack DataLink { get; set; }
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
    public GearDataLinkDefinition Mainhand { get; set; }

    /// <summary>
    /// Off hand weapon
    /// </summary>
    [JsonProperty("OFFHAND")]
    public GearDataLinkDefinition Offhand { get; set; }

    /// <summary>
    /// Head piece
    /// </summary>
    [JsonProperty("HEAD")]
    public GearDataLinkDefinition Head { get; set; }

    /// <summary>
    /// Chest piece
    /// </summary>
    [JsonProperty("BODY")]
    public GearDataLinkDefinition Body { get; set; }

    /// <summary>
    /// Hand piece
    /// </summary>
    [JsonProperty("HANDS")]
    public GearDataLinkDefinition Hands { get; set; }

    /// <summary>
    /// Waist
    /// </summary>
    [JsonProperty("WAIST")]
    public GearDataLinkDefinition Waist { get; set; }

    /// <summary>
    /// Legs
    /// </summary>
    [JsonProperty("LEGS")]
    public GearDataLinkDefinition Legs { get; set; }

    /// <summary>
    /// Feet
    /// </summary>
    [JsonProperty("FEET")]
    public GearDataLinkDefinition Feet { get; set; }

    /// <summary>
    /// Earrings
    /// </summary>
    [JsonProperty("EARRINGS")]
    public GearDataLinkDefinition Earrings { get; set; }

    /// <summary>
    /// Necklace
    /// </summary>
    [JsonProperty("NECKLACE")]
    public GearDataLinkDefinition Necklace { get; set; }

    /// <summary>
    /// Braccelets
    /// </summary>
    [JsonProperty("BRACELETS")]
    public GearDataLinkDefinition Bracelets { get; set; }

    /// <summary>
    /// Right ring
    /// </summary>
    [JsonProperty("RING1")]
    public GearDataLinkDefinition Ring1 { get; set; }

    /// <summary>
    /// Left ring
    /// </summary>
    [JsonProperty("RING2")]
    public GearDataLinkDefinition Ring2 { get; set; }

    /// <summary>
    /// Soul Crystal
    /// </summary>
    [JsonProperty("SOULCRYSTAL")]
    public GearDataLinkDefinition Soulcrystal { get; set; }
}