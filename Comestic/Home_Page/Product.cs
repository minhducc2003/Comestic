using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace Comestic.Home_Page
{
    public partial class Product : Form
    {
        public string ProductID { get; private set; }
        public byte[] ProductImage { get; private set; }

        byte[] image;

        public event EventHandler<byte[]> DataChanged;

        public Product()
        {
            InitializeComponent();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {

        }

        private void guna2Button2_Click_1(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page.Home home = new Home_Page.Home();
            home.StartPosition = FormStartPosition.Manual;
            home.Location = this.Location;
            home.ShowDialog();
            this.Close();
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image Files (*.jpg, *.jpeg, *.png, *.gif) | *.jpg; *.jpeg; *.png; *.gif";

            if (openFileDialog.ShowDialog() == DialogResult.OK)
            {
                string imagePath = openFileDialog.FileName;

                // Kiểm tra định dạng của tệp hình ảnh
                string extension = Path.GetExtension(imagePath);
                if (extension != null && (extension.ToLower() == ".jpg" || extension.ToLower() == ".jpeg" || extension.ToLower() == ".png" || extension.ToLower() == ".gif"))
                {
                    // Hiển thị hình ảnh đã chọn trên PictureBox
                    picPhoto.Image = Image.FromFile(imagePath);

                    // Đọc dữ liệu hình ảnh vào một mảng byte[]
                    using (var stream = new FileStream(imagePath, FileMode.Open, FileAccess.Read))
                    {
                        using (var reader = new BinaryReader(stream))
                        {
                            image = reader.ReadBytes((int)stream.Length);
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Vui lòng chọn một tệp hình ảnh có định dạng JPG, JPEG, PNG hoặc GIF.");
                }
            }
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            // Lưu dữ liệu sản phẩm
            SaveProductData();

            // Hiển thị form ViewProduct và ẩn form hiện tại
            this.Hide();
            Home_Page.ViewProduct staff = new Home_Page.ViewProduct();
            staff.StartPosition = FormStartPosition.Manual;
            staff.Location = this.Location;
            staff.ShowDialog();
            this.Close();
        }

        private void SaveProductData()
        {
            // Thực hiện lưu dữ liệu vào cơ sở dữ liệu
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minhd\source\repos\Comestic\Comestic\user.mdf;Integrated Security=True";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "INSERT INTO Product (Product_Name, Product_Image, Product_Rate, Product_Quantity, Product_Brand, Product_Category, Product_Status) VALUES (@ProductName, @ProductImage, @ProductRate, @ProductQuantity, @ProductBrand, @ProductCategory, @ProductStatus)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@ProductName", txtProductName.Text);
                command.Parameters.AddWithValue("@ProductImage", image); // Sử dụng biến image đã được gán trong phương thức guna2Button8_Click
                command.Parameters.AddWithValue("@ProductRate", Convert.ToInt32(nudRate.Value));
                command.Parameters.AddWithValue("@ProductQuantity", Convert.ToInt32(nudQuantity.Value));
                command.Parameters.AddWithValue("@ProductBrand", cmbBrand.Text);
                command.Parameters.AddWithValue("@ProductCategory", comboBox2.Text);
                command.Parameters.AddWithValue("@ProductStatus", comboBox3.Text);
                command.ExecuteNonQuery();
            }
        }

        private void txtProductName_TextChanged(object sender, EventArgs e)
        {

        }
    }

}