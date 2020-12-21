using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using HtmlAgilityPack;
using JetBrains.Annotations;
using NetStone.Definitions;
using NetStone.Definitions.Model;

namespace NetStone.Model.Parseables
{
    /// <summary>
    /// Container class holding information about a character and facilitating retrieval of further information.
    /// </summary>
    public class Character : LodestoneParseable
    {
        private readonly LodestoneClient client;

        private readonly ulong charId;

        private readonly CharacterDefinition charDefinition;
        private readonly GearDefinition gearDefinition;

        /// <summary>
        /// Container class for a parseable character page.
        /// </summary>
        /// <param name="client">The <see cref="LodestoneClient"/> to be used to fetch further information.</param>
        /// <param name="rootNode">The root document node of the page.</param>
        /// <param name="container">The <see cref="DefinitionsContainer"/> holding definitions to be used to access data.</param>
        /// <param name="charId">The ID of the character.</param>
        public Character(LodestoneClient client, HtmlNode rootNode, DefinitionsContainer container, ulong charId) : base(rootNode)
        {
            this.client = client;
            this.charId = charId;

            this.charDefinition = container.Character;
            this.gearDefinition = container.Gear;
        }

        #region Properties

        //public string ActiveClassJob => ParseInnerText(this.charDefinition.ActiveClassJob);

        //public int ActiveClassJobLevel => int.Parse(ParseInnerText(this.charDefinition.ActiveClassJobLevel));

        /// <summary>
        /// An URI to the avatar of the character.
        /// </summary>
        public Uri Avatar => ParseImageSource(this.charDefinition.Avatar.Selector);

        /// <summary>
        /// The character bio/description.
        /// </summary>
        public string Bio => ParseInnerText(this.charDefinition.Bio.Selector);

        /// <summary>
        /// The character FreeCompany info.
        /// </summary>
        [CanBeNull]
        public SocialGroup FreeCompany => new SocialGroup(this.RootNode, this.charDefinition.FreeCompany).GetOptional();

        /// <summary>
        /// The grand company of the character.
        /// </summary>
        public string GrandCompany => ParseInnerText(this.charDefinition.GrandCompany.Selector);

        /// <summary>
        /// The guardian deity of the character.
        /// </summary>
        public string GuardianDeity => ParseInnerText(this.charDefinition.GuardianDeity.Selector);
        
        /// <summary>
        /// The name of the character.
        /// </summary>
        public string Name => ParseInnerText(this.charDefinition.Name.Selector);

        /// <summary>
        /// The nameday of the character.
        /// </summary>
        public string Nameday => ParseInnerText(this.charDefinition.Nameday.Selector);

        /// <summary>
        /// An URI to the avatar of the character.
        /// </summary>
        public Uri Portrait => ParseImageSource(this.charDefinition.Portrait.Selector);

        /// <summary>
        /// The character PvPTeam info.
        /// </summary>
        [CanBeNull]
        public SocialGroup PvPTeam => new SocialGroup(this.RootNode, this.charDefinition.PvPTeam).GetOptional();

        //TODO: parse
        public string RaceClanGender => ParseInnerText(this.charDefinition.RaceClanGender.Selector);

        /// <summary>
        /// The server/world of the character.
        /// </summary>
        public string Server => ParseInnerText(this.charDefinition.Server.Selector);

        /// <summary>
        /// The title of the character.
        /// </summary>
        [CanBeNull]
        public string Title => ParseInnerText(this.charDefinition.Title.Selector);

        /// <summary>
        /// The town of the character.
        /// </summary>
        public string Town => ParseInnerText(this.charDefinition.Town.Selector);

        /// <summary>
        /// The character gear information.
        /// </summary>
        public Gear Gear => new Gear(this.RootNode, this.gearDefinition);

        #endregion

        /// <summary>
        /// Fetch more information about this character's classes and jobs(level, exp, unlocked, etc.).
        /// </summary>
        /// <returns><see cref="ClassJob"/> object holding this information.</returns>
        public async Task<ClassJob> GetClassJobInfo() => await this.client.GetCharacterClassJob(this.charId);

        /// <summary>
        /// String representation of this character.
        /// </summary>
        /// <returns>"Name on World"</returns>
        public override string ToString() => $"{Name} on {Server}";
    }
}
