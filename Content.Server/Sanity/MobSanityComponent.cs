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
using Content.Shared.Sanity;
using Robust.Shared.Players;

namespace Content.Server.Sanity
{
    [RegisterComponent()]
    public class MobSanityComponent : SharedMobSanityComponent
    {

        /// <summary>
        ///  Sanity variables
        /// </summary>

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
        /// <summary>
        /// How much sanity points are given per second, this rounds itself , but losses are aceptable.
        /// </summary>

        [ViewVariables(VVAccess.ReadWrite)]
        public float SanityGainPerSecond = 0.1f;
        /// <summary>
        /// Maximum sanity to lose per cycle. Can be influenced
        /// </summary>

        [ViewVariables(VVAccess.ReadWrite)]
        public int MaxSanityDecayPerCycle = 20;
        /// <summary>
        /// This divides max sanity to show the sanity hud element sprite, automatically updated when max sanity changes , do not touch.
        /// </summary>

        [ViewVariables(VVAccess.ReadOnly)]
        public int SanitySteps = 20;

        /// <summary>
        ///  This is the maximum sanity , the more a player has the bigger the buffer between the stages becomes
        /// </summary>
        [ViewVariables(VVAccess.ReadWrite)]
        public int MaxSanity
        {
            get => _maxSanity;
            set
            {
                _maxSanity = value;
                // 6 Sprites so far. 
                SanitySteps = _maxSanity / 6;
            }
        }

        private int _maxSanity = 100;

        ///
        /// Insight variables
        ///
        [ViewVariables(VVAccess.ReadWrite)]
        public int Insight
        {
            get => _insight;
            set
            {
                if (_insight + value > RequiredInsight)
                {
                    InsightPoints += (_insight + value) / RequiredInsight;
                    _insight = (_insight + value) % RequiredInsight;
                }
                else
                    _insight += value;
            }
        }

        private int _insight = 0;

        [ViewVariables(VVAccess.ReadWrite)]
        public int RequiredInsight = 100;

        [ViewVariables(VVAccess.ReadWrite)]
        public int InsightPoints = 0;

        [ViewVariables(VVAccess.ReadWrite)]
        public float PassiveInsightGainPerSecond = 0.75f;

        ///
        /// Rest variables
        ///
        [ViewVariables(VVAccess.ReadWrite)]
        public int Rest
        {
            get => _rest;
            set
            {
                if (_rest + value > RestRequired)
                {
                    RestPoints += (_rest + value) / RestRequired;
                    _rest = (_rest + value) % RestRequired;
                }
                else
                    _rest += value;
            }
        }


        private int _rest = 0;

        [ViewVariables(VVAccess.ReadWrite)]
        public int RestPoints = 0;

        [ViewVariables(VVAccess.ReadWrite)]
        public int RestRequired = 100;

        [ViewVariables(VVAccess.ReadWrite)]
        public float RestGainPerSecond = 0.75f;

      
    }
}
