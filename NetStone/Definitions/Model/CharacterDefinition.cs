using Newtonsoft.Json;

namespace NetStone.Definitions.Model
{
    public class IconLayers
    {
        [JsonProperty("BOTTOM")] public string Bottom { get; set; }

        [JsonProperty("MIDDLE")] public string Middle { get; set; }

        [JsonProperty("TOP")] public string Top { get; set; }
    }

    public class FreeCompany : ISocialGroupDefinition
    {
        [JsonProperty("NAME")] public string Name { get; set; }

        [JsonProperty("ICON_LAYERS")] public IconLayers IconLayers { get; set; }
    }

    public class PvPTeam : ISocialGroupDefinition
    {
        [JsonProperty("NAME")] public string Name { get; set; }

        [JsonProperty("ICON_LAYERS")] public IconLayers IconLayers { get; set; }
    }

    public interface ISocialGroupDefinition : IDefinition
    {
        string Name { get; set; }
        IconLayers IconLayers { get; set; }
    }

    public class CharacterDefinition : IDefinition
    {
        [JsonProperty("ACTIVE_CLASSJOB")] public string ActiveClassJob { get; set; }

        [JsonProperty("ACTIVE_CLASSJOB_LEVEL")] public string ActiveClassJobLevel { get; set; }

        [JsonProperty("AVATAR")] public string Avatar { get; set; }

        [JsonProperty("BIO")] public string Bio { get; set; }

        [JsonProperty("FREE_COMPANY")] public FreeCompany FreeCompany { get; set; }

        [JsonProperty("GRAND_COMPANY")] public string GrandCompany { get; set; }

        [JsonProperty("GUARDIAN_DEITY")] public string GuardianDeity { get; set; }
        
        [JsonProperty("NAME")] public string Name { get; set; }

        [JsonProperty("NAMEDAY")] public string Nameday { get; set; }

        [JsonProperty("PORTRAIT")] public string Portrait { get; set; }

        [JsonProperty("PVP_TEAM")] public PvPTeam PvPTeam { get; set; }

        [JsonProperty("RACE_CLAN_GENDER")] public string RaceClanGender { get; set; }

        [JsonProperty("SERVER")] public string Server { get; set; }

        [JsonProperty("TITLE")] public string Title { get; set; }

        [JsonProperty("TOWN")] public string Town { get; set; }
    }
}
