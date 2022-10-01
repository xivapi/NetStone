using JetBrains.Annotations;

namespace NetStone.Model;

/// <summary>
/// Interface indicating an optional parsed object that may or may not exist.
/// </summary>
/// <typeparam name="T">LodestoneParseable to be marked optional</typeparam>
public interface IOptionalParseable<T> where T : LodestoneParseable
{
    /// <summary>
    /// Value indicating if the object should be populated.
    /// </summary>
    bool Exists { get; }
}

public static class OptionalExtensions
{
    /// <summary>
    /// Method returning the object itself if exists.
    /// </summary>
    /// <returns>this if Exists == True</returns>
    [CanBeNull]
    public static T GetOptional<T>(this IOptionalParseable<T> opt) where T: LodestoneParseable
    {
        if (opt.Exists)
            return opt as T;

        return null;
    }
}