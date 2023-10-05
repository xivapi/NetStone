using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;
using NetStone.Model.Parseables.FreeCompany;

namespace NetStone.Model.Parseables.Character;

/// <summary>
/// Models a Free Company entry on the character profile
/// </summary>
public class FreeCompanySocialGroup : SocialGroup
{
    private readonly LodestoneClient client;

    /// <summary>
    /// Constructs FC entry for profile page
    /// </summary>
    /// <param name="client"></param>
    /// <param name="rootNode"></param>
    /// <param name="socialGroupDefinition"></param>
    public FreeCompanySocialGroup(LodestoneClient client, HtmlNode rootNode,
        ICharacterSocialGroupDefinition socialGroupDefinition) : base(rootNode, socialGroupDefinition)
    {
        this.client = client;
    }

    /// <summary>
    /// Fetch the full details of this FC.
    /// </summary>
    /// <returns><see cref="LodestoneFreeCompany"/> object containing all details of the free company.</returns>
    public async Task<LodestoneFreeCompany?> GetDetails() =>
        this.Id is null ? null : await this.client.GetFreeCompany(this.Id);
}