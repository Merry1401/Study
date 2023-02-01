using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MaterialSkin.Controls;
using MaterialSkin;
using System.Data.SqlClient;
using System.IO;

namespace ProiectGraf
{
    public partial class home : MaterialForm
    {
        string email = login.user;
        string lectie;
        public static bool DarkTheme;
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Database1.mdf;Integrated Security=True");
        public home()
        {
            InitializeComponent();
            var materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.EnforceBackcolorOnAllComponents = false;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.Green800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            
        }
        MaterialSkinManager manager = MaterialSkinManager.Instance;
        private void materialExpansionPanel1_SaveClick(object sender, EventArgs e)
        {
            c.Open();
            string insert = @"insert into lectii(email,lectie)values(@email,@lectie)";
            string count = "select count (*) from lectii where lectie = 'lectie_graf' and email ='" + email + "'";
            SqlCommand cm1 = new SqlCommand(count, c);
            SqlCommand cmd = new SqlCommand(insert, c);
            if ((int)cm1.ExecuteScalar() > 0)
            {
                MessageBox.Show("Deja te-ai inscris la lectia aia!");
            }
            else
            {
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("lectie", "lectie_graf");
                SqlDataReader r = cmd.ExecuteReader();
            }
            c.Close();
        }

        private void materialExpansionPanel2_SaveClick(object sender, EventArgs e)
        {
            c.Open();
            string insert = @"insert into lectii(email,lectie)values(@email,@lectie)";
            string count = "select count (*) from lectii where lectie = 'lectie_graphics' and email ='" + email + "'";
            SqlCommand cm1 = new SqlCommand(count, c);
            SqlCommand cmd = new SqlCommand(insert, c);
            if ((int)cm1.ExecuteScalar() > 0)
            {
                MessageBox.Show("Deja te-ai inscris la lectia aia!");
            }
            else
            {
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("lectie", "lectie_graphics");
                SqlDataReader r = cmd.ExecuteReader();
            }
            c.Close();
        }

        private void tabPage2_Enter(object sender, EventArgs e)
        {
            materialExpansionPanel1.Collapse = true;
            materialExpansionPanel2.Collapse = true;
            materialExpansionPanel3.Collapse = true;
        }

        private void materialButton1_Click(object sender, EventArgs e)
        {
            this.Hide();
            delete_account f = new delete_account();
            f.Show();
        }

        private void materialSwitch1_CheckedChanged(object sender, EventArgs e)
        {
            if (materialSwitch1.Checked)
            {
                manager.Theme = MaterialSkinManager.Themes.DARK;
                DarkTheme = true;
            }
            else
            {
                manager.Theme = MaterialSkinManager.Themes.LIGHT;
                DarkTheme = false;
            }
            
        }

        private void materialExpansionPanel3_SaveClick(object sender, EventArgs e)
        {
            c.Open();
            string insert = @"insert into lectii(email,lectie)values(@email,@lectie)";
            string count = "select count (*) from lectii where lectie = 'lectie_back' and email ='" + email + "'";
            SqlCommand cm1 = new SqlCommand(count, c);
            SqlCommand cmd = new SqlCommand(insert, c);
            if ((int)cm1.ExecuteScalar() > 0)
            {
                MessageBox.Show("Deja te-ai inscris la lectia aia!");
            }
            else
            {
                cmd.Parameters.AddWithValue("email", email);
                cmd.Parameters.AddWithValue("lectie", "lectie_back");
                SqlDataReader r = cmd.ExecuteReader();
            }
            c.Close();
        }

       

        private void tabPage3_Enter(object sender, EventArgs e)
        {
            label1.Text = email;
            c.Open();
            string select = "select lectie from lectii where email ='" + email + "'";
            SqlCommand cmd = new SqlCommand(select, c);
            SqlDataReader r = cmd.ExecuteReader();
            while (r.Read())
            {
                listBox1.Items.Add(r[0].ToString());
            }
            c.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            lectie = listBox1.SelectedItem.ToString();
            
            if (lectie == "Lectie Grafuri")
                MessageBox.Show("Graf");
        }
    }
}
