using System;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using Robust.Shared.Serialization;
using Robust.Shared.Players;
using Robust.Shared.Network;
using Robust.Shared.Prototypes;
using Robust.Shared.ViewVariables;
using System.Collections.Generic;
using Content.Shared.Construction.Conditions;
using Robust.Shared.Serialization.Manager.Attributes;
using Robust.Shared.Utility;
using Content.Shared.Sanity.Prototypes;
using Content.Shared.Popups;



namespace Content.Shared.Sanity.Breakdown.Crying
{
   public class BreakdownCrying : ISanityBreakdown
    {
        public void Start(SanityBreakdownEventArgs args)
        {
            args.Player.PopupMessage(args.Player, "You can't take it anymore , you burst into tears");
        }

        public void End(SanityBreakdownEventArgs args)
        {
            args.Player.PopupMessage(args.Player, "You feel the crying stop. You accept things as they are now.");
        }

        public void ApplyEffects(SanityBreakdownEventArgs args)
        {
            args.Player.PopupMessage(args.Player, "Cries");
        }
    }
}
