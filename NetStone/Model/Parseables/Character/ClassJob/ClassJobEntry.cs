using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using HtmlAgilityPack;
using NetStone.Definitions.Model;

namespace NetStone.Model.Parseables.Character.ClassJob
{
    public class ClassJobEntry : LodestoneParseable, IOptionalParseable<ClassJobEntry>
    {
        private readonly ClassJobEntryDefinition definition;

        public ClassJobEntry(HtmlNode rootNode, ClassJobEntryDefinition definition) : base(rootNode)
        {
            this.definition = definition;
        }

        public string Name => ParseTooltip(this.definition.UnlockState);

        public bool IsJobUnlocked => Name.Contains("/");

        public int Level
        {
            get
            {
                var level = ParseInnerText(this.definition.Level);
                return level == "-" ? 0 : int.Parse(level);
            }
        }

        public string ExpString => ParseInnerText(this.definition.Exp);

        private long? expCurrentVal;
        public long ExpCurrent
        {
            get
            {
                if (!this.expCurrentVal.HasValue)
                    ParseExp();

                return this.expCurrentVal.Value;
            }
        }
        
        private long? expMaxVal;
        public long ExpMax
        {
            get
            {
                if (!this.expCurrentVal.HasValue)
                    ParseExp();

                return this.expMaxVal.Value;
            }
        }

        public long ExpToGo => ExpMax - ExpCurrent;

        private void ParseExp()
        {
            if (!Exists)
            {
                this.expCurrentVal = 0;
                this.expMaxVal = 0;
                
                return;
            }

            var expVals = ExpString.Split(" / ").Select(x => x.Replace(",", string.Empty)).ToArray();

            if (expVals[0] == "--")
            {
                this.expCurrentVal = 0;
                this.expMaxVal = 0;
                
                return;
            }

            this.expCurrentVal = long.Parse(expVals[0]);
            this.expMaxVal = long.Parse(expVals[1]);
        }

        public bool IsSpecialized => ParseAttribute(this.definition.UnlockState, "class").Contains("--meister");
        
        public bool Exists => Level != 0;
        
        public ClassJobEntry GetOptional()
        {
            return !Exists ? null : this;
        }

        public override string ToString() => $"{Name} ({Level})";
    }
}
