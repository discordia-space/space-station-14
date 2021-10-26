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

        public INetChannel? UpdateChannel = null;
    }

    [Serializable, NetSerializable]
    public class SanityOpenUI : EntityEventArgs
    {
        public int Insight { get; }
        public int Sanity { get; }
        public int Rest { get; }

        public INetChannel Channel { get; }
        public SanityOpenUI(int insight, int sanity, int rest, INetChannel channel)
        {
            Insight = insight;
            Sanity = sanity;
            Rest = rest;
            Channel = channel;
        }
    }

    public class SanityUpdateUI : EntityEventArgs
    {
        public int Insight { get; }
        public int Sanity { get; }
        public int Rest { get; }
        public SanityUpdateUI(int insight, int sanity, int rest)
        {
            Insight = insight;
            Sanity = sanity;
            Rest = rest;
        }
    }

    [Serializable, NetSerializable]
    public class SanityCloseUI : EntityEventArgs
    {
        public INetChannel Channel { get; }

        public SanityCloseUI(INetChannel channel)
        {
            Channel = channel;
        }
    }
}


