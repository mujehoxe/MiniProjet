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
	/// Interaction logic for Dash.xaml
	/// </summary>
	public partial class Dash : Page
	{
		public Dash(Shared.Profile profile)
		{
			InitializeComponent();
			Assets.Productions p = new Assets.Productions();
			ProductionsFrame.Navigate(p);

			Assets.Profile profilePage = new Assets.Profile();
			ProfileFrame.Content = profilePage;

			for (int i = 0; i < 19; i++)
			{
				p.CreateProductionCard("Article" + i, "title" + i, i);
			}

		}

		public object ProfileInfo { get; }
	}
}
