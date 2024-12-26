using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;

namespace VP_2
{
    public partial class UserListPage : Page
    {
        public UserListPage()
        {
            InitializeComponent();
            LoadUserList();
        }

        private void LoadUserList()
        {
            string connectionString = "Data Source=WASAYPC;Initial Catalog=\"vp proje\";Integrated Security=True;Encrypt=False;";
            string query = "SELECT id, ClientName, Phone, Date FROM Users";

            try
            {
                List<User> users = new List<User>();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        users.Add(new User
                        {
                            Id = reader.GetInt32(0),
                            ClientName = reader.GetString(1),
                            Phone = reader.GetInt32(2),
                            Date = reader.GetDateTime(3).ToString("yyyy-MM-dd")
                        });
                    }

                    reader.Close();
                }

                // Bind the user list to the DataGrid
                UserDataGrid.ItemsSource = users;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred: {ex.Message}", "Error", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }

    // Class to represent user data
    public class User
    {
        public int Id { get; set; }
        public string ClientName { get; set; }
        public int Phone { get; set; }
        public string Date { get; set; }
    }
}
