using Content.Shared.Alert;
using JetBrains.Annotations;
using Robust.Shared.Serialization.Manager.Attributes;
using Content.Server.Sanity;
using Robust.Shared.GameObjects;
using Robust.Shared.Network;
using Robust.Server.Player;

namespace Content.Server.Alert.Click
{
    [UsedImplicitly]
    [DataDefinition]
    public class SanityMenu : IAlertClick
    {
        public void AlertClicked(ClickAlertEventArgs args)
        {
            INetChannel? channel = args.Player.PlayerSession()?.ConnectedClient;
            if (args.Player.TryGetComponent(out MobSanityComponent? sanityComponent) && channel is not null)
            {
                EntitySystem.Get<SanitySystem>().OpenUI(sanityComponent, channel);
            }
        }
    }
}
