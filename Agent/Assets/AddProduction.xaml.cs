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

namespace Agent.Assets
{
	/// <summary>
	/// Interaction logic for AddProduction.xaml
	/// </summary>
	public partial class AddProduction : UserControl
	{
		private Shared.ScientificProduction sp;
		public AddProduction()
		{
			InitializeComponent();
		}

		private void CancelButtonClicked(object sender, RoutedEventArgs e)
		{
			Frame productionsFrame = (((Application.Current.MainWindow as MainWindow).MainFrame as Frame).Content as Pages.Dash).ProductionsFrame;
			if (productionsFrame.NavigationService.CanGoBack)
			{
				productionsFrame.NavigationService.GoBack();
			}
			else
			{
				MessageBox.Show("No entries in back navigation history.");
			}

		}
		private void SubmitButtonClicked(object sender, RoutedEventArgs e)
		{
			sp = new Shared.ScientificProduction(TypeBox.Text, TitleBox.Text, ContentBox.Text);

			var mainWindow = (Application.Current.MainWindow as MainWindow);
            try
            {
				mainWindow.PublishingObject.PublishScientificProduction(this.sp, mainWindow.User.Profile.Id);
            }
            catch(Exception ex)
            {
				Console.WriteLine(ex.Message);
            }
		}
	}
}
