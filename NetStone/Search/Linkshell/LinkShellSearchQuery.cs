using System;
using System.Text;

namespace NetStone.Search.Linkshell;

/// <summary>
/// Models a search for a link shell
/// </summary>
public class LinkShellSearchQuery : BaseLinkShellSearchQuery
{
    
    /// <summary>
    /// Datacenter
    /// <remarks>This is ignored if <see cref="HomeWorld"/> is set</remarks>
    /// </summary>
    public string DataCenter { get; set; } = "";
    
    /// <summary>
    /// Home-world
    /// </summary>
    public string HomeWorld { get; set; } = "";
    /// <inheritdoc />
    public override string BuildQueryString()
    {
        if(string.IsNullOrEmpty(this.Name))
            throw new ArgumentException("Name must not be empty or null.", nameof(this.Name));
        
        var query = new StringBuilder();

        query.Append($"?q={this.Name}");
        if(this.RecruitingOnly)
            query.Append("&cf_public=1");
        query.Append($"&worldname={(string.IsNullOrEmpty(this.HomeWorld) ? $"_dc_{this.DataCenter}" : this.HomeWorld)}");
        query.Append($@"&character_count={this.ActiveMembers switch
        {
            LinkshellSizeCategory.OneToTen         => "1-10",
            LinkshellSizeCategory.ElevenToThirty   => "11-30",
            LinkshellSizeCategory.ThirtyOneToFifty => "31-51",
            LinkshellSizeCategory.OverFiftyOne     => "51-",
            _                                              => "",
        }}");
        query.Append($"&order={this.Sorting:D}");

        return query.ToString();
    }
}

/// <summary>
/// Models a search for a cross world link shell
/// </summary>
public class CrossWorldLinkShellSearchQuery : BaseLinkShellSearchQuery
{
    
    /// <summary>
    /// Datacenter 
    /// </summary>
    public string DataCenter { get; set; } = "";
    /// <inheritdoc />
    public override string BuildQueryString()
    {
        if(string.IsNullOrEmpty(this.Name))
            throw new ArgumentException("Name must not be empty or null.", nameof(this.Name));
        
        var query = new StringBuilder();

        query.Append($"?q={this.Name}");
        if(this.RecruitingOnly)
            query.Append("&cf_public=1");
        query.Append($"&dcname={this.DataCenter}");
        query.Append($@"&character_count={this.ActiveMembers switch
        {
            LinkshellSizeCategory.OneToTen         => "1-10",
            LinkshellSizeCategory.ElevenToThirty   => "11-30",
            LinkshellSizeCategory.ThirtyOneToFifty => "31-51",
            LinkshellSizeCategory.OverFiftyOne     => "51-",
            _                                              => "",
        }}");
        query.Append($"&order={this.Sorting:D}");

        return query.ToString();
    }
}

/// <summary>
/// Models a search for a cross world link shell
/// </summary>
public abstract class BaseLinkShellSearchQuery : ISearchQuery
{
    /// <summary>
    /// Only search for actively recruiting 
    /// </summary>
    public bool RecruitingOnly { get; set; }

    /// <summary>
    /// Name
    /// </summary>
    public string Name { get; set; } = "";
    
    /// <summary>
    /// Active member count
    /// </summary>
    public LinkshellSizeCategory ActiveMembers { get; set; } = LinkshellSizeCategory.All;

    
    /// <summary>
    /// Sort order
    /// </summary>
    public LinkshellSortKind Sorting { get; set; } = LinkshellSortKind.CreationDateNewToOld;

    /// <inheritdoc />
    public abstract string BuildQueryString();
}

/// <summary>
/// Available choice for member count
/// </summary>
public enum LinkshellSizeCategory
{
    /// <summary>
    /// All
    /// </summary>
    All,
    /// <summary>
    /// 1-10
    /// </summary>
    OneToTen,
    /// <summary>
    /// 11-30
    /// </summary>
    ElevenToThirty,
    /// <summary>
    /// 31-50
    /// </summary>
    ThirtyOneToFifty,
    /// <summary>
    /// Over 51
    /// </summary>
    OverFiftyOne,
}

/// <summary>
/// Ways to sort linkshell and cwls search results
/// </summary>
public enum LinkshellSortKind
{
    /// <summary>
    /// Creation date (newest to oldest)
    /// </summary>
    CreationDateNewToOld = 1,
    /// <summary>
    /// Creation date (oldest to newest)
    /// </summary>
    CreationDateOldToNew = 2,
    /// <summary>
    /// Name (A - Z)
    /// </summary>
    NameAtoZ = 3,
    /// <summary>
    /// Name (Z - A)
    /// </summary>
    NameZtoA = 4,
    /// <summary>
    /// Membership (high to low)
    /// </summary>
    MemberCountDesc = 5,
    /// <summary>
    /// Membership (low to high)
    /// </summary>
    MemberCountAsc = 6,
        
        
}