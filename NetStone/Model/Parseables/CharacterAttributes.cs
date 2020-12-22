using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using NetStone.Definitions.Model;

namespace NetStone.Model.Parseables
{
    public class CharacterAttributes : LodestoneParseable
    {
        private readonly CharacterAttributesDefinition definition;

        public CharacterAttributes(HtmlNode rootNode, CharacterAttributesDefinition definition) : base(rootNode)
        {
            this.definition = definition;
        }

        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string Strength => ParseInnerText(this.definition.Strength);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string Dexterity => ParseInnerText(this.definition.Dexterity);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string Vitality => ParseInnerText(this.definition.Vitality);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string Intelligence => ParseInnerText(this.definition.Intelligence);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string Mind => ParseInnerText(this.definition.Mind);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string CriticalHitRate => ParseInnerText(this.definition.CriticalHitRate);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string Determination => ParseInnerText(this.definition.Determination);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string DirectHitRate => ParseInnerText(this.definition.DirectHitRate);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string Defense => ParseInnerText(this.definition.Defense);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string MagicDefense => ParseInnerText(this.definition.MagicDefense);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string AttackPower => ParseInnerText(this.definition.AttackPower);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string SkillSpeed => ParseInnerText(this.definition.AttackPower);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string AttackMagicPotency => ParseInnerText(this.definition.AttackMagicPotency);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string HealingMagicPotency => ParseInnerText(this.definition.HealingMagicPotency);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string SpellSpeed => ParseInnerText(this.definition.SpellSpeed);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string Tenacity => ParseInnerText(this.definition.Tenacity);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string Piety => ParseInnerText(this.definition.Piety);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string Hp => ParseInnerText(this.definition.Hp);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string MpGpCp => ParseInnerText(this.definition.MpGpCp);
        
        /// <summary>
        /// This characters' strength value.
        /// </summary>
        public string MpGpCpParameterName => ParseInnerText(this.definition.MpGpCpParameterName);
    }
}
