using Newtonsoft.Json;

namespace NetStone.Definitions.Model;

/// <summary>
/// Hold information about the uri for which the definition packs are valid
/// </summary>
public class ApplicableUris
{
    /// <summary>
    /// Uri that holds information about FC focus
    /// </summary>
    [JsonProperty("freecompany/focus.json")]
    public string? FreecompanyFocusJson { get; set; }

    /// <summary>
    /// Uri that holds information about FC
    /// </summary>
    [JsonProperty("freecompany/freecompany.json")]
    public string? FreecompanyFreecompanyJson { get; set; }

    /// <summary>
    /// Uri that holds information about FC members
    /// </summary>
    [JsonProperty("freecompany/members.json")]
    public string? FreecompanyMembersJson { get; set; }

    /// <summary>
    /// Uri that holds information about FC reputation
    /// </summary>
    [JsonProperty("freecompany/reputation.json")]
    public string? FreecompanyReputationJson { get; set; }

    /// <summary>
    /// Uri that holds information about FC recruitment
    /// </summary>
    [JsonProperty("freecompany/seeking.json")]
    public string? FreecompanySeekingJson { get; set; }

    /// <summary>
    /// Uri that holds information about Cross World Link Shells
    /// </summary>
    [JsonProperty("linkshell/crossworld/cwls.json")]
    public string? LinkshellCrossworldCwlsJson { get; set; }

    /// <summary>
    /// Uri that holds information about Cross World Link Shell members
    /// </summary>
    [JsonProperty("linkshell/crossworld/members.json")]
    public string? LinkshellCrossworldMembersJson { get; set; }


    /// <summary>
    /// Uri that holds information about Link Shells
    /// </summary>
    [JsonProperty("linkshell/ls.json")]
    public string? LinkshellLsJson { get; set; }


    /// <summary>
    /// Uri that holds information about Link Shell members
    /// </summary>
    [JsonProperty("linkshell/members.json")]
    public string? LinkshellMembersJson { get; set; }


    /// <summary>
    /// Uri that holds information about a character's achievements
    /// </summary>
    [JsonProperty("profile/achievements.json")]
    public string? ProfileAchievementsJson { get; set; }

    /// <summary>
    /// Uri that holds information about a character's attributes
    /// </summary>
    [JsonProperty("profile/attributes.json")]
    public string? ProfileAttributesJson { get; set; }

    /// <summary>
    /// Uri that holds information about a character
    /// </summary>
    [JsonProperty("profile/character.json")]
    public string? ProfileCharacterJson { get; set; }

    /// <summary>
    /// Uri that holds information about a character jobs/classes
    /// </summary>
    [JsonProperty("profile/classjob.json")]
    public string? ProfileClassjobJson { get; set; }

    /// <summary>
    /// Uri that holds information about a character's gear
    /// </summary>
    [JsonProperty("profile/gearset.json")]
    public string? ProfileGearsetJson { get; set; }

    /// <summary>
    /// Uri that holds information about a character's minions
    /// </summary>
    [JsonProperty("profile/minion.json")]
    public string? ProfileMinionJson { get; set; }

    /// <summary>
    /// Uri that holds information about a character's mounts
    /// </summary>
    [JsonProperty("profile/mount.json")]
    public string? ProfileMountJson { get; set; }

    /// <summary>
    /// Uri that holds information about a PVP team's members
    /// </summary>
    [JsonProperty("pvpteam/members.json")]
    public string? PvpteamMembersJson { get; set; }

    /// <summary>
    /// Uri that holds information about a PVP team
    /// </summary>
    [JsonProperty("pvpteam/pvpteam.json")]
    public string? PvpteamPvpteamJson { get; set; }

    /// <summary>
    /// Uri that let's you search characters
    /// </summary>
    [JsonProperty("search/character.json")]
    public string? SearchCharacterJson { get; set; }

    /// <summary>
    /// Uri that let's you search Cross World Link Shells
    /// </summary>
    [JsonProperty("search/cwls.json")]
    public string? SearchCwlsJson { get; set; }

    /// <summary>
    /// Uri that let's you search Free Companies
    /// </summary>
    [JsonProperty("search/freecompany.json")]
    public string? SearchFreecompanyJson { get; set; }

    /// <summary>
    /// Uri that let's you search Linkshells
    /// </summary>
    [JsonProperty("search/linkshell.json")]
    public string? SearchLinkshellJson { get; set; }

    /// <summary>
    /// Uri that let's you search PvP teams
    /// </summary>
    [JsonProperty("search/pvpteam.json")]
    public string? SearchPvpteamJson { get; set; }
}

/// <summary>
/// Holds meta information regarding the definitions
/// </summary>
public class MetaDefinition : IDefinition
{
    /// <summary>
    /// Version
    /// </summary>
    [JsonProperty("version")]
    public string Version { get; set; }

    /// <summary>
    /// User Agent used to get desktop version of Lodestone
    /// </summary>
    [JsonProperty("userAgentDesktop")]
    public string UserAgentDesktop { get; set; }

    /// <summary>
    /// User Agent used to get mobile version of Lodestone
    /// </summary>
    [JsonProperty("userAgentMobile")]
    public string UserAgentMobile { get; set; }

    /// <summary>
    /// Collection of Uris for which the definition packs are valid
    /// </summary>
    [JsonProperty("applicableUris")]
    public ApplicableUris ApplicableUris { get; set; }
}