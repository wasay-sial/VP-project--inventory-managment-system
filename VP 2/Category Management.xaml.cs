using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace VP_2
{
    public partial class Category_Management : Window
    {
        private string connectionString = "Data Source=WASAYPC;Initial Catalog=\"vp proje\";Integrated Security=True;Encrypt=False;";

        public Category_Management()
        {
            InitializeComponent();
            LoadCategoryData();
        }

        private void LoadCategoryData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Categories", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    categoryDataGrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void AddCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string categoryId = Prompt_2.ShowDialog("Enter Category ID:", "Add Category");
                string categoryName = Prompt_2.ShowDialog("Enter Category Name:", "Add Category");
                string productId = Prompt_2.ShowDialog("Enter Product ID:", "Add Category");

                if (!string.IsNullOrEmpty(categoryId) && !string.IsNullOrEmpty(categoryName) && !string.IsNullOrEmpty(productId))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "INSERT INTO Categories (CategoryId, CategoryName, ProductId) VALUES (@CategoryId, @CategoryName, @ProductId)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@CategoryId", int.Parse(categoryId));
                            cmd.Parameters.AddWithValue("@CategoryName", categoryName);
                            cmd.Parameters.AddWithValue("@ProductId", int.Parse(productId));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Category added successfully.");
                    LoadCategoryData();
                }
                else
                {
                    MessageBox.Show("All fields are required.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding category: " + ex.Message);
            }
        }

        private void DeleteCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string categoryId = Prompt_2.ShowDialog("Enter Category ID to delete:", "Delete Category");

                if (!string.IsNullOrEmpty(categoryId))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Categories WHERE CategoryId = @CategoryId";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@CategoryId", int.Parse(categoryId));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("Category deleted successfully.");
                    LoadCategoryData();
                }
                else
                {
                    MessageBox.Show("Category ID is required.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting category: " + ex.Message);
            }
        }

        private void UpdateCategoryButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string categoryId = Prompt_2.ShowDialog("Enter Category ID to update:", "Update Category");

                if (!string.IsNullOrEmpty(categoryId))
                {
                    string newCategoryName = Prompt_2.ShowDialog("Enter new Category Name:", "Update Category");
                    string newProductId = Prompt_2.ShowDialog("Enter new Product ID:", "Update Category");

                    if (!string.IsNullOrEmpty(newCategoryName) && !string.IsNullOrEmpty(newProductId))
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "UPDATE Categories SET CategoryName = @CategoryName, ProductId = @ProductId WHERE CategoryId = @CategoryId";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@CategoryName", newCategoryName);
                                cmd.Parameters.AddWithValue("@ProductId", int.Parse(newProductId));
                                cmd.Parameters.AddWithValue("@CategoryId", int.Parse(categoryId));
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("Category updated successfully.");
                        LoadCategoryData();
                    }
                    else
                    {
                        MessageBox.Show("All fields are required.");
                    }
                }
                else
                {
                    MessageBox.Show("Category ID is required.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating category: " + ex.Message);
            }
        }

        private void SearchButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string searchQuery = Prompt_2.ShowDialog("Enter Category Name or ID to search:", "Search Category");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = $"SELECT * FROM Categories WHERE CategoryName LIKE '%{searchQuery}%' OR CategoryId = @CategoryId";
                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (int.TryParse(searchQuery, out int categoryId))
                        {
                            cmd.Parameters.AddWithValue("@CategoryId", categoryId);
                        }
                        else
                        {
                            cmd.Parameters.AddWithValue("@CategoryId", DBNull.Value);
                        }

                        SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        categoryDataGrid.ItemsSource = dataTable.DefaultView;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching data: " + ex.Message);
            }
        }
    }

    public static class Prompt_2
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
