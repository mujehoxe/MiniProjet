using System;
using System.Windows;
using System.Windows.Controls;

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
            var mainWindow = (Application.Current.MainWindow as MainWindow);
            Frame productionsFrame = (((mainWindow.MainFrame as Frame).Content as Pages.Dash).ProfileFrame.Content as Pages.Profile).ProductionsFrame;
            ReturnBackIfAvailable(productionsFrame);
        }

        private static void ReturnBackIfAvailable(Frame frame)
        {
            if (frame.NavigationService.CanGoBack)
            {
                Console.WriteLine(frame.Content);
                frame.NavigationService.GoBack();
                Console.WriteLine(frame.Content);
                return;
            }

            MessageBox.Show("No entries in back navigation history.");
        }

        private void SubmitButtonClicked(object sender, RoutedEventArgs e)
        {
            sp = new Shared.ScientificProduction(TypeBox.Text, TitleBox.Text, ContentBox.Text);

            var mainWindow = (Application.Current.MainWindow as MainWindow);
            try
            {
                string result = mainWindow.PublishingObject.PublishScientificProductionAndNotify(this.sp, mainWindow.User.Profile);
                if(result == "done")
                {
                    Frame productionsFrame = (((mainWindow.MainFrame as Frame).Content as Pages.Dash).ProfileFrame.Content as Pages.Profile).ProductionsFrame;
                    ReturnBackIfAvailable(productionsFrame);
                }
                else
                {
                    MessageBox.Show(result);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
