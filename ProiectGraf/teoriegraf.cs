using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Drawing.Drawing2D;

namespace ProiectGraf
{
    public partial class teoriegraf : Form
    {
        int n, i = 1,x=1,y=1;
        Graphics g;
        int[,] a = new int[100, 100];

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void button3_Click(object sender, EventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {

        }

        private void button6_Click(object sender, EventArgs e)
        {

        }

        public teoriegraf()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("TextFile1.Txt"))
            {
                string s1 = fin.ReadLine();
                n = int.Parse(s1);
                string s2 = fin.ReadLine();
                string[] vs = s2.Split(' ');

                string[] v1 = s2.Split(new char[]{'-', ' ' });
                if (n < 5)
                {
                    if (vs[1].ToString().Contains("-"))
                    {
                        string i = vs[1].ToString().Substring(0, vs[1].LastIndexOf("-"));
                        string j = vs[1].ToString().Substring(vs[1].IndexOf("-") + 1);

                        a[int.Parse(i), int.Parse(j)] = 1;
                    }
                    if (vs[2].ToString().Contains("-"))
                    {
                        string i = vs[2].ToString().Substring(0, vs[2].LastIndexOf("-"));
                        string j = vs[2].ToString().Substring(vs[2].IndexOf("-") + 1);

                        a[int.Parse(i), int.Parse(j)] = 1;
                    }
                    if (vs[3].ToString().Contains("-"))
                    {
                        string i = vs[3].ToString().Substring(0, vs[3].LastIndexOf("-"));
                        string j = vs[3].ToString().Substring(vs[3].IndexOf("-") + 1);

                        a[int.Parse(i), int.Parse(j)] = 1;
                    }
                    if (vs[0].ToString().Contains("-"))
                    {
                        string i = vs[0].ToString().Substring(0, vs[0].LastIndexOf("-"));
                        string j = vs[0].ToString().Substring(vs[0].IndexOf("-") + 1);

                        a[int.Parse(i), int.Parse(j)] = 1;
                    }
                }
                
                for(int i1=0;i1<=n;i1++)
                {
                    for(int j1=0;j1<=n;j1++)
                    {
                        desen(i1);
                        if(a[i1,j1] == 1)
                        {

                        }
                    }
                }
                fin.Close();
            }

            
            
        }
        
        void desen(int x)
        {
            g = this.CreateGraphics();
            Pen p = new Pen(Color.Black, 2);
            Pen p1 = new Pen(Color.Red, 1);
            Pen p2 = new Pen(Color.Blue, 1);
            
            Rectangle r = new Rectangle(225 , 175, 35, 35);
            Rectangle r1 = new Rectangle(375, 175 , 35, 35);
            Rectangle r2 = new Rectangle(225, 350 , 35, 35);
            Rectangle r3 = new Rectangle(375, 350 , 35, 35);
            Rectangle r4 = new Rectangle(300, 450 , 35, 35);
            Rectangle r5 = new Rectangle(300, 100 , 35, 35);
            Rectangle r6 = new Rectangle(100, 250, 35, 35);
            Rectangle r7 = new Rectangle(500, 250, 35, 35);

            AdjustableArrowCap bigArrow = new AdjustableArrowCap(3, 3);
            p1.CustomEndCap = bigArrow;
            if (x < 5)
            {
                g.DrawEllipse(p, r);
                g.DrawEllipse(p, r1);
                g.DrawEllipse(p, r2);
                g.DrawEllipse(p, r3);
            }
            else if (x > 5 && x < 7)
            {
                g.DrawEllipse(p, r);
                g.DrawEllipse(p, r1);
                g.DrawEllipse(p, r2);
                g.DrawEllipse(p, r3);
                g.DrawEllipse(p, r4);
                g.DrawEllipse(p, r5);
                
            }
            else if(x == 7)
            {
                g.DrawEllipse(p, r);
                g.DrawEllipse(p, r1);
                g.DrawEllipse(p, r2);
                g.DrawEllipse(p, r3);
                g.DrawEllipse(p, r4);
                g.DrawEllipse(p, r5);
                g.DrawEllipse(p, r6);
                g.DrawEllipse(p, r7);
            }

        }
    }
}
