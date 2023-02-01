using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.IO;

namespace ProiectGraf
{
    public partial class forgotpass : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Database1.mdf;Integrated Security=True");
        string email = password_email.to;
        public forgotpass()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == textBox2.Text)
            {
                c.Open();
                string update = "update users set password = '" + textBox2.Text + "' where email = '" + email + "'";
                SqlCommand cmd = new SqlCommand(update, c);
                cmd.ExecuteNonQuery();
                c.Close();
                MessageBox.Show("Parola a fost schimbata");
                this.Close();
                login f = new login();
                f.Show();
            }
            else
            {
                MessageBox.Show("Parolele nu sunt aceleasi");
            }
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
            {
                textBox1.PasswordChar = (char)0;

            }
            else
            {
                textBox1.PasswordChar = '*';
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox2.PasswordChar = (char)0;

            }
            else
            {
                textBox2.PasswordChar = '*';
            }
        }
    }
}
