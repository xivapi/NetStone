using Newtonsoft.Json;

namespace NetStone.Definitions.Model;

public class ApplicableUris
{
    [JsonProperty("freecompany/focus.json")]
    public string FreecompanyFocusJson { get; set; }

    [JsonProperty("freecompany/freecompany.json")]
    public string FreecompanyFreecompanyJson { get; set; }

    [JsonProperty("freecompany/members.json")]
    public string FreecompanyMembersJson { get; set; }

    [JsonProperty("freecompany/reputation.json")]
    public string FreecompanyReputationJson { get; set; }

    [JsonProperty("freecompany/seeking.json")]
    public string FreecompanySeekingJson { get; set; }

    [JsonProperty("linkshell/crossworld/cwls.json")]
    public string LinkshellCrossworldCwlsJson { get; set; }

    [JsonProperty("linkshell/crossworld/members.json")]
    public string LinkshellCrossworldMembersJson { get; set; }

    [JsonProperty("linkshell/ls.json")] public string LinkshellLsJson { get; set; }

    [JsonProperty("linkshell/members.json")]
    public string LinkshellMembersJson { get; set; }

    [JsonProperty("profile/achievements.json")]
    public string ProfileAchievementsJson { get; set; }

    [JsonProperty("profile/attributes.json")]
    public string ProfileAttributesJson { get; set; }

    [JsonProperty("profile/character.json")]
    public string ProfileCharacterJson { get; set; }

    [JsonProperty("profile/classjob.json")]
    public string ProfileClassjobJson { get; set; }

    [JsonProperty("profile/gearset.json")] public string ProfileGearsetJson { get; set; }

    [JsonProperty("profile/minion.json")] public string ProfileMinionJson { get; set; }

    [JsonProperty("profile/mount.json")] public string ProfileMountJson { get; set; }

    [JsonProperty("pvpteam/members.json")] public string PvpteamMembersJson { get; set; }

    [JsonProperty("pvpteam/pvpteam.json")] public string PvpteamPvpteamJson { get; set; }

    [JsonProperty("search/character.json")]
    public string SearchCharacterJson { get; set; }

    [JsonProperty("search/cwls.json")] public string SearchCwlsJson { get; set; }

    [JsonProperty("search/freecompany.json")]
    public string SearchFreecompanyJson { get; set; }

    [JsonProperty("search/linkshell.json")]
    public string SearchLinkshellJson { get; set; }

    [JsonProperty("search/pvpteam.json")] public string SearchPvpteamJson { get; set; }
}

public class MetaDefinition : IDefinition
{
    [JsonProperty("version")] public string Version { get; set; }

    [JsonProperty("userAgentDesktop")] public string UserAgentDesktop { get; set; }

    [JsonProperty("userAgentMobile")] public string UserAgentMobile { get; set; }

    [JsonProperty("applicableUris")] public ApplicableUris ApplicableUris { get; set; }
}