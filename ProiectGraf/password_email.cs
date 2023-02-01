using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Mail;

namespace ProiectGraf
{
    public partial class password_email : Form
    {
        Random rand = new Random();
        string randCode;
        public static string to;
        public password_email()
        {
            InitializeComponent();
        }

        private void password_email_Load(object sender, EventArgs e)
        {
            textBox1.Hide();
            button1.Hide();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            textBox1.Show();
            button1.Show();
            string from, password;
            
            randCode = (rand.Next(999999)).ToString();
           
                MailMessage message = new MailMessage();
                to = (textBox2.Text).ToString();
                SmtpClient smtp = new SmtpClient();
                from = "info.projectstudy@gmail.com";
                password = "nlcjdtrgrqgzgtza";
                message.To.Add(new MailAddress(to));
                message.Subject = "Password Reset";
                message.Body = "Here is your key to reset your password. Key: " + randCode;
            message.From = new MailAddress(from);
                smtp.Port = 587;
                smtp.Host = "smtp.gmail.com";
                smtp.EnableSsl = true;
                smtp.UseDefaultCredentials = false;
                smtp.Credentials = new NetworkCredential(from, password);
                smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            try
            {
                smtp.Send(message);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
            if(randCode == textBox1.Text)
            {
                forgotpass f = new forgotpass();
                f.Show();
                to = textBox2.Text;
                randCode = (rand.Next(999999)).ToString(); 
            }
        }
    }
}
