using System;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;
using Robust.Shared.Players;

namespace Content.Shared.Sanity
{
    [RegisterComponent()]
    public class SharedMobSanityComponent : Component
    {
        public override string Name => "Sanity";

        [Serializable, NetSerializable]
        protected class SanityComponentState : ComponentState
        {
            public int Insight { get; }
            public int Sanity { get; }
            public int Rest { get; }

            public SanityComponentState(int insight, int sanity, int rest)
            {
                Insight = insight;
                Sanity = sanity;
                Rest = rest;
            }
        }
    }

    [Serializable, NetSerializable]
    public class SanityOpenUI : EntityEventArgs
    {
        public int Insight { get; }
        public int Sanity { get; }
        public int Rest { get; }
        public SanityOpenUI(int insight, int sanity, int rest)
        {
            Insight = insight;
            Sanity = sanity;
            Rest = rest;
        }
    }

    [Serializable, NetSerializable]
    public class SanityCloseUI : EntityEventArgs
    {
    }
}


