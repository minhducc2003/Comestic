using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Comestic.Home_Page.Profile_home
{
    public partial class EmployeeDetailsForm : Form
    {
        public EmployeeDetailsForm(string name, string id)
        {
            InitializeComponent();
   
        }

        private void EmployeeDetailsForm_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'userDataSet3.Employees' table. You can move, or remove it, as needed.
            this.employeesTableAdapter.Fill(this.userDataSet3.Employees);

        }
    }
}
