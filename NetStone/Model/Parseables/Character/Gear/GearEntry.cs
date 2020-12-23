using System;
using System.Collections.Generic;
using System.Text;
using HtmlAgilityPack;
using JetBrains.Annotations;
using NetStone.Definitions.Model;

namespace NetStone.Model.Parseables.Character.Gear
{
    /// <summary>
    /// Container class holding information about a gear slot.
    /// </summary>
    public class GearEntry : LodestoneParseable, IOptionalParseable<GearEntry>
    {
        private readonly GearEntryDefinition definition;

        public GearEntry(HtmlNode rootNode, GearEntryDefinition definition) : base(rootNode)
        {
            this.definition = definition;
        }

        /// <summary>
        /// Link to this piece's Eorzea DB page.
        /// </summary>
        public Uri ItemDatabaseLink => ParseHref(this.definition.DbLink);

        /// <summary>
        /// Name of this item.
        /// </summary>
        public string ItemName => ParseInnerText(this.definition.Name);

        /// <summary>
        /// Link to the glamoured item's Eorzea DB page.
        /// </summary>
        public Uri GlamourDatabaseLink => ParseHref(this.definition.MirageDbLink);

        /// <summary>
        /// Name of the glamoured item.
        /// </summary>
        public string GlamourName => ParseInnerText(this.definition.MirageName);

        /// <summary>
        /// Name of the dye applied to this item.
        /// </summary>
        //TODO: parse
        public string Stain => ParseInnerText(this.definition.Stain);

        /// <summary>
        /// Materia applied to this item.
        /// </summary>
        //TODO: parse
        public string[] Materia => new[]
        {
            ParseInnerText(this.definition.Materia1),
            ParseInnerText(this.definition.Materia2),
            ParseInnerText(this.definition.Materia3),
            ParseInnerText(this.definition.Materia4),
            ParseInnerText(this.definition.Materia5),
        };

        /// <summary>
        /// Name of this item's crafter.
        /// </summary>
        public string CreatorName => ParseInnerText(this.definition.CreatorName);

        /// <summary>
        /// Indicating whether the item slot has an item equipped or not.
        /// </summary>
        public bool Exists => HasNode(this.definition.Name);

        /// <summary>
        /// Get this object if the item slot is populated, null if not.
        /// </summary>
        /// <returns>The <see cref="GearEntry"/> if the slot is populated, null if not.</returns>
        [CanBeNull]
        public GearEntry GetOptional()
        {
            return !Exists ? null : this;
        }

        /// <summary>
        /// String representation of the gear slot.
        /// </summary>
        /// <returns>The name of the item.</returns>
        public override string ToString() => ItemName;
    }
}
