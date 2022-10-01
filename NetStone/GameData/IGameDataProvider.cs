namespace NetStone.GameData;

public interface IGameDataProvider
{
    public NamedGameData? GetItem(string name);
}