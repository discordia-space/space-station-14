using System;
using System.Collections.Generic;
using System.ComponentModel;
using Content.Server.Alert;
using Content.Shared.Alert;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Content.Server.Sanity
{
    public partial class MobSanityComponent : Component
    {
        public int Sanity = 0;

        public int SanityGainDefault = 5;

        public int MaxSanityDecayPerCycle = 20;

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
            // psychohomies
            FeelingGreat,
            Happy,
            Normal,
            Unhinged,
            Crazy,
        }
    }
}
