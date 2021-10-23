using System;
using System.Collections.Generic;
using Content.Server.Alert;
using Content.Shared.Alert;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robust.Shared.GameObjects.Components;
using Robust.Server.GameObjects;
using Robust.Shared.Serialization.Manager.Attributes;
using Robust.Server.Player;
using Robust.Shared.GameObjects;
using Robust.Shared.Map;
using Robust.Shared.ViewVariables;

namespace Content.Server.Sanity
{
    [RegisterComponent()]
    public class MobSanityComponent : Component
    {
        public override string Name => "Sanity";

        public int Sanity
        {
            get => _sanity;
            set
            {
                if (_sanity + value > MaxSanity)
                {
                    _sanity = MaxSanity;
                }
                else
                    _sanity += value;

            }
        }
        /// <summary>
        ///  Internal variable for handling sanity set and get.
        /// </summary>
        private int _sanity = 0;

        public int SanityGainDefault = 5;
        /// <summary>
        /// Maximum sanity to lose per cycle. Can be influenced
        /// </summary>

        public int MaxSanityDecayPerCycle = 20;
        /// <summary>
        /// This divides max sanity to show the sanity hud element sprite, automatically updated when max sanity changes , do not touch.
        /// </summary>

        public int SanitySteps = 20;

        /// <summary>
        ///  This is the maximum sanity , the more a player has the bigger the buffer between the stages becomes
        /// </summary>
        public int MaxSanity
        {
            get => _maxSanity;
            set
            {
                _maxSanity = value;
                SanitySteps = _maxSanity / 6;
            }
        }

        private int _maxSanity = 100;
        
    }
}
