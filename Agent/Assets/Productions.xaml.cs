using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Collections.ObjectModel;

namespace Agent.Assets
{
	/// <summary>
	/// Interaction logic for Productions.xaml
	/// </summary>
	public partial class Productions : UserControl
	{
		public Productions(List<Shared.ScientificProduction> productions)
		{
			InitializeComponent();
			int i = 0;
			foreach (Shared.ScientificProduction sp in productions)
			{
				this.CreateProductionCard(sp.Type, sp.Title, i);
				i++;
			}
		}

		public Assets.ProductionCard CreateProductionCard(string type, string title, int index)
		{
			Assets.ProductionCard productionCard = new Assets.ProductionCard(type, title);
			this.Grid.Children.Add(productionCard);
			int column = index % this.Grid.ColumnDefinitions.Count;
			int row = index / 3;
			if (column == 0)
			{
				this.Grid.RowDefinitions.Add(new RowDefinition() { Height = new GridLength() });
			}
			Grid.SetColumn(productionCard, column);
			Grid.SetRow(productionCard, row);
			return productionCard;
		}
	}
}
