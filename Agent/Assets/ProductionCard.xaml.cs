using System.Windows.Controls;

namespace Agent.Assets
{
    /// <summary>
    /// Interaction logic for ProductionCard.xaml
    /// </summary>
    public partial class ProductionCard : UserControl
    {
        public ProductionCard(Shared.ScientificProduction sp)
        {
            InitializeComponent();

            Type.Content = sp.Type;
            Title.Content = sp.Title;
        }
    }
}
