using System.Windows;

namespace VP_2
{
    public partial class ProductInputDialog : Window
    {
        // Properties for each field, including ProductId
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int Price { get; set; }
        public int CategoryId { get; set; }

        public ProductInputDialog()
        {
            InitializeComponent();
        }

        private void OkButton_Click(object sender, RoutedEventArgs e)
        {
            // Validate inputs
            if (int.TryParse(ProductIdTextBox.Text, out int productId) &&
                int.TryParse(QuantityTextBox.Text, out int quantity) &&
                int.TryParse(PriceTextBox.Text, out int price) &&
                int.TryParse(CategoryIdTextBox.Text, out int categoryId))
            {
                ProductId = productId;
                ProductName = ProductNameTextBox.Text;
                Quantity = quantity;
                Price = price;
                CategoryId = categoryId;

                DialogResult = true;  // Close the dialog and return "OK" status
            }
            else
            {
                MessageBox.Show("Please enter valid values.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            DialogResult = false;  // Close the dialog and return "Cancel" status
        }
    }
}
