using Newtonsoft.Json;

namespace NetStone.Definitions.Model.Character;

public class CharacterAttributesDefinition : IDefinition
{
    [JsonProperty("STRENGTH")]
    public DefinitionsPack Strength { get; set; } 

    [JsonProperty("DEXTERITY")]
    public DefinitionsPack Dexterity { get; set; } 

    [JsonProperty("VITALITY")]
    public DefinitionsPack Vitality { get; set; } 

    [JsonProperty("INTELLIGENCE")]
    public DefinitionsPack Intelligence { get; set; } 

    [JsonProperty("MIND")]
    public DefinitionsPack Mind { get; set; } 

    [JsonProperty("CRITICAL_HIT_RATE")]
    public DefinitionsPack CriticalHitRate { get; set; } 

    [JsonProperty("DETERMINATION")]
    public DefinitionsPack Determination { get; set; } 

    [JsonProperty("DIRECT_HIT_RATE")]
    public DefinitionsPack DirectHitRate { get; set; } 

    [JsonProperty("DEFENSE")]
    public DefinitionsPack Defense { get; set; } 

    [JsonProperty("MAGIC_DEFENSE")]
    public DefinitionsPack MagicDefense { get; set; } 

    [JsonProperty("ATTACK_POWER")]
    public DefinitionsPack AttackPower { get; set; } 

    [JsonProperty("SKILL_SPEED")]
    public DefinitionsPack SkillSpeed { get; set; } 

    [JsonProperty("ATTACK_MAGIC_POTENCY")]
    public DefinitionsPack AttackMagicPotency { get; set; } 

    [JsonProperty("HEALING_MAGIC_POTENCY")]
    public DefinitionsPack HealingMagicPotency { get; set; } 

    [JsonProperty("SPELL_SPEED")]
    public DefinitionsPack SpellSpeed { get; set; } 

    [JsonProperty("TENACITY")]
    public DefinitionsPack Tenacity { get; set; } 

    [JsonProperty("PIETY")]
    public DefinitionsPack Piety { get; set; } 

    [JsonProperty("HP")]
    public DefinitionsPack Hp { get; set; } 

    [JsonProperty("MP_GP_CP")]
    public DefinitionsPack MpGpCp { get; set; } 

    [JsonProperty("MP_GP_CP_PARAMETER_NAME")]
    public DefinitionsPack MpGpCpParameterName { get; set; } 
}