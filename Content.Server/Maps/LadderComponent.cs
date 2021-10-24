using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Content.Shared.Interaction;
using Robust.Shared.GameObjects;
using Robust.Shared.Serialization.Manager.Attributes;
using Robust.Shared.IoC;
using Content.Server.GameTicking;
using Robust.Shared.Maths;
using Robust.Shared.Map;
using Content.Server.DoAfter;

namespace Content.Server.Maps
{
    [RegisterComponent]
    class LadderComponent : Component, IInteractHand
    {
        [Dependency] private readonly IMapManager _mapManager = default!;
        [Dependency] private readonly IEntitySystemManager _sysManager = default!;
        public override string Name => "Ladder";

        [DataField("down", required: true)]
        private bool _down = false;

        bool IInteractHand.InteractHand(InteractHandEventArgs eventArgs)
        {
            eventArgs.User.Transform.WorldPosition = Owner.Transform.WorldPosition;
            var gameTicker = _sysManager.GetEntitySystem<GameTicker>();

            if (!gameTicker.MapsZ.Contains(Owner.Transform.MapID)) return false;

            // RIP DoAfter. No more async :'(
            /*var doAfterSystem = EntitySystem.Get<DoAfterSystem>();

            var doAfterArgs = new DoAfterEventArgs(eventArgs.User, 1.5f, default, Owner)
            {
                BreakOnTargetMove = true,
                BreakOnUserMove = true,
                BreakOnDamage = true,
                BreakOnStun = true,
                NeedHand = true,
            };

            var result = await doAfterSystem.WaitDoAfter(doAfterArgs);

            if (result == DoAfterStatus.Cancelled) return false;*/

            var index = gameTicker.MapsZ.IndexOf(Owner.Transform.MapID);
            var mapChange = Owner.Transform.MapID;
            if (_down)
            {
                if (index + 1 > gameTicker.MapsZ.Count) return false;
                mapChange = gameTicker.MapsZ[index + 1];
            }
            else
            {
                if (index - 1 < 0) return false;
                mapChange = gameTicker.MapsZ[index - 1];
            }
            eventArgs.User.Transform.AttachParent(_mapManager.GetMapEntity(mapChange));

            return true;
        }
    }
}
