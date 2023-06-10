using System;

namespace NetStone.StaticData;

/// <summary>
/// The supported Lodestone languages.
/// </summary>
[Flags]
public enum Language
{
    /// <summary>
    /// No language specified
    /// </summary>
    None = 0,

    /// <summary>
    /// Japanese
    /// </summary>
    Japanese = 1 << 0,

    /// <summary>
    /// English
    /// </summary>
    English = 1 << 1,

    /// <summary>
    /// German
    /// </summary>
    German = 1 << 2,

    /// <summary>
    /// French
    /// </summary>
    French = 1 << 3,
}