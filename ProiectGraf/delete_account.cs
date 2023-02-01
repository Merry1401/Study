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
    public partial class delete_account : Form
    {
        SqlConnection c = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=" + Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName + @"\Database1.mdf;Integrated Security=True");
        public delete_account()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            c.Open();
            string delete = "delete from users where email='" + textBox2.Text+"'";
            string del2 = "delete from lectii where email='" + textBox2.Text + "'";
            SqlCommand cmd = new SqlCommand(delete, c);
            SqlCommand comm = new SqlCommand(del2,c);
            if(textBox2.Text == login.user && textBox1.Text == login.password)
            {
                cmd.ExecuteNonQuery();
                comm.ExecuteNonQuery();
            }
            c.Close();
            login f = new login();
            f.Show();
            this.Close();

        }
    }
}
