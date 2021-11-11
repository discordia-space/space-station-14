using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Robust.Server.GameObjects;
using Robust.Shared.GameObjects;
using Robust.Shared.GameObjects.Components;
using Robust.Server.Placement;
using Robust.Server.Player;
using Content.Shared.Alert;
using Content.Server.Alert;
using Content.Server.UserInterface;
using Content.Shared.Sanity;
using Content.Shared.Eui;
using Robust.Shared.Players;
using System.Net;
using Robust.Shared.Network;
using JetBrains.Annotations;
using Content.Shared.Popups;
using Content.Shared.ActionBlocker;
using Content.Shared.Interaction;
using Robust.Shared.IoC;
using Robust.Shared.Localization;

namespace Content.Server.Sanity
{
    public sealed class SanitySystem : SharedSanitySystem
    {
        [Dependency] private readonly UserInterfaceSystem _userInterfaceSystem = default!;
        public HashSet<MobSanityComponent> SanityCompsToTick = new();
        public float TimeAccumulator = 0.0f;
        public float TimeBetweenTicks = 15.0f;


        public override void Initialize()
        {
            base.Initialize();
            SubscribeLocalEvent<MobSanityComponent, ComponentInit>(OnInit);
            SubscribeLocalEvent<MobSanityComponent, ComponentRemove>(OnDelete);
            SubscribeNetworkEvent<SanityCloseUI>(CloseUI);
        }

        public void OnInit(EntityUid uid, MobSanityComponent component, ComponentInit args)
        {
            SanityCompsToTick.Add(component);
        }
        public void OnDelete(EntityUid uid, MobSanityComponent component, ComponentRemove args)
        {
            SanityCompsToTick.Remove(component);
        }

        public void CloseUI(SanityCloseUI msg)
        {
            MobSanityComponent? component = null;
            if(!Resolve(msg.PlayerUID, ref component))
            {
                return;
            }
            component.Updating = false;
        }
        public void OpenUI(MobSanityComponent component, IPlayerSession player)
        {
            component.Updating = true;
            component.Owner.GetUIOrNull(SanityUiKey.Key)?.Open(player);
            _userInterfaceSystem.TrySetUiState(component.Owner.Uid, SanityUiKey.Key, new SanityBoundUserInterfaceState(
                        component.Insight, component.Sanity, component.Rest));
        }

        public override void Update(float frameTime)
        {
            TimeAccumulator += frameTime;
            if (TimeAccumulator < TimeBetweenTicks)
            {
                TimeAccumulator += frameTime;
                return;
            }
            TimeAccumulator = 0.0f;

            foreach (MobSanityComponent component in SanityCompsToTick)
            {
                component.Sanity += Math.Max((int)(component.SanityGainPerSecond * TimeBetweenTicks), 0);
                if (!component.Owner.TryGetComponent(out ServerAlertsComponent? alerts))
                {
                    continue;
                }
                alerts.ShowAlert(AlertType.MobSanity, (short)(component.Sanity/component.SanitySteps));
                
                if(component.Updating)
                {
                    _userInterfaceSystem.TrySetUiState(component.Owner.Uid, SanityUiKey.Key, new SanityBoundUserInterfaceState(
                        component.Insight, component.Sanity, component.Rest));
                }
                
            }
        }
    }
}



