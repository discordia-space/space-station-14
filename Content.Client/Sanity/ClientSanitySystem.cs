using Content.Shared.Sanity;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using System;
using System.Collections.Generic;
using Content.Client.Sanity.UI;
using Robust.Shared.Players;

namespace Content.Client.Sanity
{
    public sealed class ClientSanitySystem : SharedSanitySystem
    {
        private SanityWindow? _window = null;

        public override void Initialize()
        {
            base.Initialize();
            _window = new();
            SubscribeNetworkEvent<SanityOpenUI>(OpenUI);
        }

        public void CloseUI()
        {
            RaiseNetworkEvent(new SanityCloseUI());
        }
        public void OpenUI(SanityOpenUI msg)
        {
            _window?.UpdateData(msg.Sanity);
            _window?.Open();
        }
       
    }
}
