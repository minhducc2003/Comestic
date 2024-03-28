using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Contracts;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comestic.Home_Page
{
    public partial class Home : Form
    {
        public Home()
        {
            InitializeComponent();
        }

        private void guna2Button2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page.Contact contact = new Home_Page.Contact();
            contact.StartPosition = FormStartPosition.Manual;
            contact.Location = this.Location;
            contact.ShowDialog();
            this.Close();
        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page.Product product = new Home_Page.Product();
            product.StartPosition = FormStartPosition.Manual;
            product.Location = this.Location;
            product.ShowDialog();
            this.Close();
        }

        private void guna2Button4_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page.Information information = new Home_Page.Information();
            information.StartPosition = FormStartPosition.Manual;
            information.Location = this.Location;
            information.ShowDialog();
            this.Close();
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page.Staff staff = new Home_Page.Staff();
            staff.StartPosition = FormStartPosition.Manual;
            staff.Location = this.Location;
            staff.ShowDialog();
            this.Close();
        }

        private void exit_signup_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton7_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page.Contact contact = new Contact();
            contact.StartPosition = FormStartPosition.Manual;
            contact.Location = this.Location;
            contact.ShowDialog();
            this.Close();
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page.Profile_home.Home_User_Managerment profile = new Home_Page.Profile_home.Home_User_Managerment();
            profile.StartPosition = FormStartPosition.Manual;
            profile.Location = this.Location;
            profile.ShowDialog();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("Bạn có chắc chắn muốn thoát không?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (result == DialogResult.Yes)
            {
                this.Close();
            }
        }
    }
}
