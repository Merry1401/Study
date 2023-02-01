using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Security.Cryptography;
using System.Data.SqlClient;
using System.IO;

namespace ProiectGraf
{
    public partial class login : Form
    {
        public static string user, password;
        public login()
        {
            InitializeComponent();
        }
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Database1.mdf;Integrated Security=True");
        public static string Encrypt(string encryptString)
        {
            string EncryptionKey = "fbdshahfbhjasbhjdbfkjbfsadhj";
            byte[] clearBytes = Encoding.Unicode.GetBytes(encryptString);

            using (Aes encryptor = Aes.Create())
            {
                Rfc2898DeriveBytes pass = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
                encryptor.Key = pass.GetBytes(32);
                encryptor.IV = pass.GetBytes(16);

                using (MemoryStream ms = new MemoryStream())
                {
                    using (CryptoStream cs = new CryptoStream(ms, encryptor.CreateEncryptor(),
                    CryptoStreamMode.Write))
                    {
                        cs.Write(clearBytes, 0, clearBytes.Length);
                        cs.Close();
                    }

                    encryptString = Convert.ToBase64String(ms.ToArray());
                }
            }

            return encryptString;
        }
        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "")
            {
                MessageBox.Show("Te rog introduce toate datele.", "Login", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
            }
            c.Open();
            string s1 = textBox2.Text;
            var hash = Encrypt(s1);
            string select = "select * from users where email='" + textBox1.Text + "' and password= '" + hash + "'";
            SqlCommand cmd = new SqlCommand(select, c);
            SqlDataReader r = cmd.ExecuteReader();
            if (r.Read() == true)
            {
                user = textBox1.Text;
                password = textBox2.Text;
                textBox1.Clear();
                textBox2.Clear();
                

            }
            
            c.Close();
            this.Hide();
            home f = new home();
            f.Show();
        }

        private void label5_Click(object sender, EventArgs e)
        {
            if (label2.Text == "Parola")
            {
                label2.Text = "Password";
                checkBox2.Text = "Show Password";
                
                label1.Text = "Forgot your Password?";

            }
            else if (label2.Text == "Password")
            {
                label2.Text = "Parola";
                checkBox2.Text = "Arata Parola";
                
                label1.Text = "Ai uitat parola?";

            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            this.Hide();
            password_email f = new password_email();
            f.Show();
        }

        private void label4_Click(object sender, EventArgs e)
        {
            this.Hide();
            register f = new register();
            f.Show();
        }

        private void checkBox2_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox2.Checked)
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
