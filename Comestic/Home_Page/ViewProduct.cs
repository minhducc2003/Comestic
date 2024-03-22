using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Comestic.Home_Page
{
    public partial class ViewProduct : Form
    {
        public ViewProduct()
        {
            InitializeComponent();
            LoadProductData();
        }

        private void ViewProduct_Load(object sender, EventArgs e)
        {
            LoadProductData();
        }

        private void LoadProductData()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minhd\source\repos\Comestic\Comestic\user.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Product";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                // Gán dữ liệu vào DataGridView
                dataGridView1.DataSource = dataTable;

                // Căn giữa tiêu đề của các cột
                foreach (DataGridViewColumn column in dataGridView1.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }




        public void SetProductData(string productID, byte[] productImage, int productRate, int productQuantity, string productBrand, string productCategory, string productStatus)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page.Home home = new Home_Page.Home();
            home.StartPosition = FormStartPosition.Manual;
            home.Location = this.Location;
            home.ShowDialog();
            this.Close();
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
