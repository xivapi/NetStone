using HtmlAgilityPack;
using NetStone.Definitions.Model.FreeCompany;

namespace NetStone.Model.Parseables.FreeCompany;

/// <summary>
/// Information about the Free CCompany's estate
/// </summary>
public class FreeCompanyEstate : LodestoneParseable, IOptionalParseable<FreeCompanyEstate>
{
    private readonly EstateDefinition definition;

    ///<inheritdoc />
    public FreeCompanyEstate(HtmlNode rootNode, EstateDefinition definition) : base(rootNode)
    {
        this.definition = definition;
    }

    /// <summary>
    /// Name of the estate
    /// </summary>
    public string Name => Parse(this.definition.Name);

    /// <summary>
    /// The greeting phrase for this estate
    /// </summary>
    public string Greeting => Parse(this.definition.Greeting);

    /// <summary>
    /// The plot where the estate is built
    /// </summary>
    public string Plot => Parse(this.definition.Plot);

    ///<inheritdoc />
    public bool Exists => !HasNode(this.definition.NoEstate);
}