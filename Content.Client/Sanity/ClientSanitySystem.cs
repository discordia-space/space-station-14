using Content.Shared.Sanity;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using System;
using System.Collections.Generic;
using Content.Client.Sanity.UI;
using Robust.Shared.Network;
using Robust.Shared.Players;
using Robust.Client.Player;
using Robust.Shared.IoC;

namespace Content.Client.Sanity
{
    public sealed class ClientSanitySystem : SharedSanitySystem
    {
        [Dependency] IPlayerManager _playerManager = default!;
             
        public override void Initialize()
        {
            base.Initialize();
        }


        public void NotifyUI()
        {
            EntityUid? playerUID = _playerManager?.LocalPlayer?.ControlledEntity?.Uid;
            if (playerUID is not null)
            {
                RaiseNetworkEvent(new SanityCloseUI((EntityUid)playerUID));
            }
        }
       
    }
}
