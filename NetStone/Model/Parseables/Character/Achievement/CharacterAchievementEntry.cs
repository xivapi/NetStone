using System;
using System.Linq;
using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;

namespace NetStone.Model.Parseables.Character.Achievement;

/// <summary>
/// Models data for one Achievement this character earned
/// </summary>
public class CharacterAchievementEntry : LodestoneParseable
{
    private readonly CharacterAchievementEntryDefinition definition;

    /// <summary>
    /// Create instance of achievement entry fpr given node
    /// </summary>
    /// <param name="rootNode">Root html node of this entry</param>
    /// <param name="definition">Css and regex definition</param>
    public CharacterAchievementEntry(HtmlNode rootNode, CharacterAchievementEntryDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    /// <summary>
    /// The Name of this achievement
    /// </summary>
    public string Name => ParseRegex(this.definition.Name).First(r => r.Name.Equals("Name")).Value;

    /// <summary>
    /// ID of this achievement
    /// </summary>
    public ulong? Id => ParseHrefIdULong(this.definition.Id);

    /// <summary>
    /// Link to the Eorzean Database
    /// </summary>
    public Uri? DatabaseLink => ParseHref(this.definition.Id);

    /// <summary>
    /// Time when this character earned this achievement
    /// </summary>
    public DateTime TimeAchieved => ParseTime(this.definition.Time);

    /// <inheritdoc />
    public override string ToString() => this.Name;
}