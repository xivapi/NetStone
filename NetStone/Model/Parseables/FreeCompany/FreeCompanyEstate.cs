using HtmlAgilityPack;
using NetStone.Definitions.Model.FreeCompany;

namespace NetStone.Model.Parseables.FreeCompany;

public class FreeCompanyEstate : LodestoneParseable, IOptionalParseable<FreeCompanyEstate>
{
    private readonly EstateDefinition definition;

    public FreeCompanyEstate(HtmlNode rootNode, EstateDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    public string Name => Parse(this.definition.Name);

    public string Greeting => Parse(this.definition.Greeting);

    public string Plot => Parse(this.definition.Plot);

    public bool Exists => !HasNode(this.definition.NoEstate);
}