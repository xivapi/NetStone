using System.Threading.Tasks;
using HtmlAgilityPack;
using NetStone.Definitions.Model.Character;
using NetStone.Model.Parseables.FreeCompany;

namespace NetStone.Model.Parseables.Character;

public class FreeCompanySocialGroup : SocialGroup
{
    private readonly LodestoneClient client;

    public FreeCompanySocialGroup(LodestoneClient client, HtmlNode rootNode, ICharacterSocialGroupDefinition socialGroupDefinition) : base(rootNode, socialGroupDefinition)
    {
        this.client = client;
    }

    /// <summary>
    /// Fetch the full details of this FC.
    /// </summary>
    /// <returns><see cref="LodestoneFreeCompany"/> object containing all details of the free company.</returns>
    public async Task<LodestoneFreeCompany?> GetDetails() => await this.client.GetFreeCompany(this.Id);
}