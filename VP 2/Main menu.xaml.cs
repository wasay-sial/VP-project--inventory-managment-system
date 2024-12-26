using System;
using System.Windows;

namespace VP_2
{
    public partial class Main_menu : Window
    {
        public Main_menu()
        {
            InitializeComponent();
        }

        // Event handler for "Show Products" button
        private void ShowProductsButton_Click(object sender, RoutedEventArgs e)
        {
            Window1 window = new Window1();
            window.Show();
        }

        // Event handler for "Show Users" button
        private void ShowUsersButton_Click(object sender, RoutedEventArgs e)
        {
            Window2 window = new Window2();
            window.Show();
        }

        // Event handler for "Show Categories" button
        private void ShowCategoriesButton_Click(object sender, RoutedEventArgs e)
        {
            Category_Management window = new Category_Management();
            window.Show();
        }

        // Event handler for "Show Orders" button
        private void ShowOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            Orders_Management window = new Orders_Management();
            window.Show();
        }

        private void ShowSuppliersButton_Click(object sender, RoutedEventArgs e)
        {
            SupplierWindow window = new SupplierWindow();
            window.Show();
        }

        private void ShowPurchaseOrdersButton_Click(object sender, RoutedEventArgs e)
        {
            AdminBuyProductsWindow window = new AdminBuyProductsWindow();
            window.Show();

        }

        // Event handler for "Exit" button
        private void ExitButton_Click(object sender, RoutedEventArgs e)
        {
            // Close the application
            Application.Current.Shutdown();
        }
    }
}
