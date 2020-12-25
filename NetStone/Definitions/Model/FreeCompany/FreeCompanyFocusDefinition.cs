using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;

namespace NetStone.Definitions.Model.FreeCompany
{
    public class FreeCompanyFocusEntryDefinition : IDefinition
    {
        [JsonProperty("NAME")]
        public DefinitionsPack NAME { get; set; } 

        [JsonProperty("ICON")]
        public DefinitionsPack ICON { get; set; } 

        [JsonProperty("STATUS")]
        public DefinitionsPack STATUS { get; set; } 
    }

    public class FreeCompanyFocusDefinition : IDefinition
    {
        [JsonProperty("NOT_SPECIFIED")]
        public DefinitionsPack NOTSPECIFIED { get; set; } 

        [JsonProperty("RP")]
        public FreeCompanyFocusEntryDefinition RP { get; set; } 

        [JsonProperty("LEVELING")]
        public FreeCompanyFocusEntryDefinition LEVELING { get; set; } 

        [JsonProperty("CASUAL")]
        public FreeCompanyFocusEntryDefinition CASUAL { get; set; } 

        [JsonProperty("HARDCORE")]
        public FreeCompanyFocusEntryDefinition HARDCORE { get; set; } 

        [JsonProperty("DUNGEONS")]
        public FreeCompanyFocusEntryDefinition DUNGEONS { get; set; } 

        [JsonProperty("GUILDHESTS")]
        public FreeCompanyFocusEntryDefinition GUILDHESTS { get; set; } 

        [JsonProperty("TRIALS")]
        public FreeCompanyFocusEntryDefinition TRIALS { get; set; } 

        [JsonProperty("RAIDS")]
        public FreeCompanyFocusEntryDefinition RAIDS { get; set; } 

        [JsonProperty("PVP")]
        public FreeCompanyFocusEntryDefinition PVP { get; set; } 
    }
}
