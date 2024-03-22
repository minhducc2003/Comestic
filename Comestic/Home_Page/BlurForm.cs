using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comestic.Home_Page
{
    public partial class BlurForm : Form
    {
        public BlurForm()
        {
            InitializeComponent();
        }

        public void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            SaveProductData();

            this.Hide();
            Home_Page.Staff staff = new Home_Page.Staff();
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
                string query = "INSERT INTO Employees (Name,Address,Contact,Email,DateOfBirth,DateOfJoin,WageRate,WorkedHours) VALUES (@Name, @Address, @Contact, @Email, @DateOfBirth, @DateOfJoin, @WageRate, @WorkedHours)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", guna2TextBox1.Text);
                command.Parameters.AddWithValue("@Address", guna2TextBox2.Text); // Sử dụng biến image đã được gán trong phương thức guna2Button8_Click
                command.Parameters.AddWithValue("@Contact", guna2TextBox3.Text);
                command.Parameters.AddWithValue("@Email", guna2TextBox4.Text);
                command.Parameters.AddWithValue("@DateOfBirth" ,guna2TextBox5.Text);
                command.Parameters.AddWithValue("@DateOfJoin", guna2TextBox6.Text);
                command.Parameters.AddWithValue("@WageRate", guna2TextBox7.Text);
                command.Parameters.AddWithValue("@WorkedHours", guna2TextBox8.Text);
                command.ExecuteNonQuery();
            }
        }
    }
}
