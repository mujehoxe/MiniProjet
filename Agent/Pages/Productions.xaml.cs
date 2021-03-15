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

namespace Agent.Pages
{
	/// <summary>
	/// Interaction logic for Productions.xaml
	/// </summary>
	public partial class Productions : Page
	{
		public Productions()
		{
			InitializeComponent();
		}

		public Assets.ProductionCard CreateProductionCard(string type, string title, int index)
		{
			Assets.ProductionCard productionCard = new Assets.ProductionCard(type, title);
			this.Grid.Children.Add(productionCard);
			int column = index % 3;
			int row = index / 3;
			Grid.SetColumn(productionCard, column);
			Grid.SetRow(productionCard, row);
			return productionCard;
		}
	}
}
