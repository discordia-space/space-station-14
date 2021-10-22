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

namespace Content.Server.Sanity
{
    [RegisterComponent()]
    public partial class MobSanityComponent : Component
    {
        public override string Name => "Sanity";
        public int Sanity
        {
            get => Sanity;
            set
            {
                if (Sanity + value > MaxSanity)
                {
                    Sanity = MaxSanity;
                }
                else
                    Sanity += value;

            }
        } 

        public int SanityGainDefault = 5;

        public int MaxSanityDecayPerCycle = 20;

        public int MaxSanity = 100;
        /*
        public Dictionary<SanityThreshold, int> SanityThresholds { get; } = new()
        {
            { SanityThreshold.FeelingGreat, 80 },
            { SanityThreshold.Happy , 60 },
            { SanityThreshold.Normal, 40 },
            { SanityThreshold.Unhinged, 30},
            { SanityThreshold.Crazy, 15},
        };

        public static readonly Dictionary<SanityThreshold, AlertType> SanityThresholdAlertTypes = new()
        {
            { SanityThreshold.FeelingGreat, AlertType.FeelingGreat },
            { SanityThreshold.Happy, AlertType.Happy },
            { SanityThreshold.Normal, AlertType.Normal },
            { SanityThreshold.Unhinged, AlertType.Unhinged },
            { SanityThreshold.Crazy, AlertType.Crazy },
        };
        
        public enum SanityThreshold : byte
        {
            // psychomies
            FeelingGreat,
            Happy,
            Normal,
            Unhinged,
            Crazy,
        }
        */
    }
}
