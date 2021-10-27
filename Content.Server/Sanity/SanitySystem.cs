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

namespace Content.Server.Sanity
{
    public sealed class SanitySystem : SharedSanitySystem
    {
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
        public void OpenUI(MobSanityComponent component, INetChannel channel)
        {
            component.Updating = true;
            RaiseNetworkEvent(new SanityOpenUI(component.Insight, component.Sanity, component.Rest, component.Owner.Uid), channel);
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
                    INetChannel? channel = component.Owner.PlayerSession()?.ConnectedClient;
                    if (channel is not null)
                    {
                        RaiseNetworkEvent(new SanityUpdateUI(component.Insight, component.Sanity, component.Rest), channel);
                    }
                }
            }
        }
    }
}



