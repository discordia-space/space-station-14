using System;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;


namespace Content.Shared.Sanity
{
    public class SharedMobSanityComponent : Component
    {
        public override string Name => "Sanity";

        [Serializable, NetSerializable]
        public enum SanityUiKey
        {
            Key,
        }

        [Serializable, NetSerializable]
        public class SanityBoundUserInterfaceState : BoundUserInterfaceMessage
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
    }
}
  
