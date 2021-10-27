using Robust.Client.UserInterface.CustomControls;
using Robust.Client.AutoGenerated;
using Robust.Client.UserInterface.XAML;
using Robust.Client.GameObjects;
using Robust.Client.GameStates;
using Robust.Shared.GameObjects;
using Robust.Shared.GameStates;
using Robust.Client.Utility;



namespace Content.Client.Sanity.UI
{
    [GenerateTypedNameReferences]
    public partial class SanityWindow : SS14Window
    {
        public SanityWindow()
        {
            RobustXamlLoader.Load(this);
        }

        public void UpdateData(int sanity)
        {
            SanityLineEdit.Text = sanity.ToString();
        }
    }
}
