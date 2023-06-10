using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;

namespace NetStone.Model.Parseables.Character.Collectable;

/// <summary>
/// Models a collection of collectables for characters
/// </summary>
public class CharacterCollectable : LodestoneParseable
{
    private readonly CharacterCollectableDefinition definition;

    /// <summary>
    /// Constructs a collectable collection
    /// </summary>
    /// <param name="rootNode">Root node of list</param>
    /// <param name="definition">Parser definitions</param>
    public CharacterCollectable(HtmlNode rootNode, CharacterCollectableDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    private CharacterCollectableEntry[]? parsedResults;

    /// <summary>
    /// All collectables collected by the character.
    /// </summary>
    public CharacterCollectableEntry[] Collectables
    {
        get
        {
            if (this.parsedResults == null)
                ParseCollectables();

            return this.parsedResults!;
        }
    }

    private void ParseCollectables()
    {
        var nodes = QueryChildNodes(this.definition.GetDefinitions().Root);

        this.parsedResults = new CharacterCollectableEntry[nodes.Length];
        for (var i = 0; i < this.parsedResults.Length; i++)
        {
            this.parsedResults[i] = new CharacterCollectableEntry(nodes[i], this.definition);
        }
    }
}