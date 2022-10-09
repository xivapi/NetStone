using System;
using System.Threading.Tasks;
using HtmlAgilityPack;
using JetBrains.Annotations;
using NetStone.Definitions;
using NetStone.Definitions.Model.Character;
using NetStone.Model.Parseables.Character.Achievement;
using NetStone.Model.Parseables.Character.ClassJob;
using NetStone.Model.Parseables.Character.Collectable;
using NetStone.Model.Parseables.Character.Gear;

namespace NetStone.Model.Parseables.Character;

/// <summary>
/// Container class holding information about a character and facilitating retrieval of further information.
/// </summary>
public class LodestoneCharacter : LodestoneParseable
{
    private readonly LodestoneClient client;

    private readonly string charId;

    private readonly CharacterDefinition charDefinition;
    private readonly CharacterGearDefinition gearDefinition;
    private readonly CharacterAttributesDefinition attributesDefinition;

    /// <summary>
    /// Container class for a parseable character page.
    /// </summary>
    /// <param name="client">The <see cref="LodestoneClient"/> to be used to fetch further information.</param>
    /// <param name="rootNode">The root document node of the page.</param>
    /// <param name="container">The <see cref="DefinitionsContainer"/> holding definitions to be used to access data.</param>
    /// <param name="charId">The ID of the character.</param>
    public LodestoneCharacter(LodestoneClient client, HtmlNode rootNode, DefinitionsContainer container, string charId) : base(rootNode)
    {
        this.client = client;
        this.charId = charId;

        this.charDefinition = container.Character;
        this.gearDefinition = container.Gear;
        this.attributesDefinition = container.Attributes;
    }

    #region Properties

    //public string ActiveClassJob => ParseInnerText(this.charDefinition.ActiveClassJob);

    /// <summary>
    /// Level of the current active ClassJob.
    /// </summary>
    public int ActiveClassJobLevel => int.Parse(ParseInnerText(this.charDefinition.ActiveClassJobLevel).Remove(0, 6));

    /// <summary>
    /// An URI to the avatar of the character.
    /// </summary>
    public Uri Avatar => ParseImageSource(this.charDefinition.Avatar);

    /// <summary>
    /// The character bio/description.
    /// </summary>
    public string Bio => Parse(this.charDefinition.Bio);

    /// <summary>
    /// The character FreeCompany info.
    /// </summary>
    [CanBeNull]
    public SocialGroup FreeCompany => new FreeCompanySocialGroup(this.client, this.RootNode, this.charDefinition.FreeCompany).GetOptional();

    /// <summary>
    /// The grand company of the character.
    /// </summary>
    public string GrandCompanyName => ParseRegex(this.charDefinition.GrandCompany)["Name"].Value;

    /// <summary>
    /// The grand company rank of the character.
    /// </summary>
    public string GrandCompanyRank => ParseRegex(this.charDefinition.GrandCompany)["Rank"].Value;

    /// <summary>
    /// The name of the guardian deity of the character.
    /// </summary>
    public string GuardianDeityName => Parse(this.charDefinition.GuardianDeity.Name);

    /// <summary>
    /// The icon of the guardian deity of the character.
    /// </summary>
    public Uri GuardianDeityIcon => ParseImageSource(this.charDefinition.GuardianDeity.Icon);

    /// <summary>
    /// The name of the character.
    /// </summary>
    public string Name => Parse(this.charDefinition.Name);

    /// <summary>
    /// The nameday of the character.
    /// </summary>
    public string Nameday => Parse(this.charDefinition.Nameday);

    /// <summary>
    /// An URI to the avatar of the character.
    /// </summary>
    public Uri Portrait => ParseImageSource(this.charDefinition.Portrait);

    /// <summary>
    /// The character PvPTeam info.
    /// </summary>
    [CanBeNull]
    public SocialGroup PvPTeam => new SocialGroup(this.RootNode, this.charDefinition.PvPTeam).GetOptional();

    //TODO: parse
    public string RaceClanGender => Parse(this.charDefinition.RaceClanGender);

    /// <summary>
    /// The server/world of the character.
    /// </summary>
    public string Server => Parse(this.charDefinition.Server);

    /// <summary>
    /// The title of the character.
    /// </summary>
    [CanBeNull]
    public string Title => Parse(this.charDefinition.Title);

    /// <summary>
    /// The town of the character.
    /// </summary>
    public string TownName => Parse(this.charDefinition.Town.Name);

    /// <summary>
    /// The town of the character.
    /// </summary>
    public Uri TownIcon => ParseHref(this.charDefinition.Town.Icon);

    /// <summary>
    /// The character gear information.
    /// </summary>
    public CharacterGear Gear => new(this.client, this.RootNode, this.gearDefinition);

    /// <summary>
    /// The character attribute information.
    /// </summary>
    public CharacterAttributes Attributes => new(this.RootNode, this.attributesDefinition);

    #endregion

    /// <summary>
    /// Fetch more information about this character's classes and jobs(level, exp, unlocked, etc.).
    /// </summary>
    /// <returns><see cref="CharacterClassJob"/> object holding this information.</returns>
    public async Task<CharacterClassJob?> GetClassJobInfo() => await this.client.GetCharacterClassJob(this.charId);

    /// <summary>
    /// Fetch more information about this character's unlocked achievements.
    /// </summary>
    /// <returns><see cref="CharacterAchievementPage"/> object holding this information.</returns>
    public async Task<CharacterAchievementPage?> GetAchievement() => await this.client.GetCharacterAchievement(this.charId);

    /// <summary>
    /// Fetch more information about this character's unlocked mounts.
    /// </summary>
    /// <returns><see cref="CharacterCollectable"/> object holding this information.</returns>
    public async Task<CharacterCollectable?> GetMounts() => await this.client.GetCharacterMount(this.charId);

    /// <summary>
    /// Fetch more information about this character's unlocked minions.
    /// </summary>
    /// <returns><see cref="CharacterCollectable"/> object holding this information.</returns>
    public async Task<CharacterCollectable?> GetMinions() => await this.client.GetCharacterMinion(this.charId);

    /// <summary>
    /// String representation of this character.
    /// </summary>
    /// <returns>"Name on World"</returns>
    public override string ToString() => $"{Name} on {Server}";
}