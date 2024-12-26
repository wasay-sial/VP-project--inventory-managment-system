using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;

namespace VP_2
{
    public partial class PlaceOrderWindow : Window
    {
        private List<Product> availableProducts = new List<Product>();

        public PlaceOrderWindow()
        {
            InitializeComponent();
            LoadProductList();
        }

        private void LoadProductList()
        {
            string connectionString = "Data Source=WASAYPC;Initial Catalog=\"vp proje\";Integrated Security=True;Encrypt=False;";
            string query = "SELECT ProductId, ProductName, Quantity, Price, CategoryId FROM Products";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        var product = new Product
                        {
                            ProductId = reader.GetInt32(0),
                            ProductName = reader.GetString(1),
                            Quantity = reader.GetInt32(2),
                            Price = reader.GetInt32(3),
                            CategoryId = reader.GetInt32(4)
                        };

                        availableProducts.Add(product);
                    }

                    reader.Close();
                    ProductDataGrid.ItemsSource = availableProducts; // Bind products to the DataGrid
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading products: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void SubmitOrderButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate inputs
            if (!int.TryParse(ProductIdTextBox.Text, out int productId))
            {
                MessageBox.Show("Invalid Product ID. Please enter a valid numeric Product ID.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            var selectedProduct = availableProducts.Find(p => p.ProductId == productId);
            if (selectedProduct == null)
            {
                MessageBox.Show("Product ID does not exist. Please select a valid product.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (selectedProduct.Quantity <= 0)
            {
                MessageBox.Show($"The product \"{selectedProduct.ProductName}\" is out of stock.", "Stock Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(ProductNameTextBox.Text) ||
                string.IsNullOrWhiteSpace(AddressTextBox.Text) ||
                string.IsNullOrWhiteSpace(EmailTextBox.Text))
            {
                MessageBox.Show("All fields are required.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            if (ProductNameTextBox.Text != selectedProduct.ProductName)
            {
                MessageBox.Show("Product Name does not match the selected Product ID.", "Validation Error", MessageBoxButton.OK, MessageBoxImage.Warning);
                return;
            }

            // Generate a new OrderId manually
            string connectionString = "Data Source=WASAYPC;Initial Catalog=\"vp proje\";Integrated Security=True;Encrypt=False;";
            string getMaxOrderIdQuery = "SELECT MAX(OrderId) FROM Orders";
            string insertOrderQuery = "INSERT INTO Orders (OrderId, ProductId, ProductName, Address, Email) VALUES (@OrderId, @ProductId, @ProductName, @Address, @Email)";
            string updateProductQuantityQuery = "UPDATE Products SET Quantity = Quantity - 1 WHERE ProductId = @ProductId";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Get the last used OrderId and increment it by 1
                    SqlCommand getMaxOrderIdCommand = new SqlCommand(getMaxOrderIdQuery, connection);
                    object result = getMaxOrderIdCommand.ExecuteScalar();
                    int newOrderId = (result == DBNull.Value) ? 1 : Convert.ToInt32(result) + 1; // Start at 1 if no orders exist

                    // Insert the order with the manually generated OrderId
                    SqlCommand insertOrderCommand = new SqlCommand(insertOrderQuery, connection);
                    insertOrderCommand.Parameters.AddWithValue("@OrderId", newOrderId);
                    insertOrderCommand.Parameters.AddWithValue("@ProductId", productId);
                    insertOrderCommand.Parameters.AddWithValue("@ProductName", ProductNameTextBox.Text);
                    insertOrderCommand.Parameters.AddWithValue("@Address", AddressTextBox.Text);
                    insertOrderCommand.Parameters.AddWithValue("@Email", EmailTextBox.Text);

                    int rowsAffected = insertOrderCommand.ExecuteNonQuery();

                    if (rowsAffected > 0)
                    {
                        // Update the product quantity
                        SqlCommand updateProductCommand = new SqlCommand(updateProductQuantityQuery, connection);
                        updateProductCommand.Parameters.AddWithValue("@ProductId", productId);
                        updateProductCommand.ExecuteNonQuery();

                        MessageBox.Show($"Order placed successfully! Your Order ID is {newOrderId}.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        this.Close();
                    }
                    else
                    {
                        MessageBox.Show("Failed to place the order. Please try again.", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error placing order: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
