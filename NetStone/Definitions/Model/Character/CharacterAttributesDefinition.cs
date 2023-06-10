using Newtonsoft.Json;

namespace NetStone.Definitions.Model.Character;

/// <summary>
/// Node definitions for a character's attributes
/// </summary>
public class CharacterAttributesDefinition : IDefinition
{
    /// <summary>
    /// Strength
    /// </summary>
    [JsonProperty("STRENGTH")]
    public DefinitionsPack Strength { get; set; }

    /// <summary>
    /// Dexterity
    /// </summary>
    [JsonProperty("DEXTERITY")]
    public DefinitionsPack Dexterity { get; set; }

    /// <summary>
    /// Vitality
    /// </summary>
    [JsonProperty("VITALITY")]
    public DefinitionsPack Vitality { get; set; }

    /// <summary>
    /// Intelligence
    /// </summary>
    [JsonProperty("INTELLIGENCE")]
    public DefinitionsPack Intelligence { get; set; }

    /// <summary>
    /// Mind
    /// </summary>
    [JsonProperty("MIND")]
    public DefinitionsPack Mind { get; set; }

    /// <summary>
    /// Critical Hit
    /// </summary>
    [JsonProperty("CRITICAL_HIT_RATE")]
    public DefinitionsPack CriticalHitRate { get; set; }

    /// <summary>
    /// Determination
    /// </summary>
    [JsonProperty("DETERMINATION")]
    public DefinitionsPack Determination { get; set; }

    /// <summary>
    /// Direct Hit
    /// </summary>
    [JsonProperty("DIRECT_HIT_RATE")]
    public DefinitionsPack DirectHitRate { get; set; }

    /// <summary>
    /// Defense
    /// </summary>
    [JsonProperty("DEFENSE")]
    public DefinitionsPack Defense { get; set; }

    /// <summary>
    /// Magic Defense
    /// </summary>
    [JsonProperty("MAGIC_DEFENSE")]
    public DefinitionsPack MagicDefense { get; set; }

    /// <summary>
    /// Attack Power
    /// </summary>
    [JsonProperty("ATTACK_POWER")]
    public DefinitionsPack AttackPower { get; set; }

    /// <summary>
    /// Skill Speed
    /// </summary>
    [JsonProperty("SKILL_SPEED")]
    public DefinitionsPack SkillSpeed { get; set; }

    /// <summary>
    /// Attack Magic Potency
    /// </summary>
    [JsonProperty("ATTACK_MAGIC_POTENCY")]
    public DefinitionsPack AttackMagicPotency { get; set; }

    /// <summary>
    /// Healing Magic Potency
    /// </summary>
    [JsonProperty("HEALING_MAGIC_POTENCY")]
    public DefinitionsPack HealingMagicPotency { get; set; }

    /// <summary>
    /// Spell Speed
    /// </summary>
    [JsonProperty("SPELL_SPEED")]
    public DefinitionsPack SpellSpeed { get; set; }

    /// <summary>
    /// Tenacity
    /// </summary>
    [JsonProperty("TENACITY")]
    public DefinitionsPack Tenacity { get; set; }

    /// <summary>
    /// Piety
    /// </summary>
    [JsonProperty("PIETY")]
    public DefinitionsPack Piety { get; set; }

    /// <summary>
    /// Hit Points
    /// </summary>
    [JsonProperty("HP")]
    public DefinitionsPack Hp { get; set; }

    /// <summary>
    /// MP, GP or CP depending on Job
    /// </summary>
    [JsonProperty("MP_GP_CP")]
    public DefinitionsPack MpGpCp { get; set; }

    /// <summary>
    /// Name of <see cref="MpGpCp"/>
    /// </summary>
    [JsonProperty("MP_GP_CP_PARAMETER_NAME")]
    public DefinitionsPack MpGpCpParameterName { get; set; }
}