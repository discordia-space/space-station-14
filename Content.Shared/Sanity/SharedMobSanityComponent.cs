using System;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;


namespace Content.Shared.Sanity
{

    [Serializable, NetSerializable]
    public enum SanityMenuUiKey
    {
        Key,
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
}


