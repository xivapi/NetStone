using System.Diagnostics.CodeAnalysis;

namespace NetStone.GameData;

/// <summary>
/// Generic container for game data
/// </summary>
[SuppressMessage("ReSharper", "UnusedAutoPropertyAccessor.Global")]
public struct GameDataInfo
{
    /// <summary>
    /// Key /ID of data
    /// </summary>
    public uint Key { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; }
}