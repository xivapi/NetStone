using System;

namespace NetStone.StaticData;

/// <summary>
/// The supported Lodestone languages.
/// </summary>
[Flags]
public enum Language
{
    None = 0,
    Japanese = 1 << 0,
    English = 1 << 1,
    German = 1 << 2,
    French = 1 << 3,
}