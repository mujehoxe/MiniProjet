using System.Windows.Controls;

namespace Agent.Assets
{
    /// <summary>
    /// Interaction logic for Profile.xaml
    /// </summary>
    public partial class Profile : UserControl
    {
        public Profile(Shared.Profile p)
        {
            InitializeComponent();
            this.ID.Content = p.Id;
            this.Username.Content = p.Username;
            this.Fullname.Content = p.Fullname;
            this.Email.Content = p.Email;

            this.TeamId.Content = p.TeamId;
            foreach (string role in p.Roles)
            {
                this.Roles.Content += ", " + role;
            }
            this.Field.Content = p.Field;
        }
    }
}
