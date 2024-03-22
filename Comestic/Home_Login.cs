using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.ListView;

namespace Comestic
{

    public partial class Home_Login : Form

    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;

        public Home_Login()
        {
            InitializeComponent();
        }

        private void Home_Login_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minhd\source\repos\Comestic\Comestic\user.mdf;Integrated Security=True");
            cn.Open();
        }

        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Login login = new Login();
            login.StartPosition = FormStartPosition.Manual;
            login.Location = this.Location;
            login.ShowDialog();
            this.Close();
        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void guna2ImageButton1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if( password.Text != string.Empty || cfpassword.Text != string.Empty || guna2TextBox1.Text != string.Empty)
            {
                if (password.Text == cfpassword.Text)
                {
                    if (!IsValidPhoneNumber(guna2TextBox3.Text))
                    {
                        MessageBox.Show("Số điện thoại không hợp lệ. Vui lòng nhập số điện thoại bắt đầu bằng số 0 và có đúng 10 số.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!IsValidEmail(guna2TextBox2.Text))
                    {
                        MessageBox.Show("Email không hợp lệ. Vui lòng nhập địa chỉ email của Gmail.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    if (!IsValidPassword(password.Text))
                    {
                        MessageBox.Show("Mật khẩu không hợp lệ. Mật khẩu cần chứa ít nhất một ký tự in hoa, một ký tự in thường, một số và một ký tự đặc biệt.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return;
                    }
                    
                    cmd = new SqlCommand("select * from LoginTable where username = '" + guna2TextBox1.Text + "'", cn);
                    dr = cmd.ExecuteReader();
                    if(dr.Read())
                    {
                        dr.Close();
                        MessageBox.Show("Tên đăng nhập đã tồn tại", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dr.Close();
                        cmd = new SqlCommand("INSERT INTO LoginTable (username, email, phone, password, confirmPassword) VALUES (@username, @email, @phone, @password, @confirmPassword)", cn);
                        cmd.Parameters.AddWithValue("@username", guna2TextBox1.Text);
                        cmd.Parameters.AddWithValue("@password", password.Text);
                        cmd.Parameters.AddWithValue("@email", guna2TextBox2.Text);
                        cmd.Parameters.AddWithValue("@phone", guna2TextBox3.Text);
                        cmd.Parameters.AddWithValue("@confirmPassword", cfpassword.Text);

                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Đăng ký thành công", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
                else
                {
                    MessageBox.Show("Mật khẩu không trùng khớp", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void password_TextChanged(object sender, EventArgs e)
        {

        }
        private bool IsValidPhoneNumber(string phoneNumber)
        {
            if (phoneNumber.Length != 10)
                return false;

            if (phoneNumber[0] != '0')
                return false;

            foreach (char c in phoneNumber)
            {
                if (!char.IsDigit(c))
                    return false;
            }

            return true;
        }
        private bool IsValidEmail(string email)
        {
            string pattern = @"^[a-zA-Z0-9](\.?[a-zA-Z0-9]){5,}@g(oogle)?mail\.com$";
            return Regex.IsMatch(email, pattern);
        }
        private bool IsValidPassword(string password)
        {
            // Kiểm tra xem mật khẩu có ít nhất một ký tự in hoa không
            if (!password.Any(char.IsUpper))
                return false;

            // Kiểm tra xem mật khẩu có ít nhất một ký tự in thường không
            if (!password.Any(char.IsLower))
                return false;

            // Kiểm tra xem mật khẩu có ít nhất một ký tự số không
            if (!password.Any(char.IsDigit))
                return false;

            // Kiểm tra xem mật khẩu có ít nhất một ký tự đặc biệt không
            if (!password.Any(ch => !char.IsLetterOrDigit(ch)))
                return false;

            return true;
        }
    }
}