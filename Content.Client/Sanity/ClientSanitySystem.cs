using Content.Shared.Sanity;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using System;
using System.Collections.Generic;
using Content.Client.Sanity.UI;
using Robust.Shared.Network;
using Robust.Shared.Players;
using Robust.Client.Player;

namespace Content.Client.Sanity
{
    public sealed class ClientSanitySystem : SharedSanitySystem
    {
        private SanityWindow? _window = null;

        private EntityUid? _playerUID = null;
        public override void Initialize()
        {
            base.Initialize();
            _window = new();
            SubscribeNetworkEvent<SanityOpenUI>(OpenUI);
            SubscribeNetworkEvent<SanityUpdateUI>(UpdateData);
        }

        public void UpdateData(SanityUpdateUI msg)
        {
            _window?.UpdateData(msg.Sanity);
        }

        public void CloseUI()
        {
            if (_playerUID is not null)
            {
                RaiseNetworkEvent(new SanityCloseUI((EntityUid)_playerUID));
            }
        }
        public void OpenUI(SanityOpenUI msg)
        {
            _playerUID = msg.PlayerUID;
            _window?.UpdateData(msg.Sanity);
            _window?.Open();
        }
       
    }
}
