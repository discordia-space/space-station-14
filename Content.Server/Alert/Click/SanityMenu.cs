using Content.Shared.Alert;
using JetBrains.Annotations;
using Robust.Shared.Serialization.Manager.Attributes;
using Content.Server.Sanity;
using Robust.Shared.GameObjects;

namespace Content.Server.Alert.Click
{
    [UsedImplicitly]
    [DataDefinition]
    public class SanityMenu : IAlertClick
    {
        public void AlertClicked(ClickAlertEventArgs args)
        {
            if (args.Player.TryGetComponent(out MobSanityComponent? sanityComponent))
            {
                EntitySystem.Get<SanitySystem>().OpenUI(sanityComponent);
            }
        }
    }
}
