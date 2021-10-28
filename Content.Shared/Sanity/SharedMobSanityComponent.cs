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

namespace Content.Shared.Sanity
{
    public class SharedMobSanityComponent : Component
    {
        public override string Name => "Sanity";
    }

    [Serializable, NetSerializable]

    [Prototype("SanityBreakdown")]
    public class SanityBreakdownPrototype : IPrototype
    {
        [DataField("name")]
        public string Name { get; } = string.Empty;

        [DataField("id", required: true)]
        public string ID { get; } = default!;

        [DataField("duration")]
        public float Duration { get; } = 120.0f;
        public enum SanityUiKey
    {
        Key,
    }

    [Serializable, NetSerializable]
    public class SanityOpenUI : EntityEventArgs
    {
        public int Insight { get; }
        public int Sanity { get; }
        public int Rest { get; }

        public EntityUid PlayerUID { get; }
        public SanityOpenUI(int insight, int sanity, int rest, EntityUid playerUID)
        {
            Insight = insight;
            Sanity = sanity;
            Rest = rest;
            PlayerUID = playerUID;
        }
    }
    [Serializable, NetSerializable]
    public class SanityBoundUserInterfaceState : BoundUserInterfaceState
    {
        public int Insight { get; }
        public int Sanity { get; }
        public int Rest { get; }
        public SanityBoundUserInterfaceState(int insight, int sanity, int rest)
        {
            Insight = insight;
            Sanity = sanity;
            Rest = rest;
        }
    }

    [Serializable, NetSerializable]
    public class SanityCloseUI : EntityEventArgs
    {
        public EntityUid PlayerUID { get; }

        public SanityCloseUI(EntityUid playerUID)
        {
            PlayerUID = playerUID;
        }
    }
}


