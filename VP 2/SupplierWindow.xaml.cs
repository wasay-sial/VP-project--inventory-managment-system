using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace VP_2
{
    public partial class SupplierWindow : Window
    {
        private List<Supplier> suppliers = new List<Supplier>();

        public SupplierWindow()
        {
            InitializeComponent();
            LoadSuppliers();
        }

        private void LoadSuppliers()
        {
            string connectionString = "Data Source=WASAYPC;Initial Catalog=\"vp proje\";Integrated Security=True;Encrypt=False;";
            string query = "SELECT SupplierId, SupplierName, Contact FROM Suppliers";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    suppliers.Clear();
                    while (reader.Read())
                    {
                        suppliers.Add(new Supplier
                        {
                            SupplierId = reader.GetInt32(0),
                            SupplierName = reader.GetString(1),
                            Contact = reader.GetString(2)
                        });
                    }

                    reader.Close();
                    SuppliersDataGrid.ItemsSource = null;
                    SuppliersDataGrid.ItemsSource = suppliers;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading suppliers: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void AddSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            var prompt = new Prompt4("Add Supplier", "Enter Supplier Details:");
            if (prompt.ShowDialog() == true)
            {
                var newSupplier = prompt.Supplier;

                string connectionString = "Data Source=WASAYPC;Initial Catalog=\"vp proje\";Integrated Security=True;Encrypt=False;";
                string query = "INSERT INTO Suppliers (SupplierId, SupplierName, Contact) VALUES (@SupplierId, @SupplierName, @Contact)";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@SupplierId", new Random().Next(1, 10000)); // Generate random ID
                        command.Parameters.AddWithValue("@SupplierName", newSupplier.SupplierName);
                        command.Parameters.AddWithValue("@Contact", newSupplier.Contact);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Supplier added successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadSuppliers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error adding supplier: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void EditSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            if (SuppliersDataGrid.SelectedItem is Supplier selectedSupplier)
            {
                var prompt = new Prompt4("Edit Supplier", "Edit Supplier Details:", selectedSupplier);
                if (prompt.ShowDialog() == true)
                {
                    var updatedSupplier = prompt.Supplier;

                    string connectionString = "Data Source=WASAYPC;Initial Catalog=\"vp proje\";Integrated Security=True;Encrypt=False;";
                    string query = "UPDATE Suppliers SET SupplierName = @SupplierName, Contact = @Contact WHERE SupplierId = @SupplierId";

                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();
                            SqlCommand command = new SqlCommand(query, connection);
                            command.Parameters.AddWithValue("@SupplierId", updatedSupplier.SupplierId);
                            command.Parameters.AddWithValue("@SupplierName", updatedSupplier.SupplierName);
                            command.Parameters.AddWithValue("@Contact", updatedSupplier.Contact);
                            command.ExecuteNonQuery();

                            MessageBox.Show("Supplier updated successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                            LoadSuppliers();
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error updating supplier: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a supplier to edit.", "Edit Supplier", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        private void DeleteSupplierButton_Click(object sender, RoutedEventArgs e)
        {
            if (SuppliersDataGrid.SelectedItem is Supplier selectedSupplier)
            {
                string connectionString = "Data Source=WASAYPC;Initial Catalog=\"vp proje\";Integrated Security=True;Encrypt=False;";
                string query = "DELETE FROM Suppliers WHERE SupplierId = @SupplierId";

                try
                {
                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        SqlCommand command = new SqlCommand(query, connection);
                        command.Parameters.AddWithValue("@SupplierId", selectedSupplier.SupplierId);
                        command.ExecuteNonQuery();

                        MessageBox.Show("Supplier deleted successfully.", "Success", MessageBoxButton.OK, MessageBoxImage.Information);
                        LoadSuppliers();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting supplier: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a supplier to delete.", "Delete Supplier", MessageBoxButton.OK, MessageBoxImage.Warning);
            }
        }

        public class Prompt4 : Window
        {
            public Supplier Supplier { get; private set; }
            private TextBox SupplierNameTextBox;
            private TextBox ContactTextBox;

            public Prompt4(string title, string header, Supplier existingSupplier = null)
            {
                Title = title;
                Width = 400;
                Height = 300;
                WindowStartupLocation = WindowStartupLocation.CenterOwner;
                Supplier = existingSupplier ?? new Supplier();

                var grid = new Grid { Margin = new Thickness(10) };
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });
                grid.RowDefinitions.Add(new RowDefinition { Height = new GridLength(1, GridUnitType.Star) });
                grid.RowDefinitions.Add(new RowDefinition { Height = GridLength.Auto });

                var headerBlock = new TextBlock { Text = header, FontSize = 16, FontWeight = FontWeights.Bold, Margin = new Thickness(0, 0, 0, 10) };
                grid.Children.Add(headerBlock);

                var stackPanel = new StackPanel { Margin = new Thickness(0, 20, 0, 10) };
                Grid.SetRow(stackPanel, 1);
                grid.Children.Add(stackPanel);

                stackPanel.Children.Add(new TextBlock { Text = "Supplier Name:" });
                SupplierNameTextBox = new TextBox { Text = Supplier.SupplierName };
                stackPanel.Children.Add(SupplierNameTextBox);

                stackPanel.Children.Add(new TextBlock { Text = "Contact:" });
                ContactTextBox = new TextBox { Text = Supplier.Contact };
                stackPanel.Children.Add(ContactTextBox);

                var buttonPanel = new StackPanel { Orientation = Orientation.Horizontal, HorizontalAlignment = HorizontalAlignment.Right };
                Grid.SetRow(buttonPanel, 2);
                grid.Children.Add(buttonPanel);

                var saveButton = new Button { Content = "Save", Width = 80, Margin = new Thickness(5) };
                saveButton.Click += (s, e) =>
                {
                    Supplier.SupplierName = SupplierNameTextBox.Text;
                    Supplier.Contact = ContactTextBox.Text;
                    DialogResult = true;
                };
                buttonPanel.Children.Add(saveButton);

                var cancelButton = new Button { Content = "Cancel", Width = 80, Margin = new Thickness(5) };
                cancelButton.Click += (s, e) => DialogResult = false;
                buttonPanel.Children.Add(cancelButton);

                Content = grid;
            }
        }
    }
}
