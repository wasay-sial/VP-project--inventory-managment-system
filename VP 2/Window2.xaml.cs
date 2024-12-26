using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace VP_2
{
    public partial class Window2 : Window
    {
        private string connectionString = "Data Source=WASAYPC;Initial Catalog=\"vp proje\";Integrated Security=True;Encrypt=False;";

        public Window2()
        {
            InitializeComponent();
            LoadUserData();
        }

        private void LoadUserData()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Users", conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    userDataGrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading data: " + ex.Message);
            }
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = Prompt.ShowDialog("Enter User ID:", "Add User");
                string clientName = Prompt.ShowDialog("Enter Client Name:", "Add User");
                string phone = Prompt.ShowDialog("Enter Phone Number:", "Add User");
                string date = Prompt.ShowDialog("Enter Date (YYYY-MM-DD):", "Add User");

                if (!string.IsNullOrEmpty(id) && !string.IsNullOrEmpty(clientName) && !string.IsNullOrEmpty(phone) && !string.IsNullOrEmpty(date))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "INSERT INTO Users (Id, ClientName, Phone, Date) VALUES (@Id, @ClientName, @Phone, @Date)";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", int.Parse(id));
                            cmd.Parameters.AddWithValue("@ClientName", clientName);
                            cmd.Parameters.AddWithValue("@Phone", int.Parse(phone));
                            cmd.Parameters.AddWithValue("@Date", DateTime.Parse(date));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("User added successfully.");
                    LoadUserData();
                }
                else
                {
                    MessageBox.Show("All fields are required.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error adding user: " + ex.Message);
            }
        }

        private void DeleteUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = Prompt.ShowDialog("Enter User ID to delete:", "Delete User");

                if (!string.IsNullOrEmpty(id))
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        string query = "DELETE FROM Users WHERE Id = @Id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@Id", int.Parse(id));
                            cmd.ExecuteNonQuery();
                        }
                    }
                    MessageBox.Show("User deleted successfully.");
                    LoadUserData();
                }
                else
                {
                    MessageBox.Show("User ID is required.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error deleting user: " + ex.Message);
            }
        }

        private void UpdateUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = Prompt.ShowDialog("Enter User ID to update:", "Update User");

                if (!string.IsNullOrEmpty(id))
                {
                    string newClientName = Prompt.ShowDialog("Enter new Client Name:", "Update User");
                    string newPhone = Prompt.ShowDialog("Enter new Phone Number:", "Update User");
                    string newDate = Prompt.ShowDialog("Enter new Date (YYYY-MM-DD):", "Update User");

                    if (!string.IsNullOrEmpty(newClientName) && !string.IsNullOrEmpty(newPhone) && !string.IsNullOrEmpty(newDate))
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            string query = "UPDATE Users SET ClientName = @ClientName, Phone = @Phone, Date = @Date WHERE Id = @Id";
                            using (SqlCommand cmd = new SqlCommand(query, conn))
                            {
                                cmd.Parameters.AddWithValue("@ClientName", newClientName);
                                cmd.Parameters.AddWithValue("@Phone", int.Parse(newPhone));
                                cmd.Parameters.AddWithValue("@Date", DateTime.Parse(newDate));
                                cmd.Parameters.AddWithValue("@Id", int.Parse(id));
                                cmd.ExecuteNonQuery();
                            }
                        }
                        MessageBox.Show("User updated successfully.");
                        LoadUserData();
                    }
                    else
                    {
                        MessageBox.Show("All fields are required.");
                    }
                }
                else
                {
                    MessageBox.Show("User ID is required.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error updating user: " + ex.Message);
            }
        }

        private void SearchUserButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                string id = Prompt.ShowDialog("Enter User ID to search (leave blank to search by Client Name):", "Search User");

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string searchQuery;
                    //if (!string.IsNullOrEmpty(id))
                    //{
                        searchQuery = $"SELECT * FROM Users WHERE Id = {int.Parse(id)}";
                    //}
                    //else
                    //{
                        //searchQuery = $"SELECT * FROM Users WHERE ClientName LIKE '%{SearchUserBox.Text}%'";
                    //}

                    SqlDataAdapter adapter = new SqlDataAdapter(searchQuery, conn);
                    DataTable dataTable = new DataTable();
                    adapter.Fill(dataTable);
                    userDataGrid.ItemsSource = dataTable.DefaultView;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error searching data: " + ex.Message);
            }
        }
    }

    public static class Prompt
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
