using System;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;
using Robust.Shared.Players;
using Robust.Shared.Network;
using Robust.Shared.Prototypes;
using Robust.Shared.ViewVariables;
using System.Collections.Generic;
using Content.Shared.Construction.Conditions;
using Robust.Shared.Serialization.Manager.Attributes;
using Robust.Shared.Utility;

namespace Content.Shared.Sanity.Prototypes
{
    [Serializable, NetSerializable]

    [Prototype("sanitybreakdown")]
    public class SanityBreakdownPrototype : IPrototype
    {
        [DataField("name")]
        public ISanityBreakdown Name { get; } = default!;

        [DataField("ID", required: true)]
        public string ID { get; } = default!;

        [DataField("duration")]
        public float Duration { get; } = 120.0f;

        [DataField("canoccurat")]

        public int CanOccurAt { get; } = 30;

        [DataField("imposeddelay")]

        public float ImposedDelay { get; } = 300.0f;

        [DataField("beginstring")]
        public string BeginString { get; } = string.Empty;

        [DataField("endingstring")]

        public string EndingString { get; } = string.Empty;

        [DataField("reoccuring")]

        public bool Reoccuring { get; } = false;

        [DataField("reoccuringmessage")]

        public float ReoccuringInterval { get; } = 10.0f;

        [DataField("reoccuringeffects")]

        public ISanityReoccuring ReoccuringEffects { get; } = default!;



    }

    public interface ISanityBreakdown
    {
        void Start(SanityBreakdownEventArgs args)
        {
        }

        void End(SanityBreakdownEventArgs args)
        {
        }
    }

    public interface ISanityReoccuring
    {
        void ApplyEffects(SanityBreakdownEventArgs args)
        {

        }

        void EndEffects(SanityBreakdownEventArgs args)
        {

        }
    }
}
