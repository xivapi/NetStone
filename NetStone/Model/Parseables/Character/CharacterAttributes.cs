using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;

namespace NetStone.Model.Parseables.Character;

public class CharacterAttributes : LodestoneParseable
{
    private readonly CharacterAttributesDefinition definition;

    public CharacterAttributes(HtmlNode rootNode, CharacterAttributesDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    /// <summary>
    /// This characters' Strength value.
    /// </summary>
    public int Strength => int.Parse(Parse(this.definition.Strength));
        
    /// <summary>
    /// This characters' Dexterity value.
    /// </summary>
    public int Dexterity => int.Parse(Parse(this.definition.Dexterity));
        
    /// <summary>
    /// This characters' Vitality value.
    /// </summary>
    public int Vitality => int.Parse(Parse(this.definition.Vitality));
        
    /// <summary>
    /// This characters' Intelligence value.
    /// </summary>
    public int Intelligence => int.Parse(Parse(this.definition.Intelligence));
        
    /// <summary>
    /// This characters' Mind value.
    /// </summary>
    public int Mind => int.Parse(Parse(this.definition.Mind));
        
    /// <summary>
    /// This characters' Critical Hit Rate value.
    /// </summary>
    public int CriticalHitRate => int.Parse(Parse(this.definition.CriticalHitRate));
        
    /// <summary>
    /// This characters' Determination value.
    /// </summary>
    public int Determination => int.Parse(Parse(this.definition.Determination));
        
    /// <summary>
    /// This characters' Direct Hit Rate value.
    /// </summary>
    public int DirectHitRate => int.Parse(Parse(this.definition.DirectHitRate));
        
    /// <summary>
    /// This characters' Defense value.
    /// </summary>
    public int Defense => int.Parse(Parse(this.definition.Defense));
        
    /// <summary>
    /// This characters' Magic Defense value.
    /// </summary>
    public int MagicDefense => int.Parse(Parse(this.definition.MagicDefense));
        
    /// <summary>
    /// This characters' Attack Power value.
    /// </summary>
    public int AttackPower => int.Parse(Parse(this.definition.AttackPower));
        
    /// <summary>
    /// This characters' Skill Speed value.
    /// </summary>
    public int SkillSpeed => int.Parse(Parse(this.definition.AttackPower));
        
    /// <summary>
    /// This characters' Attack Magic Potency value.
    /// </summary>
    public int AttackMagicPotency => int.Parse(Parse(this.definition.AttackMagicPotency));
        
    /// <summary>
    /// This characters' Healing Magic Potency value.
    /// </summary>
    public int HealingMagicPotency => int.Parse(Parse(this.definition.HealingMagicPotency));
        
    /// <summary>
    /// This characters' Spell Speed value.
    /// </summary>
    public int SpellSpeed => int.Parse(Parse(this.definition.SpellSpeed));
        
    /// <summary>
    /// This characters' Tenacity value.
    /// </summary>
    public int Tenacity => int.Parse(Parse(this.definition.Tenacity));
        
    /// <summary>
    /// This characters' Piety value.
    /// </summary>
    public int Piety => int.Parse(Parse(this.definition.Piety));
        
    /// <summary>
    /// This characters' HP value.
    /// </summary>
    public int Hp => int.Parse(Parse(this.definition.Hp));
        
    /// <summary>
    /// This characters' MP, GP or CP value. Check the <see cref="MpGpCpParameterName"/> Property to find out which.
    /// </summary>
    public int MpGpCp => int.Parse(Parse(this.definition.MpGpCp));
        
    /// <summary>
    /// Value indicating which of MP, GP, or CP is indicated by <see cref="MpGpCp"/>.
    /// </summary>
    public string MpGpCpParameterName => Parse(this.definition.MpGpCpParameterName);
}