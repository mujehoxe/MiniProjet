using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;

namespace Agent.Assets
{
    /// <summary>
    /// Interaction logic for Productions.xaml
    /// </summary>
    public partial class Productions : UserControl
    {
        private int CurrentColumn;
        private int CurrentRow;
        public Productions(List<Shared.ScientificProduction> productions)
        {
            InitializeComponent();
            CurrentColumn = 0;
            CurrentRow = 0;
            foreach (Shared.ScientificProduction sp in productions)
            {
                CreateAndPlaceProductionCard(sp);
            }
        }

        public void CreateAndPlaceProductionCard(Shared.ScientificProduction sp)
        {
            ProductionCard productionCard = new Assets.ProductionCard(sp);
            this.Grid.Children.Add(productionCard);

            TronsformToColumnAndRow();

            Grid.SetColumn(productionCard, CurrentColumn);
            Grid.SetRow(productionCard, CurrentRow);
        }

        private void TronsformToColumnAndRow()
        {
            CurrentColumn = Grid.Children.Count % this.Grid.ColumnDefinitions.Count;
            CurrentRow = Grid.Children.Count / this.Grid.ColumnDefinitions.Count;

            if (CurrentColumn == 0)
            {
                this.Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength() });
            }
        }

        private void AddButtonClicked(object sender, RoutedEventArgs e)
        {
            (((Application.Current.MainWindow as MainWindow).MainFrame as Frame).Content as Pages.Dash).ProductionsFrame.Navigate(new Assets.AddProduction());
            //(this.Parent as Frame).Navigate(new Assets.AddProduction());
        }
    }
}
