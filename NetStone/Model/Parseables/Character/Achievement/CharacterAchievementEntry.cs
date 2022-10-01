using System;
using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;

namespace NetStone.Model.Parseables.Character.Achievement;

public class CharacterAchievementEntry : LodestoneParseable
{
    private readonly LodestoneClient client;
    private readonly CharacterAchievementEntryDefinition definition;

    public CharacterAchievementEntry(LodestoneClient client, HtmlNode rootNode, CharacterAchievementEntryDefinition definition) : base(rootNode)
    {
        this.client = client;
        this.definition = definition;
    }

    public string Name => Parse(this.definition.ActivityDescription);

    public ulong? Id => ParseHrefIdULong(this.definition.Id);

    public Uri DatabaseLink => ParseHref(this.definition.Id);

    public DateTime TimeAchieved => ParseTime(this.definition.Time);

    public override string ToString() => Name;
}