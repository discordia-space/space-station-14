using System;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;

namespace Content.Shared.Sanity
{
    [RegisterComponent()]
    public class SharedMobSanityComponent : Component
    {
        public override string Name => "Sanity";
    }



    [Serializable, NetSerializable]
    public class SanityUpdateData : EntityEventArgs
    {

        public int Insight { get; }
        public int Sanity { get; }
        public int Rest { get; }
        public SanityUpdateData(int insight, int sanity, int rest)
        {
            Insight = insight;
            Sanity = sanity;
            Rest = rest;
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


