using System;
using System.Net.Mail;
using System.Net;
using System.Windows.Forms;

namespace Comestic.Home_Page
{
    public partial class Contact : Form
    {
        public Contact()
        {
            InitializeComponent();
        }

        private void guna2Button1_Click(object sender, EventArgs e)
        {
            string toEmailAddress = guna2TextBox1.Text;
            string displayName = guna2TextBox2.Text;
            string messageBody = guna2TextBox3.Text;

            // Gửi email
            SendEmail(toEmailAddress, displayName, messageBody);
        }
        private void SendEmail(string toEmailAddress, string displayName, string messageBody)
        {
            try
            {
                // Cấu hình thông tin SMTP của Gmail
                SmtpClient client = new SmtpClient("smtp.gmail.com");
                client.Port = 587;
                client.EnableSsl = true;
                client.UseDefaultCredentials = false;
                client.Credentials = new NetworkCredential("mizo.cosmetics.customer@gmail.com", "aijxjlysibqntrut");

                // Tạo đối tượng MailMessage và gửi email
                MailMessage mailMessage = new MailMessage();
                mailMessage.From = new MailAddress("mizo.cosmetics.customer@gmail.com");
                mailMessage.To.Add(toEmailAddress);
                mailMessage.Subject = "MIZO COMESTIC - Thông báo xác nhận";
                mailMessage.Body = "Chào " + displayName + ", \n\nCảm ơn bạn đã liên hệ với chúng tôi. Chúng tôi sẽ phản hồi lại bạn trong thời gian sớm nhất.\n\nTrân trọng,\nMIZO COMESTIC";

                client.Send(mailMessage);

                MessageBox.Show("Email đã được gửi thành công!", "Thành công", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Đã xảy ra lỗi khi gửi email: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
        private void guna2TextBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
