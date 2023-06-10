using HtmlAgilityPack;
using NetStone.Definitions.Model.FreeCompany;

namespace NetStone.Model.Parseables.FreeCompany;

/// <summary>
/// Infomation about the content this FC focuses on
/// </summary>
public class FreeCompanyFocus : LodestoneParseable, IOptionalParseable<FreeCompanyFocus>
{
    private readonly FreeCompanyFocusDefinition definition;

    ///<inheritdoc />
    public FreeCompanyFocus(HtmlNode rootNode, FreeCompanyFocusDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    /// <summary>
    /// Indicates that this FC has specified a focus
    /// </summary>
    public bool HasFocus => !HasNode(this.definition.NOTSPECIFIED);

    ///<inheritdoc />
    public bool Exists => this.HasFocus;

    /// <summary>
    /// Entry for this FC's focus on role play
    /// </summary>
    public FreeCompanyFocusEntry RolePlay => new(this.RootNode, this.definition.RolePlay);

    /// <summary>
    /// Entry for this FC's focus on leveling
    /// </summary>
    public FreeCompanyFocusEntry Leveling => new(this.RootNode, this.definition.Leveling);

    /// <summary>
    /// Entry for this FC's focus on casual content
    /// </summary>
    public FreeCompanyFocusEntry Casual => new(this.RootNode, this.definition.Casual);

    /// <summary>
    /// Entry for this FC's focus on hardcore content
    /// </summary>
    public FreeCompanyFocusEntry Hardcore => new(this.RootNode, this.definition.Hardcore);

    /// <summary>
    /// Entry for this FC's focus on dungeons
    /// </summary>
    public FreeCompanyFocusEntry Dungeons => new(this.RootNode, this.definition.Dungeons);

    /// <summary>
    /// Entry for this FC's focus on guild heists
    /// </summary>
    public FreeCompanyFocusEntry Guildhests => new(this.RootNode, this.definition.Guildhests);

    /// <summary>
    /// Entry for this FC's focus on trials
    /// </summary>
    public FreeCompanyFocusEntry Trials => new(this.RootNode, this.definition.Trials);

    /// <summary>
    /// Entry for this FC's focus on raiding
    /// </summary>
    public FreeCompanyFocusEntry Raids => new(this.RootNode, this.definition.Raids);

    /// <summary>
    /// Entry for this FC's focus on PvP
    /// </summary>
    public FreeCompanyFocusEntry PvP => new(this.RootNode, this.definition.PvP);
}