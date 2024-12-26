using System;
using System.Windows;
using System.Windows.Controls;

namespace VP_2
{
    public partial class Menu_user : Window
    {
        public Menu_user()
        {
            InitializeComponent();
        }

        // Event handler for the "Show User" button
        private void ShowUserButton_Click(object sender, RoutedEventArgs e)
        {
            // Navigate to the UserListPage
            ContentFrame.Navigate(new UserListPage());
        }

        // Event handler for the "Place Order" button
        private void PlaceOrderButton_Click(object sender, RoutedEventArgs e)
        {
            PlaceOrderWindow placeOrderWindow = new PlaceOrderWindow();
            placeOrderWindow.ShowDialog();
        }


        // Event handler for the "Exit" button
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
