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

namespace Content.Server.Sanity
{
    public class SanitySystem : EntitySystem
    {

        public float frameaccul = 0.0f;
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


        public override void Update(float frameTime)
        {
            frameaccul += frameTime;
            if(frameaccul > 10.0f)
            {
                frameaccul = 0.0f;
            }
            else
            {
                return;
            }
            /*
            if(Counter > 10)
            {
                Counter = 0;
            }
            else
            {
                Counter++;
                return;
            }
            */

            foreach (MobSanityComponent component in EntityManager.EntityQuery<MobSanityComponent>())
            {
                component.Sanity += component.SanityGainDefault;
                if (!component.Owner.TryGetComponent(out ServerAlertsComponent? alerts))
                {
                    continue;
                }
                short variable = 2;
                alerts.ShowAlert(AlertType.MobSanity, variable);
            }
            
        }
    }
}



