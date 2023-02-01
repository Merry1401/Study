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
using System.Threading;

namespace ProiectGraf
{
    public partial class graf : Form
    {
        int[,] a = new int[100, 100];
        int n;
        int s;
        int[] viz = new int[100];
        int[] suc = new int[100];
        int[] pred = new int[100];
        Graphics g;
        public graf()
        {
            InitializeComponent();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            using (StreamReader fin = new StreamReader("TextFile1.Txt"))
            {
                string s1 = fin.ReadLine();
                n = int.Parse(s1);
                string s2 = fin.ReadLine();
                string[] vs = s2.Split('-');
                
                
                for (int i = 0; i < n; i++)
                {
                    string[] v1 = vs[i].Split();
                    MessageBox.Show(v1[i].ToString());
                    i++;
                    
                }
                fin.Close();
            }

        }
        void desen(int x)
        {
            g = this.CreateGraphics();
            Pen p = new Pen(Color.Black,1);
            
            Rectangle r = new Rectangle(50, 50 + x * 100, 50, 50);
            Rectangle r1 = new Rectangle(150, 50 + x * 100, 50, 50);

            using (StreamReader fin = new StreamReader("TextFile1.Txt"))
            {
                string s1 = fin.ReadLine();
                n = int.Parse(s1);
                string s2 = fin.ReadLine();
                string[] vs = s2.Split('-');
                
                string[] v1 = vs[1].Split();
                for (int i = 0; i < v1.Count(); i++)
                    a[i, int.Parse(v1[i].ToString())] = 1;
                Font drawFont = new Font("Arial", 12);
                SolidBrush drawBrush = new SolidBrush(Color.Red);
                for (int i = 1; i <= n; i++)
                {
                    if (i < 3)
                    {
                        g.DrawRectangle(p, 100, 100, 50, 50);
                        g.DrawString(vs[0].ToString(), drawFont, drawBrush, 110, 110);
                        g.DrawRectangle(p, 200, 100, 50, 50);
                        g.DrawString(vs[1].ToString(), drawFont, drawBrush, 210, 110);
                        g.DrawRectangle(p, 100, 200, 50, 50);
                        g.DrawString(vs[0].ToString(), drawFont, drawBrush, 110, 210);
                    }

                }
                fin.Close();
            }
            
            Thread.Sleep(500);
        }
        
        void desen2(int x,int y)
        {
            g = this.CreateGraphics();
            
            Pen p1 = new Pen(Color.Black, 1);
            
            Rectangle r = new Rectangle(50, 50 + x * 100, 50, 50);
            Rectangle r1 = new Rectangle(150, 50 + y * 100, 50, 50);
            AdjustableArrowCap bigArrow = new AdjustableArrowCap(3, 3);
            p1.CustomEndCap = bigArrow;
            g.DrawLine(p1, 50, 50 + x * 100, 150, 50 + y * 100);
            Thread.Sleep(500);
        }

        void dfsuc(int x, int nrc)
        {
            using (StreamReader fin = new StreamReader("TextFile1.Txt"))
            {
                string s1 = fin.ReadLine();
                n = int.Parse(s1);
                fin.Close();
            }
            viz[x] = 1;
            suc[x] = nrc;
            for(int i=1;i<=n;i++)
            {
                if(a[x,i] == 1 && suc[i]==0)
                {
                    dfsuc(i, nrc);
                }
            }
        }
        

        void dfpred(int x, int nrc)
        {
            using (StreamReader fin = new StreamReader("TextFile1.Txt"))
            {
                string s1 = fin.ReadLine();
                n = int.Parse(s1);
                fin.Close();
            }
            viz[x] = 1;
            pred[x] = nrc;
            for (int i = 1; i <= n; i++)
            {
                if (a[i,x] == 1 && pred[i] == 0)
                {
                    dfpred(i, nrc);
                }
            }
        }

        void parcurgere()
        {
            using (StreamReader fin = new StreamReader("TextFile1.Txt"))
            {
                string s1 = fin.ReadLine();
                n = int.Parse(s1);
                string s2 = fin.ReadLine();
                string[] vs = s2.Split('-');
                string[] v1 = vs[1].Split();
                for (int i = 0; i < v1.Count(); i++)
                    a[i, int.Parse(v1[i].ToString())] = 1;
                fin.Close();
            }
            int nrc = 1;
            for(int i=1;i<=n;i++)
            {
                if(suc[i] == 0)
                {
                    dfsuc(i, nrc);
                    dfpred(i, nrc);
                    for(int j = 1;j<=n;j++)
                    {
                        if(suc[j] != pred[i])
                        {
                            suc[j] = pred[j] = 0;
                        }
                        nrc++;
                    }
                }
            }
            for(int i=1;i<=n;i++)
            {
                for(int j=1;j<=n;j++)
                {
                    if(a[i,j] == 1)
                    {
                        desen(i);
                        desen2(i,j);
                        i++;
                        j++;
                    }
                }
            }
        }
    }
}
