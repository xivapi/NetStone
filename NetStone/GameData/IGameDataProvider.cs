namespace NetStone.GameData;

/// <summary>
/// Needed interface for a provider of game data
/// </summary>
public interface IGameDataProvider
{
    /// <summary>
    /// Get item data by name.
    /// </summary>
    /// <param name="name">Name of the item</param>
    /// <returns>Game data</returns>
    public NamedGameData? GetItem(string name);
}