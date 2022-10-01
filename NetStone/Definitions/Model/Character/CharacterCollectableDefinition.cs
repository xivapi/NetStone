using Newtonsoft.Json;

namespace NetStone.Definitions.Model.Character;

public interface CharacterCollectableDefinition : IDefinition
{
    public CollectableNodeDefinition GetDefinitions();
}

public class CharacterMountDefinition : CharacterCollectableDefinition
{
    [JsonProperty("MOUNTS")]
    public CollectableNodeDefinition Mounts { get; set; }

    public CollectableNodeDefinition GetDefinitions()
    {
        return Mounts;
    }
}

public class CharacterMinionDefinition : CharacterCollectableDefinition
{
    [JsonProperty("MINIONS")]
    public CollectableNodeDefinition Minions { get; set; }

    public CollectableNodeDefinition GetDefinitions()
    {
        return Minions;
    }
}
    
public class CollectableNodeDefinition
{
    [JsonProperty("ROOT")] public DefinitionsPack Root { get; set; }

    [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }
}