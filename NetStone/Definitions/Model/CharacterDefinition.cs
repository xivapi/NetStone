using Newtonsoft.Json;

namespace NetStone.Definitions.Model
{
    public class IconLayers
    {
        [JsonProperty("BOTTOM")] public DefinitionsPack Bottom { get; set; }

        [JsonProperty("MIDDLE")] public DefinitionsPack Middle { get; set; }

        [JsonProperty("TOP")] public DefinitionsPack Top { get; set; }
    }

    public class FreeCompany : ISocialGroupDefinition
    {
        [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }

        [JsonProperty("ICON_LAYERS")] public IconLayers IconLayers { get; set; }
    }

    public class PvPTeam : ISocialGroupDefinition
    {
        [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }

        [JsonProperty("ICON_LAYERS")] public IconLayers IconLayers { get; set; }
    }

    public interface ISocialGroupDefinition : IDefinition
    {
        DefinitionsPack Name { get; set; }
        IconLayers IconLayers { get; set; }
    }

    public class CharacterDefinition : IDefinition
    {
        [JsonProperty("ACTIVE_CLASSJOB")] public DefinitionsPack ActiveClassJob { get; set; }

        [JsonProperty("ACTIVE_CLASSJOB_LEVEL")] public DefinitionsPack ActiveClassJobLevel { get; set; }

        [JsonProperty("AVATAR")] public DefinitionsPack Avatar { get; set; }

        [JsonProperty("BIO")] public DefinitionsPack Bio { get; set; }

        [JsonProperty("FREE_COMPANY")] public FreeCompany FreeCompany { get; set; }

        [JsonProperty("GRAND_COMPANY")] public DefinitionsPack GrandCompany { get; set; }

        [JsonProperty("GUARDIAN_DEITY")] public DefinitionsPack GuardianDeity { get; set; }
        
        [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }

        [JsonProperty("NAMEDAY")] public DefinitionsPack Nameday { get; set; }

        [JsonProperty("PORTRAIT")] public DefinitionsPack Portrait { get; set; }

        [JsonProperty("PVP_TEAM")] public PvPTeam PvPTeam { get; set; }

        [JsonProperty("RACE_CLAN_GENDER")] public DefinitionsPack RaceClanGender { get; set; }

        [JsonProperty("SERVER")] public DefinitionsPack Server { get; set; }

        [JsonProperty("TITLE")] public DefinitionsPack Title { get; set; }

        [JsonProperty("TOWN")] public DefinitionsPack Town { get; set; }
    }
}
