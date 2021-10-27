using System;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;
using Robust.Shared.Players;
using Robust.Shared.Network;

namespace Content.Shared.Sanity
{
    public class SharedMobSanityComponent : Component
    {
        public override string Name => "Sanity";
    }

    [Serializable, NetSerializable]
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


