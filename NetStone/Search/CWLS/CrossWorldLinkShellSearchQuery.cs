using System;
using System.Text;

namespace NetStone.Search.CWLS;

/// <summary>
/// Models a search for a cross world link shell
/// </summary>
public class CrossWorldLinkShellSearchQuery : ISearchQuery
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
    /// Datacenter
    /// </summary>
    public string DataCenter { get; set; } = "";
    
    /// <summary>
    /// Active member count
    /// </summary>
    public ActiveMemberChoice ActiveMembers { get; set; } = ActiveMemberChoice.All;

    
    /// <summary>
    /// Sort order
    /// </summary>
    public SortKind Sorting { get; set; } = SortKind.CreationDateNewToOld;


    /// <inheritdoc />
    public string BuildQueryString()
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
            ActiveMemberChoice.OneToTen         => "1-10",
            ActiveMemberChoice.ElevenToThirty   => "11-30",
            ActiveMemberChoice.ThirtyOneToFifty => "31-51",
            ActiveMemberChoice.OverFiftyOne     => "51-",
            _ => "",
        }}");
        query.Append($"&order={this.Sorting:D}");

        return query.ToString();
    }
    
    /// <summary>
    /// Available choice for member count
    /// </summary>
    public enum ActiveMemberChoice
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

    public enum SortKind
    {
        CreationDateNewToOld = 1,
        CreationDateOldToNew = 2,
        NameAtoZ = 3,
        NameZtoA = 4,
        MemberCountDesc = 5,
        MemberCountAsc = 6,
        
        
    }
}