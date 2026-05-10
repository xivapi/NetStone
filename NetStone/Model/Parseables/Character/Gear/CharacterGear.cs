using System;
using AngleSharp.Dom;
using NetStone.Definitions.Model.Character;

namespace NetStone.Model.Parseables.Character.Gear;

/// <summary>
/// Container class holding information about a character's equipped gear.
/// </summary>
public class CharacterGear : LodestoneParseable
{
    private readonly CharacterGearDefinition definition;

    /// <summary>
    /// Constructs parser for character gear
    /// </summary>
    /// <param name="rootNode"></param>
    /// <param name="definition"></param>
    public CharacterGear(IElement rootNode, CharacterGearDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    /// <summary>
    /// Information about the characters' weapon. Null if none is equipped.
    /// </summary>
    public GearEntry? Mainhand { get; internal set; }

    internal string? MainHandLink => ParseAttribute(this.definition.Mainhand.DataLink);

    /// <summary>
    /// Information about the characters' shield/offhand. Null if none is equipped.
    /// </summary>
    public GearEntry? Offhand { get; internal set; }
    
    internal string? OffHandLink => ParseAttribute(this.definition.Offhand.DataLink);

    /// <summary>
    /// Information about the characters' headgear. Null if none is equipped.
    /// </summary>
    public GearEntry? Head { get; internal set; }
    
    internal string? HeadLink => ParseAttribute(this.definition.Head.DataLink);


    /// <summary>
    /// Information about the characters' body gear. Null if none is equipped.
    /// </summary>
    public GearEntry? Body { get; internal set; }

    internal string? BodyLink => ParseAttribute(this.definition.Body.DataLink);
    
    /// <summary>
    /// Information about the characters' gloves. Null if none is equipped.
    /// </summary>
    public GearEntry? Hands { get; internal set; }

    internal string? HandsLink => ParseAttribute(this.definition.Hands.DataLink);
    
    /// <summary>
    /// Information about the characters' waist gear. Null if none is equipped.
    /// </summary>
    [Obsolete("Not part of the game any longer. Will be removed in a future release.")]
    // ReSharper disable once UnusedAutoPropertyAccessor.Global
    public GearEntry? Waist { get; internal set; }
    [Obsolete("Not part of the game any longer. Will be removed in a future release.")]
    internal string? WaistLink => ParseAttribute(this.definition.Waist.DataLink);
    
    /// <summary>
    /// Information about the characters' pants. Null if none is equipped.
    /// </summary>
    public GearEntry? Legs { get; internal set; }
    
    internal string? LegsLink => ParseAttribute(this.definition.Legs.DataLink);

    /// <summary>
    /// Information about the characters' shoes. Null if none is equipped.
    /// </summary>
    public GearEntry? Feet { get; internal set; }

    internal string? FeetLink => ParseAttribute(this.definition.Feet.DataLink);
    
    /// <summary>
    /// Information about the characters' earrings. Null if none is equipped.
    /// </summary>
    public GearEntry? Earrings { get; internal set; }
    
    internal string? EarringsLink => ParseAttribute(this.definition.Earrings.DataLink);

    /// <summary>
    /// Information about the characters' necklace. Null if none is equipped.
    /// </summary>
    public GearEntry? Necklace { get; internal set; }
    
    internal string? NecklaceLink => ParseAttribute(this.definition.Necklace.DataLink);

    /// <summary>
    /// Information about the characters' bracelets. Null if none is equipped.
    /// </summary>
    public GearEntry? Bracelets { get; internal set; }
    
    internal string? BraceletsLink => ParseAttribute(this.definition.Bracelets.DataLink);

    /// <summary>
    /// Information about the characters' first ring. Null if none is equipped.
    /// </summary>
    public GearEntry? Ring1 { get; internal set; }
    
    internal string? Ring1Link => ParseAttribute(this.definition.Ring1.DataLink);

    /// <summary>
    /// Information about the characters' second ring. Null if none is equipped.
    /// </summary>
    public GearEntry? Ring2 { get; internal set; }
    
    internal string? Ring2Link => ParseAttribute(this.definition.Ring2.DataLink);

    /// <summary>
    /// Information about the characters' soul crystal. Null if none is equipped.
    /// </summary>
    public SoulcrystalEntry? Soulcrystal { get; internal set; }
    
    internal string? SoulcrystalLink => ParseAttribute(this.definition.Soulcrystal.DataLink);
}