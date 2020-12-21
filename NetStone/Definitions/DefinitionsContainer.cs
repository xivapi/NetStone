using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using NetStone.Definitions.Model;

namespace NetStone.Definitions
{
    /// <summary>
    /// Class providing definitions(Selectors, paths) for parsing lodestone content.
    /// </summary>
    public abstract class DefinitionsContainer : IDisposable
    {
        #region Definitions

        // Entities
        public CharacterDefinition Character { get; protected set; }
        public ClassJobDefinition ClassJob { get; protected set; }
        public GearDefinition Gear { get; protected set; }

        
        // Search
        public CharacterSearchDefinition CharacterSearch { get; protected set; }
        
        #endregion

        public abstract Task Reload();
        public abstract void Dispose();
    }
}
