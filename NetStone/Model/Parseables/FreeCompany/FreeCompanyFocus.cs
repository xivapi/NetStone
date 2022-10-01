using HtmlAgilityPack;
using NetStone.Definitions.Model.FreeCompany;

namespace NetStone.Model.Parseables.FreeCompany;

public class FreeCompanyFocus : LodestoneParseable, IOptionalParseable<FreeCompanyFocus>
{
    private readonly FreeCompanyFocusDefinition definition;

    public FreeCompanyFocus(HtmlNode rootNode, FreeCompanyFocusDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    public bool HasFocus => !HasNode(this.definition.NOTSPECIFIED);
    public bool Exists => HasFocus;

    public FreeCompanyFocusEntry RolePlay => new FreeCompanyFocusEntry(this.RootNode, this.definition.RolePlay);
        
    public FreeCompanyFocusEntry Leveling => new FreeCompanyFocusEntry(this.RootNode, this.definition.Leveling);
        
    public FreeCompanyFocusEntry Casual => new FreeCompanyFocusEntry(this.RootNode, this.definition.Casual);
        
    public FreeCompanyFocusEntry Hardcore => new FreeCompanyFocusEntry(this.RootNode, this.definition.Hardcore);
        
    public FreeCompanyFocusEntry Dungeons => new FreeCompanyFocusEntry(this.RootNode, this.definition.Dungeons);
        
    public FreeCompanyFocusEntry Guildhests => new FreeCompanyFocusEntry(this.RootNode, this.definition.Guildhests);
        
    public FreeCompanyFocusEntry Trials => new FreeCompanyFocusEntry(this.RootNode, this.definition.Trials);
        
    public FreeCompanyFocusEntry Raids => new FreeCompanyFocusEntry(this.RootNode, this.definition.Raids);
        
    public FreeCompanyFocusEntry PvP => new FreeCompanyFocusEntry(this.RootNode, this.definition.PvP);
}