using Newtonsoft.Json;

namespace NetStone.Definitions.Model.Character;

public class CharacterFreeCompany : ICharacterSocialGroupDefinition
{
    [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }

    [JsonProperty("ICON_LAYERS")] public IconLayersDefinition IconLayers { get; set; }
}

public class CharacterPvPTeam : ICharacterSocialGroupDefinition
{
    [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }

    [JsonProperty("ICON_LAYERS")] public IconLayersDefinition IconLayers { get; set; }
}

public interface ICharacterSocialGroupDefinition : IDefinition
{
    DefinitionsPack Name { get; set; }
    IconLayersDefinition IconLayers { get; set; }
}

public class NameIconDefinition : IDefinition
{
    [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }
        
    [JsonProperty("ICON")] public DefinitionsPack Icon { get; set; }
}

public class CharacterDefinition : IDefinition
{
    [JsonProperty("ACTIVE_CLASSJOB")] public DefinitionsPack ActiveClassJob { get; set; }

    [JsonProperty("ACTIVE_CLASSJOB_LEVEL")] public DefinitionsPack ActiveClassJobLevel { get; set; }

    [JsonProperty("AVATAR")] public DefinitionsPack Avatar { get; set; }

    [JsonProperty("BIO")] public DefinitionsPack Bio { get; set; }

    [JsonProperty("FREE_COMPANY")] public CharacterFreeCompany FreeCompany { get; set; }

    [JsonProperty("GRAND_COMPANY")] public DefinitionsPack GrandCompany { get; set; }

    [JsonProperty("GUARDIAN_DEITY")] public NameIconDefinition GuardianDeity { get; set; }
        
    [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }

    [JsonProperty("NAMEDAY")] public DefinitionsPack Nameday { get; set; }

    [JsonProperty("PORTRAIT")] public DefinitionsPack Portrait { get; set; }

    [JsonProperty("PVP_TEAM")] public CharacterPvPTeam PvPTeam { get; set; }

    [JsonProperty("RACE_CLAN_GENDER")] public DefinitionsPack RaceClanGender { get; set; }

    [JsonProperty("SERVER")] public DefinitionsPack Server { get; set; }

    [JsonProperty("TITLE")] public DefinitionsPack Title { get; set; }

    [JsonProperty("TOWN")] public NameIconDefinition Town { get; set; }
}