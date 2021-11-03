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

        [DataField("reoccuring")]

        public bool Reoccuring { get; } = false;

        [DataField("reoccuringdelay")]

        public float ReoccuringInterval { get; } = 10.0f;



    }

    public interface ISanityBreakdown
    {
        void Start(SanityBreakdownEventArgs args)
        {
        }

        void End(SanityBreakdownEventArgs args)
        {
        }

        void ApplyEffects(SanityBreakdownEventArgs args)
        {

        }
    }

}
