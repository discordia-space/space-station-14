using Content.Shared.Sanity;
using Robust.Client.GameObjects;
using Robust.Shared.GameObjects;
using Content.Client.Sanity;

namespace Content.Client.Sanity.UI
{
    /// <summary>
    /// Initializes a <see cref="HandLabelerWindow"/> and updates it when new server messages are received.
    /// </summary>
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

        }

        /// <summary>
        /// Update the UI state based on server-sent info
        /// </summary>
        /// <param name="state"></param>
        protected override void UpdateState(BoundUserInterfaceState state)
        {
            base.UpdateState(state);
            if (_window == null || state is not SanityBoundUserInterface cast)
                return;

            _window.SetCurrentLabel(cast.CurrentLabel);
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);
            if (!disposing) return;
            _window?.Dispose();
        }
    }

}
