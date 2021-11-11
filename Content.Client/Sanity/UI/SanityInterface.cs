using Robust.Client.GameObjects;
using Robust.Shared.GameObjects;
using Content.Client.Sanity;
using Content.Shared.Sanity;
using System;

namespace Content.Client.Sanity.UI
{
    /// <summary>
    /// </summary>
    ///
    public class SanityBoundUserInterface : BoundUserInterface
    {
        private SanityWindow? _window;

        public SanityBoundUserInterface(ClientUserInterfaceComponent owner, object uiKey) : base(owner, uiKey)
        {
        }

        protected override void Open()
        {
            base.Open();

            _window = new SanityWindow();
            if (State != null)
                UpdateState(State);

            _window.OpenCentered();

            _window.OnClose += Close;
            _window.OnClose += NotifySystem;

        }

        protected override void UpdateState(BoundUserInterfaceState state)
        {
            base.UpdateState(state);
            if (_window == null || state is not SanityBoundUserInterfaceState cast)
                return;

            _window.UpdateData(cast.Sanity);
        }

        protected void NotifySystem()
        {
            EntitySystem.Get<ClientSanitySystem>().NotifyUI();
        }

       

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing) return;
            _window?.Dispose();
        }
    }

}
