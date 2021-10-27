using Content.Shared.Alert;
using JetBrains.Annotations;
using Robust.Shared.Serialization.Manager.Attributes;
using Content.Server.Sanity;
using Robust.Shared.GameObjects;
using Robust.Shared.Network;
using Robust.Server.Player;
using Robust.Server.GameObjects;

namespace Content.Server.Alert.Click
{
    [UsedImplicitly]
    [DataDefinition]
    public class SanityMenu : IAlertClick
    {
        public void AlertClicked(ClickAlertEventArgs args)
        {

            if (args.Player.TryGetComponent(out MobSanityComponent? sanityComponent) && args.Player.TryGetComponent(out ActorComponent? actorComponent))
            {
                EntitySystem.Get<SanitySystem>().OpenUI(sanityComponent, actorComponent.PlayerSession);
            }
        }
    }
}
