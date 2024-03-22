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

namespace Comestic
{
    public partial class Login : Form
    {
        SqlCommand cmd;
        SqlConnection cn;
        SqlDataReader dr;
        public Login()
        {
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {
            cn = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minhd\source\repos\Comestic\Comestic\user.mdf;Integrated Security=True");
            cn.Open();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            this.Hide();
            Home_Login home_Login = new Home_Login();
            home_Login.StartPosition = FormStartPosition.Manual;
            home_Login.Location = this.Location;
            home_Login.ShowDialog();
            this.Close();
        }

        private void exit_signin_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            if(password.Text != string.Empty || guna2TextBox1.Text != string.Empty)
            {
                cmd = new SqlCommand("select * from LoginTable where username = '" + guna2TextBox1.Text + "' and password = '" + password.Text + "'", cn);
                dr = cmd.ExecuteReader();
                if (dr.Read())
                {
                    dr.Close();
                    this.Hide();
                    Home_Page.Home home = new Home_Page.Home();
                    home.StartPosition = FormStartPosition.Manual;
                    home.Location = this.Location;
                    home.ShowDialog();
                }
                else
                {
                    dr.Close();
                    MessageBox.Show("Sai tên đăng nhập hoặc mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Vui lòng nhập tên đăng nhập và mật khẩu", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void guna2PictureBox1_Click(object sender, EventArgs e)
        {

        }
    }
}
