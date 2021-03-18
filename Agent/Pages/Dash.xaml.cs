using System.Windows.Controls;

namespace Agent.Pages
{
    /// <summary>
    /// Interaction logic for Dash.xaml
    /// </summary>
    public partial class Dash : Page
    {
        public Dash(Shared.Profile profile)
        {
            InitializeComponent();
            ProfileFrame.Navigate(new Assets.Profile(profile));
            ProductionsFrame.Navigate(new Assets.Productions(profile.ScientificProductions));
        }
    }
}
