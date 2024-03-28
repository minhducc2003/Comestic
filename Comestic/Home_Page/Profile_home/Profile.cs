using System;
using System.Data.SqlClient;
using System.Drawing;
using System.IO;
using System.Windows.Forms;


namespace Comestic.Home_Page.Profile_home
{
    public partial class Profile : Form

    {
        private Home_User_Managerment homeUserManagementForm;
        public Profile()
        {
            InitializeComponent();

        }
        public Profile(Home_User_Managerment form)
        {
            InitializeComponent();
            homeUserManagementForm = form;
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (!isSelectingText)
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image Files(*.BMP;*.JPG;*.JPEG;*.PNG)|*.BMP;*.JPG;*.JPEG;*.PNG|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string selectedFile = openFileDialog.FileName;
                    DisplayImage(selectedFile);
                }
            }
        }
        private bool isSelectingText = false;

        private void richTextBox1_MouseDown(object sender, MouseEventArgs e)
        {
            isSelectingText = true;
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            isSelectingText = false;
        }
        private void DisplayImage(string imagePath)
        {
            try
            {
                System.Drawing.Image img = System.Drawing.Image.FromFile(imagePath);
                pictureBox1.Image = img;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load image: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
        private void pictureBox_DragEnter(object sender, DragEventArgs e)
        {
            if (e.Data.GetDataPresent(DataFormats.FileDrop))
            {
                string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
                foreach (string file in files)
                {
                    if (IsImageFile(file))
                    {
                        e.Effect = DragDropEffects.Copy;
                        return;
                    }
                }
            }
            e.Effect = DragDropEffects.None;
        }
        private bool IsImageFile(string filePath)
        {
            string ext = Path.GetExtension(filePath).ToLower();
            return ext == ".jpg" || ext == ".jpeg" || ext == ".png" || ext == ".bmp";
        }

        private void PictureBox_DragDrop(object sender, DragEventArgs e)
        {
            string[] files = (string[])e.Data.GetData(DataFormats.FileDrop);
            foreach (string file in files)
            {
                if (IsImageFile(file))
                {
                    DisplayImage(file);
                    return;
                }
            }
        }
        private Color originalButtonColor;
        private void Form_Load(object sender, EventArgs e)
        {
            // Lưu màu nền gốc của các nút
            originalButtonColor = guna2Button5.BackColor;
        }

        private void guna2Button5_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;
                style ^= FontStyle.Bold;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }

            // Thay đổi màu nền của nút
            guna2Button5.BackColor = richTextBox1.SelectionFont.Bold ? Color.LightGray : originalButtonColor;
        }

        private void guna2Button6_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;
                style ^= FontStyle.Italic;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }

            // Thay đổi màu nền của nút
            guna2Button6.BackColor = richTextBox1.SelectionFont.Italic ? Color.LightGray : originalButtonColor;
        }

        private void guna2Button7_Click(object sender, EventArgs e)
        {
            if (richTextBox1.SelectionFont != null)
            {
                FontStyle style = richTextBox1.SelectionFont.Style;
                style ^= FontStyle.Underline;
                richTextBox1.SelectionFont = new Font(richTextBox1.SelectionFont, style);
            }

            // Thay đổi màu nền của nút
            guna2Button7.BackColor = richTextBox1.SelectionFont.Underline ? Color.LightGray : originalButtonColor;
        }

        private void guna2Button8_Click(object sender, EventArgs e)
        {
            string text = richTextBox1.Text.Trim();

            if (!text.StartsWith("•"))
            {
                richTextBox1.AppendText("• ");
            }
            else
            {
                richTextBox1.AppendText("\n• ");
            }

            // Di chuyển con trỏ đến cuối văn bản
            richTextBox1.SelectionStart = richTextBox1.Text.Length;

            // Thay đổi màu nền của nút
            guna2Button8.BackColor = originalButtonColor;
        }

        private void guna2Button9_Click(object sender, EventArgs e)
        {
            this.Hide();
            Home_Page.Profile_home.Home_User_Managerment home = new Home_Page.Profile_home.Home_User_Managerment();
            home.StartPosition = FormStartPosition.Manual;
            home.Location = this.Location;
            home.ShowDialog();
            this.Close();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            SaveProductData();

            this.Hide();
            Home_Page.Profile_home.Home_User_Managerment staff = new Home_Page.Profile_home.Home_User_Managerment();
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
                string query = "INSERT INTO Employees (Name, Address, Contact, Email, DateOfBirth, DateOfJoin, WageRate, WorkedHour, Sex) VALUES (@Name, @Address, @Contact, @Email, @DateOfBirth, @DateOfJoin, @WageRate, @WorkedHour, @Sex)";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Name", guna2TextBox1.Text);
                command.Parameters.AddWithValue("@Address", guna2TextBox2.Text);
                command.Parameters.AddWithValue("@Contact", guna2TextBox3.Text);
                command.Parameters.AddWithValue("@Email", guna2TextBox4.Text);
                command.Parameters.AddWithValue("@DateOfBirth", guna2TextBox5.Text);
                command.Parameters.AddWithValue("@DateOfJoin", guna2TextBox6.Text);
                command.Parameters.AddWithValue("@WageRate", guna2TextBox7.Text);
                command.Parameters.AddWithValue("@WorkedHour", guna2TextBox8.Text);
                command.Parameters.AddWithValue("@Sex", guna2TextBox9.Text);


                command.ExecuteNonQuery();
            }


        }

        private void guna2Button10_Click(object sender, EventArgs e)
        {
            homeUserManagementForm.DeleteSelectedRow();
        }

    }
}
