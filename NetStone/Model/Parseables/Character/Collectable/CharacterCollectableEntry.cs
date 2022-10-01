using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;

namespace NetStone.Model.Parseables.Character.Collectable;

public class CharacterCollectableEntry : LodestoneParseable
{
    private readonly CharacterCollectableDefinition definition;

    public CharacterCollectableEntry(HtmlNode rootNode, CharacterCollectableDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }
        
    /// <summary>
    /// The name of this collectable.
    /// </summary>
    public string Name => Parse(this.definition.GetDefinitions().Name);

    /// <summary>
    /// The string representation of this collectable.
    /// </summary>
    /// <returns><see cref="Name"/></returns>
    public override string ToString() => Name;
}