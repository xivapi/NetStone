using Newtonsoft.Json;

namespace NetStone.Definitions.Model.Character;

/// <summary>
/// Definitions for free company of character
/// </summary>
public class CharacterFreeCompany : ICharacterSocialGroupDefinition
{
    ///<inheritdoc />
    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; }

    ///<inheritdoc />
    [JsonProperty("ICON_LAYERS")]
    public IconLayersDefinition IconLayers { get; set; }
}

/// <summary>
/// Definitions for PvP team of character
/// </summary>
public class CharacterPvPTeam : ICharacterSocialGroupDefinition
{
    ///<inheritdoc />
    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; }

    ///<inheritdoc />
    [JsonProperty("ICON_LAYERS")]
    public IconLayersDefinition IconLayers { get; set; }
}

/// <summary>
/// General definition of a social group
/// </summary>
public interface ICharacterSocialGroupDefinition : IDefinition
{
    /// <summary>
    /// Definition for the name of the group
    /// </summary>
    DefinitionsPack Name { get; set; }

    /// <summary>
    /// Definition of Icon Layers
    /// </summary>
    IconLayersDefinition IconLayers { get; set; }
}

/// <summary>
/// Generic definition for icon and name combination
/// </summary>
public class NameIconDefinition : IDefinition
{
    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; }

    /// <summary>
    /// Icon
    /// </summary>
    [JsonProperty("ICON")]
    public DefinitionsPack Icon { get; set; }
}

/// <summary>
/// Set of definition packs for character profile
/// </summary>
public class CharacterDefinition : IDefinition
{
    /// <summary>
    /// Currently active class/job
    /// </summary>
    [JsonProperty("ACTIVE_CLASSJOB")]
    public DefinitionsPack ActiveClassJob { get; set; }

    /// <summary>
    /// Level of current class/job
    /// </summary>
    [JsonProperty("ACTIVE_CLASSJOB_LEVEL")]
    public DefinitionsPack ActiveClassJobLevel { get; set; }

    /// <summary>
    /// Characters avatar picture
    /// </summary>
    [JsonProperty("AVATAR")]
    public DefinitionsPack Avatar { get; set; }

    /// <summary>
    /// Players description for this character
    /// </summary>
    [JsonProperty("BIO")]
    public DefinitionsPack Bio { get; set; }

    /// <summary>
    /// Free Company of this character
    /// </summary>
    [JsonProperty("FREE_COMPANY")]
    public CharacterFreeCompany FreeCompany { get; set; }

    /// <summary>
    /// Grand company
    /// </summary>
    [JsonProperty("GRAND_COMPANY")]
    public DefinitionsPack GrandCompany { get; set; }

    /// <summary>
    /// Deity
    /// </summary>
    [JsonProperty("GUARDIAN_DEITY")]
    public NameIconDefinition GuardianDeity { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("NAME")]
    public DefinitionsPack Name { get; set; }

    /// <summary>
    /// Nameday (Birthday)
    /// </summary>
    [JsonProperty("NAMEDAY")]
    public DefinitionsPack Nameday { get; set; }

    /// <summary>
    /// Image of full character
    /// </summary>
    [JsonProperty("PORTRAIT")]
    public DefinitionsPack Portrait { get; set; }

    /// <summary>
    /// PvP Team
    /// </summary>
    [JsonProperty("PVP_TEAM")]
    public CharacterPvPTeam PvPTeam { get; set; }

    /// <summary>
    /// Race, Clan and Gender of the character
    /// </summary>
    [JsonProperty("RACE_CLAN_GENDER")]
    public DefinitionsPack RaceClanGender { get; set; }

    /// <summary>
    /// Homeworld of the character
    /// </summary>
    [JsonProperty("SERVER")]
    public DefinitionsPack Server { get; set; }

    /// <summary>
    /// Title
    /// </summary>
    [JsonProperty("TITLE")]
    public DefinitionsPack Title { get; set; }

    /// <summary>
    /// City-State affiliation
    /// </summary>
    [JsonProperty("TOWN")]
    public NameIconDefinition Town { get; set; }
}