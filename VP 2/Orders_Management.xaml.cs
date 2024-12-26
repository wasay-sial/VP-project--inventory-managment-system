using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace VP_2
{
    public partial class Orders_Management : Window
    {
        private string connectionString = "Data Source=WASAYPC;Initial Catalog=\"vp proje\";Integrated Security=True;Encrypt=False;";

        public Orders_Management()
        {
            InitializeComponent();
            LoadOrderData();
        }

        private void LoadOrderData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Orders", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    orderDataGrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

       

        private void DeleteOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string orderId = Prompt2.ShowDialog("Enter Order ID to delete:", "Delete Order");

                if (!string.IsNullOrEmpty(orderId))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Orders WHERE OrderId = @OrderId";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@OrderId", int.Parse(orderId));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Order deleted successfully.");
                    LoadOrderData();
                }
                else
                {
                    MessageBox.Show("Order ID is required.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting order: " + ex.Message);
            }
        }

        private void UpdateOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string orderId = Prompt2.ShowDialog("Enter Order ID to update:", "Update Order");

                if (!string.IsNullOrEmpty(orderId))
                {
                    string newProductId = Prompt2.ShowDialog("Enter new Product ID:", "Update Order");
                    string newProductName = Prompt2.ShowDialog("Enter new Product Name:", "Update Order");
                    string newAddress = Prompt2.ShowDialog("Enter new Address:", "Update Order");
                    string newEmail = Prompt2.ShowDialog("Enter new Email:", "Update Order");

                    if (!string.IsNullOrEmpty(newProductId) && !string.IsNullOrEmpty(newProductName) && !string.IsNullOrEmpty(newAddress) && !string.IsNullOrEmpty(newEmail))
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "UPDATE Orders SET ProductId = @ProductId, ProductName = @ProductName, Address = @Address, Email = @Email WHERE OrderId = @OrderId";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@ProductId", int.Parse(newProductId));
                                cmd.Parameters.AddWithValue("@ProductName", newProductName);
                                cmd.Parameters.AddWithValue("@Address", newAddress);
                                cmd.Parameters.AddWithValue("@Email", newEmail);
                                cmd.Parameters.AddWithValue("@OrderId", int.Parse(orderId));
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Order updated successfully.");
                        LoadOrderData();
                    }
                    else
                    {
                        MessageBox.Show("All fields are required.");
                    }
                }
                else
                {
                    MessageBox.Show("Order ID is required.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating order: " + ex.Message);
            }
        }

        private void SearchOrderButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string orderId = Prompt2.ShowDialog("Enter Order ID to search (leave blank to search by Product Name):", "Search Order");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string searchQuery;
                    if (!string.IsNullOrEmpty(orderId))
                    {
                        searchQuery = $"SELECT * FROM Orders WHERE OrderId = {int.Parse(orderId)}";
                    }
                    else
                    {
                        searchQuery = $"SELECT * FROM Orders WHERE ProductName LIKE '%{orderId}%'";
                    }

                    SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    orderDataGrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching data: " + ex.Message);
            }
        }
    }

    // Separate class for input prompts
    public static class Prompt2
    {
        public static string ShowDialog(string text, string caption, string defaultText = "")
        {
            Window prompt = new Window
            {
                Width = 300,
                Height = 150,
                Title = caption,
                WindowStartupLocation = WindowStartupLocation.CenterScreen
            };

            StackPanel stackPanel = new StackPanel { Margin = new Thickness(10) };
            prompt.Content = stackPanel;

            Label textLabel = new Label { Content = text };
            stackPanel.Children.Add(textLabel);

            TextBox inputBox = new TextBox { Text = defaultText };
            stackPanel.Children.Add(inputBox);

            Button confirmation = new Button { Content = "OK", Width = 70, IsDefault = true };
            confirmation.Click += (sender, e) => prompt.DialogResult = true;
            stackPanel.Children.Add(confirmation);

            return prompt.ShowDialog() == true ? inputBox.Text : null;
        }
    }
}
