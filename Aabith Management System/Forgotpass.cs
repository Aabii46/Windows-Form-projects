using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Mail;
using System.Net;


namespace Aabith_Management_System
{
    public partial class Forgotpass : Form
    {
        string randomcode;
        public Forgotpass()
        {
            InitializeComponent();
        }

        private void button6_Click(object sender, EventArgs e)
        {
            string  from, pass, messagebody, to;
            Random random = new Random();
            randomcode = (random.Next(999999)).ToString();
            MailMessage message = new MailMessage();
            to = (textBox1.Text).ToString();
            from = "aabithmusharaf@gmail.com";
            pass = "nqlx vbts lyqg emwa";
            messagebody = "Your OTP Verification Code " + randomcode;
            message.To.Add(to);
            message.From = new MailAddress(from);
            message.Body = messagebody;
            message.Subject = "Employee Management Verification";
            SmtpClient smtp = new SmtpClient("smtp.gmail.com");
            smtp.EnableSsl = true;
            smtp.Port = 587;
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.Credentials = new NetworkCredential(from, pass);

            try
            {
                smtp.Send(message);
                MessageBox.Show("OTP Sended Successfully");
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(randomcode == (textBox2.Text).ToString())
            {
                MessageBox.Show("OTP Verified Successfully");
                changepass cp = new changepass();
                cp.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("Invalid OTP");
            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
