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

namespace Content.Server.Sanity
{
    public class SanitySystem : EntitySystem
    {

        public float TimeAccumulator = 0.0f;
        public float TimeBetweenTicks = 15.0f;
        public HashSet<MobSanityComponent> SanityCompsToTick = new();


        public override void Initialize()
        {
            base.Initialize();
            SubscribeLocalEvent<MobSanityComponent, ComponentInit>(OnInit);
            SubscribeLocalEvent<MobSanityComponent, ComponentRemove>(OnDelete);
        }

        public void OnInit(EntityUid uid, MobSanityComponent component, ComponentInit args)
        {
            SanityCompsToTick.Add(component);
        }

        public void OnDelete(EntityUid uid, MobSanityComponent component, ComponentRemove args)
        {
            SanityCompsToTick.Remove(component);
        }

        public void OpenUI(MobSanityComponent component)
        {
            if(component.Owner.TryGetComponent(out ActorComponent? actorComponent))
            {
                component.Owner.GetUIOrNull(SanityMenuUiKey.Key)?.Open(actorComponent.PlayerSession);
            }
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
            }
            
        }
    }
}



