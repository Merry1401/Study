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
using System.Security.Cryptography;

namespace ProiectGraf
{
    public partial class register : Form
    {
        
        public register()
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
                Rfc2898DeriveBytes pdb = new Rfc2898DeriveBytes(EncryptionKey, new byte[] {
            0x49, 0x76, 0x61, 0x6e, 0x20, 0x4d, 0x65, 0x64, 0x76, 0x65, 0x64, 0x65, 0x76});
                encryptor.Key = pdb.GetBytes(32);
                encryptor.IV = pdb.GetBytes(16);

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
        private void label4_Click(object sender, EventArgs e)
        {
            if(label2.Text == "Parola")
            {
                label2.Text = "Password";
                checkBox1.Text = "Show Password";
                button1.Text = "Register Account";
            }
            else if(label2.Text == "Password")
            {
                label2.Text = "Parola";
                checkBox1.Text = "Arata Parola";
                button1.Text = "Inregistreaza Cont";
            }
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                textBox1.PasswordChar = (char)0;

            }
            else
            {
                textBox1.PasswordChar = '*';
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            bool EmExists = false;
            if (textBox1.Text != "" && textBox2.Text != "")
            {
                c.Open();
                string s1 = textBox1.Text;
                var hash = Encrypt(s1);
                string insert = @"insert into users(email,password)values(@email,@password)";
                string count = "select count (*) from users where email = '" + textBox2.Text + "'";
                SqlCommand cm1 = new SqlCommand(count, c);
                SqlCommand cmd = new SqlCommand(insert, c);
                if ((int)cm1.ExecuteScalar() > 0)
                {
                    MessageBox.Show("Acest E-Mail a fost folosit deja!");
                    textBox2.Clear();
                    textBox1.Clear();
                }
                else
                {
                    cmd.Parameters.AddWithValue("email", textBox2.Text);
                    cmd.Parameters.AddWithValue("password", hash);
                    SqlDataReader r = cmd.ExecuteReader();
                    textBox2.Clear();
                    textBox1.Clear();
                    this.Hide();
                    login f = new login();
                    f.Show();
                }
                c.Close();
                
            }
            else
            {
                if (label2.Text == "Parola")
                {
                    MessageBox.Show("Te rog introduce toate datele.", "Register", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
                else if(label2.Text == "Password")
                {
                    MessageBox.Show("Please introduce all required data.", "Register", MessageBoxButtons.OKCancel, MessageBoxIcon.Error);
                }
            }
        }

        private void label5_Click(object sender, EventArgs e)
        {
            this.Hide();
            login f = new login();
            f.Show();
        }
    }
}
