﻿using Newtonsoft.Json;

namespace NetStone.Definitions.Model.CWLS;


/// <summary>
/// 
/// </summary>
public class CrossworldLinkshellMemberEntryDefinition : PagedEntryDefinition
{
    /// <summary>
    /// Avatar
    /// </summary>
    [JsonProperty("AVATAR")] public DefinitionsPack Avatar { get; set; }
    
    /// <summary>
    /// ID
    /// </summary>
    [JsonProperty("ID")] public DefinitionsPack Id { get; set; }
    
    /// <summary>
    /// Name
    /// </summary>
    [JsonProperty("NAME")] public DefinitionsPack Name { get; set; }
    
    /// <summary>
    /// Rank
    /// </summary>
    [JsonProperty("RANK")] public DefinitionsPack Rank { get; set; }
    
    /// <summary>
    /// Rank Icon
    /// </summary>
    [JsonProperty("RANK_ICON")] public DefinitionsPack RankIcon { get; set; }
    
    /// <summary>
    /// Linkshell rank
    /// </summary>
    [JsonProperty("LINKSHELL_RANK")] public DefinitionsPack LinkshellRank { get; set; }
    
    /// <summary>
    /// Linkshell rank Icon
    /// </summary>
    [JsonProperty("LINKSHELL_RANK_ICON")] public DefinitionsPack LinkshellRankIcon { get; set; }
    
    /// <summary>
    /// Server
    /// </summary>
    [JsonProperty("SERVER")] public DefinitionsPack Server { get; set; }
}