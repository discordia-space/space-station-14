using System;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;
using Content.Shared.Sanity;
using Content.Client.Sanity.UI;

namespace Content.Client.Sanity
{
    public class ClientMobSanityComponent : SharedMobSanityComponent
    {

        public SanityWindow? SanityMenu;

        public int Sanity = 0;
        public int Insight = 0;
        public int Rest = 0;

        public override void HandleComponentState(ComponentState? curState, ComponentState? nextState)
        {
            if (curState is not SanityComponentState actualState)
                return;

            Sanity = actualState.Sanity;
            Insight = actualState.Insight;
            Rest = actualState.Rest;
        }
    }
}
