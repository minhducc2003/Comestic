using Bunifu.UI.WinForms;
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

namespace Comestic.Home_Page.Profile_home
{
    public partial class Home_User_Managerment : Form

    {
        public void DeleteSelectedRow()
        {
                string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minhd\source\repos\Comestic\Comestic\user.mdf;Integrated Security=True";
                if (guna2DataGridView1.SelectedRows.Count > 0)
            {
                int selectedRowIndex = guna2DataGridView1.SelectedRows[0].Index;
                string employeeID = guna2DataGridView1.Rows[selectedRowIndex].Cells["ID"].Value.ToString();

                string deleteQuery = "DELETE FROM Employees WHERE ID = @ID";
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(deleteQuery, connection);
                    command.Parameters.AddWithValue("@ID", employeeID);
                    try
                    {
                        connection.Open();
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Đã xoá dòng thành công!");
                            LoadData(); // Cập nhật DataGridView
                        }
                        else
                        {
                            MessageBox.Show("Không tìm thấy dòng để xoá!");
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Lỗi khi xoá dòng: " + ex.Message);
                    }
                }
            }
            else
            {
                MessageBox.Show("Vui lòng chọn một dòng để xoá!");
            }
        }
        public Home_User_Managerment()
        {
            InitializeComponent();
            LoadProductData();

            guna2DataGridView1.CellContentClick += DataGridView_CellContentClick;
        }
        private void DataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Đảm bảo rằng chỉ xử lý sự kiện khi người dùng nhấp vào nút
            if (e.RowIndex >= 0 && e.ColumnIndex == guna2DataGridView1.Columns["View"].Index)
            {
                // Lấy thông tin từ dòng được chọn
                DataGridViewRow selectedRow = guna2DataGridView1.Rows[e.RowIndex];
                string employeeName = selectedRow.Cells["Name"].Value.ToString();
                string employeeID = selectedRow.Cells["ID"].Value.ToString();
                // và các thông tin khác bạn muốn hiển thị

                // Mở một form khác để hiển thị thông tin chi tiết
                ShowEmployeeDetailsForm(employeeName, employeeID);
            }
        }
        private void ShowEmployeeDetailsForm(string name, string id)
        {
            // Tạo một instance mới của Form chi tiết
            EmployeeDetailsForm detailsForm = new EmployeeDetailsForm(name, id);
            // Hiển thị form chi tiết
            detailsForm.ShowDialog();
        }
        private void ViewProduct_Load(object sender, EventArgs e)
        {
            
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page.Profile_home.Profile profile = new Home_Page.Profile_home.Profile(); 
            profile.StartPosition = FormStartPosition.Manual;
            profile.Location = this.Location;
            profile.ShowDialog();
            this.Close();
        }
        

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home home = new Home();
            home.StartPosition = FormStartPosition.Manual;
            home.Location = this.Location;
            home.ShowDialog();
            this.Close();
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void Home_User_Managerment_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'userDataSet2.Employees' table. You can move, or remove it, as needed.
            //LoadProductData(); // Bạn không cần gọi lại LoadProductData() ở đây vì đã gọi ở constructor rồi

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
        private void LoadProductData()
        {
            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minhd\source\repos\Comestic\Comestic\user.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT * FROM Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                guna2DataGridView1.DataSource = dataTable;

                foreach (DataGridViewColumn column in guna2DataGridView1.Columns)
                {
                    column.HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleCenter;
                }
            }
        }
        private void LoadData()
        {

            string connectionString = @"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=C:\Users\minhd\source\repos\Comestic\Comestic\user.mdf;Integrated Security=True";
            using (SqlConnection connection = new SqlConnection(connectionString))
                try 
        { 
                connection.Open();
                string query = "SELECT * FROM Employees";
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection); // Sử dụng this.connection để truy cập biến connection của lớp hiện tại
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);
                guna2DataGridView1.DataSource = dataTable;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
        private void ResetDataGridView()
        {
            bunifuTextBox1.Text = ""; // Xoá nội dung trong ô tìm kiếm
            LoadData(); // Tải lại dữ liệu ban đầu
        }

        private void dataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void guna2DataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrEmpty(bunifuTextBox1.Text))
                {
                    ResetDataGridView(); // Nếu ô tìm kiếm trống, thực hiện việc reset DataGridView
                    return;
                }

                DataView dv = new DataView(((DataTable)guna2DataGridView1.DataSource));
                dv.RowFilter = string.Format("Name LIKE '%{0}%'", bunifuTextBox1.Text);
                guna2DataGridView1.DataSource = dv.ToTable();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error: " + ex.Message);
            }
        }
    }
    
}
