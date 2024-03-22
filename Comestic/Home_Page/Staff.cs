using Guna.UI2.WinForms;
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
    public partial class Staff : Form
    {
        public Staff()
        {
            InitializeComponent();
        }

        private void Staff_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'userDataSet1.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.userDataSet1.Employees);

        }

        private void guna2Button3_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page.BlurForm staff = new Home_Page.BlurForm();
            staff.StartPosition = FormStartPosition.Manual;
            staff.Location = this.Location;
            staff.ShowDialog();
            this.Close();
        }
    }
}
