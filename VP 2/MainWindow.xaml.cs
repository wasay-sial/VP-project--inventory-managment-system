using System.Windows;

namespace VP_2
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void LoginAsAdmin_Click(object sender, RoutedEventArgs e)
        {
            Admin_login admin_Login = new Admin_login();
            admin_Login.Show();
        }

        private void LoginAsUser_Click(object sender, RoutedEventArgs e)
        {
           User_login user_Login = new User_login();
           user_Login.Show();
        }

        private void CloseButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            this.Close();
        }
    }
}
