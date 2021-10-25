using Content.Shared.Sanity;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using System;
using System.Collections.Generic;
using Content.Client.Sanity.UI;

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
            SubscribeNetworkEvent<SanityUpdateData>(UpdateData);
            SubscribeLocalEvent<SanityCloseUI>(CloseUI);
        }

        public void UpdateData(SanityUpdateData msg)
        {
            _window?.UpdateData(msg.Sanity);
        }

        public void OpenUI(SanityOpenUI msg)
        {
            _window?.UpdateData(msg.Sanity);
            _window?.Open();
        }
        public override void Update(float frameTime)
        {

        }
    }
}
